using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GradeManagement.DataAccresssLayer;

namespace GradeManagement.ServiceLayer; 

public static class DependencyInjection
{   
    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection AddServiceLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDataAccessLayer(configuration); 
        services.AddScoped<AuthService>();
        services.AddScoped<GradeService>();
        services.AddScoped<CourseService>();
        services.AddScoped<UserService>();
        return services;
    }
}