﻿namespace ShoppingApp.Endpoints.Orders;

public record OrderRequest (List<Guid> ProductsIds, string DeliveryAddress);

