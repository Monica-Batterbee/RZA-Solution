<script setup>
import Ticket from './Ticket.vue';

const tickets = {
  Adult: {
    price: 20,
    age: '18+'
  },
  Child: {
    price: 10,
    age: 'Under 18'
  }
}
</script>

<template>
  <div class="flex items-center justify-center">
    <div class="bg-white p-3 rounded-md shadow-md">

      <div v-for="([name, info], index) in Object.entries(tickets)"
           :key="index"
           class="mb-4">

        <Ticket 
          :name="name"
          :price="info.price"
          :age="info.age"
        />
      </div>

    </div>
  </div>
</template>