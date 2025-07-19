namespace Darts.Server.Application.DTO;

public class RoleDTO
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
}

public class RoleCreationDTO
{
    public string Code { get; set; }
    public string Name { get; set; }
}
