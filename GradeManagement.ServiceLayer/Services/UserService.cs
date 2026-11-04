namespace GradeManagement.ServiceLayer;

using System.Reflection.Metadata;
using GradeManagement.Domain;

public class UserService : IUserService
{
    private readonly IUserRepository _UserRepository;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userRepository"></param>
    public UserService(IUserRepository userRepository)
    {
        _UserRepository = userRepository;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public List <UserDto> GetAll()
    {
       List<User> users = _UserRepository.GetAll();
       return users.Select(u => new UserDto
       {
           Id = u.Id,
           Email = u.Email,
           FirstName = u.FirstName,
           LastName = u.LastName

       }).ToList();
    }
    /// <summary>
    ///     
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public UserDto? GetById(int id)
    {
        User user = _UserRepository.GetById(id);
        if (user == null)
        {
            throw new Exception($"User with id {id} not found");  
    }
    return new UserDto
    {
           Id = user.Id,
           Email = user.Email,
           FirstName = user.FirstName,
           LastName = user.LastName
    };
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    public UserDto? GetByEmail(string email)
    {
        User user = _UserRepository.GetByEmail(email);
        if (user == null)
        {
            throw new Exception($"User with email {email} not found");  
    }
    return new UserDto
    {
           Id = user.Id,
           Email = user.Email,
           FirstName = user.FirstName,
           LastName = user.LastName
    };
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public UserDto? GetByName(string name)
    {
        User user = _UserRepository.GetByName(name);
        if (user == null)
        {
            throw new Exception($"User with name {name} not found");  
    }
    return new UserDto
    {
           Id = user.Id,
           Email = user.Email,
           FirstName = user.FirstName,
           LastName = user.LastName
    };
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="createUserDto"></param>
    /// <returns></returns>
    public UserDto CreateUser(CreateUserDto createUserDto)
    {
        User newUserEntity = new User
        {
            Email = createUserDto.Email,
            FirstName = createUserDto.FirstName,
            LastName = createUserDto.LastName
        };
        User createdUser = _UserRepository.CreateUser(newUserEntity);
  
        return new UserDto
        {   
            Id = createdUser.Id,
            Email = createdUser.Email,
            FirstName = createdUser.FirstName,
            LastName = createdUser.LastName
        };  
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="updateUserDto"></param>
    /// <returns></returns>
    public bool UpdateUser(int id, UpdateUserDto updateUserDto)
    {
        User userEntity = new User
        {
            Id = id,
            Email = updateUserDto.Email,
            FirstName = updateUserDto.FirstName,
            LastName = updateUserDto.LastName
        };

        return _UserRepository.UpdateUser(id, userEntity);        
        
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public bool DeleteUser(int id)
    {
        return _UserRepository.DeleteUser(id);
    }
}

