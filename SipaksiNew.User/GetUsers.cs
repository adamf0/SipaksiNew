using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using SipaksiNew.User.Entities;

namespace SipaksiNew.User
{
    internal class GetUsers
    {
        public static void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("api/users", async (UserContext context) =>
            {
                var List = await context.Users.Select(
                     s => new UserDTO
                     {
                         Id = s.Id,
                         FirstName = s.FirstName,
                         LastName = s.LastName,
                         Username = s.Username,
                         Password = s.Password,
                         EnrollmentDate = s.EnrollmentDate
                     }
                 ).ToListAsync();

                    if (List.Count < 0)
                    {
                        return Results.NotFound();
                    }
                    else
                    {
                        return Results.Ok(List);
                    }
            });
        }
    }
}
