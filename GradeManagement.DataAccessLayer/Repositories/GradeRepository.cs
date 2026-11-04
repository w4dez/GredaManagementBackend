namespace GradeManagement.DataAccresssLayer;
using Microsoft.EntityFrameworkCore;
using GradeManagement.Domain;

/// <summary>
/// 
/// </summary>
public class GradeRepository : IGradeRepository
{
    private readonly GradesContext _context;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    public GradeRepository(GradesContext context)
    {
        _context = context;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public List<Grade> GetAll()
    {
        List<Grade> grades = _context.Grade
            .Include(g => g.Course)
            .Include(g => g.User)
            .ToList();
            
        return grades;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Grade? GetById(int id)
    {
        Grade? grade = _context.Grade
            .Include(g => g.Course)
            .Include(g => g.User)
            .FirstOrDefault(g => g.Id == id);
            
        return grade;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="grade"></param>
    /// <returns></returns>
    public Grade Create(Grade grade)
    {
        _context.Grade.Add(grade);
        _context.SaveChanges();
        
        return grade;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="grade"></param>
    /// <returns></returns>
    public bool UpdateGrade(int id, Grade grade)
    {
        Grade? gradeToUpdate = _context.Grade.FirstOrDefault(g => g.Id == id);
        
        if (gradeToUpdate == null) return false;

        gradeToUpdate.GradeValue = grade.GradeValue;
        gradeToUpdate.ExamDate = grade.ExamDate;
        gradeToUpdate.Comment = grade.Comment;

        _context.SaveChanges();
        return true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool DeleteGrade(int id)
    {
        Grade? gradeToDelete = _context.Grade.FirstOrDefault(g => g.Id == id);
        
        if (gradeToDelete == null) return false;

        _context.Grade.Remove(gradeToDelete);
        _context.SaveChanges();
        return true;
    }
}