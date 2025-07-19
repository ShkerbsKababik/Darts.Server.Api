using Darts.Server.Domain.Enatities;

namespace Darts.Server.Domain.Interfaces;

public interface IRoleRepository
{
    public User GetRoleById(Guid id);
    public void CreateRole(User user);
    public void UpdateRole(User user);
    public void DeleteRole(User user);
}
