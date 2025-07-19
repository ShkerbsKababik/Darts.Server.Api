namespace Darts.Server.Domain.Enatities;

public class BaseEntity
{
    public Guid Id { get; set; }
    public TimeSpan CreationTime { get; set; }
    public TimeSpan Updatetime { get; set; }

    public BaseEntity()
    {
        Id = Guid.NewGuid();
        CreationTime = DateTime.Now.TimeOfDay;
        Updatetime = DateTime.Now.TimeOfDay;
    }
}
