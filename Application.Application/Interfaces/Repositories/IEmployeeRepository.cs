using Application.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Application.Interfaces.Repositories
{
    public interface IEmployeeRepository
    {
        Task CreateEmployeeAsync(CreateEmployeeDto createEmployeeDto);
        Task<List<GetEmployeeDto>> GetAllEmployeesAsync(int page, int pageSize);

        Task<GetEmployeeDto> GetEmployeeByIdAsync(int id);

        Task DeleteEmployeeAsync(int id);

        Task UpdateEmployeeAsync(int id, UpdateEmployeeDto updateEmployeeDto);

    }
}
