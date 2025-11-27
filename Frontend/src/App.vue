<script setup>
import {ref} from 'vue';
import HomePage from './Views/HomePage.vue';
import Logo from './Assets/Logo.vue'
import Booking from './Views/Booking.vue';

let activeComp = ref("Home");
</script>

<template>
  <div class="flex h-full w-full flex-col">
    <header class="shadow-md bg-[#A89C87] w-full p flex flex-row justify-between items-center">
      <div class="flex items-center justify-center">
        <logo class="w-18 h-18 mr-4 rounded-xl"/>
        <h1 class="text-xl  text-white">Riget Zoo Adventures</h1>
      </div>
      <nav class="text-white text-lg">
        <a class="mx-2 cursor-pointer  hover:text-green-300" @click="activeComp='Booking'">Book Now</a>
        <a class="mx-2 cursor-pointer  hover:text-green-300">Log in</a>
        <a class="mx-2 cursor-pointer  hover:text-green-300">Educational visits</a>
        <a class="mx-2 cursor-pointer  hover:text-green-300">Contact us</a>
      </nav>
    </header>

      <HomePage v-if="activeComp==='Home'"
      v-model="activeComp" />

      <Booking v-if="activeComp==='Booking'" 
      v-model="activeComp"/>

  </div>


</template>

<style scoped></style>
