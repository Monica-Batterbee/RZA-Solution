<script setup>
import Ticket from './Ticket.vue';

const tickets = defineModel('tickets');
const totalPrice = defineModel('totalPrice');
const selectedDates = defineModel('selectedDates');
const ticketsSelected = defineModel('ticketsSelected');

const cost = totalPrice.value * selectedDates.value.length
</script>
<template>
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
           :key="index"
           class="mb-4">
           <Ticket v-if="info.quantity!==0"
          :name="name"
          :price="info.price"
          :age="info.age"
          :quantity="info.quantity"
          v-model = ticketsSelected
        />
      </div>

      <div class="flex flex-col items-center">
        <p >(Total Cost - £{{ cost }})</p>
        <button class="text-left text-white p-3 bg-[#A89C87] rounded-md m-3 cursor-pointer">Check out</button>
      </div>
    </div>
    <div class="flex justify-center items-center cursor-pointer mt-3 text-white" @click="ticketsSelected=false">
        <i class="fa-solid fa-arrow-left mr-2"></i>
        <b>Go back to tickets</b>
    </div>
    </div>
</template>