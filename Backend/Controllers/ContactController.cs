using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Models;

[Route("api/[controller]")]
[ApiController]
public class ContactController : ControllerBase
{
    private readonly AppDbContext _context;

    public ContactController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetContacts()
    {
        var contacts = await _context.ContactForm.ToListAsync();
        return Ok(contacts);
    }

    [HttpPost]
    public async Task<IActionResult> AddContactForm([FromBody] ContactForm contactForm)
    {
        _context.ContactForm.Add(contactForm);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetContacts), new { id = contactForm. ContactID }, contactForm);
    }


}

