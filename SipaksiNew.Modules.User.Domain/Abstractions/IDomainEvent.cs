namespace SipaksiNew.Modules.User.Domain.Abstractions
{
    public interface IDomainEvent
    {
        Guid Id { get; }

        DateTime OccurredOnUtc { get; }
    }

}
