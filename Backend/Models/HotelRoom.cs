using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class HotelRoom
    {
        [Key]
        public int RoomID { get; set; }
        public string?  Name { get; set; } 
        public string? URL { get; set; }
        public string? Description { get; set; }
        public int FamilyPrice { get; set; }
        public int DoublePrice { get; set; }
        public int SinglePrice { get; set; }
    }
}