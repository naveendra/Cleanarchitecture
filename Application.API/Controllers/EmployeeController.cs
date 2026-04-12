using Application.Application.Dtos;
using Application.Application.Interfaces.Services;
using Application.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] int page=1, [FromQuery] int pageSize=10)
        {
            var employees = await _employeeService.GetAllEmployeesAsync(page, pageSize);
            return Ok(employees);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee =await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] CreateEmployeeDto createEmployeeDto)
        {
            await _employeeService.CreateEmployeeAsync(createEmployeeDto);

            return Ok();
            

        }

        [HttpPut]
        [Route("Update/{id}")]
        public  async Task<IActionResult> Update(int id, [FromBody] UpdateEmployeeDto updateEmployeeDto)
        {
            await  _employeeService.UpdateEmployeeAsync(id, updateEmployeeDto);
           
            return Ok();
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _employeeService.DeleteEmployeeAsync(id);
            return Ok();
        }
    }
}