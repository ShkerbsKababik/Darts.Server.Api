using Darts.Server.Domain.Enatities;

namespace Darts.Server.Domain.Interfaces;

public interface IRoleRepository
{
    public Role GetRoleById(Guid id);
    public List<Role> GetAllRoles(); 


    public void CreateRole(Role role);
    public void UpdateRole(Role role);
    public void DeleteRole(Role role);
}
