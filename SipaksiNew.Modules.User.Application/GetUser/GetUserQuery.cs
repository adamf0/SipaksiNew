using SipaksiNew.Common.Application.Messaging;

namespace SipaksiNew.Modules.User.Application.GetUser
{
    public sealed record GetUserQuery(Guid UserId) : IQuery<UserResponse>;
}
