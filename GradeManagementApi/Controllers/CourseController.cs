using GradeManagement.Domain;
using GradeManagement.ServiceLayer;
using Microsoft.AspNetCore.Mvc;

namespace GreadeManagementApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CourseController : ControllerBase
{
    private readonly CourseService _courseService;

    public CourseController(CourseService courseService)
    {
        _courseService = courseService;
    }

    [HttpGet]
    public ActionResult<List<CourseDto>> GetAll()
    {
        var courses = _courseService.GetAll();
        return Ok(courses);
    }

    [HttpGet("by-id/{id}")]
    public ActionResult<CourseDto> GetById(int id)
    {
        var course = _courseService.GetById(id);
        return Ok(course);
    }

    [HttpGet("by-name/{name}")]
    public ActionResult<CourseDto> GetByName(string name)
    {
        var course = _courseService.GetByName(name);
        return Ok(course);
    }

    [HttpGet("by-acronym/{acronym}")]
    public ActionResult<CourseDto> GetByAcronym(string acronym)
    {
        var course = _courseService.GetByAcronym(acronym);
        return Ok(course);
    }

    [HttpPost]
    public ActionResult<CourseDto> CreateCourse([FromBody] CreateCourseDto createCourseDto)
    {
        var newCourse = _courseService.CreateCourse(createCourseDto);
        return Created($"/api/course/by-id/{newCourse.Id}", newCourse);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCourse(int id, [FromBody] UpdateCourseDto updateCourseDto)
    {
        var success = _courseService.UpdateCourse(id, updateCourseDto);
        if (!success) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCourse(int id)
    {
        var success = _courseService.DeleteCourse(id);
        if (!success) return NotFound();
        return NoContent();
    }
}
