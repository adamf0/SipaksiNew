using Microsoft.AspNetCore.Routing;

namespace SipaksiNew.Modules.User.Persentation.User
{
    public static class UserEndpoints
    {
        public static void MapEndpoints(IEndpointRouteBuilder app)
        {
            CreateUser.MapEndpoint(app);
            GetUser.MapEndpoint(app);
        }
    }
}
