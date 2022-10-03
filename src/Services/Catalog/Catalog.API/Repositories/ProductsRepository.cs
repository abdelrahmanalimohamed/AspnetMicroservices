using Catalog.API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.API.Repositories
{
    public class ProductsRepository : IProductsRepository
    {


        public Task CreateProduct(Products product)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteProduct(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Products> GetProduct(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Products>> GetProductByCategory(string categoryName)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Products>> GetProductByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Products>> GetProducts()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateProduct(Products product)
        {
            throw new System.NotImplementedException();
        }
    }
}
