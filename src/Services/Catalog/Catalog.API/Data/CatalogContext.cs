using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSetting:ConnectionSettings"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSetting:DatabaseName"));
            Products = database.GetCollection<Product>
                (configuration.GetValue<string>("DatabaseSetting:CollectionName"));

            CatalogContextSeed.SeedData(Products); 
        }
        public IMongoCollection<Product> Products { get; }
    }
}
