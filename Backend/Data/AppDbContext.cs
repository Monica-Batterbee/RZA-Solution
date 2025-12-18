using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace Backend.Data
{
    //DB context
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        //All data tables in DB
        public DbSet<User> User { get; set; }
        public DbSet<Booking> Booking { get; set; }
        public DbSet<HotelRoom> HotelRoom {get; set; }
        public DbSet<HotelBooking> HotelBooking { get; set; }
        public DbSet<ContactForm> ContactForm { get; set; }
    }
}