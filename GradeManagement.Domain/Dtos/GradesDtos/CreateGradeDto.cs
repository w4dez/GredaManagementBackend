namespace GradeManagement.Domain;

/// <summary>
/// 
/// </summary>
public class CreateGradeDto
{
    public decimal GradeValue { get; set; }
    public DateOnly ExamDate { get; set; }
    public string Comment { get; set; } = string.Empty;

    public int CourseId { get; set; } 
}