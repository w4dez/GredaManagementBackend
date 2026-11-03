using GradeManagement.Domain;
namespace GradeManagement.DataAccresssLayer;

    /// <summary>
    /// 
    /// </summary>
public class userRepository : IUserRepository
{
    private readonly GradeManagement.DataAccresssLayer.UsersContext _context;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    public userRepository(UsersContext context)
    {
        _context = context;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public List <User> GetAll()
    {
        return _context.User.ToList();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public User GetById(int id)
    {
        return _context.User.FirstOrDefault(u => u.Id == id);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    public User GetByEmail(string email)
    {
        return _context.User.FirstOrDefault(u => u.Email == email);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public User GetByName(string name)
    {
        return _context.User.FirstOrDefault(u => u.FirstName == name);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public User CreateUser(User user)
    {
        _context.User.Add(user);
        _context.SaveChanges();
        return user;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="user"></param>
    /// <returns></returns>
    public bool UpdateUser(int id, User user)
     {
        var userToUpdate = _context.User.FirstOrDefault(u => u.Id == id);  
        if (userToUpdate == null) return false;
        userToUpdate.Email = user.Email;
        userToUpdate.FirstName = user.FirstName;
        userToUpdate.LastName = user.LastName;

        _context.SaveChanges();
        return true;
    }
    public bool DeleteUser (int id)
    {
        var userToDelete = _context.User.FirstOrDefault(u => u.Id == id);  
        if (userToDelete == null) return false;

        _context.User.Remove(userToDelete);
        _context.SaveChanges();
        return true;       
    }
}