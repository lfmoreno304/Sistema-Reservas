using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservaInteligente.Models.DTOs;
using ReservaInteligente.Services;

namespace ReservaInteligente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }
       

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegisterDTO user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var result = await _userService.RegisterUserAsync(user);

            if (result == "User created successfully")
            {
                return Ok(new { message = result });
            }
            return BadRequest(new { message = result });

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userService.GetUserAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}
