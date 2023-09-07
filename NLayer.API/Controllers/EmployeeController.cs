using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using RealEstate.Core.Services;

namespace NLayer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IService<Employee> _employeeService;
        private readonly IMapper _mapper;

        public EmployeeController(IService<Employee> employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetEmployees()
        {
            var employees = await _employeeService.GetAllAsync();
            var employeeDTOs = _mapper.Map<IEnumerable<EmployeeDTO>>(employees);
            return Ok(CustomResponseDto<IEnumerable<EmployeeDTO>>.Success(200, employeeDTOs));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDTO>> GetEmployee(int id)
        {
            var employee = await _employeeService.GetByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            var employeeDTO = _mapper.Map<EmployeeDTO>(employee);
            return Ok(employeeDTO);
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeDTO>> CreateEmployee(EmployeeDTO employeeDTO)
        {
            var employee = _mapper.Map<Employee>(employeeDTO);
            employee.CreatedDate = DateTime.Now;
            var createdEmployee = await _employeeService.AddAsync(employee);
            var createdEmployeeDTO = _mapper.Map<EmployeeDTO>(createdEmployee);
            return Ok(CustomResponseDto<EmployeeDTO>.Success(201, createdEmployeeDTO));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, EmployeeDTO employeeDTO)
        {
            if (id != employeeDTO.Id)
            {
                return BadRequest();
            }

            var existingEmployee = await _employeeService.GetByIdAsync(id);
            if (existingEmployee == null)
            {
                return NotFound();
            }

            _mapper.Map(employeeDTO, existingEmployee);
            existingEmployee.UpdatedDate = DateTime.Now;

            await _employeeService.UpdateAsync(existingEmployee);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var existingEmployee = await _employeeService.GetByIdAsync(id);
            if (existingEmployee == null)
            {
                return NotFound();
            }

            await _employeeService.RemoveAsync(existingEmployee);

            return NoContent();
        }
    }
}
