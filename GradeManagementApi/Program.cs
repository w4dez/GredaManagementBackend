using Microsoft.OpenApi;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using GradeManagement.Domain;
using GradeManagement.ServiceLayer;
namespace GradeManagementApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        
        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();
        builder.Services.AddScoped<CourseService, CourseService>();
        builder.Services.AddScoped<UserService, UserService>();
        builder.Services.AddServiceLayer(builder.Configuration); 
        builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "GradeManagement API",
        Version = "v1"
    });

    // XML-Dokumentationsdatei einbinden
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
    {
        options.IncludeXmlComments(xmlPath);
    }
});
            


        var app = builder.Build();
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "GamesManagement API v1");
            });
        }

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

 // 1. "Who are you?"
// The app checks whether a valid token header exists
// and creates the user's identity from it (HttpContext.User).
app.UseAuthentication();

// 2. "Are you allowed to do that?"
// The app checks whether the identified user
// has permission for the requested endpoint.
app.UseAuthorization();

        app.MapControllers();

        app.Run();

    }
}