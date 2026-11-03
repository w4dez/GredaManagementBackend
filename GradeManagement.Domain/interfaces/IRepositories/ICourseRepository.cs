namespace GradeManagement.Domain;

public interface ICourseRepository
{
    public List<Course> GetAll();
    public Course GetById(int id);
    public Course GetByName(string name);
    public Course GetByAcronym(string acronym);
    public Course CreateCourse(Course course);
    public bool UpdateCourse(int id, Course course);
    public bool DeleteCourse(int id);
}