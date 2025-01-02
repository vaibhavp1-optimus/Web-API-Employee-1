using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace Infrastructure.Repositories
{
    public class EmployeeRepository(AppDbContext dbContext) : IEmployeeRepository
    {
        public async Task<IEnumerable<EmployeeEntity>> GetEmployees()
        {
            return await dbContext.Employees.ToListAsync();
        }

        public async Task<EmployeeEntity> GetEmployeeByIdAsync(Guid id)
        {
            return await dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
        }
    
        public async Task<EmployeeEntity> AddEmployeeAsync(EmployeeEntity entity)
        {
            entity.Id = Guid.NewGuid();//this will generate a new id each time an entity is added
            dbContext.Employees.Add(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<EmployeeEntity> updateEmployeeAsync(Guid id, EmployeeEntity entity)
        {
            var employee = await dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (employee != null)
            {
                employee.name = entity.name;
                employee.Phone = entity.Phone;
                employee.Email = entity.Email;
                await dbContext.SaveChangesAsync();
                return employee;
            }
            return entity;

        }

        public async Task<bool> DeleteEmployeeAsync(Guid id)
        {
           var employee =  await dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (employee is not null)
            {
                dbContext.Employees.Remove(employee);
                await dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        
    }
}
