namespace GradeManagement.Domain;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// 
/// </summary>
public class LoginRequestDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
}