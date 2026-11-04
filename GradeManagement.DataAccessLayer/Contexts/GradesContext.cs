namespace GradeManagement.DataAccresssLayer;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// 
/// </summary>
public class GradesContext : DbContext
{   
    public GradesContext(DbContextOptions<GradesContext> options) : base(options)
    {
    }

    public DbSet<GradeManagement.Domain.Grade> Grade { get; set; } = null!;
}
