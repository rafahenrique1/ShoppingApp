using Dapper;
using Microsoft.Data.SqlClient;
using ShoppingApp.Endpoints.Employees;

namespace ShoppingApp.Infra.Data;

public class QueryAllUsersWithClaimName
{
    private readonly IConfiguration configuration;

    public QueryAllUsersWithClaimName(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public IEnumerable<EmployeeResponse> Execute(int page, int rows)
    {
        var database = new SqlConnection(configuration["ConnectionString:ShoppingAppDb"]);
        var query =
            @"select Email, ClaimValue as Name
            from AspNetUsers u inner 
            join AspNetUserClaims c
            on u.id = c.UserId and claimtype = 'Name'
            order by name
            OFFSET (@page -1 ) * @rows ROWS FETCH NEXT @rows ROWS ONLY";

        return database.Query<EmployeeResponse>(query, new { page, rows });
    }
}
