using Catalog.Core.Entities;
using MongoDB.Driver;
using System.Text.Json;

namespace Catalog.Infrastructure.Data
{
    public static class BrandContextSeed
    {
        public static void SeedData(IMongoCollection<ProductBrand> brandcollection)
        {
            bool checkBrands = brandcollection.Find(b => true).Any();
            string path = Path.Combine("Data", "SeedData","brands.json");
            if (!checkBrands) { 
                var brandsData = File.ReadAllText(path);
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                if (brands != null)
                {
                    foreach (var brand in brands) {
                        brandcollection.InsertOneAsync(brand);                    
                    }
                }
            }
        }
    }
}
