namespace Darts.Server.Domain.Enatities;

public class Role : BaseEntity
{
    public string Code { get; set; }
    public string Name { get; set; }

    public Role(string code, string name)
    {
        Code = code;
        Name = name;
    }
}
