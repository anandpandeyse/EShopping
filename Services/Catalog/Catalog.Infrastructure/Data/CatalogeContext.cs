using Catalog.Core.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;


namespace Catalog.Infrastructure.Data
{
    public class CatalogeContext : ICatalogeContext
    {

        public CatalogeContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            Brands = database.GetCollection<ProductBrand>(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            Types = database.GetCollection<ProductType>(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            Products = database.GetCollection<Product>(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            BrandContextSeed.SeedData(Brands);
            TypeContextSeed.SeedData(Types);
            CatalogContextSeed.SeedData(Products);
        }
        public IMongoCollection<Product> Products { get; }

        public IMongoCollection<ProductBrand> Brands { get; }

        public IMongoCollection<ProductType> Types { get; }
    }
}
