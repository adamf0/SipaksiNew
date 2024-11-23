//using SipaksiNew.Modules.User.Domain.Abstractions;
using SipaksiNew.Common.Domain;

namespace SipaksiNew.Modules.User.Domain.User
{
    public sealed class UserCreatedDomainEvent(Guid eventId) : DomainEvent
    {
        public Guid EventId { get; init; } = eventId;
    }

}
