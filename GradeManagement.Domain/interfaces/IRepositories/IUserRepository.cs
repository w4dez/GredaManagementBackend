namespace GradeManagement.Domain; 

public interface IUserRepository
{
    public List <User> GetAll();
    public User GetById(int id);
    public User GetByEmail(string email);
    public User GetByName(string name);
    public User CreateUser(User user);
    public bool UpdateUser(int id, User user);
    public bool DeleteUser(int id);
}