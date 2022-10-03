using Catalog.API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.API.Repositories
{
    public interface IProductsRepository
    {
        Task<IEnumerable<Products>> GetProducts();
        Task<Products> GetProduct(string id);
        Task<IEnumerable<Products>> GetProductByName(string name);
        Task<IEnumerable<Products>> GetProductByCategory(string categoryName);

        Task CreateProduct(Products product);
        Task<bool> UpdateProduct(Products product);
        Task<bool> DeleteProduct(string id);
    }
}
