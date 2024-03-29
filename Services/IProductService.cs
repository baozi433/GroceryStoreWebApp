﻿using MyFirstWeb.Models;

namespace MyFirstWeb.Services
{
    public interface IProductService
    {
        List<ProductModel> GetAllProducts();
        List<ProductModel> SearchProducts(string searchTerm);
        ProductModel GetProductById(int id);
        int Insert(ProductModel product);
        int Update(ProductModel product);
        int Delete(ProductModel product);
    }
}
