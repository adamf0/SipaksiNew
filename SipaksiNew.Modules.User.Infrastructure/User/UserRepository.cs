using SipaksiNew.Modules.User.Domain.User;
using SipaksiNew.Modules.User.Infrastructure.Database;

namespace SipaksiNew.Modules.User.Infrastructure.User
{
    internal sealed class UserRepository(UsersDbContext context) : IUserRepository
    {
        public void Insert(Domain.User.User user)
        {
            context.Users.Add(user);
        }
    }
}
