using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Models;

[Route("api/[controller]")]
[ApiController]
public class HotelBookingsController : ControllerBase
{
    private readonly AppDbContext _context;

    public HotelBookingsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetHotelBookings()
    {
        var bookings = await _context.HotelBooking.ToListAsync();
        return Ok(bookings);
    }

    [HttpPost]
    public async Task<IActionResult> AddHotelBooking([FromBody] HotelBooking booking)
    {
        _context.HotelBooking.Add(booking);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetHotelBookings), new { id = booking.HotelBookingID }, booking);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBooking(int id)
    {
        var booking = await _context.HotelBooking.FindAsync(id);

        if (booking == null)
            return NotFound();

        _context.HotelBooking.Remove(booking);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}

