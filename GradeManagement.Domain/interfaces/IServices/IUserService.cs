namespace GradeManagement.Domain; 

public interface IUserService
{
    public List <UserDto> GetAll();
    public UserDto GetById(int id);
    public UserDto GetByEmail(string email);
    public UserDto GetByName(string name);
    public UserDto CreateUser(CreateUserDto createUserDto);
    public bool UpdateUser(int id, UpdateUserDto updateUserDto);
    public bool DeleteUser(int id);
}