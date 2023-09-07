using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Service.Services;
using RealEstate.Core.Services;

namespace NLayer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : Controller
    {
        private readonly IService<Client> _clientService;
        private readonly IMapper _mapper;

        public ClientController(IService<Client> clientService, IMapper mapper)
        {
            _clientService = clientService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientDTO>>> GetClients()
        {
            var clients = await _clientService.GetAllAsync();
            var clientDTOs = _mapper.Map<IEnumerable<ClientDTO>>(clients);
            return Ok(clientDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClientDTO>> GetClient(int id)
        {
            var client = await _clientService.GetByIdAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            var clientDTO = _mapper.Map<ClientDTO>(client);
            return Ok(clientDTO);
        }

        [HttpPost]
        public async Task<ActionResult<ClientDTO>> CreateClient(ClientDTO clientDto)
        {
            var client = await _clientService.AddAsync(_mapper.Map<Client>(clientDto));
            var clientsDto = _mapper.Map<ClientDTO>(client);
            return Ok(CustomResponseDto<ClientDTO>.Success(201, clientsDto));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(int id, ClientDTO clientDTO)
        {
            if (id != clientDTO.Id)
            {
                return BadRequest();
            }

            var existingClient = await _clientService.GetByIdAsync(id);
            if (existingClient == null)
            {
                return NotFound();
            }

            _mapper.Map(clientDTO, existingClient);
            existingClient.UpdatedDate = DateTime.Now;

            await _clientService.UpdateAsync(existingClient);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var existingClient = await _clientService.GetByIdAsync(id);
            if (existingClient == null)
            {
                return NotFound();
            }

            await _clientService.RemoveAsync(existingClient);

            return NoContent();
        }
    }
}
