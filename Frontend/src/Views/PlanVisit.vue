<script setup>
import UpcomingEvents from './UpcomingEvents.vue';
    //Page showing daily schedule of the zoo
    const activeComp = defineModel();
    //Object storing the daily schedule
    const dailySchedule = {
    morning: [
        {
        time: "09:00 AM",
        location: "Savanna Enclosure",
        description: "Giraffe feeding and keeper talk about diet and conservation."
        },
        {
        time: "10:00 AM",
        location: "Big Cat Habitat",
        description: "Lion feeding session with insights into their hunting behaviors."
        }
    ],

    midday: [
        {
        time: "12:00 PM",
        location: "Rainforest Dome",
        description: "Red panda feeding and enrichment activity demonstration."
        },
        {
        time: "01:00 PM",
        location: "Reptile House",
        description: "Snake feeding with explanations about handling and safety."
        }
    ],

    afternoon: [
        {
        time: "02:00 PM",
        location: "Elephant Plains",
        description: "Elephant bath time and Q&A with keepers."
        },
        {
        time: "03:30 PM",
        location: "Penguin Bay",
        description: "Penguin feeding with information about their natural habitats."
        }
    ]
};
</script>

<template>
    <div class="flex items-center justify-center text-white p-4 flex-col">

        <div class="w-full flex flex-row justify-start">
            <button class="text-left text-white p-3 bg-[#A89C87] rounded-md cursor-pointer self-start"
            @click="activeComp='Home'">Go Back to Home</button>
            <div class="flex grow justify-center items-center">
                <div>
                <h1 class="text-4xl mb-4">Plan your visit!</h1>
                <div class="bg-white p-3 rounded-md text-black">
            <div class="flex flex-row justify-between items-center">
                <h2 class="text-2xl">Our Daily Schedule</h2>
                <a class="font-bold text-[#A89C87] cursor-pointer" @click="activeComp='UpcomingEvents'">View Our Upcoming Events</a>
            </div>
            <div v-for="[key,value] in Object.entries(dailySchedule)">
                <div class="border-gray-300 border p-3 rounded-md shadow-md ">
                    <div class="flex flex-row">
                        <h2 class="text-xl w-1/4">{{ key }}:</h2>
                        <div class="flex flex-col">
                        <div class="flex flex-col bg-gray-100 rounded-md m-2 p-1" v-for="arr in value">
                            <p>{{ arr.time }}</p>
                            <p>{{ arr.description }}</p>
                            <p>Location - {{arr.location}}</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
                </div> 
            </div>
        </div>
        
    </div>
</template>