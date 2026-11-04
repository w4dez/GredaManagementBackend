namespace GradeManagement.Domain;

public interface IGradeService
{
    List<GradeDto> GetAll();
    
    GradeDto? GetById(int id);
    
    GradeDto CreateGrade(CreateGradeDto createDto);
    
    bool UpdateGrade(int id, UpdateGradeDto updateDto);
    
    bool DeleteGrade(int id);
}