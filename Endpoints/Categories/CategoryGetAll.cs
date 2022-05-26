using ShoppingApp.Domain.Products;
using ShoppingApp.Infra.Data;

namespace ShoppingApp.Endpoints.Categories;

public class CategoryGetAll
{
    public static string Template => "/categories";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handler => Action;

    public static IResult Action(ApplicationDbContext context)
    {
        var categories = context.Categories.ToList();
        var response = categories.Select(p => new CategoryResponse { Id = p.Id, Name = p.Name, Active = p.Active });

        return Results.Ok(response);
    }
}
