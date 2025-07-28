namespace Darts.Server.Domain.Enatities.UserAgregate;

public class User : BaseEntity
{
    public string Login { get; set; }
    public string Password { get; set; }
    public List<Role> Roles { get; set; }

    public User(string login, string password)
    {
        Login = login;
        Password = password;
    }

    public void ChangePassword(string newPassord)
    { 
        Password = newPassord;
    }

    public void AddRoles(List<Role> roles)
    { 
        Roles.AddRange(roles);
    }

    public void RemoveRoles(List<Role> roles)
    {
        Roles.AddRange(roles);
    }
}
