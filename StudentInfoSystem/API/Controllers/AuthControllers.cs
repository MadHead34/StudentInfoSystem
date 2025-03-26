using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }


    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
            var token = _authService.Authenticate(request.Username, request.Password);

            if (token == null)
                return Unauthorized(new { message = "Invalid username or password" });

            return Ok(new { Token = token });
    }
}

public class LoginRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}

