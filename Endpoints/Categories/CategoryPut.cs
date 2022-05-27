using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Infra.Data;

namespace ShoppingApp.Endpoints.Categories;

public class CategoryPut
{
    public static string Template => "/categories/{id:guid}";
    public static string[] Methods => new string[] { HttpMethod.Put.ToString() };
    public static Delegate Handler => Action;

    public static IResult Action([FromRoute] Guid id, CategoryRequest categoryRequest, ApplicationDbContext context)
    {
        var category = context.Categories.Where(c => c.Id == id).FirstOrDefault();

        if (category == null)
        {
            return Results.NotFound();
        }
            
        category.Name = categoryRequest.Name;
        category.Active = categoryRequest.Active;

        context.SaveChanges();
        return Results.Ok();
    }
}
