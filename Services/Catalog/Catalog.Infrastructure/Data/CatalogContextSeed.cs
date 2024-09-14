using Catalog.Core.Entities;
using MongoDB.Driver;
using System.Text.Json;

namespace Catalog.Infrastructure.Data
{
    public class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> typecollection)
        {
            bool checkProducts = typecollection.Find(b => true).Any();
            string path = Path.Combine("Data", "SeedData", "products.json");
            if (!checkProducts)
            {
                var productssData = File.ReadAllText(path);
                var products = JsonSerializer.Deserialize<List<Product>>(productssData);
                if (products != null)
                {
                    foreach (var product in products)
                    {
                        typecollection.InsertOneAsync(product);
                    }
                }
            }
        }
    }
}
