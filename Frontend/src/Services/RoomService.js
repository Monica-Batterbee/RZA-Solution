import axios from "axios";


const API_URL = "http://localhost:5085/api/rooms";

export const getRooms = async () => {
    try {
      const response = await axios.get(API_URL);
      return response.data; 
    } catch (error) {
      console.error("Error fetching assignments:", error);
      throw error;
    }
  };


