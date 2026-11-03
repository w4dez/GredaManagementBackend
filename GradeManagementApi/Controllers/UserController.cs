using GradeManagement.Domain;
using GradeManagement.ServiceLayer;
using Microsoft.AspNetCore.Mvc;

namespace GreadeManagementApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userService"></param>
    public UserController(UserService userService)
    {
        _userService = userService;
    }
    [HttpGet]
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public ActionResult<List<UserDto>> GetAll() 
    {
        var users = _userService.GetAll(); 
        return Ok(users);
    }

    [HttpGet("by-id/{id}")]
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public ActionResult<UserDto> GetById(int id)
    {
        var user = _userService.GetById(id);
        return Ok(user);
    }

    [HttpGet("by-name/{name}")]
    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public ActionResult<UserDto> GetByName(string name)
    {
        var user = _userService.GetByName(name);
        return Ok(user);
    }

    [HttpGet("by-email/{email}")]
    /// <summary>
    /// 
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    public ActionResult<UserDto> GetByEmail(string email)
    {
        var user = _userService.GetByEmail(email);
        return Ok(user);
    }

    [HttpPost]
    /// <summary>
    /// 
    /// </summary>
    /// <param name="createUserDto"></param>
    /// <returns></returns>
    public ActionResult<UserDto> CreateUser([FromBody] CreateUserDto createUserDto)
    {
        var newUser = _userService.CreateUser(createUserDto);
        return Created($"/api/user/by-id/{newUser.Id}", newUser);
    }

    [HttpPut("{id}")]
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="updateUserDto"></param>
    /// <returns></returns>
    public IActionResult UpdateUser(int id, [FromBody] UpdateUserDto updateUserDto)
    {
        var success = _userService.UpdateUser(id, updateUserDto);
        if (!success) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public IActionResult DeleteUser(int id)
    {
        var success = _userService.DeleteUser(id);
        if (!success) return NotFound();
        return NoContent();
    }
}
