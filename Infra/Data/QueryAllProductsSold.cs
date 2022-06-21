namespace ShoppingApp.Infra.Data;

public class QueryAllProductsSold
{ 
    private readonly IConfiguration configuration;

    public QueryAllProductsSold(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public async Task<IEnumerable<ProductsSoldReportResponse>> Execute()
    {
        var database = new SqlConnection(configuration["ConnectionString:ShoppingAppDb"]);
        var query =
            @"SELECT 
                p.Id,
                p.Name,
                count(*) Amount 
            FROM
                Orders o INNER JOIN OrderProducts op on o.Id = op.OrdersId
                INNER JOIN Products p on p.Id = op.ProductsId
            GROUP BY
                p.Id, p.Name
                order by Amount DESC";

        return await database.QueryAsync<ProductsSoldReportResponse>(query);
    }
}

