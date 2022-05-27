using ShoppingApp.Domain.Products;
using ShoppingApp.Infra.Data;

namespace ShoppingApp.Endpoints.Categories;

public class CategoryPost
{
    public static string Template => "/categories";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handler => Action;

    public static IResult Action(CategoryRequest categoryRequest, ApplicationDbContext context)
    {        
        var category = new Category(categoryRequest.Name)
        {
            CreatedBy = "Test",
            CreatedOn = DateTime.Now,
            EditedBy = "Test",
            EditedOn = DateTime.Now,
        };

        if (!category.IsValid)
        {
            return Results.BadRequest(category.Notifications);
        }

        context.Categories.Add(category);
        context.SaveChanges();

        return Results.Created($"/categories/{category.Id}", category.Id);
    }
}
