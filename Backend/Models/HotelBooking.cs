namespace Backend.Models
{
    public class HotelBooking
    {
        public int HotelBookingID { get; set; }
        public string?  DateBookingMade { get; set; } 
        public string? BookingDetails { get; set; }
        public int UserID { get; set; }

    }
}