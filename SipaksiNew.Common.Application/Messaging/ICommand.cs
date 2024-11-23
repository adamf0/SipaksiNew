using SipaksiNew.Common.Domain;
using MediatR;

namespace SipaksiNew.Common.Application.Messaging
{
    public interface ICommand : IRequest<Result>, IBaseCommand;

    public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand;

    public interface IBaseCommand;
}
