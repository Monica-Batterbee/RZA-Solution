<script setup>
    import HotelModal from './HotelModal.vue';
    import { postHotelBooking } from '@/Services/HotelBookingService';
    import {ref, toRaw} from 'vue'

    //Basket showing the selected dates and hotel rooms

    const selectedDates = defineModel('selectedDates');
    const currentComp = defineModel('currentComp');
    const cost = defineModel('cost');
    const selectedRooms = defineModel('selectedRooms')
    const loggedIn = defineModel('loggedIn');
    const activeComp = defineModel('activeComp')
    const foundUser = defineModel('foundUser')
    const nextPage = defineModel('nextPage')

    const checkout = ref(false);
    nextPage.value='Hotel'
    const totalCost = cost.value * selectedDates.value.length;
    const postSuccesful = ref(null)

    //Decides what page users will be navigated to once they've pressed check out
    function changePage() {
    //If their logged in, the booking will be posted to the database
    if (loggedIn.value) {
        const now = new Date();
        const date = now.toString()

        const newBooking = {
        dateBookingMade: date,
        bookingDetails: JSON.stringify({
            dates: toRaw(selectedDates.value),
            cost: totalCost,
            rooms: toRaw(selectedRooms.value)
        }),
        UserID: foundUser.value.userID
        };

        try{
            postHotelBooking(newBooking)
        }
        catch{
            postSuccesful.value = false;
            return
        }
        postSuccesful.value = true
    }
    //If theyre not logged in, the hotel modal will be opened
    else {
        checkout.value = true
    }
}
</script>

<template>
    <HotelModal v-if="checkout" 
        v-model:checkout="checkout" 
        v-model:activeComp="activeComp"
        v-model:nextPage="nextPage"
        v-model:foundUser="foundUser"
        v-model:currentComp="currentComp"
        v-model:loggedIn="loggedIn"/>

     <div class="flex items-center mt-20 justify-center flex-col">
        <div class="bg-white p-3 shadow-md rounded-md flex flex-col ">
            <div class="flex flex-row items-center">
                <i class="fa-solid fa-basket-shopping text-4xl mr-3"></i>
                <h1 class="text-4xl">Your Basket</h1>
            </div>
            <div class="flex flex-row p-3">
                <b class="mr-3">Dates Selected: </b>
                <div v-for="date in selectedDates" key:date class="mx-1">
                    {{ new Date(date).toLocaleDateString('en-GB') }}
                </div>
            </div>

            <div v-for="room in selectedRooms" class="flex items-center justify-center flex-col">
                <p> Room - {{ room[0] }} ({{ room[1] }})</p>
            </div>

      <div class="flex justify-center items-center">
        <p >(Total Cost - £{{totalCost }})</p>
        <button class="text-left text-white p-3 bg-[#A89C87] rounded-md m-3 cursor-pointer" @click="changePage()">Check out</button>
      </div>
      <p v-if="postSuccesful" class="text-center text-green-400 font-bold">Booking Made</p>
      <p v-if="postSuccesful === false" class="text-center text-red-400 font-bold">Booking Unsucessful</p>
    </div>
    <div class="flex justify-center items-center cursor-pointer mt-3 text-white" @click="currentComp='Rooms'">
        <i class="fa-solid fa-arrow-left mr-2"></i>
        <b>Go back to rooms</b>
    </div>
    </div>
</template>

