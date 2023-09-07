using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using RealEstate.Core.Repositories;
using RealEstate.Core.UnitOfWork;

namespace NLayer.Service.Services
{
    public class DetailsOfProductsService : Service<DetailsOfProduct>, IDetailsOfProductsService
    {
        private readonly IDetailsOfProductsRepository _detailsOfProductsRepository;
        private readonly IMapper _mapper;
        public DetailsOfProductsService(IDetailsOfProductsRepository detailsOfProductsRepository, IMapper mapper, IGenericRepository<DetailsOfProduct> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _detailsOfProductsRepository = detailsOfProductsRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<List<ProductWithDetailsDTO>>> GetDetailsByProductId()
        {
            var products = await _detailsOfProductsRepository.GetDetailsByProductId();
            var productDto = _mapper.Map<List<ProductWithDetailsDTO>>(products);
            return CustomResponseDto<List<ProductWithDetailsDTO>>.Success(200, productDto);
        }
    }
}
