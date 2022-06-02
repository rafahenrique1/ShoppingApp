namespace ShoppingApp.Endpoints.Categories;

public record CategoryRequest
{
    public string Name { get; set; }
    public bool Active { get; set; }
}
