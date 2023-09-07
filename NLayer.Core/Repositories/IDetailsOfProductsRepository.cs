using NLayer.Core.Models;
using RealEstate.Core.Repositories;

namespace NLayer.Core.Repositories
{
    public interface IDetailsOfProductsRepository : IGenericRepository<DetailsOfProduct>
    {
        Task <List<DetailsOfProduct>> GetDetailsByProductId();


    }
}
