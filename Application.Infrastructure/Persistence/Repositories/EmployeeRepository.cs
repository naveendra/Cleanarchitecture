using Application.Application.Dtos;
using Application.Application.Interfaces.Repositories;
using Application.Domain.Entities;
using Application.Infrastructure.Persistence.Context;
using Microsoft.Data.SqlTypes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Application.Infrastructure.Persistence.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DefaultDbContext _context;

        public EmployeeRepository(DefaultDbContext context)
        {
            _context = context;
        }

        public async Task CreateEmployeeAsync(CreateEmployeeDto createEmployeeDto )
        {
            await _context.Employees.AddAsync(new Employee
            {
                
                Name = createEmployeeDto.Name,
                EmployeeId = createEmployeeDto.EmployeeId,
                Address = createEmployeeDto.address,
                City = createEmployeeDto.city,
                State = createEmployeeDto.state,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
            });
            await _context.SaveChangesAsync();

        }

        public async Task DeleteEmployeeAsync(int id)
        {
                var res = await _context.Employees.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
            if (res != null) { 
             res.IsDeleted = true;
            }
            await _context.SaveChangesAsync();
        }

        public async Task<List<GetEmployeeDto>> GetAllEmployeesAsync(int page, int pageSize)
        {
            var data = await _context.Employees
        .Skip((page - 1) * pageSize)
        .Take(pageSize)
        .Select(e => new GetEmployeeDto
        {
            Id = e.Id,
            Name = e.Name,
            EmployeeId = e.EmployeeId,
            Address = e.Address,
            City = e.City,
            State = e.State,
        })
        .AsNoTracking()
        .ToListAsync();

          

            return data;         
           
        }

        public Task<GetEmployeeDto?> GetEmployeeByIdAsync(int id)
        {
            return _context.Employees.Where(e => e.Id == id && !e.IsDeleted).Select(e => new GetEmployeeDto
            {
                Id = e.Id,
                Name = e.Name,
                EmployeeId = e.EmployeeId,
                Address = e.Address,
                City = e.City,
                State = e.State,
            }).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task UpdateEmployeeAsync(int id, UpdateEmployeeDto updateEmployeeDto)
        {
            var res = _context.Employees.AsNoTracking().FirstOrDefault(e => e.Id == id);
            if (res != null)
            {
                res.Name = updateEmployeeDto.Name;
                res.EmployeeId = updateEmployeeDto.EmployeeId;
                res.Address = updateEmployeeDto.Address;
                res.City = updateEmployeeDto.City;
                res.State = updateEmployeeDto.State;                       

            }
            await _context.SaveChangesAsync();
        }
    }
}
