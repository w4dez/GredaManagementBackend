using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GradeManagement.DataAccresssLayer;

namespace GradeManagement.ServiceLayer; 

public static class DependencyInjection
{
    public static IServiceCollection AddServiceLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDataAccessLayer(configuration); 

        services.AddScoped<CourseService>();
        services.AddScoped<UserService>();
        return services;
    }
}