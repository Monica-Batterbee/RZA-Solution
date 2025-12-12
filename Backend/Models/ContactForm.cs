using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class ContactForm
    {
        [Key]
        public int ContactID { get; set; }
        public string?  Email { get; set; } 
        public string? Message { get; set; }
        public string? MobileNumber { get; set; }

    }
}