namespace GradeManagement.Domain;

public interface IGradeService
{
    public List<GradeDto> GetAll();
    public GradeDto GetById(int id);
    public GradeDto GetByDate(DateOnly date);
    public GradeDto GetByComment (string comment);
    public List<GradeDto> GetByName (string courseName);
    public GradeDto CreateGrade(CreateGradeDto grade);
    public bool UpdateGrade(int id, UpdateGradeDto grade);
    public bool DeleteGrade(int id);
}