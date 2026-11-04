namespace GradeManagement.ServiceLayer; 
using GradeManagement.Domain;

/// <summary>
/// 
/// </summary>
public class CourseService : ICourseService
{
    private readonly ICourseRepository _CourseRepository;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="courseRepository"></param>
    public CourseService(ICourseRepository courseRepository)
    {
        _CourseRepository = courseRepository;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public List <CourseDto> GetAll()
    {
        List <Course> courses = _CourseRepository.GetAll();
        return courses.Select(c => new CourseDto
        {
            Id = c.Id,
            Name = c.Name,
            Acronym = c.Acronym,
            AverageGrade = c.Grades.Any()
            ? Math.Round(c.Grades.Average(g => g.GradeValue), 2)
            : (decimal?)null
    }).ToList();

    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public CourseDto GetById(int id)
    {
        Course course = _CourseRepository.GetById(id);
        if (course == null)
        {
            throw new Exception($"Course with id {id} not found");  
    }
    return new CourseDto
    {
        Id = course.Id,
        Name = course.Name,
        Acronym = course.Acronym,

        AverageGrade = course.Grades.Any() 
            ? Math.Round(course.Grades.Average(g => g.GradeValue), 2) 
            : null


    };
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public CourseDto GetByName(string name)
    {
        Course course = _CourseRepository.GetByName(name);
        if (course == null)
        {
            throw new Exception($"Course with name {name} not found");
        }
        return new CourseDto{
            Id = course.Id,
            Name = course.Name,
            Acronym = course.Acronym,
            
        AverageGrade = course.Grades.Any() 
            ? Math.Round(course.Grades.Average(g => g.GradeValue), 2) 
            : null
        };
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="acronym"></param>
    /// <returns></returns>
    public CourseDto GetByAcronym(string acronym)
    {
        Course course = _CourseRepository.GetByAcronym(acronym);
        if (course == null)
        {
            throw new Exception($"Course with acronym {acronym} not found");
        }
        return new CourseDto{
            Id = course.Id,
            Name = course.Name,
            Acronym = course.Acronym,

        AverageGrade = course.Grades.Any() 
            ? Math.Round(course.Grades.Average(g => g.GradeValue), 2) 
            : null
        };
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="createCourseDto"></param>
    /// <returns></returns>
    public CourseDto CreateCourse(CreateCourseDto createCourseDto)
    {
        Course newCourseEntity = new Course
        {
            Name = createCourseDto.Name,
            Acronym = createCourseDto.Acronym
        };
        Course createdCourse = _CourseRepository.CreateCourse(newCourseEntity);
  
        return new CourseDto
        {
            Id = createdCourse.Id,
            Name = createdCourse.Name,
            Acronym = createdCourse.Acronym
        };   
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="updateCourseDto"></param>
    /// <returns></returns>
    public bool UpdateCourse(int id, UpdateCourseDto updateCourseDto)
    {
        Course courseEntity = new Course
        {
            Id = id,
            Name = updateCourseDto.Name,
            Acronym = updateCourseDto.Acronym
        };

        return _CourseRepository.UpdateCourse(id, courseEntity);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool DeleteCourse(int id)
    {
        return _CourseRepository.DeleteCourse(id);
    }
}