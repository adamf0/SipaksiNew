using SipaksiNew.Common.Application.Messaging;

namespace SipaksiNew.Modules.User.Application.CreateUser
{
    public sealed record CreateUserCommand(
    string FirstName,
    string LastName,
    string Username,
    string Password,
    DateTime EnrollmentDate) : ICommand<Guid>;

}
