using SipaksiNew.Common.Domain;
//using SipaksiNew.Modules.User.Domain.Abstractions;

namespace SipaksiNew.Modules.User.Domain.User
{
    public sealed class User : Entity
    {
        private User()
        {
        }

        public Guid Id { get; private set; }

        public string FirstName { get; private set; } = null!;

        public string LastName { get; private set; } = null!;

        public string Username { get; private set; } = null!;

        public string Password { get; private set; } = null!;

        public DateTime EnrollmentDate { get; private set; }

        public static Result<User> Create(
        string firstname,
        string lastname,
        string username,
        string password,
        DateTime enrollmentdate)
        {
            if (username.Length>0)
            {
                return Result.Failure<User>(UserErrors.UsernameNotEmpty);
            }

            var @user = new User
            {
                Id = Guid.NewGuid(),
                FirstName = firstname,
                LastName = lastname,
                Username = username,
                Password = password,
                EnrollmentDate = enrollmentdate
            };

            @user.Raise(new UserCreatedDomainEvent(@user.Id));

            return @user;
        }
    }
}
