<script setup>

defineProps({
  name: String,
  price: Number,
  age: String
})

</script>

<template>
    <div class="border border-gray-300 p-3 rounded-md cursor-pointer flex flex-row">
        <div>
        <h1 class="text-2xl">{{name}} Ticket</h1>
        <div class="flex flex-row">
        <h1 class="mr-auto">This ticket is suitable for ages ({{age}})</h1>
        <h1 class="pl-5">£{{price}}</h1>
        </div>
        <input type="number" placeholder="0" class="bg-gray-200"></input>
        </div>
    </div>
</template>