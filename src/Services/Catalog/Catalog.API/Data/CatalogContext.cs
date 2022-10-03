using Catalog.API.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContext
    {
        public CatalogContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Products = database.GetCollection<Products>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
          ///  CatalogContextSeed.SeedData(Products);
        }

        public IMongoCollection<Products> Products { get; }
    }
}
