namespace GradeManagement.DataAccresssLayer;
using GradeManagement.Domain;

public class CourseRepository : ICourseRepository
{
    private readonly CoursesContext _context;
    
    public CourseRepository(CoursesContext context)
    {
        _context = context;
    }

    public List<Course> GetAll()
    {
        return _context.Courses.ToList();
    }

    public Course? GetById(int id)
    {   
        return _context.Courses.FirstOrDefault(c => c.Id == id);  
    }

    public Course? GetByName(string name)
    {
        return _context.Courses.FirstOrDefault(c => c.Name == name);
    }

    public Course? GetByAcronym(string acronym)
    {
        return _context.Courses.FirstOrDefault(c => c.Acronym == acronym);
    }

    public Course CreateCourse(Course course)
    {
        _context.Courses.Add(course);
        _context.SaveChanges();
        return course;
    }

    public bool UpdateCourse(int id, Course course)
    {
        var courseToUpdate = _context.Courses.FirstOrDefault(c => c.Id == id);  
        if (courseToUpdate == null) return false;
        courseToUpdate.Name = course.Name;
        courseToUpdate.Acronym = course.Acronym;
        _context.SaveChanges();
        return true;
    }

    public bool DeleteCourse(int id)
    {
        var courseToDelete = _context.Courses.FirstOrDefault(c => c.Id == id);  
        if (courseToDelete == null) return false;

        _context.Courses.Remove(courseToDelete);
        _context.SaveChanges();
        return true;
    }
}
