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
import ManageBookings from './Views/ManageBookings.vue';
import Hotel from './Views/Hotel.vue';
import EducationalVisits from './Views/EducationalVisits.vue';
import ContactUs from './Views/ContactUs.vue';

//Ref values that are set and used throughout the program
let loggedIn = ref(false);
let activeComp = ref("Home");
let foundUser = ref({})
let nextPage = ref('Home')
const bookingComp = ref('Calendar')
const ticketDates = ref([])
const currentComp = ref('Rooms')
const selectedDates = ref([])
const nextComp = ref('Rooms')
const selectedRooms = ref([])
const cost = ref(0)


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
  <!-- The header which is responsive for mobile/desktop devices -->
  <header
  class="shadow-md bg-[#A89C87] w-full p-1 flex flex-row justify-between items-center">
  <div class="flex items-center">
    <logo class="w-18 h-18 mr-4 rounded-xl" />
    <h1 class="text-xl text-white">Riget Zoo Adventures</h1>
  </div>

  <nav
    class="hidden md:flex text-white text-lg items-center ">

      <a class="mx-2 cursor-pointer hover:text-green-300" @click="activeComp = 'Home'">Home</a>
      <a class="mx-2 cursor-pointer hover:text-green-300" @click="activeComp = 'Hotel'">Our Hotel</a>
      <a class="mx-2 cursor-pointer hover:text-green-300" v-if="loggedIn" @click="activeComp='ManageBookings'">Manage Bookings</a>
      <a class="mx-2 cursor-pointer hover:text-green-300" @click="activeComp = 'Booking'">Book Now</a>

      <a class="mx-2 cursor-pointer hover:text-green-300" @click="activeComp='EducationalVisits'">Educational visits</a>
      </nav>

    <nav class="text-white text-lg">

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

    <a class="mx-2 cursor-pointer hover:text-green-300"  @click="activeComp='ContactUs'">Contact us</a>
  </nav>


  <button
    @click="mobileOpen = !mobileOpen"
    class="md:hidden text-white text-3xl focus:outline-none"
  >
    ☰
  </button>
</header>


  <div
    v-if="mobileOpen"
    class="md:hidden bg-[#A89C87] text-white flex flex-col p-4 space-y-3">
    <a class="cursor-pointer hover:text-green-300" @click="activeComp = 'Home'">Home</a>
    <a class="cursor-pointer hover:text-green-300" @click="activeComp = 'Hotel'">Our Hotel</a>
    <a class="cursor-pointer hover:text-green-300" v-if="loggedIn" @click="activeComp='ManageBookings'">Manage Bookings</a>
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

    <a class="cursor-pointer hover:text-green-300" @click="activeComp='EducationalVisits'">Educational visits</a>
    <a class="cursor-pointer hover:text-green-300" @click="activeComp='ContactUs'">Contact us</a>
  </div>

    <!--Sign up page-->
      <SignUp v-if="activeComp==='SignUp'" 
      v-model:loggedIn="loggedIn"
      v-model:activeComp="activeComp"
      v-model:foundUser="foundUser"
      v-model:nextPage="nextPage"
      v-model:bookingComp="bookingComp"
      />

      <!--Home page-->
     <HomePage v-if="activeComp==='Home'"
      v-model="activeComp" />

      <!--About our animals information page-->
      <AboutOurAnimals v-if="activeComp==='AboutOurAnimals'"
       v-model="activeComp" />

      <!--Plan your visit information page-->
      <PlanVisit v-if="activeComp==='PlanVisit'"
       v-model="activeComp" />

      <!--Meet the keepers information page-->
      <MeetTheKeepers v-if="activeComp==='MeetTheKeepers'"
       v-model="activeComp" />

       <!--Upcoming events information page-->
      <UpcomingEvents v-if="activeComp==='UpcomingEvents'"
       v-model="activeComp" />

      <!--Takes to components that sort zoo ticket booking-->
      <Booking v-if="activeComp==='Booking'" 
      v-model:activeComp="activeComp"
      v-model:loggedIn="loggedIn"
      v-model:foundUser="foundUser"
      v-model:nextPage="nextPage"
      v-model:bookingComp="bookingComp"
      v-model:tickets="tickets"
      v-model:selectedDates="ticketDates"/> 

      <!--Page to manage bookings-->
      <ManageBookings v-if="activeComp==='ManageBookings'"
      v-model:foundUser="foundUser"/>

      <!--Takes to components that show information about hotel and allow users to book a room-->
      <Hotel v-if="activeComp==='Hotel'"
      v-model:currentComp="currentComp"
      v-model:nextPage="nextPage"
      v-model:loggedIn="loggedIn"
      v-model:activeComp="activeComp"
      v-model:foundUser="foundUser"
      v-model:selectedDates="selectedDates"
      v-model:nextComp="nextComp"
      v-model:selectedRooms="selectedRooms"
      v-model:cost="cost"/>

      <!--Page showing information about educational visits-->
      <EducationalVisits v-if="activeComp==='EducationalVisits'" />

      <!--Page to contact RZA-->
      <ContactUs v-if="activeComp==='ContactUs'" 
      v-model="activeComp"/>

  </div>


</template>

