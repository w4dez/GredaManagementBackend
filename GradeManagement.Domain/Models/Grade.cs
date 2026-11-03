namespace GradeManagement.Domain;

public class Grade
{
    public int Id {get;set;}
    public decimal GradeValue {get; set;}
    public DateOnly ExamDate {get; set;}
    public string Comment {get; set;} = string.Empty;
    public DateTime CreationDate {get; set;}

    public int UserId {get; set;}
    public int CourseId {get; set;}
    public string CourseName { get; set; } = string.Empty;
    public string CourseAcronym { get; set; } = string.Empty;
}
