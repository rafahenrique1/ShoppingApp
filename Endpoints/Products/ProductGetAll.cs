﻿namespace ShoppingApp.Endpoints.Products;

public class ProductGetAll
{
    public static string Template => "/products";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    [Authorize(Policy = "EmployeePolicy")]
    public static IResult Action(ApplicationDbContext context)
    {
        var products = context.Products.AsNoTracking()
            .Include(p => p.Category)
            .OrderBy(p => p.Name).ToList();

        var results = products.Select(p => new ProductResponse(p.Id, p.Name, p.Category.Name, p.Description, p.Price, p.HasStock, p.Active));

        return Results.Ok(results);
    }
}
