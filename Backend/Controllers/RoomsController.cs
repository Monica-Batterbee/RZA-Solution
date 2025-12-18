using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Models;

[Route("api/[controller]")]
[ApiController]
public class RoomsController : ControllerBase
{
    private readonly AppDbContext _context;

    public RoomsController(AppDbContext context)
    {
        _context = context;
    }

    //Gets all rooms 
    [HttpGet]
    public async Task<IActionResult> GetRooms()
    {
        var rooms = await _context.HotelRoom.ToListAsync();
        return Ok(rooms);
    }
    //Adds a new room
    [HttpPost]
    public async Task<IActionResult> AddRoom([FromBody] HotelRoom room)
    {
        _context.HotelRoom.Add(room);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetRooms), new { id = room.RoomID }, room);
    }
}