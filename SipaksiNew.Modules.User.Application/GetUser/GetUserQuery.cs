using MediatR;

namespace SipaksiNew.Modules.User.Application.GetUser
{
    public sealed record GetUserQuery(Guid UserId) : IRequest<UserResponse?>;
}
