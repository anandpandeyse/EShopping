
namespace Catalog.Core.Repositories
{
    public interface ITypesRepository
    {
        Task<IEnumerable<Entities.ProductType>> GetAllTypes();
    }
}
