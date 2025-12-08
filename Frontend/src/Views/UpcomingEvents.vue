<script setup>
    import Modal from '@/Components/Modal.vue';
    import {ref} from 'vue'

    const activeComp = defineModel();
    const openModal = ref(false);
    const checkout = false;


const upcomingEvents = {
  wildlifeWonderDay: {
    title: "Wildlife Wonder Day",
    date: "2025-04-12",
    time: "10:00 AM – 4:00 PM",
    location: "Main Zoo Grounds",
    image: "https://chicagoparent.nyc3.cdn.digitaloceanspaces.com/wp-content/uploads/2023/01/how-to-explore-zoo-with-kids-this-winter-photo-credit-brookfield-zoo.jpg",
    description:
      "Join us for a full day of hands-on animal encounters, behind-the-scenes demonstrations, and interactive conservation activities for guests of all ages. Visitors will have the unique opportunity to watch expert keepers showcase the zoo’s most remarkable species—from agile big cats to towering giraffes—while learning about the challenges they face in the wild. With craft stations, educational talks, and live demonstrations spread throughout the park, this is a celebration of biodiversity designed to inspire curiosity and a deeper appreciation for the natural world."
  },

  nightSafariAdventure: {
    title: "Night Safari Adventure",
    date: "2025-05-03",
    time: "7:30 PM – 10:00 PM",
    location: "Safari Trail",
    image: "https://www.marylandzoo.org/wp-content/uploads/2025/04/SILantern2-660x440.jpg",
    description:
      "Experience the zoo after dark and witness the mysterious world of nocturnal wildlife. Guided by our knowledgeable safari team, guests will explore dimly lit pathways to observe animals that come alive when the sun sets. From the quiet rustle of hunting predators to the surprising calls of night-active birds, every moment offers a rare insight into behaviors rarely seen during the day. This immersive adventure blends storytelling, ecology, and quiet observation in one unforgettable evening under the stars."
  },

  conservationTalkSeries: {
    title: "Conservation Talk Series: Saving Endangered Species",
    date: "2025-05-18",
    time: "2:00 PM – 3:30 PM",
    location: "Discovery Hall Theater",
    image: "https://cdn.mos.cms.futurecdn.net/RsPuG8enmiFnnkAoCPkugE.jpg",
    description:
      "Join leading conservationists and wildlife biologists as they discuss the urgent challenges facing endangered species around the globe. This in-depth talk highlights ongoing field projects, groundbreaking scientific innovations, and the strategies zoos are using to protect vulnerable populations. Attendees will gain insight into the complexities of habitat loss, climate change, and species recovery while learning meaningful actions they can take to support conservation efforts. A Q&A session will follow, offering guests the chance to engage directly with experts in the field."
  },

  juniorKeeperWorkshop: {
    title: "Junior Keeper Workshop",
    date: "2025-06-07",
    time: "9:00 AM – 12:00 PM",
    location: "Education Center & Animal Care Zones",
    image: "https://cms.whipsnadezoo.org/sites/default/files/styles/responsive/public/1024/1024/0/2023-04/Junior%20Academy_8456.jpg.webp",
    description:
      "Perfect for young animal enthusiasts, this hands-on workshop lets children step into the shoes of a real zookeeper for a day. Participants will prepare enrichment items, learn how specialized diets are created, and observe safe animal-care techniques up close. Throughout the workshop, our education team emphasizes teamwork, empathy, and responsibility—core values that guide professional wildlife caretakers. The experience ends with a special behind-the-scenes visit to one of our most popular animal habitats."
  },

  summerZooFestival: {
    title: "Summer Zoo Festival",
    date: "2025-07-20",
    time: "11:00 AM – 6:00 PM",
    location: "Central Plaza",
    image: "https://i0.wp.com/downtowninbusiness.com/wp-content/uploads/2023/05/Into-the-Night-at-Chester-Zoo-8-copy.jpg?fit=1280%2C720&ssl=1",
    description:
      "Celebrate summer with a vibrant festival filled with live music, themed food stalls, keeper presentations, and animal-themed activities for the whole family. Wander through colorful displays, join interactive games, and enjoy pop-up enrichment demonstrations featuring some of the zoo's most charismatic residents. With special performances throughout the day and exclusive festival-only merchandise, this energetic event brings together the joy of summer with the excitement of wildlife discovery."
  }
};
</script>

<template>
    <Modal v-if="openModal" 
    v-model:checkout="checkout"
    v-model:openModal="openModal"/>
    <h1 class="text-white text-4xl p-3 text-center mt-3 mb-3">Upcoming Events</h1>
    <div v-for="event in Object.values(upcomingEvents)" class="flex flex-row w-full justify-start my-4 bg-[#A89C87]">
        <img :src="event.image" class="w-1/2 object-cove"/>
        <div class="w-1/2 flex p-3 flex-col text-white justify-between text-xl">
            <div>
            <div class="bg-white w-full rounded-md flex items-center justify-center mb-4 p-3 ">
            <h1 class="sm:text-xl md:text-2xl lg:text-3xl  text-black underline">{{ event.title }}</h1>
            </div>
            <p class="mt-3 mb-5 ">{{ event.description }}</p>

            <p class="my-3 mt-10"><b>Date</b> : {{ event.date }}</p>
            <p class="my-3"><b>Time</b> : {{ event.time }}</p>
            <p class="my-3"><b>Location</b> : {{ event.location }}</p>
            </div>

            <div class="w-full flex justify-center mb-5">
                <button class=" bg-green-500 bg-opacity-50 p-4 rounded-md cursor-pointer self-start" @click="openModal = true">
                    <b>Register for this event!</b>
                </button>
            </div>
        </div>
    </div>
</template>

