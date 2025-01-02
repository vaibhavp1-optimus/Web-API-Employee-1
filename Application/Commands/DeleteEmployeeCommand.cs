using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Commands
{
    public record DeleteEmployeeCommand(Guid EmployeeId) : IRequest<bool>;

    public record DeleteEmployeeCommandHandler(IEmployeeRepository EmployeeRepository) : IRequestHandler<DeleteEmployeeCommand, bool>
    {
        public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            return await EmployeeRepository.DeleteEmployeeAsync(request.EmployeeId);
        }
    }
}
