
namespace SipaksiNew.Modules.User.Application.GetUser
{
    public sealed record UserResponse(
       Guid Id,
       string FirstName,
       string LastName,
       string Username,
       string Password,
       DateTime EnrollmentDate);

}
