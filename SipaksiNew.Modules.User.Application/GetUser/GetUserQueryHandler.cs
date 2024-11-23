using Dapper;
using MediatR;
using SipaksiNew.Modules.User.Application.Abstractions.Data;
using SipaksiNew.Modules.User.Domain.User;
using System.Data.Common;

namespace SipaksiNew.Modules.User.Application.GetUser
{
    internal sealed class GetUserQueryHandler(IDbConnectionFactory dbConnectionFactory)
    : IRequestHandler<GetUserQuery, UserResponse?>
    {
        public async Task<UserResponse?> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            await using DbConnection connection = await dbConnectionFactory.OpenConnectionAsync();

            const string sql =
                $"""
             SELECT
                 id AS {nameof(UserResponse.Id)},
                 FirstName AS {nameof(UserResponse.FirstName)},
                 LastName AS {nameof(UserResponse.LastName)},
                 Username AS {nameof(UserResponse.Username)},
                 Password AS {nameof(UserResponse.Password)},
                 EnrollmentDate AS {nameof(UserResponse.EnrollmentDate)}
             FROM user
             WHERE id = @Id
             """;

            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

            return await connection.QuerySingleOrDefaultAsync<UserResponse>(sql, new { Id = request.UserId });
        }
    }
}
