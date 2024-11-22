using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SipaksiNew.User.Entities;

namespace SipaksiNew.User
{
    public static class UserModule
    {
        public static void MapEndpoints(IEndpointRouteBuilder app)
        {
            CreateUser.MapEndpoint(app);
            GetUsers.MapEndpoint(app);
        }

        public static IServiceCollection AddUserModule(this IServiceCollection services, IConfiguration configuration)
        {
            string? databaseConnectionString = configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrEmpty(databaseConnectionString))
            {
                throw new InvalidOperationException("Database connection string 'DefaultConnection' is missing or empty.");
            }

            services.AddDbContext<UserContext>(options =>
                options.UseMySQL(databaseConnectionString));

            return services;
        }
    }
}
