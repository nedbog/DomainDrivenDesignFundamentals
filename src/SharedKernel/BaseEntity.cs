namespace SharedKernel;

public class BaseEntity<TId>
{
    public TId Id { get; set; }
    public List<BaseDomainEvent> Event = new();
}