using Microsoft.AspNetCore.Mvc;
using FinanceTracker.API.Data;
using FinanceTracker.Api.Models;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly FinanceContext _context;

    public UsersController(FinanceContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null) return NotFound();
        return Ok(user);
    }

    [HttpGet]
    public IActionResult GetAllUsers()
    {
        return Ok(_context.Users.ToList());
    }
}
