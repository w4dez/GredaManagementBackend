namespace GradeManagement.Domain;

public interface IGradeRepository
{
    public List<Grade> GetAll();
    
    public Grade? GetById(int id);
    
    public Grade Create(Grade grade);
    
    public bool UpdateGrade(int id, Grade grade);
    
    public bool DeleteGrade(int id);
}