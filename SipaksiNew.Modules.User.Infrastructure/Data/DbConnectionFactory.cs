using System.Data.Common;
using MySql.Data.MySqlClient;
using SipaksiNew.Modules.User.Application.Abstractions.Data;

namespace SipaksiNew.Modules.User.Infrastructure.Data
{
    internal sealed class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly string _connectionString;

        public DbConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async ValueTask<DbConnection> OpenConnectionAsync()
        {
            var connection = new MySqlConnection(_connectionString);
            await connection.OpenAsync();
            return connection;
        }
    }

}
