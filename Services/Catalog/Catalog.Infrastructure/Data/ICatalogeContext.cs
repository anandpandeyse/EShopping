using Catalog.Core.Entities;
using MongoDB.Driver;


namespace Catalog.Infrastructure.Data
{
    public interface ICatalogeContext
    {
        IMongoCollection<Product> Products { get; }
        IMongoCollection<ProductBrand> Brands { get; }
        IMongoCollection<ProductType> Types { get; }
    }
}
