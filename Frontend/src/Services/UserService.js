import axios from "axios";


const API_URL = "http://localhost:5085/api/users";

//Calls get endpoint to retrieve all users
export const getUsers = async () => {
    try {
      const response = await axios.get(API_URL);
      return response.data; 
    } catch (error) {
      console.error("Error fetching assignments:", error);
      throw error;
    }
  };

//Calls post endpoint to add a user
export const postUser = async (newUser) => {
    await axios.post(API_URL, newUser)
    .then(function (response) {
        console.log(response);
      })
      .catch(function (error) {
        console.log(error);
      });

};