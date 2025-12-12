<script setup>
    import {ref} from 'vue'
    import { postContact } from '@/Services/ContactService'

    const model = defineModel();

    const submitClicked = ref(false)
    const email = ref('')
    const phone = ref('')
    const message = ref('')
    
    function submitForm() {
        submitClicked.value = true;

        if(email.value.length > 0 && phone.value.length > 0 && message.value.length > 0) {
            const newForm = {
                Email : email.value,
                Message : message.value,
                MobileNumber : phone.value
            }
            postContact(newForm)
        }
    }
</script>

<template>
    <div class="w-full flex justify-start p-2">
        <button class="text-left text-white p-3 bg-[#A89C87] rounded-md cursor-pointer" @click="model='Home'">Back to home</button>
    </div>
    

    <div class="p-4 text-white flex  items-center justify-center flex-col">
        <h1 class="text-4xl">Contact Us</h1>

        <div class="bg-white p-3 flex flex-col w-full md:w-2/5 mt-3 text-black rounded-md">
            <h1 class="text-2xl mb-3">Contact Form</h1>
            <label>Email</label>
            <input class="p-1 border border-gray-300 w-full" v-model="email"/>
            <p v-if="submitClicked && email.length===0" class="text-red-500 font-bold">Please enter your email</p>

            <label class="mt-3">Phone Number</label>
            <input class="p-1 border border-gray-300 w-full" v-model="phone"/>
            <p v-if="submitClicked && phone.length===0" class="text-red-500 font-bold">Please enter your number</p>

            <label class="mt-3">Message</label>
            <textarea class="p-1 border border-gray-300 w-full" rows="8" v-model="message"> </textarea>
            <p v-if="submitClicked && message.length===0" class="text-red-500 font-bold">Please enter a message</p>

            <button class="bg-[#A89C87] cursor-pointer p-2 rounded-md mt-5 text-white" @click="submitForm()">Submit</button>
        </div>
        <div class="flex flex-row items-center text-xl mt-3">
            <i class="fa-solid fa-phone"></i>
            <p>Mobile Number - 01874923411</p>
        </div>
    </div>
    
</template>