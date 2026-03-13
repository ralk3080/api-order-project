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
        new User { Id = 2, Name = "Ana", Email = "ana@email.com" },
        new User { Id = 3, Name = "Carlos", Email = "carlos@email.com" },
        new User { Id = 4, Name = "Maria", Email = "maria@email.com" },
        new User { Id = 5, Name = "Luis", Email = "luis@email.com" },
        new User { Id = 6, Name = "Sofia", Email = "sofia@email.com" },
        new User { Id = 7, Name = "Pedro", Email = "pedro@email.com" },
        new User { Id = 8, Name = "Laura", Email = "laura@email.com" },
        new User { Id = 9, Name = "Miguel", Email = "miguel@email.com" },
        new User { Id = 10, Name = "Valeria", Email = "valeria@email.com" }
    };



    [HttpGet("getAllUsers")]
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

    [HttpPost("createUser")]
    public IActionResult CreateUser(User user)
    {
        user.Id = users.Count + 1;
        users.Add(user);

        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
    }
}
