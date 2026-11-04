using GradeManagement.Domain;


namespace GradeManagement.ServiceLayer;

/// <summary>
/// 
/// </summary>
public class GradeService : IGradeService
{
    private readonly IGradeRepository _gradeRepository;

    public GradeService(IGradeRepository gradeRepository)
    {
        _gradeRepository = gradeRepository;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public List<GradeDto> GetAll()
    {
        List<Grade> grades = _gradeRepository.GetAll();
        
        List<GradeDto> dtos = grades.Select(grade => new GradeDto
        {
            Id = grade.Id,
            GradeValue = grade.GradeValue,
            ExamDate = grade.ExamDate,
            Comment = grade.Comment,
            CourseId = grade.CourseId,
            
           CourseName = grade.Course != null ? grade.Course.Name : string.Empty
        }).ToList();

        return dtos;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public GradeDto? GetById(int id)
    {
        Grade? grade = _gradeRepository.GetById(id);
        if (grade == null) return null;

        return new GradeDto
        {
            Id = grade.Id,
            GradeValue = grade.GradeValue,
            ExamDate = grade.ExamDate,
            Comment = grade.Comment,
            CourseId = grade.CourseId,
            CourseName = grade.Course != null ? grade.Course.Name : string.Empty
        };
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="createDto"></param>
    /// <returns></returns>
    public GradeDto CreateGrade(CreateGradeDto createDto)
    {
        Grade newGrade = new Grade
        {
            GradeValue = createDto.GradeValue,
            ExamDate = createDto.ExamDate,
            Comment = createDto.Comment,
            CourseId = createDto.CourseId,
            CreationDate = DateTime.UtcNow
        
        };

        Grade savedGrade = _gradeRepository.Create(newGrade);

        return new GradeDto
        {
            Id = savedGrade.Id,
            GradeValue = savedGrade.GradeValue,
            ExamDate = savedGrade.ExamDate,
            Comment = savedGrade.Comment,
            CourseId = savedGrade.CourseId,
            CourseName = string.Empty 
        };
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="updateDto"></param>
    /// <returns></returns>
    public bool UpdateGrade(int id, UpdateGradeDto updateDto)
    {
        Grade gradeEntity = new Grade
        {
            Id = id,
            GradeValue = updateDto.GradeValue,
            ExamDate = updateDto.ExamDate,
            Comment = updateDto.Comment
        };

        return _gradeRepository.UpdateGrade(id, gradeEntity);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool DeleteGrade(int id)
    {
        return _gradeRepository.DeleteGrade(id);
    }
}