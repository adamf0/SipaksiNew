using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using SipaksiNew.Modules.User.Application.CreateUser;

namespace SipaksiNew.Modules.User.Persentation.User
{
    internal static class CreateUser
    {
        public static void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("user", async (Request request, ISender sender) =>
            {
                var command = new CreateUserCommand(
                    request.FirstName,
                    request.LastName,
                    request.Username,
                    request.Password,
                    request.EnrollmentDate);

                Guid eventId = await sender.Send(command);

                return Results.Ok(eventId);
            });
        }

        internal sealed class Request
        {
            public string FirstName { get;  set; } = null!;

            public string LastName { get;  set; } = null!;

            public string Username { get;  set; } = null!;

            public string Password { get;  set; } = null!;

            public DateTime EnrollmentDate { get;  set; }
        }
    }

}
