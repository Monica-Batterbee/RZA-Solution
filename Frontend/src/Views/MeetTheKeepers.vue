<script setup>
    const activeComp = defineModel();

    //Object storing information about each zoo zeeper
    const zooKeepers = {
    keeper1: {
        name: "Emily Hart",
        role: "Senior Mammal Keeper",
        experience: "8 years",
        specialty: "Big Cats",
        image: "https://cms.zsl.org/sites/default/files/styles/responsive/public/1024/1024/0/2022-09/Zookeeper%20Anusia%20Acus%20with%20giraffe%20Bashu_1.JPG.webp",
        bio: "Emily has spent over a decade working closely with giraffes, studying their gentle behavior and helping visitors understand these incredible giants. She is passionate about conservation and leads daily giraffe feeding sessions."
    },

    keeper2: {
        name: "James Dalton",
        role: "Reptile Specialist",
        experience: "5 years",
        specialty: "Snakes & Lizards",
        image: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQC28ac_yOV9PRQBonfKugdPomaxol0aC3GPA&s",
        bio: "James works directly with our rhinos, helping with training sessions, health checks, and conservation awareness. His calm, steady demeanor makes him a favorite among these powerful yet sensitive animals."
    },

    keeper3: {
        name: "Sofia Ramirez",
        role: "Avian Keeper",
        experience: "6 years",
        specialty: "Tropical Birds",
        image: "https://www.pbs.org/wnet/nature/files/2021/07/Lauren-Del-Grosso-2.jpg",
        bio: "Sofia’s love for giraffes began during a volunteer trip to Africa. Now she focuses on enrichment and habitat care, making sure our giraffes stay mentally stimulated and active every day."
    },

    keeper4: {
        name: "Marcus Lee",
        role: "Aquatic Life Keeper",
        experience: "4 years",
        specialty: "Penguins & Marine Life",
        image: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQOqYOXjjUkVdUxWfRUzdzxt-BrZLOjJrLI1g&s",
        bio: "Marcus oversees the care of our kangaroos, focusing on habitat safety and behavior monitoring. His interest in marsupials drives him to create new ways for our roos to hop, explore, and thrive."
    },

    keeper5: {
        name: "Hannah Collins",
        role: "Educational Programs Coordinator",
        experience: "7 years",
        specialty: "Animal Behavior",
        image: "https://www.hertfordshirezoo.com/wp-content/uploads/2024/07/2.-sDSC_4198-copy-1024x1024.jpg",
        bio: "Hannah leads educational tours and training sessions, helping visitors understand the importance of conservation. She’s known for her deep knowledge of bear behavior and her warm connection with the animals."
    },

    keeper6: {
        name: "Aarav Patel",
        role: "Herbivore Specialist",
        experience: "9 years",
        specialty: "Elephants & Giraffes",
        image: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSu2M9QguLlkBeKWDVKZCgnqwzL09ygM8Ixrg&s",
        bio: "Aarav oversees the care of the zoo’s largest herbivores, managing enrichment routines and habitat improvements."
    }
};

</script>

<template>
 <div class="flex items-center justify-center text-white flex-col p-5">
        <div class="flex justify-start w-full">
            <button class="text-left text-white p-3 bg-[#A89C87] rounded-md cursor-pointer"
            @click="activeComp='Home'">Go Back to Home</button>
        </div>
        <h1 class="text-5xl p-4 mb-5">Our Zoo Keepers</h1>
        <div class="grid grid-cols-1 sm:grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
            <div  v-for="keeper in Object.values(zooKeepers)">
                <div class="bg-white p-3 rounded-md shadow-md text-black flex items-center justify-center flex-col max-w-sm h-full">
                <h2 class="text-2xl mb-4">{{ keeper.name }}</h2>
                <img :src='keeper.image' class="w-80 h-80 rounded-md mb-4"/>
                <p>{{ keeper.bio }}</p>
                </div>
            </div>
        </div>

    </div>
</template>