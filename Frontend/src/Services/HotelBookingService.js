import axios from "axios";


const API_URL = "http://localhost:5085/api/hotelBookings";

export const getHotelBookings = async () => {
    try {
      const response = await axios.get(API_URL);
      return response.data; 
    } catch (error) {
      console.error("Error fetching assignments:", error);
      throw error;
    }
  };


export const postHotelBooking = async (newBooking) => {
    await axios.post(API_URL, newBooking)
    .then(function (response) {
        console.log(response);
      })
      .catch(function (error) {
        console.log(error);
      });

};

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