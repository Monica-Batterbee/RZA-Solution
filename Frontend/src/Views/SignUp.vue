<script setup>
import {ref} from 'vue'
const option = ref("Log in")
const email = ref("")
const password = ref("")
const confirmation = ref("")
const fName = ref('')
const LName = ref('')

const loggedIn = defineModel('loggedIn');
const activeComp = defineModel('activeComp');
const foundUser = defineModel('foundUser')
const nextPage = defineModel('nextPage')

console.log('page',nextPage.value)

import axios from "axios";

async function authenticate() {
    if (option.value === 'Sign up') {
        if (password.value===confirmation.value){
            const newUser = {
                'Fname' : fName.value,
                'Lname' : LName.value,
                'Email' : email.value,
                'Password' : password.value
            }

            await axios.post('http://localhost:5085/api/users', newUser)
            .then(function (response) {
                console.log(nextPage.value)
                loggedIn.value = true;
                activeComp.value = nextPage.value
            })
            .catch(function (error) {
                console.log(error);
                
            });
        }
    }

    else{
        const response = await axios.get('http://localhost:5085/api/users');
        const userData = response.data;

        console.log(userData);

        const user = userData.find(
            (u) => u.email === email.value && u.password === password.value
        );

        console.log(user)
        if(user) {
            console.log(nextPage.value, 'nextPage')
            foundUser.value = user
            loggedIn.value = true;
            activeComp.value = nextPage.value
        }
        else {
            console.log("Not found")
        }
    }
}

</script>

<template>

    <div class="w-screen h-screen  flex items-center justify-center">
       <div class="bg-white p-5 rounded-md shadow-md flex items-center justify-center flex-col w-1/3">
       <form class="flex flex-col w-full">
        <div class="flex items-center justify-center flex-col">
            <h1 class="text-4xl mb-3">{{ option }}</h1>
            <div v-if="option==='Log in'" class="flex flex-row mb-3">
                <p class="mr-2">Dont have an account?</p>
                <b class="text-green-500 cursor-pointer" @click="option='Sign up'">Sign up</b>
            </div>

            <div v-else class="flex flex-row mb-3">
                <p class="mr-2">Already have an account?</p>
                <b class="text-green-500 cursor-pointer" @click="option='Log in'">Log in</b>
            </div>
        </div>

        <div  v-if="option==='Sign up'" class="flex flex-col">
            <label class="text-left mb-1">First Name</label>
            <input class="border border-gray-300 p-2 rounded-md **w-full**" v-model="fName" placeholder="enter your first name"></input>

            <label class="text-left mb-1 mt-3">Sir Name</label>
            <input class="border border-gray-300 p-2 rounded-md **w-full**" v-model="LName" placeholder="enter your sir name"></input>
        </div>

        <label class="text-left mb-1 mt-3">Email</label>
        <input class="border border-gray-300 p-2 rounded-md **w-full**" v-model="email" placeholder="enter your email"></input>

        <label class="text-left mb-1 mt-3">Password</label>
        <input class="border border-gray-300 p-2 rounded-md **w-full**" v-model="password" placeholder="enter your password"></input>

        <div  v-if="option==='Sign up'" class="flex flex-col">
            <label class="text-left mb-1 mt-3">Confirm Password</label>
            <input class="border border-gray-300 p-2 rounded-md **w-full**" v-model="confirmation" placeholder="enter your password again"></input>
        </div>
       </form>

       <button class="px-5 py-1 mt-3 text-white bg-green-400 rounded-md cursor-pointer" @click="authenticate()">
        <b>{{option}}</b>
        </button>
    </div>
    </div>
</template>