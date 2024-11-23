using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using SipaksiNew.Common.Domain;
using SipaksiNew.Modules.User.Application.GetUser;
using SipaksiNew.Modules.User.Persentation.ApiResults;

namespace SipaksiNew.Modules.User.Persentation.User
{
    internal static class GetUser
    {
        public static void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("user/{id}", async (Guid id, ISender sender) =>
            {
                Result<UserResponse> result = await sender.Send(new GetUserQuery(id));

                return result.Match(Results.Ok, ApiResults.ApiResults.Problem);
            });
        }
    }

}
