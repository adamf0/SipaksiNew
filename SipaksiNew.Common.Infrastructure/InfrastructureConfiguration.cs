using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SipaksiNew.Common.Application.Clock;
using SipaksiNew.Common.Application.Data;
using SipaksiNew.Common.Infrastructure.Clock;
using SipaksiNew.Common.Infrastructure.Data;

namespace SipaksiNew.Common.Infrastructure
{
    public static class InfrastructureConfiguration
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            string databaseConnectionString)
        {
            services.AddScoped<IDbConnectionFactory>(_ => new DbConnectionFactory(databaseConnectionString));

            services.TryAddSingleton<IDateTimeProvider, DateTimeProvider>();

            return services;
        }
    }
}
