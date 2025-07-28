using Darts.Server.Application.DTO;
using Darts.Server.Domain.Enatities;
using Darts.Server.Domain.Interfaces;

namespace Darts.Server.Application.Services;

public interface IUserService
{
    UserDTO GetUserById(Guid id);

    void CreateUser(UserCreationDTO userCreationDTO);
    void ChangeUserPassword(ChangeUserPasswordDTO changeUserPasswordDTO);
    void AddRolesToUser(AddRolesToUserDTO addRolesToUserDTO);
    void RemoveRolesToUser(RemoveRolesFromUserDTO removeRolesFromUserDTO);
}

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;

    public UserService(
        IUserRepository userRepository, 
        IRoleRepository roleRepository)
    {
        _userRepository = userRepository;
        _roleRepository = roleRepository;
    }

    public UserDTO GetUserById(Guid id)
    {
        var user = _userRepository.GetUserById(id);
        if (user is null)
        {
            // throw exception
        }

        var userDTO = new UserDTO()
        {
            Login = user.Login
        };

        return userDTO;
    }

    public void AddRolesToUser(AddRolesToUserDTO addRolesToUserDTO)
    {
        var user = _userRepository.GetUserById(addRolesToUserDTO.UserId);
        if (user is null)
        {
            // throw exception
        }

        var roles = _roleRepository.GetAllRoles()
            .Where(role => addRolesToUserDTO.RolesIds.Contains(role.Id))
            .ToList();
        if (roles.Count != addRolesToUserDTO.RolesIds.Count)
        { 
            // throw exception
        }

        user.AddRoles(roles);
        _userRepository.UpdateUser(user);
    }

    public void ChangeUserPassword(ChangeUserPasswordDTO changeUserPasswordDTO)

    {
        var user = _userRepository.GetUserById(changeUserPasswordDTO.UserId);
        if (user is null)
        { 
            // throw exception
        }

        user.ChangePassword(changeUserPasswordDTO.Password);
        _userRepository.UpdateUser(user);
    }

    public void CreateUser(UserCreationDTO userCreationDTO)
    {
        var user = new User(userCreationDTO.Login, userCreationDTO.Password);
        _userRepository.CreateUser(user);
    }

    public void RemoveRolesToUser(RemoveRolesFromUserDTO removeRolesFromUserDTO)
    {
        var user = _userRepository.GetUserById(removeRolesFromUserDTO.UserId);
        if (user is null)
        {
            // throw exception
        }

        var roles = _roleRepository.GetAllRoles()
            .Where(role => removeRolesFromUserDTO.RolesIds.Contains(role.Id))
            .ToList();
        if (roles.Count != removeRolesFromUserDTO.RolesIds.Count)
        {
            // throw exception
        }

        user.AddRoles(roles);
        _userRepository.UpdateUser(user);
    }
}
