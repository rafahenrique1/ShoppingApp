namespace ShoppingApp.Endpoints.Products;

public class ProductGetSold
{
    public static string Template => "/products/report";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    [Authorize(Policy = "EmployeePolicy")]
    public static async Task<IResult> Action(QueryAllProductsSold query)
    {
        var result = await query.Execute();

        return Results.Ok(result);
    }
}
