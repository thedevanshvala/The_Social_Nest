using FirebaseAdmin.Auth;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
//using TSN_WPF;
namespace TSN_Web.Server.Controllers
{
  [ApiController] // Add this attribute
  [Route("[controller]")]
  public class Login : Controller
  {

    private readonly FirebaseAuthService _firebaseAuthService;

    public Login(FirebaseAuthService firebaseAuthService)
    {
      _firebaseAuthService = firebaseAuthService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserCredentials credentials)
    {
      string result = await _firebaseAuthService.RegisterUserAsync(credentials.Email, credentials.Password);

      if (result.StartsWith("Error"))
      {
        return BadRequest(new { message = "Registration Failed: " + result });
      }

      return Ok(new { message = "Registration Successful!", userId = result });
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginUser([FromBody] UserCredentials credentials)
    {
      string result = await _firebaseAuthService.LoginUserAsync(credentials.Email, credentials.Password);

      if (result.StartsWith("Error"))
      {
        return Unauthorized(new { message = "Login Failed: " + result });
      }

      return Ok(new { message = "Login Successful!", token = result });
    }

    [HttpPost("forgot-password")]
    public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest request)
    {
      string result = await _firebaseAuthService.SendPasswordResetEmailAsync(request.Email);

      if (result.StartsWith("Error"))
      {
        return BadRequest(new { message = "Failed to send password reset email: " + result });
      }

      return Ok(new { message = "Password reset email sent successfully." });
    }
  }

  public class UserCredentials
  {
    public string Email { get; set; }
    public string Password { get; set; }
  }

  public class ForgotPasswordRequest
  {
    public string Email { get; set; }
  }
}