using SipaksiNew.Common.Application.Messaging;
using SipaksiNew.Common.Domain;
using SipaksiNew.Modules.User.Application.Abstractions.Data;
using SipaksiNew.Modules.User.Domain.User;

namespace SipaksiNew.Modules.User.Application.CreateUser
{
    internal sealed class CreateUserCommandHandler(
    IUserRepository userRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<CreateUserCommand, Guid>
    {
        public async Task<Result<Guid>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            Result<Domain.User.User> result = Domain.User.User.Create(
                request.FirstName,
                request.LastName,
                request.Username,
                request.Password,
                request.EnrollmentDate
            );

            if (result.IsFailure)
            {
                return Result.Failure<Guid>(result.Error);
            }

            userRepository.Insert(result.Value);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return result.Value.Id;
        }
    }

}
