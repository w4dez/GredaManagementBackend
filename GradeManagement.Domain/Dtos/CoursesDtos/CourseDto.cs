namespace GradeManagement.Domain;

/// <summary>
/// 
/// </summary>
public class CourseDto
{
    public int Id {get;set;}
    public string? Name {get; set;} = string.Empty;

    public string Acronym {get; set;} = string.Empty;
    public decimal? AverageGrade { get; set; }
}