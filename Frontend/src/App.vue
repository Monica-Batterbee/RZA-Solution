<script setup>
import {ref} from 'vue';
import HomePage from './Views/HomePage.vue';
import Logo from './Assets/Logo.vue'
import Booking from './Views/Booking.vue';
import SignUp from './Views/SignUp.vue';
import AboutOurAnimals from './Views/AboutOurAnimals.vue';
import PlanVisit from './Views/PlanVisit.vue';
import MeetTheKeepers from './Views/MeetTheKeepers.vue';
import UpcomingEvents from './Views/UpcomingEvents.vue';

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


const mobileOpen = ref(false);




</script>

<template>
  <div class="flex h-full w-full flex-col">
  <header
  v-if="activeComp !== 'SignUp'"
  class="shadow-md bg-[#A89C87] w-full p-1 flex flex-row justify-between items-center">
  <!-- Logo + Title -->
  <div class="flex items-center">
    <logo class="w-18 h-18 mr-4 rounded-xl" />
    <h1 class="text-xl text-white">Riget Zoo Adventures</h1>
  </div>

  <!-- Desktop Nav -->
  <nav
    class="hidden md:flex text-white text-lg items-center"
  >
    <a class="mx-2 cursor-pointer hover:text-green-300" @click="activeComp = 'Booking'">Book Now</a>
    <a
      v-if="!loggedIn"
      class="mx-2 cursor-pointer hover:text-green-300"
      @click="activeComp = 'SignUp'"
    >Log in</a>
    <a
      v-else
      class="mx-2 cursor-pointer hover:text-green-300"
      @click="foundUser = {}; loggedIn = false"
    >Log out</a>

    <a class="mx-2 cursor-pointer hover:text-green-300">Educational visits</a>
    <a class="mx-2 cursor-pointer hover:text-green-300">Contact us</a>
  </nav>

  <!-- Mobile Hamburger -->
  <button
    @click="mobileOpen = !mobileOpen"
    class="md:hidden text-white text-3xl focus:outline-none"
  >
    ☰
  </button>
</header>


  <div
    v-if="mobileOpen"
    class="md:hidden bg-[#A89C87] text-white flex flex-col p-4 space-y-3"
  >
    <a class="cursor-pointer hover:text-green-300" @click="activeComp = 'Booking'; mobileOpen = false">Book Now</a>

    <a
      v-if="!loggedIn"
      class="cursor-pointer hover:text-green-300"
      @click="activeComp = 'SignUp'; mobileOpen = false"
    >Log in</a>

    <a
      v-else
      class="cursor-pointer hover:text-green-300"
      @click="foundUser = {}; loggedIn = false; mobileOpen = false"
    >Log out</a>

    <a class="cursor-pointer hover:text-green-300">Educational visits</a>
    <a class="cursor-pointer hover:text-green-300">Contact us</a>
  </div>

      <SignUp v-if="activeComp==='SignUp'"
      v-model:loggedIn="loggedIn"
      v-model:activeComp="activeComp"
      v-model:foundUser="foundUser"
      v-model:nextPage="nextPage"
      v-model:bookingComp="bookingComp"
      />

     <HomePage v-if="activeComp==='Home'"
      v-model="activeComp" />

      <AboutOurAnimals v-if="activeComp==='AboutOurAnimals'"
       v-model="activeComp" />

      <PlanVisit v-if="activeComp==='PlanVisit'"
       v-model="activeComp" />

      <MeetTheKeepers v-if="activeComp==='MeetTheKeepers'"
       v-model="activeComp" />

      <UpcomingEvents v-if="activeComp==='UpcomingEvents'"
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

