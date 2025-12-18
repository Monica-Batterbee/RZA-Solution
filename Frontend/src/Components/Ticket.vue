<script setup>
import { ref, watch } from 'vue'

//Individual component showcasing each ticket (imported throughout system)
const ticketsSelected = defineModel();

// Props
const props = defineProps({
  name: String,
  price: Number,
  age: String,
  quantity: Number
})

// Emits
const emit = defineEmits(['update:quantity'])

// Local reactive copy of the prop
const localQuantity = ref(props.quantity)

// Watch localQuantity and emit updates
watch(localQuantity, (newVal) => {
  emit('update:quantity', newVal)
})
</script>

<template>
  <div class="border border-gray-300 p-3 rounded-md  flex flex-col gap-3 mb-4">
    <h1 class="text-2xl">{{ name }} Ticket</h1>

    <div class="flex flex-row justify-between">
      <h1>This ticket is suitable for ages ({{ age }})</h1>
      <h1 class="px-5">£{{ price }} / Day</h1>
      <p v-if="ticketsSelected">x {{ localQuantity }}</p>
    </div>

    <div v-if="!ticketsSelected" class="flex items-center gap-2">
      <label>Quantity:</label>
      <input
        type="number"
        min="0"
        class="bg-gray-200 p-1 rounded"
        v-model.number="localQuantity"
        @input="localQuantity = Math.max(0, localQuantity || 0)"
      />
    </div>

  </div>
</template>