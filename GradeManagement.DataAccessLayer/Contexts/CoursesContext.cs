namespace GradeManagement.DataAccresssLayer;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// 
/// </summary>
public class CoursesContext : DbContext
{    
    public CoursesContext(DbContextOptions<CoursesContext> options) : base(options)
    {
    }

    public DbSet<GradeManagement.Domain.Course> Course { get; set; } = null!;
}
