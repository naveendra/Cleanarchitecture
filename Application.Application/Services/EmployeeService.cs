using Application.Application.Dtos;
using Application.Application.Interfaces.Repositories;
using Application.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task CreateEmployeeAsync(CreateEmployeeDto createEmployeeDto)
        {
            await _employeeRepository.CreateEmployeeAsync(createEmployeeDto);
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            await _employeeRepository.DeleteEmployeeAsync(id);
        }

        public async Task<List<GetEmployeeDto>> GetAllEmployeesAsync(int page, int pageSize)
        {
            return await _employeeRepository.GetAllEmployeesAsync(page, pageSize);
        }

        public async Task<GetEmployeeDto> GetEmployeeByIdAsync(int id)
        {
            return await _employeeRepository.GetEmployeeByIdAsync(id);
        }

        public async Task UpdateEmployeeAsync(int id, UpdateEmployeeDto updateEmployeeDto)
        {
            await _employeeRepository.UpdateEmployeeAsync(id, updateEmployeeDto);
        }
    }
}
