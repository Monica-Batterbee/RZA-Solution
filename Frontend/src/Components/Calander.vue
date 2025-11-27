<script setup>
import { ref } from 'vue'

const selectedDates = defineModel('selectedDates');
const proceed = defineModel('proceed');

// Today (used for disabling past dates)
const today = new Date()
today.setHours(0, 0, 0, 0)

const currentMonth = ref(today.getMonth())
const currentYear = ref(today.getFullYear())


// Helpers
function daysInMonth(month, year) {
  return new Date(year, month + 1, 0).getDate()
}

function getStartDay(month, year) {
  return new Date(year, month, 1).getDay()
}

function nextMonth() {
  if (currentMonth.value === 11) {
    currentMonth.value = 0
    currentYear.value++
  } else {
    currentMonth.value++
  }
}

function prevMonth() {
  if (currentMonth.value === 0) {
    currentMonth.value = 11
    currentYear.value--
  } else {
    currentMonth.value--
  }
}

function isPast(day) {
  const date = new Date(currentYear.value, currentMonth.value, day)
  date.setHours(0, 0, 0, 0)
  return date < today
}

// Toggle select / unselect a date
function toggleDate(day) {
  const date = new Date(currentYear.value, currentMonth.value, day)
  date.setHours(0, 0, 0, 0)

  if (isPast(day)) return // block past dates

  const timestamp = date.getTime()

  // If date is already selected → remove it
  if (selectedDates.value.includes(timestamp)) {
    selectedDates.value = selectedDates.value.filter(d => d !== timestamp)
  } 
  else {
    selectedDates.value.push(timestamp)
  }
}

// Check if a day is selected
function isSelected(day) {
  const date = new Date(currentYear.value, currentMonth.value, day)
  date.setHours(0, 0, 0, 0)
  return selectedDates.value.includes(date.getTime())
}
</script>

<template>

    <div class="flex flex-col items-center p-10">
  <h1 class="text-4xl mb-6 text-white drop-shadow">Select the dates you would like to visit!</h1>

  <div class="flex flex-row items-start justify-start mt-4">

    <!-- Calendar -->
    <div class="w-full max-w-md bg-white p-6 rounded-xl shadow-lg">

      <!-- Month Navigation -->
      <div class="flex justify-between items-center mb-4">
        <button 
          @click="prevMonth"
          class="px-3 py-1 bg-gray-200 rounded hover:bg-gray-300"
        >
          ‹
        </button>

        <h2 class="text-xl font-semibold">
          {{ new Date(currentYear, currentMonth).toLocaleString('default', { month: 'long' }) }}
          {{ currentYear }}
        </h2>

        <button 
          @click="nextMonth"
          class="px-3 py-1 bg-gray-200 rounded hover:bg-gray-300"
        >
          ›
        </button>
      </div>

      <!-- Weekdays -->
      <div class="grid grid-cols-7 text-center font-semibold text-gray-600 mb-2">
        <div>Sun</div>
        <div>Mon</div>
        <div>Tue</div>
        <div>Wed</div>
        <div>Thu</div>
        <div>Fri</div>
        <div>Sat</div>
      </div>

      <!-- Calendar -->
      <div class="grid grid-cols-7 gap-1 text-center">
        
        <!-- Empty offset cells -->
        <div
          v-for="n in getStartDay(currentMonth, currentYear)"
          :key="'empty-'+n"
          class="p-3"
        ></div>

        <!-- Days -->
        <div
          v-for="day in daysInMonth(currentMonth, currentYear)"
          :key="day"
          @click="toggleDate(day)"
          class="p-3 rounded-lg transition"
          :class="[
            isPast(day)
              ? 'text-gray-300 bg-gray-100 cursor-not-allowed'
              : 'cursor-pointer hover:bg-blue-200',

            isSelected(day)
              ? 'bg-green-500 text-white'
              : ''
          ]"
        >
          {{ day }}
        </div>

      </div>
    </div>

    <!-- Selected Dates -->
    <div class="ml-6 p-4 bg-white rounded-xl shadow-lg"
         v-if="selectedDates.length > 0">

      <h3 class="font-semibold mb-2 text-lg">Selected Dates:</h3>

      <ul class="list-disc pl-5 text-gray-700">
        <li v-for="d in selectedDates" :key="d">
          {{ new Date(d).toDateString() }}
        </li>
      </ul>

      <div class="w-full flex justify-center">
        <button 
          class="px-5 py-2 bg-green-500 text-white mt-4 cursor-pointer rounded-md hover:bg-green-600"
          @click="proceed=true">
          Proceed
        </button>
      </div>

    </div>
  </div>
</div>

</template>