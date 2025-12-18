namespace Backend.Models
{
    //Model of hotel booking table (Storing columns and datatypes)
    public class HotelBooking
    {
        public int HotelBookingID { get; set; }
        public string?  DateBookingMade { get; set; } 
        public string? BookingDetails { get; set; }
        public int UserID { get; set; }

    }
}