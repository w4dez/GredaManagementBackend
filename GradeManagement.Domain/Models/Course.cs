namespace GradeManagement.Domain;

/// <summary>
/// 
/// </summary>
public class Course
{
    public int Id {get;set;}
    public string Name {get; set;} = string.Empty;

    public string Acronym {get; set;} = string.Empty;
    public ICollection<Grade> Grades { get; set; } = new List<Grade>();

}