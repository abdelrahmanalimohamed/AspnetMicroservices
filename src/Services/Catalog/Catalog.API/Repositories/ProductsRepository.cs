using Catalog.API.Data;
using Catalog.API.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Catalog.API.Repositories
{
    public class ProductsRepository : IProductsRepository
    {

        private readonly ICatalogContext catalogContext;

        public ProductsRepository(ICatalogContext _catalogContext)
        {
            catalogContext = _catalogContext ?? throw new ArgumentNullException(nameof(_catalogContext));
        }
        public async Task CreateProduct(Products product)
        {
             await catalogContext.Products.InsertOneAsync(product);
        }

        public async Task<bool> DeleteProduct(string id)
        {
            FilterDefinition<Products> filter = Builders<Products>.Filter.Eq(p => p.Id, id);

            DeleteResult deleteResult = await catalogContext.Products.DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;


        }

        public async Task<Products> GetProduct(string id)
        {

            return await catalogContext.Products.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Products>> GetProductByCategory(string categoryName)
        {
            FilterDefinition<Products> filter = Builders<Products>.Filter.Eq(p => p.Category, categoryName);

            return await catalogContext.Products.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Products>> GetProductByName(string name)
        {
            FilterDefinition<Products> filter = Builders<Products>.Filter.Eq(p => p.Name, name);

            return await catalogContext.Products.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Products>> GetProducts()
        {
            return await catalogContext.Products.Find(p => true).ToListAsync();
        }

        public async Task<bool> UpdateProduct(Products product)
        {
            var UpdateResults = await catalogContext.Products.ReplaceOneAsync(filter: x => x.Id == product.Id, replacement: product);

            return UpdateResults.IsAcknowledged && UpdateResults.ModifiedCount > 0;
        }
    }
}
