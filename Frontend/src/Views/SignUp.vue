<script setup>
import { ref, computed } from 'vue'
import axios from "axios";

//Sets ref values
const option = ref("Log in")
const email = ref("")
const password = ref("")
const confirmation = ref("")
const fName = ref('')
const LName = ref('')
const errors = ref({})

//This retrieves the necesssary information from app.vue
const loggedIn = defineModel('loggedIn');
const activeComp = defineModel('activeComp');
const foundUser = defineModel('foundUser')
const nextPage = defineModel('nextPage')



const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

const isFormValid = computed(() => {
  errors.value = {}
    //Validates emails
  if (!email.value) {
    errors.value.email = 'Email is required'
  } else if (!emailRegex.test(email.value)) {
    errors.value.email = 'Invalid email format'
  }
  //Validates password
  if (!password.value) {
    errors.value.password = 'Password is required'
  } else if (password.value.length < 6) {
    errors.value.password = 'Password must be at least 6 characters'
  }

  if (option.value === 'Sign up') {
    //Validates name
    if (!fName.value) errors.value.fName = 'First name is required'
    if (!LName.value) errors.value.LName = 'Surname is required'

    //Validates password confirmation
    if (!confirmation.value) {
      errors.value.confirmation = 'Please confirm password'
    } else if (confirmation.value !== password.value) {
      errors.value.confirmation = 'Passwords do not match'
    }
  }

  return Object.keys(errors.value).length === 0
})

//Authenticates user
async function authenticate() {
  if (!isFormValid.value) return;

  try {
    if (option.value === 'Sign up') {
      const newUser = {
        Fname: fName.value,
        Lname: LName.value,
        Email: email.value,
        Password: password.value
      }
      //Posts new user to database
      await axios.post('http://localhost:5085/api/users', newUser)

      loggedIn.value = true;
      activeComp.value = nextPage.value
    } else {
        //Retrieves current users
      const response = await axios.get('http://localhost:5085/api/users');
      const user = response.data.find(
        u => u.email === email.value && u.password === password.value
      );

      //Checks if user is fetched
      if (!user) {
        errors.value.general = 'Invalid email or password'
        return
      }

      foundUser.value = user
      loggedIn.value = true;
      activeComp.value = nextPage.value
    }
  } catch (err) {
    errors.value.general = 'Something went wrong. Try again.'
  }
}
</script>

<template>

    <div class="mt-30 flex justify-center">
       <div class="bg-white p-5 rounded-md shadow-md flex items-center justify-center flex-col w-4/5 lg:w-1/3">
       <form class="flex flex-col w-full">
        <div class="flex items-center justify-center flex-col">
            <h1 class="text-4xl mb-3">{{ option }}</h1>
            <div v-if="option==='Log in'" class="flex flex-row mb-3">
                <p class="mr-2">Dont have an account?</p>
                <b class="text-green-500 cursor-pointer" @click="option='Sign up'">Sign up</b>
            </div>

            <div v-else class="flex flex-row mb-3">
                <p class="mr-2">Already have an account?</p>
                <b class="text-green-500 cursor-pointer" @click="option='Log in'">Log in</b>
            </div>
        </div>

        <div  v-if="option==='Sign up'" class="flex flex-col">
            <label class="text-left mb-1">First Name</label>
            <input class="border border-gray-300 p-2 rounded-md **w-full**" v-model="fName" placeholder="enter your first name"></input>
            <p v-if="errors.fName" class="text-red-500 text-sm">{{ errors.fName }}</p>

            <label class="text-left mb-1 mt-3">Sir Name</label>
            <input class="border border-gray-300 p-2 rounded-md **w-full**" v-model="LName" placeholder="enter your sir name"></input>
            <p v-if="errors.LName" class="text-red-500 text-sm">{{ errors.LName }}</p>
        </div>

        <label class="text-left mb-1 mt-3">Email</label>
        <input class="border border-gray-300 p-2 rounded-md **w-full**" placeholder="Enter your email" v-model="email" />
        <p v-if="errors.email" class="text-red-500 text-sm">{{ errors.email }}</p>

        <label class="text-left mb-1 mt-3">Password</label>
        <input type="password" class="border border-gray-300 p-2 rounded-md **w-full**" placeholder="Enter your password" v-model="password" />
        <p v-if="errors.password" class="text-red-500 text-sm">{{ errors.password }}</p>

        <div  v-if="option==='Sign up'" class="flex flex-col">
            <label class="text-left mb-1 mt-3">Confirm Password</label>
            <input class="border border-gray-300 p-2 rounded-md **w-full**" v-model="confirmation" placeholder="enter your password again"></input>
            <p v-if="errors.confirmation" class="text-red-500 text-sm">
            {{ errors.confirmation }}
            </p>
        </div>

        <p v-if="errors.general" class="text-red-600 text-sm text-center mt-2">
            {{ errors.general }}
        </p>
       </form>

       <button class="px-5 py-1 mt-3 text-white bg-green-400 rounded-md cursor-pointer" @click="authenticate()">
        <b>{{option}}</b>
        </button>
    </div>
    </div>
</template>