<script setup>
import LionImage from '@/Assets/LionImage.vue';
import GiraffeImage from '@/Assets/GiraffeImage.vue';
import ZooKeeperImage from '@/Assets/ZooKeeperImage.vue';
import RhinosImage from '@/Assets/RhinosImage.vue';

const activeComp = defineModel('activeComp');
</script>

<template>
      <div class="grid grid-cols-1 sm:grid-cols-1 md:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4 gap-8">
        <div class="p-3 flex flex-col justify-start items-center w-78 text-ellipsis text-white shadow-md bg-[#A89C87] cursor-pointer sm:w-full" @click="activeComp='AboutOurAnimals'"> 
          <h1 class="text-2xl mb-3">About Our Animals</h1>
          <LionImage class=" h-64 mb-3 rounded-md sm:w-120"/>
          <p>Step into a world of incredible creatures from every corner of the globe. At RZA, we’re home to more than 200 species. Each animal in our care helps tell the
             story of life on Earth.</p>
        </div>
        <div class="p-3 flex flex-col justify-start items-center w-78 text-ellipsis text-white shadow-md bg-[#A89C87] cursor-pointer sm:w-full"
         @click="activeComp='PlanVisit'"> 
          <h1 class="text-2xl mb-3">Plan Your Visit</h1>
          <GiraffeImage class="w-78 h-64 mb-3 rounded-md sm:w-full"/>
          <p>Get ready for a wild adventure at our zoo! Discover everything you need to make the most of your day - from opening hours
             and ticket prices to maps, dining options, and daily animal encounters.</p>
        </div>

        <div class="p-3 flex flex-col justify-start items-center w-78 text-ellipsis text-white shadow-md bg-[#A89C87] cursor-pointer sm:w-full"
        @click="activeComp='MeetTheKeepers'"> 
          <h1 class="text-2xl mb-3">Meet the Keepers</h1>
          <ZooKeeperImage class="w-78 h-64 mb-3 rounded-md sm:w-full" />
          <p>Our dedicated zookeepers are the heart of the zoo, caring for every animal with passion and expertise. They work tirelessly to ensure each creature’s health, safety, and happiness 
            - while also sharing their knowledge to inspire visitors about wildlife conservation</p>
        </div>

        <div class="p-3 flex flex-col justify-start items-center w-78 text-ellipsis text-white shadow-md bg-[#A89C87] cursor-pointer sm:w-full"
          @click="activeComp='UpcomingEvents'"> 
          <h1 class="text-2xl mb-3">Upcoming Events</h1>
          <RhinosImage class="w-78 h-64 mb-3 rounded-md sm:w-full"/>
          <p>There’s always something exciting happening at RZA Zoo! 
            Check out what’s coming up and plan your next adventure with us - there’s something for every animal lover!</p>
        </div>
      </div>
</template>    