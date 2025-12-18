<script setup>
import SignUp from '@/Views/SignUp.vue';
import Ticket from './Ticket.vue';
import {ref} from 'vue';
import BookingModal from './BookingModal.vue';
import { postBooking } from '@/Services/BookingService';

//Basket for zoo tickets

const tickets = defineModel('tickets');
const totalPrice = defineModel('totalPrice');
const selectedDates = defineModel('selectedDates');
const ticketsSelected = defineModel('ticketsSelected');
const loggedIn = defineModel('loggedIn')
const bookingComp = defineModel('bookingComp')
const activeComp = defineModel('activeComp')
const nextPage = defineModel('nextPage')
const foundUser = defineModel('foundUser')

const postSuccesful = ref(null)
const cost = totalPrice.value * selectedDates.value.length
const checkout = ref(false)

//Decides what page a user sees once the click checkout
function changePage() {
    //If user is logged in, the booking is posted to the database
    if (loggedIn.value) {
        const now = new Date();
        
        const newBooking = {
            dateBookingMade :  now.toString(),
            bookingDetails: JSON.stringify({
                dates: selectedDates.value,
                cost: cost,
                ticketData: tickets.value,
            }),
            UserID : foundUser.value.userID
        }
        try{
            postBooking(newBooking)
        }
        catch{
            postSuccesful.value = false;
            return
        }
        postSuccesful.value = true
        
    }
    //If the user is not logged in, the booking modal is opened
    else {
        checkout.value = true
    }
}

</script>
<template>
    <BookingModal v-if="checkout" 
    v-model:checkout="checkout" 
    v-model:activeComp="activeComp"
    v-model:nextPage="nextPage"
    v-model:foundUser="foundUser"
    v-model:bookingComp="bookingComp"
    v-model:loggedIn="loggedIn"/>

    <div class="flex items-center justify-center flex-col">
        <div class="bg-white p-3 shadow-md rounded-md flex flex-col ">
            <div class="flex flex-row items-center">
                <i class="fa-solid fa-basket-shopping text-4xl mr-3"></i>
                <h1 class="text-4xl">Your Basket</h1>
            </div>
            <div class="flex flex-row p-3">
                <b class="mr-3">Dates Selected: </b>
                <div v-for="date in selectedDates" key:date class="mx-1">
                    {{ new Date(date).toISOString().split('T')[0] }}
                </div>
            </div>

        <div v-for="([name, info], index) in Object.entries(tickets)"
           :key="index">
           <Ticket v-if="info.quantity!==0"
          :name="name"
          :price="info.price"
          :age="info.age"
          :quantity="info.quantity"
          v-model = ticketsSelected
        />
      </div>

      <div class="flex justify-center items-center">
        <p >(Total Cost - £{{ cost }})</p>
        <button class="text-left text-white p-3 bg-[#A89C87] rounded-md m-3 cursor-pointer" @click="changePage">Check out</button>
      </div>
      <p v-if="postSuccesful" class="text-center text-green-400 font-bold">Booking Made</p>
      <p v-if="postSuccesful === false" class="text-center text-red-400 font-bold">Booking Unsucessful</p>
    </div>
    <div class="flex justify-center items-center cursor-pointer mt-3 text-white" @click="bookingComp='Tickets'">
        <i class="fa-solid fa-arrow-left mr-2"></i>
        <b>Go back to tickets</b>
    </div>
    </div>
</template>