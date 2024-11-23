using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using SipaksiNew.Modules.User.Application.GetUser;

namespace SipaksiNew.Modules.User.Persentation.User
{
    internal static class GetUser
    {
        public static void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("events/{id}", async (Guid id, ISender sender) =>
            {
                UserResponse @event = await sender.Send(new GetUserQuery(id));

                return @event is null ? Results.NotFound() : Results.Ok(@event);
            });
        }
    }

}
