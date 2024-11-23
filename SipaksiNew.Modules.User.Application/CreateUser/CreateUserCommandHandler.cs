using MediatR;
using SipaksiNew.Modules.User.Application.Abstractions.Data;
using SipaksiNew.Modules.User.Domain.User;

namespace SipaksiNew.Modules.User.Application.CreateUser
{
    internal sealed class CreateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<CreateUserCommand, Guid>
    {
        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var @user = Domain.User.User.Create(
                request.FirstName,
                request.LastName,
                request.Username,
                request.Password,
                request.EnrollmentDate
            );

            userRepository.Insert(@user);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return @user.Id;
        }
    }
}
