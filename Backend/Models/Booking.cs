namespace Backend.Models
{
    public class Booking
    {
        public int BookingID { get; set; }
        public DateOnly  Date { get; set; } 
        public TimeOnly TimeOfBooking { get; set; }
        public int UserID { get; set; }

    }
}