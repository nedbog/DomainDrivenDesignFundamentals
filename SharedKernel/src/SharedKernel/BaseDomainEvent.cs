using MediatR;

namespace SharedKernel;

public class BaseDomainEvent : INotification
{
    public DateTimeOffset DateOccured { get; protected set; } = DateTimeOffset.UtcNow;
}