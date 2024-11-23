using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SipaksiNew.Modules.User.Application.Abstractions.Data;
using SipaksiNew.Modules.User.Domain.User;
using SipaksiNew.Modules.User.Infrastructure.Data;
using SipaksiNew.Modules.User.Infrastructure.Database;
using SipaksiNew.Modules.User.Infrastructure.User;
using SipaksiNew.Modules.User.Persentation.User;

namespace SipaksiNew.Modules.User.Infrastructure
{
    public static class UserModule
    {
        public static void MapEndpoints(IEndpointRouteBuilder app)
        {
            UserEndpoints.MapEndpoints(app);
        }

        public static IServiceCollection AddUserModule(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(Application.AssemblyReference.Assembly);
            });

            //services.AddValidatorsFromAssembly(Application.AssemblyReference.Assembly, includeInternalTypes: true);

            services.AddInfrastructure(configuration);

            return services;
        }

        private static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            string databaseConnectionString = configuration.GetConnectionString("Database")!;

            //services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();
            services.AddScoped<IDbConnectionFactory>(_ => new DbConnectionFactory(databaseConnectionString));

            services.AddDbContext<UsersDbContext>(optionsBuilder => optionsBuilder.UseMySQL(databaseConnectionString));

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<UsersDbContext>());
        }
    }
}
