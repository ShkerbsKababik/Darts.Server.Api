using Darts.Server.Domain.Enatities;

namespace Darts.Server.Domain.Interfaces;

public interface IUserRepository
{
    public User GetUserById(Guid id);
    public List<User> GetAllUsers();

    public void CreateUser(User user);
    public void UpdateUser(User user);
    public void DeleteUser(User user);
}
