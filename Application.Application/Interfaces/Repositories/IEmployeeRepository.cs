using Application.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Application.Interfaces.Repositories
{
    public interface IEmployeeRepository
    {
        Task CreateEmployeeAsync(CreateEmployeeDto createEmployeeDto);
        Task<List<GetEmployeeDto>> GetAllEmployeesAsync();

        Task<GetEmployeeDto> GetEmployeeByIdAsync(int id);

        Task DeleteEmployeeAsync(int id);

        Task UpdateEmployeeAsync(int id, UpdateEmployeeDto updateEmployeeDto);

    }
}
