using NLayer.Core.DTOs;
using NLayer.Core.Models;
using RealEstate.Core.Services;

namespace NLayer.Core.Services
{
    public interface IDetailsOfProductsService : IService<DetailsOfProduct>
    {
        Task<CustomResponseDto<List<ProductWithDetailsDTO>>> GetDetailsByProductId();
    }
}
