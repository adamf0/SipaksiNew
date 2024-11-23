using MediatR;
using SipaksiNew.Common.Domain;

namespace SipaksiNew.Common.Application.Messaging
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>;
}
