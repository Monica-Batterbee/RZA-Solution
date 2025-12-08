<script setup>

const activeComp = defineModel();

const animals = {
  lion: {
    name: "African Lion",
    species: "Panthera leo",
    image: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ5mY_cvo6-XP-Fivsf9qUh_gIIDBZunOhq2Q&s",
    description:
      "African lions are powerful social cats known for their pride structure and iconic roar. They play a crucial role in maintaining balance in their ecosystems.",
    habitat: "Savannas, grasslands",
    diet: "Carnivore"
  },

  giraffe: {
    name: "Masai Giraffe",
    species: "Giraffa camelopardalis tippelskirchi",
    image: "https://cdn.pixabay.com/photo/2023/06/10/14/48/giraffe-8054174_1280.jpg",
    description:
      "Giraffes are the tallest land animals, easily recognized by their long necks and striking patterns. They are gentle browsers that rely on acacia trees for food.",
    habitat: "Open woodlands, savannas",
    diet: "Herbivore"
  },

  redPanda: {
    name: "Red Panda",
    species: "Ailurus fulgens",
    image: "https://cdn.pixabay.com/photo/2016/11/23/01/03/red-panda-1851590_1280.jpg",
    description:
      "Red pandas are small, tree-dwelling mammals known for their vibrant color and bushy tails. They are shy and primarily active during dawn and dusk.",
    habitat: "Temperate mountain forests",
    diet: "Omnivore (bamboo, fruits, insects)"
  },

  tiger: {
    name: "Bengal Tiger",
    species: "Panthera tigris tigris",
    image: "https://cdn.pixabay.com/photo/2016/11/14/03/56/tiger-1822535_1280.jpg",
    description:
      "The Bengal tiger is a solitary and powerful predator, known for its striking orange coat striped with black. It is one of the largest big cat species.",
    habitat: "Tropical forests, grasslands, mangroves",
    diet: "Carnivore"
  },

  penguin: {
    name: "Humboldt Penguin",
    species: "Spheniscus humboldti",
    image: "https://cdn.pixabay.com/photo/2023/01/11/08/05/humboldt-penguin-7711121_1280.jpg",
    description:
      "Humboldt penguins are medium-sized penguins native to South America. They are fast swimmers and thrive in cool coastal climates.",
    habitat: "Coastal cliffs and rocky shorelines",
    diet: "Carnivore (fish, squid)"
  },

  elephant: {
    name: "African Elephant",
    species: "Loxodonta africana",
    image: "https://cdn.pixabay.com/photo/2023/09/14/19/46/elephant-8253639_1280.jpg",
    description:
      "African elephants are the largest land mammals, celebrated for their intelligence, memory, and strong family bonds. They shape their environment in vital ways.",
    habitat: "Savannas, forests",
    diet: "Herbivore"
  }
};
</script>

<template>
    <div class="flex items-center justify-center text-white flex-col p-5">
        <div class="flex justify-start w-full">
            <button class="text-left text-white p-3 bg-[#A89C87] rounded-md cursor-pointer"
            @click="activeComp='Home'">Go Back to Home</button>
        </div>
        <h1 class="text-5xl p-4 mb-5">About our animals</h1>
        <div class="grid grid-cols-1 sm:grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
            <div  v-for="animal in Object.values(animals)">
                <div class="bg-white p-3 rounded-md shadow-md text-black flex items-center justify-center flex-col max-w-sm h-full">
                <h2 class="text-2xl mb-4">{{ animal.name }}</h2>
                <img :src='animal.image' class="w-80 h-80 rounded-md mb-4"/>
                <p>{{ animal.description }}</p>
                <div class="flex flex-col w-full items-start justify-start mt-4">
                    <p><b>Species</b> - {{ animal.species }}</p>
                    <p><b>Habitat</b> - {{ animal.habitat }}</p>
                </div>
                </div>
            </div>
        </div>

    </div>
</template>