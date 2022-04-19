using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Week11_G4_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly JwtAuthenticationManager _jwtAuthenticationManager;

        public AuthenticationController(JwtAuthenticationManager manager)
        {
            _jwtAuthenticationManager = manager;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] User user)
        {
            string token = _jwtAuthenticationManager.Authenticate(user.Username, user.Password);

            if (token == "")
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }

    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
