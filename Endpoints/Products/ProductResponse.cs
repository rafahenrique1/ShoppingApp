namespace ShoppingApp.Endpoints.Products;

public record ProductResponse(Guid Id, string Name, string CategoryName, string Description, decimal price, bool HasStock, bool Active);
