using Darts.Server.Domain.Enatities;
using Darts.Server.Domain.Interfaces;
using Darts.Server.Infrastructure.Data;

namespace Darts.Server.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DartsDbContext _dartsDbContext;

    public void CreateUser(User user)
    {
        _dartsDbContext.Users.Add(user);
        _dartsDbContext.SaveChanges();
    }

    public void DeleteUser(User user)
    {
        _dartsDbContext.Users.Remove(user);
        _dartsDbContext.SaveChanges();
    }

    public User GetUserById(Guid id)
    {
        var user = _dartsDbContext.Users
            .Where(u => u.Id == id)
            .First();

        return user;
    }

    public void UpdateUser(User user)
    {
        _dartsDbContext.Users.Update(user);
        _dartsDbContext.SaveChanges();
    }
}
