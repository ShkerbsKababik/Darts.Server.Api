using Darts.Server.Domain.Enatities.UserAgregate;

namespace Darts.Server.Domain.Interfaces;

public interface IUserRepository
{
    public User GetUserById(Guid id);
    public List<User> GetUsersByIds(List<Guid> ids);
    public List<User> GetAllUsers();

    public void CreateUser(User user);
    public void UpdateUser(User user);
    public void DeleteUser(User user);
}
