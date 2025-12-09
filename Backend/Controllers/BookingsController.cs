using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Models;

[Route("api/[controller]")]
[ApiController]
public class BookingsController : ControllerBase
{
    private readonly AppDbContext _context;

    public BookingsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetBookings()
    {
        var bookings = await _context.Booking.ToListAsync();
        return Ok(bookings);
    }

    [HttpPost]
    public async Task<IActionResult> AddBooking([FromBody] Booking booking)
    {
        _context.Booking.Add(booking);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetBookings), new { id = booking.BookingID }, booking);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBooking(int id)
    {
        var booking = await _context.Booking.FindAsync(id);

        if (booking == null)
            return NotFound();

        _context.Booking.Remove(booking);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}

