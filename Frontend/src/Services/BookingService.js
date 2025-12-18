import axios from "axios";


const API_URL = "http://localhost:5085/api/bookings";

//Calls get endpoint to retrieve all bookings
export const getBookings = async () => {
    try {
      const response = await axios.get(API_URL);
      return response.data; 
    } catch (error) {
      console.error("Error fetching assignments:", error);
      throw error;
    }
  };

//Calls post endpoint to add a new booking
export const postBooking = async (newBooking) => {
    await axios.post(API_URL, newBooking)
    .then(function (response) {
        console.log(response);
      })
      .catch(function (error) {
        console.log(error);
      });

};
//Calls delete endpoint to delete a booking
export const deleteBooking = async (bookingID) => {
  try {
    const response = await axios.delete(`${API_URL}/${bookingID}`);
    return response.data;
  } catch (error) {
    console.error("Error deleting booking:", error);
    throw error;
  }
};