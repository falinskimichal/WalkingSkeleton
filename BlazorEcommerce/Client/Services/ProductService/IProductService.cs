﻿namespace BlazorEcommerce.Client.Services.ProductService
{
    public interface IProductService
    {
        event Action ProductChanged;

        List<Product> Products { get; set; }
        string Message { get; set; }

        Task GetProducts(string? categoryUrl = null);

        Task<ServiceResponse<Product>> GetProduct(int productIt);

        Task SearchProduct(string text);
        Task<List<String>> GetProductSearchSugestions(string text);
    }
}
