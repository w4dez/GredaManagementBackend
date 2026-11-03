namespace GradeManagement.Domain; 

public interface IUserRepository
{
    public List <User> GetAll();
    public User GetById(int id);
    public User GetByEmail(string email);
    public List<User> GetByName(string name);
    public User CreateUser(CreateUserDto user);
    public bool UpdateUser(int id, UpdateUserDto user);
    public bool DeleteUser(int id);
}