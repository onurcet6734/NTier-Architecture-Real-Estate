using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using RealEstate.Core.Repositories;
using RealEstate.Core.Services;
using RealEstate.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IGenericRepository<Product> repository, IUnitOfWork unitOfWork, IProductRepository productRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<List<ProductWithCategoryDTO>>> GetProductsByCategory()
        {
            var product = await _productRepository.GetProductsByCategory();
            var productDto = _mapper.Map<List<ProductWithCategoryDTO>>(product);
            return CustomResponseDto<List<ProductWithCategoryDTO>>.Success(200, productDto);
        }
    }
}
