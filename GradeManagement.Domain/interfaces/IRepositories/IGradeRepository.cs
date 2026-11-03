namespace GradeManagement.Domain;

public interface IGradeRepository
{
    public List<Grade> GetAll();
    public Grade GetById(int id);
    public Grade GetByDate(DateOnly date);
    public Grade GetByComment (string comment);
    public List<Grade> GetByName (string courseName);
    public Grade CreateGrade(Grade grade);
    public bool UpdateGrade(int id, Grade grade);
    public bool DeleteGrade(int id);
}