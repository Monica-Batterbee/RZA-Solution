<script setup>
import {ref} from 'vue';
import HomePage from './Views/HomePage.vue';
import Logo from './Assets/Logo.vue'
import Booking from './Views/Booking.vue';
import SignUp from './Views/SignUp.vue';


let loggedIn = ref(false);
let activeComp = ref("Home");
let foundUser = ref({})
let nextPage = ref('Home')
const bookingComp = ref('Calendar')
const selectedDates = ref([])

const tickets = ref({
  Adult: { price: 20, age: '18+', quantity: 0 },
  Child: { price: 15, age: '5 - 18', quantity: 0 },
  Toddler: { price: 10, age: 'Under 5', quantity: 0 },
  Senior: { price: 15, age: '65+', quantity: 0 }
})

</script>

<template>
  <div class="flex h-full w-full flex-col">
    <header v-if="activeComp!=='SignUp'" class="shadow-md bg-[#A89C87] w-full p flex flex-row justify-between items-center">
      <div class="flex items-center justify-center">
        <logo class="w-18 h-18 mr-4 rounded-xl"/>
        <h1 class="text-xl  text-white">Riget Zoo Adventures</h1>
      </div>
      <nav class="text-white text-lg">
        <a class="mx-2 cursor-pointer  hover:text-green-300" @click="activeComp='Booking'">Book Now</a>
        <a v-if="!loggedIn" class="mx-2 cursor-pointer  hover:text-green-300" @click="activeComp='SignUp'" >Log in</a>
        <a v-else class="mx-2 cursor-pointer  hover:text-green-300" @click="foundUser={}, loggedIn=false">Log out</a>
        <a class="mx-2 cursor-pointer  hover:text-green-300">Educational visits</a>
        <a class="mx-2 cursor-pointer  hover:text-green-300">Contact us</a>
      </nav>
    </header>

      <SignUp v-if="activeComp==='SignUp'"
      v-model:loggedIn="loggedIn"
      v-model:activeComp="activeComp"
      v-model:foundUser="foundUser"
      v-model:nextPage="nextPage"
      v-model:bookingComp="bookingComp"
      />

     <HomePage v-if="activeComp==='Home'"
      v-model="activeComp" />

      <Booking v-if="activeComp==='Booking'" 
      v-model:activeComp="activeComp"
      v-model:loggedIn="loggedIn"
      v-model:foundUser="foundUser"
      v-model:nextPage="nextPage"
      v-model:bookingComp="bookingComp"
      v-model:tickets="tickets"
      v-model:selectedDates="selectedDates"/> 


  </div>


</template>

