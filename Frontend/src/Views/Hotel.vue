<script setup>
    import Rooms from '@/Components/Rooms.vue'
    import Calander from '@/Components/Calander.vue';
    import HotelBasket from '@/Components/HotelBasket.vue';

    const loggedIn = defineModel('loggedIn')
    const activeComp = defineModel('activeComp')
    const foundUser= defineModel('foundUser')
    const nextPage = defineModel('nextPage')
    const currentComp = defineModel('currentComp')
    const selectedDates = defineModel('selectedDates')
    const nextComp = defineModel('nextComp')
    const selectedRooms = defineModel('selectedRooms')
    const cost = defineModel('cost')
</script>

<template>
    <Rooms v-if="currentComp==='Rooms' && selectedDates.length===0"
    :msg="'Stay in one of our adventurous rooms!'"
    :allowSelect="false"
    v-model:currentComp="currentComp"
    v-model:selectedRooms="selectedRooms"
    v-model:cost="cost"/>

    <Rooms v-if="currentComp==='Rooms' && selectedDates.length>0"
    :msg="'Select the rooms you would like to book'"
    :allowSelect="true"
    v-model:currentComp="currentComp"
    v-model:selectedRooms="selectedRooms"
    v-model:cost="cost"/>

    <Calander v-if="currentComp==='Calendar'" 
    v-model:selectedDates="selectedDates"
    v-model:nextPage="nextComp"
    v-model="currentComp"/>


    <HotelBasket  v-if="currentComp==='HotelBasket'"
        v-model:selectedDates="selectedDates"
        v-model:currentComp="currentComp"
        v-model:cost="cost"
        v-model:nextPage="nextPage"
        v-model:selectedRooms="selectedRooms"
        v-model:loggedIn="loggedIn"
        v-model:activeComp="activeComp"
        v-model:foundUser="foundUser"/>


</template> 