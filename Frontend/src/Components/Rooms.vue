<script setup>
    import { getRooms } from '@/Services/RoomService';
    import { ref, onMounted } from 'vue';

    //Page to showcase hotel rooms
    
    // Props
    const props = defineProps({
      msg: {
        type: String,
        required: true
      },
      allowSelect: {
        type: Boolean,
        required: true
      }
    });

    // Models
    const currentComp = defineModel('currentComp');
    const selectedRooms = defineModel('selectedRooms');
    const cost = defineModel('cost');
    
    const rooms = ref([]);
    
    //Fetches all current rooms
    async function fetchRooms() {
      const res = await getRooms();
      rooms.value = res;
    }
    
    onMounted(fetchRooms);
    </script>
<template>
    <div class="w-full h-full text-white p-8">
        <div class="flex flex-row items-center justify-between">
            <h1 class="text-4xl">{{ msg }}</h1>
            <button v-if="!props.allowSelect"
             class=" bg-green-500 bg-opacity-50 p-4 rounded-md cursor-pointer font-bold" @click="currentComp='Calendar'">Check Availability</button>

             <div v-if="selectedRooms.length>0" class="flex flex-col">
                <p class="flex flex-row mb-3">
                    Selected Rooms : 
                    <p v-for="room in selectedRooms">
                        <p class="mx-1">{{ room[0] }} ({{ room[1] }})</p>
                    </p>

                </p>
                <button 
                class="self-start ml-auto bg-green-500 bg-opacity-50 p-4 rounded-md cursor-pointer font-bold" @click="currentComp='HotelBasket'">Proceed</button>
            </div>
        </div>
    
      <div class="grid 2xl:grid-cols-2 gap-3 mt-4">
        <div v-for="room in rooms" :key="room.roomID">
        <div class="bg-[#A89C87] border border-white rounded-md p-3  flex  flex-row">
            <img :src="room.url" class="w-120 h-100 rounded-md"/>
            <div class="flex items-start p-2 justify-start flex-col">
                <h1 class="text-2xl mb-3">{{ room.name }}</h1>   
                <p>{{ room.description }}</p>

                <div class="bg-green-900 rounded-md p-3 w-full flex  items-center my-2 justify-between">
                    <p>Family Price (2 adults, 3 children) - £{{ room.familyPrice }} / day</p>
                    <b v-if="props.allowSelect" class="cursor-pointer" 
                    @click="selectedRooms.push([room.name, 'Family']), cost+=room.familyPrice">Select this room</b>
                </div>

                <div class="bg-green-600 rounded-md p-3 w-full flex  items-center my-2 justify-between">
                    <p>Double Price (2 people) - £{{ room.doublePrice }} / day</p>
                    <b v-if="props.allowSelect" class="cursor-pointer" 
                    @click="selectedRooms.push([room.name, 'Double']),cost+=room.doublePrice">Select this room</b>
                </div>

                <div class="bg-green-400 rounded-md p-3 w-full flex  items-center my-2 justify-between">
                    <p>Single Price (1 person) - £{{ room.singlePrice }} / day</p>
                    <b v-if="props.allowSelect" class="cursor-pointer" 
                    @click="selectedRooms.push([room.name, 'Single']),cost+=room.singlePrice">Select this room</b>
                </div>

             
            </div>
        </div>
      </div>
      </div>

    </div>
  </template>