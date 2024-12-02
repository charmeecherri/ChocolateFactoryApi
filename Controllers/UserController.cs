using ChocolateFactoryApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers;
using ChocolateFactoryApi.Models;
using ChocolateFactoryApi.Services;

namespace ChocolateFactoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IUserService _userService;

        public UserController(AppDbContext context,IUserService userService)
        {
            this.context = context;
            _userService = userService;
        }
        [HttpGet]

        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await context.Users.ToListAsync();
        }

        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            if (_userService.RegisterUser(user))
                return Ok("User registered successfully!");
            return BadRequest("Email already exists.");
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreatedUser(User user)
        {
            context.Users.Add(user);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUsers),new {id= user.UserId},user);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, User user)
        {
            if (id != user.UserId) return BadRequest();
            context.Entry(user).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

    }
}
