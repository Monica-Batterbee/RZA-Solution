namespace Backend.Models
{
    public class Booking
    {
        public int BookingID { get; set; }
        public string?  DateBookingMade { get; set; } 
        public string? BookingDetails { get; set; }
        public int UserID { get; set; }

    }
}