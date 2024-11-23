using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using SipaksiNew.Modules.User.Api.Entities;
using System.Net;

namespace SipaksiNew.Modules.User.Api
{
    internal class CreateUser
    {
        public static void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("api/user/create", async (UserDTO request, UserContext context) =>
            {
                var entity = new Entities.User()
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Username = request.Username,
                    Password = request.Password,
                    EnrollmentDate = request.EnrollmentDate
                };

                context.Add(entity);
                await context.SaveChangesAsync();

                return HttpStatusCode.Created;
            });
        }
    }
}
