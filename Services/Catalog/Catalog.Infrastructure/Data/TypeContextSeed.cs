using Catalog.Core.Entities;
using MongoDB.Driver;
using System.Text.Json;


namespace Catalog.Infrastructure.Data
{
    public static class TypeContextSeed
    {
        public static void SeedData(IMongoCollection<ProductType> typecollection)
        {
            bool checkTypes = typecollection.Find(b => true).Any();
            string path = Path.Combine("Data", "SeedData", "types.json");
            if (!checkTypes)
            {
                var typesData = File.ReadAllText(path);
                var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                if (types != null)
                {
                    foreach (var type in types)
                    {
                        typecollection.InsertOneAsync(type);
                    }
                }
            }
        }
    }
}
