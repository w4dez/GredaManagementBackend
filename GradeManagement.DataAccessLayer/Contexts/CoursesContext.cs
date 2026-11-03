namespace GradeManagement.DataAccresssLayer;
using Microsoft.EntityFrameworkCore;

public class CoursesContext : DbContext
{   
    public CoursesContext(DbContextOptions<CoursesContext> options) : base(options)
    {
    }

    public DbSet<GradeManagement.Domain.Course> Courses { get; set; } = null!;
}
