import axios from "axios";


const API_URL = "http://localhost:5085/api/contact";

//Calls get endpoint to retrieve all contact forms
export const getContacts = async () => {
    try {
      const response = await axios.get(API_URL);
      return response.data; 
    } catch (error) {
      console.error("Error fetching assignments:", error);
      throw error;
    }
  };

//Calls post endoint to add a contact form
export const postContact = async (newForm) => {
    await axios.post(API_URL, newForm)
    .then(function (response) {
        console.log(response);
      })
      .catch(function (error) {
        console.log(error);
      });

};
