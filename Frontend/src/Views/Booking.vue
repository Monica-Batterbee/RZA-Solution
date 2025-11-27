<script setup>
import {ref,computed} from 'vue'
import Calander from '@/Components/Calander.vue';
import Tickets from '@/Components/Tickets.vue';
import Basket from '@/Components/Basket.vue';

const tickets = ref({
  Adult: { price: 20, age: '18+', quantity: 0 },
  Child: { price: 15, age: '5 - 18', quantity: 0 },
  Toddler: { price: 10, age: 'Under 5', quantity: 0 },
  Senior: { price: 15, age: '65+', quantity: 0 }
})

const ticketsSelected = ref(false)

const model = defineModel()
const selectedDates = ref([])
const proceed = ref(false)

const totalPrice = computed(() =>
  Object.values(tickets.value).reduce((sum, ticket) => sum + ticket.price * ticket.quantity, 0)
)
</script>

<template>
    <div class="flex items-start">
        <button class="text-left text-white p-3 bg-[#A89C87] rounded-md m-3 cursor-pointer"
        @click="model='Home'">Go Back to Home</button>
    </div>

    <Calander v-if="!proceed"
    v-model:selectedDates="selectedDates"
    v-model:proceed="proceed"
    />

    <Tickets v-if="proceed && !ticketsSelected" 
    v-model:tickets="tickets"
    v-model:totalPrice="totalPrice"
    v-model:ticketsSelected="ticketsSelected"/>

    <Basket v-if="ticketsSelected"
    v-model:tickets="tickets"
    v-model:totalPrice="totalPrice"
    v-model:selectedDates="selectedDates"
    v-model:ticketsSelected="ticketsSelected"/>

</template>