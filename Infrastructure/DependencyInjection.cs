using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Repositories;
using Domain.Interfaces;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
        {
            //adding dependency injection for db context class
            services.AddDbContext<AppDbContext>(option => option.UseSqlServer("Server=CPC-vaibh-VQPEI;Database=PracticeDB;Trusted_Connection=True;TrustServerCertificate=true;"));

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            return services;
        }
    }
}
