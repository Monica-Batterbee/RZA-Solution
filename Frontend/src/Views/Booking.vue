<script setup>
import { ref, computed } from 'vue'
import Calander from '@/Components/Calander.vue'
import Tickets from '@/Components/Tickets.vue'
import Basket from '@/Components/Basket.vue'



const bookingComp = defineModel('bookingComp')
const loggedIn = defineModel('loggedIn')
const foundUser = defineModel('foundUser')
const tickets = defineModel('tickets')
const nextPage = defineModel('nextPage')
const activeComp = defineModel('activeComp')
const selectedDates = defineModel('selectedDates')
const ticketsSelected = ref(false)

const totalPrice = computed(() =>
  Object.values(tickets.value)
    .reduce((sum, ticket) => sum + ticket.price * ticket.quantity, 0)
)
</script>

<template>
    <div class="flex items-start">
        <button class="text-left text-white p-3 bg-[#A89C87] rounded-md m-3 cursor-pointer"
        @click="activeComp='Home'">Go Back to Home</button>
    </div>

    <Calander v-if="bookingComp==='Calendar'"
    v-model:selectedDates="selectedDates"
    v-model:bookingComp="bookingComp"
    />

    <Tickets v-if="bookingComp==='Tickets'" 
    v-model:tickets="tickets"
    v-model:totalPrice="totalPrice"
    v-model:ticketsSelected="ticketsSelected"
    v-model:bookingComp="bookingComp"/>

    <Basket v-if="bookingComp==='Basket'"
    v-model:tickets="tickets"
    v-model:totalPrice="totalPrice"
    v-model:selectedDates="selectedDates"
    v-model:ticketsSelected="ticketsSelected"
    v-model:loggedIn="loggedIn"
    v-model:nextPage="nextPage"
    v-model:bookingComp="bookingComp"
    v-model:activeComp="activeComp"
    v-model:foundUser="foundUser"/>

    <GetDetails v-if="bookingComp==='GetDetails'" />


</template>