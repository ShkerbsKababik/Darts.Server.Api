using Darts.Server.Domain.Enatities.UserAgregate;
using Darts.Server.Domain.Interfaces;
using Darts.Server.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Darts.Server.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DartsDbContext _dartsDbContext;

    public UserRepository(DartsDbContext dartsDbContext)
    {
        _dartsDbContext = dartsDbContext;
    }

    public User GetUserById(Guid id)
    {
        return _dartsDbContext.Users.FirstOrDefault(u => u.Id == id)
            ?? throw new Exception($"user with id: {id} not found");
    }

    public User GetUserByLogin(string login)
    {
        return _dartsDbContext.Users.FirstOrDefault(u => u.Login == login)
            ?? throw new Exception($"user with login: {login} not found");
    }

    public User GetUserWithRolesByLogin(string login)
    {
        return _dartsDbContext.Users
            .Include(u => u.Roles)
            .FirstOrDefault(u => u.Login == login)
            ?? throw new Exception($"user with login: {login} not found");
    }

    public List<User> GetUsersByIds(List<Guid> ids)
    {
        return _dartsDbContext.Users
            .Where(u => ids.Contains(u.Id))
            .ToList();
    }

    public List<User> GetUsersByLogins(List<string> logins)
    {
        return _dartsDbContext.Users
            .Where(u => logins.Contains(u.Login))
            .ToList();
    }

    public List<User> GetAllUsers()
    {
        return _dartsDbContext.Users.ToList();
    }

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

    public void UpdateUser(User user)
    {
        _dartsDbContext.Users.Update(user);
        _dartsDbContext.SaveChanges();
    }
}
