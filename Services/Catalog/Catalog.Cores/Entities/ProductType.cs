using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Cores.Entities
{
    public class ProductType :BaseEntity
    {
        [BsonElement("Name")]
        public string Name { get; set; }
    }
}
