using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces

{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeEntity>> GetEmployees();
        Task<EmployeeEntity> GetEmployeeByIdAsync(Guid id);
        Task<EmployeeEntity> updateEmployeeAsync(Guid id, EmployeeEntity entity);
        Task<bool> DeleteEmployeeAsync(Guid id);
        Task<EmployeeEntity> AddEmployeeAsync(EmployeeEntity employee);
    }
}
