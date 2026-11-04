namespace GradeManagement.Domain;

/// <summary>
/// 
/// </summary>
public class Grade
{
    public int Id {get;set;}
    public decimal GradeValue {get; set;}
    public DateOnly ExamDate {get; set;}
    public string Comment {get; set;} = string.Empty;
    public DateTime CreationDate {get; set;}
    public int UserId {get; set;}
    public int CourseId {get; set;}

    public User? User { get; set; }
    public Course? Course { get; set; }
}
