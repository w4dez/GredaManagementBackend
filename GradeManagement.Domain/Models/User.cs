namespace GradeManagement.Domain;

/// <summary>
/// 
/// </summary>
public class User
{
    public int Id {get;set;}
    public string Email {get; set;} = string.Empty;
    public string FirstName {get; set;} = string.Empty;
    public string LastName {get; set;} = string.Empty;
    public ICollection<Grade> Grades { get; set; } = new List<Grade>();
}