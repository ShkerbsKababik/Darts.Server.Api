using Darts.Server.Application.DTO;
using Darts.Server.Domain.Enatities.UserAgregate;
using Darts.Server.Domain.Interfaces;

namespace Darts.Server.Application.Services;

public interface IRoleService
{
    void CreateRole(RoleCreationDTO roleCreationDTO);
    List<RoleDTO> GetAllRoles();
}

public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;

    public RoleService(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public void CreateRole(RoleCreationDTO roleCreationDTO)
    {
        var role = new Role(roleCreationDTO.Code, roleCreationDTO.Name);
        _roleRepository.CreateRole(role);
    }

    public List<RoleDTO> GetAllRoles()
    {
        var roles = _roleRepository.GetAllRoles()
            .Select(r => new RoleDTO() 
            { 
                Code = r.Code, 
                Name = r.Name 
            }).ToList();

        return roles;
    }
}
