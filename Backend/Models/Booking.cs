namespace Backend.Models
{
    //Model of booking table (Storing columns and datatypes)
    public class Booking
    {
        public int BookingID { get; set; }
        public string?  DateBookingMade { get; set; } 
        public string? BookingDetails { get; set; }
        public int UserID { get; set; }

    }
}