namespace GradeManagement.Domain;

/// <summary>
/// 
/// </summary>
public class UpdateGradeDto
{
    public decimal GradeValue {get; set;}
    public DateOnly ExamDate {get; set;}
    public string Comment {get; set;} = string.Empty;
    public DateTime CreationDate {get; set;}
    public int CourseId {get; set;}
    public required string CourseName { get; set; } = string.Empty;
    public required string CourseAcronym { get; set; } = string.Empty;
}