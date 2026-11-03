namespace GradeManagement.DataAccresssLayer;
using GradeManagement.Domain;

public class CourseRepository : ICourseRepository
{
    private readonly CoursesContext _context;
    
    /// <summary>
    ///     
    /// </summary>
    /// <param name="context"></param>
    public CourseRepository(CoursesContext context)
    {
        _context = context;
    }

    /// <summary>
    ///     
    /// </summary>
    /// <returns></returns>
    public List<Course> GetAll()
    {
        return _context.Courses.ToList();
    }
    /// <summary>
    ///     
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Course GetById(int id)
    {   
        return _context.Courses.FirstOrDefault(c => c.Id == id);  
    }
    /// <summary>
    ///     
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public Course GetByName(string name)
    {
        return _context.Courses.FirstOrDefault(c => c.Name == name);
    }
    /// <summary>
    ///     
    /// </summary>
    /// <param name="acronym"></param>
    /// <returns></returns>
    public Course GetByAcronym(string acronym)
    {
        return _context.Courses.FirstOrDefault(c => c.Acronym == acronym);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="course"></param>
    /// <returns></returns>
    public Course CreateCourse(Course course)
    {
        _context.Courses.Add(course);
        _context.SaveChanges();
        return course;
    }
    /// <summary>
    ///     
    /// </summary>
    /// <param name="id"></param>
    /// <param name="course"></param>
    /// <returns></returns>
    public bool UpdateCourse(int id, Course course)
    {
        var courseToUpdate = _context.Courses.FirstOrDefault(c => c.Id == id);  
        if (courseToUpdate == null) return false;
        courseToUpdate.Name = course.Name;
        courseToUpdate.Acronym = course.Acronym;
        _context.SaveChanges();
        return true;
    }
    /// <summary>
    ///     
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool DeleteCourse(int id)
    {
        var courseToDelete = _context.Courses.FirstOrDefault(c => c.Id == id);  
        if (courseToDelete == null) return false;

        _context.Courses.Remove(courseToDelete);
        _context.SaveChanges();
        return true;
    }
}
