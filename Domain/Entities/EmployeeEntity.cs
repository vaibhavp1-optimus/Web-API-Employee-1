using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class EmployeeEntity
    {
        public Guid Id { get; set; }
        public string? name { get; set; }

        public string? Email { get; set; }

        public string Phone { get; set; }
    }
}
