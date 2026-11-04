namespace GradeManagement.DataAccresssLayer;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// 
/// </summary>
public class UsersContext : DbContext
{   
    public UsersContext(DbContextOptions<UsersContext> options) : base(options)
    {
    }

    public DbSet<GradeManagement.Domain.User> User { get; set; } = null!;
}
