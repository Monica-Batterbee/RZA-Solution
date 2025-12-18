import axios from "axios";


const API_URL = "http://localhost:5085/api/hotelBookings";

//Calls get endpoint to retrieve all hotel bookings
export const getHotelBookings = async () => {
    try {
      const response = await axios.get(API_URL);
      return response.data; 
    } catch (error) {
      console.error("Error fetching assignments:", error);
      throw error;
    }
  };

//Calls post endpoint to add a new hotel booking
export const postHotelBooking = async (newBooking) => {
    await axios.post(API_URL, newBooking)
    .then(function (response) {
        console.log(response);
      })
      .catch(function (error) {
        console.log(error);
      });

};
//Calls delete endpoint to delete a hotel booking
export const deleteHotelBooking = async (bookingID) => {
  try {
    console.log('bookingID',bookingID)
    const response = await axios.delete(`${API_URL}/${bookingID}`);
    return response.data;
  } catch (error) {
    console.error("Error deleting booking:", error);
    throw error;
  }
};