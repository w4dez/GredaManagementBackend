using GradeManagement.Domain;
using GradeManagement.ServiceLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
namespace GreadeManagementApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
/// <summary>
/// 
/// </summary>
public class GradeController : ControllerBase
{
    private readonly GradeService _gradeService;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="gradeService"></param>
    public GradeController(GradeService gradeService)
    {
        _gradeService = gradeService;
    }
    [HttpGet]
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public ActionResult<List<GradeDto>> GetAll() 
    {
        var grades = _gradeService.GetAll(); 
        return Ok(grades);
    }

    [HttpGet("by-id/{id}")]
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public ActionResult<GradeDto> GetById(int id)
    {
        var grade = _gradeService.GetById(id);
        return Ok(grade);
    }

    [HttpPost]
    /// <summary>
    /// 
    /// </summary>
    /// <param name="createGradeDto"></param>
    /// <returns></returns>
    public ActionResult<Grade> CreateGrade([FromBody] CreateGradeDto createGradeDto)
    {
        var newGrade = _gradeService.CreateGrade(createGradeDto);
        return Created($"/api/grade/by-id/{newGrade.Id}", newGrade);
    }

    [HttpPut("{id}")]
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="updateGraderDto"></param>
    /// <returns></returns>
    public IActionResult UpdateGrade(int id, [FromBody] UpdateGradeDto updateGradeDto)
    {
        var success = _gradeService.UpdateGrade(id, updateGradeDto);
        if (!success) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public IActionResult DeleteGrade(int id)
    {
        var success = _gradeService.DeleteGrade(id);
        if (!success) return NotFound();
        return NoContent();
    }
}
