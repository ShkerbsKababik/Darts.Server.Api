namespace Darts.Server.Application.DTO;

public class UserDTO
{ 
    public string Login { get; set; }
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

public class RemoveRolesFromUser
{
    public Guid UserId { get; set; }
    public List<Guid> RolesIds { get; set; }
}