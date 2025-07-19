using Darts.Server.Application.DTO;
using Darts.Server.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Darts.Server.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        public UserController(
            IUserService userService, 
            IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        [HttpGet("/user/{id}")]
        public UserDTO GetUser(Guid id)
        {
            return _userService.GetUserById(id);
        }

        [HttpPost("/user/add")]
        public void CreateUser(UserCreationDTO userCreationDTO)
        {
            _userService.CreateUser(userCreationDTO);
        }

        [HttpPut("/user/password")]
        public void ChangeUserPassword(ChangeUserPasswordDTO changeUserPasswordDTO)
        {
            _userService.ChangeUserPassword(changeUserPasswordDTO);
        }

        [HttpPut("/user/roles")]
        public void ChangeUserPassword(AddRolesToUserDTO addRolesToUserDTO)
        {
            _userService.AddRolesToUser(addRolesToUserDTO);
        }

        [HttpDelete("/user/roles")]
        public void ChangeUserPassword(RemoveRolesFromUserDTO removeRolesFromUserDTO)
        {
            _userService.RemoveRolesToUser(removeRolesFromUserDTO);
        }

        [HttpPost("/role/add")]
        public void CreateRole(RoleCreationDTO roleCreationDTO)
        {
            _roleService.CreateRole(roleCreationDTO);
        }
    }
}
