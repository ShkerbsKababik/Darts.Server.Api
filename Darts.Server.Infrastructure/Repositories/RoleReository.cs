using Darts.Server.Domain.Enatities;
using Darts.Server.Domain.Interfaces;
using Darts.Server.Infrastructure.Data;

namespace Darts.Server.Infrastructure.Repositories;

public class RoleReository : IRoleRepository
{
    private readonly DartsDbContext _dartsDbContext;

    public RoleReository(DartsDbContext dartsDbContext)
    {
        _dartsDbContext = dartsDbContext;
    }

    public void CreateRole(Role role)
    {
        _dartsDbContext.Roles.Add(role);
        _dartsDbContext.SaveChanges();
    }

    public void DeleteRole(Role role)
    {
        _dartsDbContext.Roles.Remove(role);
        _dartsDbContext.SaveChanges();
    }

    public List<Role> GetAllRoles()
    {
        var roles = _dartsDbContext.Roles.ToList();
        return roles;
    }

    public Role GetRoleById(Guid id)
    {
        return _dartsDbContext.Roles
            .FirstOrDefault(r => r.Id == id);
    }

    public void UpdateRole(Role role)
    {
        _dartsDbContext.Roles .Update(role);
        _dartsDbContext.SaveChanges();
    }
}
