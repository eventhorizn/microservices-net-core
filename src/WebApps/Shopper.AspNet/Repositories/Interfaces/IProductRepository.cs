using Shopper.AspNet.Entities;

namespace Shopper.AspNet.Repositories.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetProducts();
    Task<Product> GetProductById(int id);
    Task<IEnumerable<Product>> GetProductByName(string name);
    Task<IEnumerable<Product>> GetProductByCategory(int categoryId);
    Task<IEnumerable<Category>> GetCategories();
}