namespace Gestor_de_tareas.Controllers
{
    using Gestor_de_tareas.Services;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    namespace UserAuthApp.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class AuthController : ControllerBase
        {
            private readonly AuthService _authService;

            public AuthController(AuthService authService)
            {
                _authService = authService;
            }

            [HttpPost("register")]
            public async Task<IActionResult> Register([FromBody] RegisterRequest request)
            {
                if (await _authService.Register(request.Username, request.Password))
                {
                    return Ok("User registered successfully.");
                }
                return BadRequest("Username already exists.");
            }

            [HttpPost("login")]
            public IActionResult Login([FromBody] LoginRequest request)
            {
                if (_authService.Login(request.Username, request.Password))
                {
                    return Ok("Login successful.");
                }
                return Unauthorized("Invalid username or password.");
            }
        }

        public class RegisterRequest
        {
            public string Username { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public class LoginRequest
        {
            public string Username { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
        }
    }
}
