namespace GradeManagement.DataAccresssLayer;
using Microsoft.EntityFrameworkCore;
using GradeManagement.Domain;

/// <summary>
/// 
/// </summary>
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
        return _context.Course.Include(c => c.Grades).ToList();
    }
    /// <summary>
    ///     
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Course GetById(int id)
    {       
        return _context.Course.Include(c => c.Grades).FirstOrDefault(c => c.Id == id);  
    }
    /// <summary>
    ///     
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public Course GetByName(string name)
    {
        return _context.Course.Include(c => c.Grades).FirstOrDefault(c => c.Name == name);
    }
    /// <summary>
    ///     
    /// </summary>
    /// <param name="acronym"></param>
    /// <returns></returns>
    public Course GetByAcronym(string acronym)
    {
        return _context.Course.Include(c => c.Grades).FirstOrDefault(c => c.Acronym == acronym);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="course"></param>
    /// <returns></returns>
    public Course CreateCourse(Course course)
    {
        _context.Course.Add(course);
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
        Course courseToUpdate = _context.Course.FirstOrDefault(c => c.Id == id);  
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
        Course courseToDelete = _context.Course.FirstOrDefault(c => c.Id == id);  
        if (courseToDelete == null) return false;

        _context.Course.Remove(courseToDelete);
        _context.SaveChanges();
        return true;
    }
}
