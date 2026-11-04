using Microsoft.AspNetCore.Mvc;
using GradeManagement.ServiceLayer;
using GradeManagement.Domain;
namespace GradeManagementApi.Controllers;


[ApiController]
[Route("api/[controller]")]

/// <summary>
/// 
/// </summary>
public class AuthController : ControllerBase // Controller for handling authentication-related API requests
{
  private GradeService _gradeService; 

private readonly AuthService _authService;
/// <summary>
/// 
/// </summary>
/// <param name="gradeService"></param>
/// <param name="authService"></param>
  public AuthController(GradeService gradeService, AuthService authService) // Constructor injection for the GameService
  {
    _gradeService = gradeService;    
    _authService = authService;
  }
[HttpPost("login")]
/// <summary>
/// 
/// </summary>
/// <param name="loginRequest"></param>
/// <returns></returns>
public ActionResult<LoginResponseDto> Login([FromBody] LoginRequestDto loginRequest)
{   
    LoginResponseDto response = _authService.Login(loginRequest);

    if (response == null)
    {
        // Don't say "Password was wrong" or "User does not exist".
        // Always return a generic error message.
        return Unauthorized("Invalid login credentials.");
    }

    return Ok(response);
}
}