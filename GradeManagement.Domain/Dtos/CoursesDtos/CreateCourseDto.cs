namespace GradeManagement.Domain;

public class CreateCourseDto
{
    public required string Name {get; set;} = string.Empty;

    public required string Acronym {get; set;} = string.Empty;
}