using NLayer.Core.Models;
using RealEstate.Core.Repositories;

namespace NLayer.Core.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<List<Product>> GetProductsByCategory();
    }
}
