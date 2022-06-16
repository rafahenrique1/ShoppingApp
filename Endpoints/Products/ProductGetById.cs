﻿namespace ShoppingApp.Endpoints.Products;

public class ProductGetById
{
    public static string Template => "/products/{id}";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    [Authorize(Policy = "EmployeePolicy")]
    public static IResult Action(ApplicationDbContext context)
    {
        var products = context.Products.AsNoTracking()
            .Include(p => p.Category)
            .OrderBy(p => p.Name).ToList();

        var results = products.Select(p => new ProductResponse(p.Name, p.Category.Name, p.Description, p.Price, p.HasStock, p.Active));

        return Results.Ok(results);
    }
}
