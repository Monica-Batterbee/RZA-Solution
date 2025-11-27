<script setup>
import Ticket from './Ticket.vue';

const tickets = defineModel('tickets');
const totalPrice = defineModel('totalPrice');
const ticketsSelected = defineModel('ticketsSelected');
</script>

<template>
  <div class="flex items-center flex-col justify-center">
    <div class="bg-white p-3 rounded-md shadow-md">

      <div v-for="([name, info], index) in Object.entries(tickets)"
           :key="index"
           class="mb-4">

           <Ticket 
          :name="name"
          :price="info.price"
          :age="info.age"
          :quantity="info.quantity"
          @update:quantity="val => tickets[name].quantity = val"
          v-model = ticketsSelected
        />

      </div>
    </div>
    
    <button v-if="totalPrice !== 0"
     class="text-left text-white p-3 bg-[#A89C87] rounded-md m-3 cursor-pointer" @click="ticketsSelected=true">Proceed to checkout</button>

  </div>
</template>