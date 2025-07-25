using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservaInteligente.Models.DTOs;
using ReservaInteligente.Services;

namespace ReservaInteligente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtService _jwtService;
        private readonly UserService _userService;
        public AuthController(JwtService jwtService, UserService userService)
        {
            _jwtService = jwtService;
            _userService = userService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthRequestDTO authRequest)
        {
            var user = await _userService.AuthenticateUserAsync(authRequest);
            if (user == null)
            {
                return Unauthorized("Invalid credentials");
            }

            var token = _jwtService.GenerateToken(user);
            return Ok(new AuthResponseDTO
            {
                Token = token,
                Expires = DateTime.Now.AddMinutes(120)
            });
        }
    }
}
