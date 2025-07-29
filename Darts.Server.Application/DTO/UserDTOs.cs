using Darts.Server.Domain.Enatities.UserAgregate;

namespace Darts.Server.Application.DTO;

public class UserDTO
{ 
    public Guid Id { get; set; }
    public string Login { get; set; }

    public static UserDTO FromDomain(User user)
    {
        return new UserDTO()
        { 
            Id = user.Id,
            Login = user.Login
        };
    }
}

public class UserCreationDTO
{
    public string Login { get; set; }
    public string Password { get; set; }
}

public class ChangeUserPasswordDTO
{
    public Guid UserId { get; set; }
    public string Password { get; set; }
}

public class AddRolesToUserDTO
{ 
    public Guid UserId { get; set; }
    public List<Guid> RolesIds { get; set; }
}

public class RemoveRolesFromUserDTO
{
    public Guid UserId { get; set; }
    public List<Guid> RolesIds { get; set; }
}