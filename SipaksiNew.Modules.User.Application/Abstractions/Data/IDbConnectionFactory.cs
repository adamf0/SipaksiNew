using System.Data.Common;

namespace SipaksiNew.Modules.User.Application.Abstractions.Data
{
    public interface IDbConnectionFactory
    {
        ValueTask<DbConnection> OpenConnectionAsync();
    }
}
