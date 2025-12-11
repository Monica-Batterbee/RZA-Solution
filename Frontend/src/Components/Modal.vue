<script setup>
import {ref} from 'vue'
import { getUsers } from '@/Services/UserService';
import SignUp from '@/Views/SignUp.vue';


const activeComp = defineModel('activeComp')
const openModal = defineModel("openModal")

const userEmail = ref('');
const goToSignUp = ref(false);


</script>

<template>
     <div class="fixed inset-0 z-50 bg-black/80 backdrop-blur-sm flex justify-center items-center">
        <div class="bg-white p-3 shadow-xl rounded-md" >
               <div class="flex flex-row w-full justify-between">
                <p class="text-3xl mb-4">Your details</p>
                <i class="fa-solid fa-x cursor-pointer" @click="openModal=false"></i>
            </div>
            <label class="text-left">Please enter your full name</label>
            <input class="p-3 border border-gray-400 rounded-md w-full mt-2" placeholder="enter your full name"
            v-model="userEmail"/>
            <label class="text-left">Please enter your email</label>
            <input class="p-3 border border-gray-400 rounded-md w-full mt-2" placeholder="enter your email"
            v-model="userEmail"/>
            <button class="mt-3 p-3 bg-[#7C9C8A] text-white font-bold rounded-md cursor-pointer" 
            :disabled="userEmail.length===0">Sumbit</button>
            <div class="flex flex-row" v-if="goToSignUp">
                <p class="mr-3">We couldn't find your account</p>
                <a class="font-bold text-[#7C9C8A] cursor-pointer" @click="activeComp='SignUp'">Go to sign up</a>
            </div>
            </div>
        </div>
</template>