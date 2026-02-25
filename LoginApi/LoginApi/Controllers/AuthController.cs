using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login([FromBody] CLoginRequest request)
    {
        // Example: simple check (replace with DB check later)
        if (request.Username == "admin" && request.Password == "1234")
        {
            return Ok(new { message = "Login Successful!" });
        }
        return Unauthorized(new { message = "Invalid username or password" });
    }
}
