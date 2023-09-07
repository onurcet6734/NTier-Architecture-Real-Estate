using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailsOfProductController : ControllerBase
    {
        private readonly IDetailsOfProductsService _detailsOfProductService;
        private readonly IMapper _mapper;

        public DetailsOfProductController(IDetailsOfProductsService detailsOfProductService, IMapper mapper)
        {
            _detailsOfProductService = detailsOfProductService;
            _mapper = mapper;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetDetailsByProductId()
        {
            var str = await _detailsOfProductService.GetDetailsByProductId();
            return Ok(str);
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetailsOfProductDTO>>> GetDetailsOfProducts()
        {
            var detailsOfProducts = await _detailsOfProductService.GetAllAsync();
            var detailsOfProductDTOs = _mapper.Map<IEnumerable<DetailsOfProductDTO>>(detailsOfProducts);
            return Ok(CustomResponseDto<IEnumerable<DetailsOfProductDTO>>.Success(200, detailsOfProductDTOs));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DetailsOfProductDTO>> GetDetailsOfProduct(int id)
        {
            var detailsOfProduct = await _detailsOfProductService.GetByIdAsync(id);
            if (detailsOfProduct == null)
            {
                return NotFound();
            }

            var detailsOfProductDTO = _mapper.Map<DetailsOfProductDTO>(detailsOfProduct);
            return Ok(detailsOfProductDTO);
        }

        [HttpPost]
        public async Task<ActionResult<DetailsOfProductDTO>> CreateDetailsOfProduct(DetailsOfProductDTO detailsOfProductDTO)
        {
            var detailsOfProduct = _mapper.Map<DetailsOfProduct>(detailsOfProductDTO);
            var createdDetailsOfProduct = await _detailsOfProductService.AddAsync(detailsOfProduct);
            var createdDetailsOfProductDTO = _mapper.Map<DetailsOfProductDTO>(createdDetailsOfProduct);
            return Ok(CustomResponseDto<DetailsOfProductDTO>.Success(201, createdDetailsOfProductDTO));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDetailsOfProduct(int id, DetailsOfProductDTO detailsOfProductDTO)
        {
           
            var existingDetailsOfProduct = await _detailsOfProductService.GetByIdAsync(id);
            if (existingDetailsOfProduct == null)
            {
                return NotFound();
            }

            _mapper.Map(detailsOfProductDTO, existingDetailsOfProduct);
            

            await _detailsOfProductService.UpdateAsync(existingDetailsOfProduct);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetailsOfProduct(int id)
        {
            var existingDetailsOfProduct = await _detailsOfProductService.GetByIdAsync(id);
            if (existingDetailsOfProduct == null)
            {
                return NotFound();
            }

            await _detailsOfProductService.RemoveAsync(existingDetailsOfProduct);

            return NoContent();
        }
    }
}
