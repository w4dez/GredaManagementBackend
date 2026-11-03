namespace GradeManagement.Domain;

public interface ICourseService
{
    public List<CourseDto> GetAll();
    public CourseDto GetById(int id);
    public CourseDto GetByName(string name);
    public CourseDto GetByAcronym(string acronym);
    public CourseDto CreateCourse(CreateCourseDto course);
    public bool UpdateCourse(int id, UpdateCourseDto course);
    public bool DeleteCourse(int id);
}