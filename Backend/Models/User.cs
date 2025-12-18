namespace Backend.Models
{
    //Model of user table (Storing columns and datatypes)
    public class User
    {
        public int UserID { get; set; }
        public string Fname { get; set; } = string.Empty;
        public string? Lname { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

         public ICollection<Booking>? Bookings { get; set; }

    }
}