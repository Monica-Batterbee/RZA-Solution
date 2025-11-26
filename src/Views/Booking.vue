<script setup>
import {ref} from 'vue'
import Calander from '@/Components/Calander.vue';
import Tickets from '@/Components/Tickets.vue';

const model = defineModel()
const selectedDates = ref([])
const proceed = ref(false)
</script>

<template>
    <div class="flex items-start">
        <button class="text-left p-3 bg-[#A89C87] rounded-md m-3 cursor-pointer"
        @click="model='Home'">Go Back to Home</button>
    </div>

    <Calander v-if="!proceed"
    v-model:selectedDates="selectedDates"
    v-model:proceed="proceed"
    />

    <Tickets v-if="proceed" />

</template>