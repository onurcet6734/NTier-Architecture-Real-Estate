using NLayer.Core.DTOs;
using NLayer.Core.Models;
using RealEstate.Core.Services;

namespace NLayer.Core.Services
{
    public interface IProductService : IService<Product> 
    {
        Task <CustomResponseDto<List<ProductWithCategoryDTO>>> GetProductsByCategory();
    }
}
