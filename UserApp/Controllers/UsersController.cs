using Microsoft.AspNetCore.Mvc;
using UserApp.Models;

namespace UserApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private static List<User> users = new()
    {
        new User { Id = 1, Name = "Juan", Email = "juan@email.com" },
        new User { Id = 2, Name = "Ana", Email = "ana@email.com" }
    };

    [HttpGet]
    public IActionResult GetUsers()
    {
        return Ok(users);
    }

    [HttpGet("{id}")]
    public IActionResult GetUser(int id)
    {
        var user = users.FirstOrDefault(u => u.Id == id);

        if (user == null)
            return NotFound();

        return Ok(user);
    }

    [HttpPost]
    public IActionResult CreateUser(User user)
    {
        user.Id = users.Count + 1;
        users.Add(user);

        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
    }
}
