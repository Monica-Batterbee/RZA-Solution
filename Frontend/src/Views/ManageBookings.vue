<script setup>
import {ref} from 'vue'
import { getBookings, deleteBooking } from '@/Services/BookingService';
import { getHotelBookings, deleteHotelBooking } from '@/Services/HotelBookingService';
import Ticket from '@/Components/Ticket.vue';

const user = defineModel('foundUser')
const bookingIDs = ref([])
const ticketsSelected = ref(true);
const userBookings = ref([])
const hotelBookings = ref([])


async function fetchBookings() {
    const bookings = await getBookings();
    userBookings.value = bookings
        .filter(b => b.userID === user.value.userID)
        .map(b => ({
            ...b,
            bookingDetails: JSON.parse(b.bookingDetails)
        }));


    const hotelB = await getHotelBookings();
    hotelBookings.value = hotelB
    .filter(b => b.userID === user.value.userID)
    .map(b => ({
        ...b,
        bookingDetails: JSON.parse(b.bookingDetails)
    }))  

    console.log(hotelBookings.value)
}

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
<div class="h-full w-full p-6 text-white space-y-6">

<h1 class="text-4xl font-bold tracking-wide">Manage Bookings</h1>

<!-- Section -->
<div class="bg-[#A89C87] p-6 rounded-lg shadow-lg space-y-6">

    <h1 class="text-3xl font-semibold">Your Zoo Tickets</h1>

    <!-- Grid layout -->
    <div class="grid md:grid-cols-2 lg:grid-cols-3 gap-6">

        <!-- Booking Card -->
        <div 
            v-for="booking in userBookings" 
            :key="booking.bookingID"
            class="bg-white p-6 rounded-xl shadow-md text-black flex flex-col justify-between transition hover:shadow-xl"
        >
            <!-- Booking Date -->
            <p class="text-xl font-semibold mb-4">
                Booking for:
                <span class="font-normal">
                    {{
                        booking.bookingDetails.dates
                            .map(d => formatDate(d))
                            .join(' - ')
                    }}
                </span>
            </p>

            <!-- Tickets -->
            <div class="space-y-3">
                <div 
                    v-for="([name, info], index) in Object.entries(booking.bookingDetails.ticketData)" 
                    :key="index"
                >
                    <Ticket 
                        v-if="info.quantity !== 0"
                        :name="name"
                        :price="info.price"
                        :age="info.age"
                        :quantity="info.quantity"
                        v-model="ticketsSelected"
                    />
                </div>
            </div>

            <!-- Cancel Button -->
            <div class="w-full flex justify-end mt-6">
                <button 
                    class="px-4 py-2 cursor-pointer bg-[#A89C87] text-white rounded-lg shadow hover:bg-green-700 transition *: font-medium"
                    @click="deleteBooking(booking.bookingID)"
                >
                    Cancel Booking
                </button>
            </div>
        </div>

    </div>
    </div>
    <div class="bg-[#A89C87] p-6 mt-10 rounded-lg shadow-lg space-y-6">

<h1 class="text-3xl font-semibold">Your Hotel Bookings</h1>


<div class="grid md:grid-cols-2 lg:grid-cols-3 gap-6">
    <div 
        v-for="booking in hotelBookings" 
        :key="booking.bookingID"
        class="bg-white p-6 rounded-xl shadow-md text-black flex flex-col justify-between transition hover:shadow-xl"
    >
        <p class="text-xl font-semibold mb-4">
            Booking for:
            <span class="font-normal">
                {{
                    booking.bookingDetails.dates
                        .map(d => formatDate(d))
                        .join(' - ')
                }}
            </span>
        </p>
        <p>Rooms Booked:</p>
        <p v-for="room in booking.bookingDetails.rooms">{{ room[0]}} ({{ room[1] }})</p>

        <div class="w-full flex justify-between items-center">
            <p>(Cost - £{{ booking.bookingDetails.cost }})</p>
            <button 
                class="px-4 py-2 cursor-pointer bg-[#A89C87] text-white rounded-lg shadow hover:bg-green-700 transition *: font-medium"
                @click="deleteBooking(booking.bookingID)"
            >
                Cancel Booking
            </button>
        </div>
    </div>

</div>
</div>

</div>
</template>

