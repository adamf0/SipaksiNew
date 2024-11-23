using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using SipaksiNew.Common.Domain;
using SipaksiNew.Modules.User.Application.CreateUser;
using SipaksiNew.Modules.User.Persentation.ApiResults;

namespace SipaksiNew.Modules.User.Persentation.User
{
    internal static class CreateUser
    {
        public static void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("user", async (Request request, ISender sender) =>
            {
                Result<Guid> result = await sender.Send(new CreateUserCommand(
                    request.FirstName,
                    request.LastName,
                    request.Username,
                    request.Password,
                    request.EnrollmentDate)
                );

                return result.Match(Results.Ok, ApiResults.ApiResults.Problem);
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
