using Dapper;
using SipaksiNew.Common.Application.Data;
using SipaksiNew.Common.Application.Messaging;
using SipaksiNew.Common.Domain;
using SipaksiNew.Modules.User.Domain.User;
using System.Data.Common;

namespace SipaksiNew.Modules.User.Application.GetUser
{
    internal sealed class GetUserQueryHandler(IDbConnectionFactory dbConnectionFactory)
    : IQueryHandler<GetUserQuery, UserResponse>
    {
        public async Task<Result<UserResponse>> Handle(GetUserQuery request, CancellationToken cancellationToken)
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

            DefaultTypeMap.MatchNamesWithUnderscores = true;

            var result = await connection.QuerySingleOrDefaultAsync<UserResponse?>(sql, new { Id = request.UserId });
            if (result==null) {
                return Result.Failure<UserResponse>(UserErrors.NotFound(request.UserId));
            }

            return result;
        }
    }
}
