<script setup>
import {ref} from 'vue';
import SiteMap from './SiteMap.vue';
import HotelImage from '@/Assets/HotelImage.vue';
import InfoPages from '@/Components/InfoPages.vue';

const model = defineModel();
//Home page


//Array of image sources
const imageLibrary = ["https://images.photowall.com/products/62137/zoo-animals.jpg?h=699&q=85",
'https://wallpapers.com/images/hd/zoo-animals-pictures-p2xol45muslpeops.jpg']

let i = ref(0);

//Allows user to flick through image library
function changeImg(operation) {
  if (operation === 'plus') {
    if (i.value === imageLibrary.length-1) {
      i.value = 0
    }
    else{
      i.value++;
    }
  } 
  else{
    if (i.value === 0) {
      i.value = imageLibrary.length-1
    }
    else{
      i.value--;
    }
  }
}
</script>

<template>
    <div class="w-full flex justify-center items-center p-10 flex-col">
      <div class="flex flex-row items-center justify-center w-full">
        <button class="w-15 h-15 rounded-full bg-[#A89C87] flex items-center
          cursor-pointer justify-center mr-3" @click="changeImg('minus')">
            <b class="text-xl text-white"><</b>
        </button>

        <img 
          :src="imageLibrary[i]" 
          class= "h-[50vh] w-60 object-cover rounded-md sm:w-120 md:w-130 lg:w-210 xl:w-280 2xl:w-280"
        />

            <div class="absolute top-1/2 left-1/2 transform -translate-x-1/2 
            -translate-y-1/2 bg-green-500 bg-opacity-50 p-4 rounded-md cursor-pointer" @click="model='Booking'">
              <p class="text-white text-xl font-bold">Book Now!</p>
            </div>

          <button class="w-15 h-15 rounded-full bg-[#A89C87] flex
          cursor-pointer items-center justify-center ml-3" @click="changeImg('plus')">
            <b class="text-xl text-white" >></b>
        </button>
      </div>
      <!--Shows info pages-->
      <InfoPages  class="p-3 mt-8"
      v-model:activeComp="model"/>
      <SiteMap class="w-6xl" />

    </div>
</template>