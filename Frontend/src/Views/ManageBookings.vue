<script setup>
import {ref} from 'vue'
import { getBookings, deleteBooking } from '@/Services/BookingService';
import Ticket from '@/Components/Ticket.vue';

//Page to show the user what booking they have made

const user = defineModel('foundUser')
const bookingIDs = ref([])
const ticketsSelected = ref(true);
const userBookings = ref([])

//Retrieves all bookings made by the current user
async function fetchBookings() {
    const bookings = await getBookings();
    userBookings.value = bookings
        .filter(b => b.userID === user.value.userID)
        .map(b => ({
            ...b,
            bookingDetails: JSON.parse(b.bookingDetails)
        }));
    console.log(userBookings.value)
}

//Puts the date into a nicer, more readable format
function formatDate(ts) {
  const d = new Date(ts);
  const day = String(d.getDate()).padStart(2, '0');
  const month = String(d.getMonth() + 1).padStart(2, '0');
  const year = d.getFullYear();
  return `${day}/${month}/${year}`;
}

fetchBookings();

</script>

<template>
    <div class="h-full w-full p-3 text-white">
    <h1 class="text-3xl">Manage Bookings</h1>
    <div class="grid grid-cols-1 lg:grid-cols-2 gap-5">
    <div v-for="booking in userBookings">
        <div class="bg-white rounded-md p-3 shadow-md text-black my-3">
            <p class="text-xl p-2">
            Booking For Dates :
            {{
                booking.bookingDetails.dates
                .map(d => formatDate(d))
                .join(' - ')
            }}
            </p>
            <div v-for="([name, info], index) in Object.entries(booking.bookingDetails.ticketData)"
                :key="index">
                <Ticket v-if="info.quantity!==0"
                :name="name"
                :price="info.price"
                :age="info.age"
                :quantity="info.quantity"
                v-model = ticketsSelected
                />
            </div>
            <div class="w-full flex justify-center">
                <button class="text-left text-white p-3 bg-[#A89C87] rounded-md cursor-pointer" @click="deleteBooking(booking.bookingID)">Cancel Booking</button>
            </div>
        </div>
    </div>
    </div>
</div>
</template>

