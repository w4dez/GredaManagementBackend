namespace GradeManagement.Domain; 

public interface IUserService
{
    public List <UserDto> GetAll();
    public UserDto GetById(int id);
    public UserDto GetByEmail(string email);
    public List<UserDto> GetByName(string name);
    public UserDto CreateUser(CreateUserDto user);
    public bool UpdateUser(int id, UpdateUserDto user);
    public bool DeleteUser(int id);
}