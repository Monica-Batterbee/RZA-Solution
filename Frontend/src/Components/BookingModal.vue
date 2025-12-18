<script setup>
    import {ref} from 'vue'
    import { getUsers } from '@/Services/UserService';

    
    const checkout = defineModel('checkout')
    const activeComp = defineModel('activeComp')
    const nextPage = defineModel('nextPage')
    const foundUser = defineModel('foundUser')
    const bookingComp = defineModel('bookingComp')
    const loggedIn = defineModel('loggedIn')
    
    const userEmail = ref('');
    const goToSignUp = ref(false);
    
    //Searches for the user in the database
    async function searchUser() {
        const allUsers = await getUsers();
        const user = allUsers.find((u) => u.email === userEmail.value)
    
        //If the user has been found, they will be navigated back to the basket to checkout
        if (user) {
            foundUser.value=user;
            loggedIn.value=true;
            checkout.value=false
            bookingComp.value = 'Basket'
        }
    
        //If the user has not been found, they will be navigated to sign up to enter their details for the booking
        else {
            nextPage.value = 'Booking'
            goToSignUp.value = true;
        }
    }
    </script>
    
    <template>
        <div class="fixed inset-0 z-50 bg-black/80 backdrop-blur-sm flex justify-center items-center">
            <div class="bg-white p-3 shadow-xl rounded-md">
                <div class="flex flex-row w-full justify-between">
                    <p class="text-3xl mb-4">Your details</p>
                    <i class="fa-solid fa-x cursor-pointer" @click="checkout=false"></i>
                </div>
                <label class="text-left">Please enter your email</label>
                <input class="p-3 border border-gray-400 rounded-md w-full mt-2" placeholder="enter your email"
                v-model="userEmail"/>
                <button class="mt-3 p-3 bg-[#7C9C8A] text-white font-bold rounded-md cursor-pointer" @click="searchUser"
                :disabled="userEmail.length===0">Sumbit</button>
                <div class="flex flex-row" v-if="goToSignUp">
                    <p class="mr-3">We couldn't find your account</p>
                    <a class="font-bold text-[#7C9C8A] cursor-pointer" @click="activeComp='SignUp'">Go to sign up</a>
                </div>
            </div>
        </div>
    </template>