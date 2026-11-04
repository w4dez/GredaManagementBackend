namespace GradeManagement.Domain;

/// <summary>
/// 
/// </summary>
public class CreateUserDto
{
    public required string Email {get; set;} = string.Empty;
    public required string FirstName {get; set;} = string.Empty;
    public required string LastName {get; set;} = string.Empty;
}

