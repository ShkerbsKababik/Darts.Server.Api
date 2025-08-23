using Darts.Server.Domain.Enatities.UserAgregate;

namespace Darts.Server.Domain.Interfaces;

public interface IUserRepository
{
    // Queries
    public User GetUserById(Guid id);
    public User GetUserByLogin(string login);
    public User GetUserWithRolesByLogin(string login);
    public List<User> GetUsersByIds(List<Guid> ids);
    public List<User> GetUsersByLogins(List<string> logins);
    public List<User> GetAllUsers();

    // Commands
    public void CreateUser(User user);
    public void UpdateUser(User user);
    public void DeleteUser(User user);
}
