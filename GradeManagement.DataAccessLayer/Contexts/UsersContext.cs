namespace GradeManagement.DataAccresssLayer;
using Microsoft.EntityFrameworkCore;

public class UsersContext : DbContext
{   
    public UsersContext(DbContextOptions<UsersContext> options) : base(options)
    {
    }

    public DbSet<GradeManagement.Domain.User> User { get; set; } = null!;
}
