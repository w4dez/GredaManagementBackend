namespace GradeManagement.Domain;

public class UpdateCourseDto
{
    public required string Name {get; set;} = string.Empty;

    public required string Acronym {get; set;} = string.Empty;
}