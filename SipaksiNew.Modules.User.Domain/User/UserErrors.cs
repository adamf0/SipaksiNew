using SipaksiNew.Common.Domain;

namespace SipaksiNew.Modules.User.Domain.User
{
    public static class UserErrors
    {
        public static Error NotFound(Guid Id) =>
            Error.NotFound("User.NotFound", $"The event with the identifier {Id} was not found");

        public static readonly Error UsernameNotEmpty = Error.Problem(
            "User.Username",
            "The user username is optional");
    }
}
