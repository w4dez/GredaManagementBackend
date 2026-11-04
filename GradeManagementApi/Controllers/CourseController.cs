using GradeManagement.Domain;
using GradeManagement.ServiceLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GreadeManagementApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
/// <summary>
/// 
/// </summary>
public class CourseController : ControllerBase
{
    private readonly CourseService _courseService;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="courseService"></param>
    public CourseController(CourseService courseService)
    {
        _courseService = courseService;
    }
    [HttpGet]
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public ActionResult<List<CourseDto>> GetAll() 
    {
        var courses = _courseService.GetAll(); 
        return Ok(courses);
    }

    [HttpGet("by-id/{id}")]
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public ActionResult<CourseDto> GetById(int id)
    {
        var course = _courseService.GetById(id);
        return Ok(course);
    }

    [HttpGet("by-name/{name}")]
    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public ActionResult<CourseDto> GetByName(string name)
    {
        var course = _courseService.GetByName(name);
        return Ok(course);
    }

    [HttpGet("by-acronym/{acronym}")]
    /// <summary>
    /// 
    /// </summary>
    /// <param name="acronym"></param>
    /// <returns></returns>
    public ActionResult<CourseDto> GetByAcronym(string acronym)
    {
        var course = _courseService.GetByAcronym(acronym);
        return Ok(course);
    }

    [HttpPost]
    /// <summary>
    /// 
    /// </summary>
    /// <param name="createCourseDto"></param>
    /// <returns></returns>
    public ActionResult<CourseDto> CreateCourse([FromBody] CreateCourseDto createCourseDto)
    {
        var newCourse = _courseService.CreateCourse(createCourseDto);
        return Created($"/api/course/by-id/{newCourse.Id}", newCourse);
    }

    [HttpPut("{id}")]
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="updateCourseDto"></param>
    /// <returns></returns>
    public IActionResult UpdateCourse(int id, [FromBody] UpdateCourseDto updateCourseDto)
    {
        var success = _courseService.UpdateCourse(id, updateCourseDto);
        if (!success) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public IActionResult DeleteCourse(int id)
    {
        var success = _courseService.DeleteCourse(id);
        if (!success) return NotFound();
        return NoContent();
    }
}
