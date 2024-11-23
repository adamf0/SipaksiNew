using MediatR;
using SipaksiNew.Common.Domain;

namespace SipaksiNew.Common.Application.Messaging
{
    public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>;

}
