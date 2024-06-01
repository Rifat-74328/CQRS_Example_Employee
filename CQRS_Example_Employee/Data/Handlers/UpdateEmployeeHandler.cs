using CQRS_Example_Employee.Data.Commands;
using CQRS_Example_Employee.Models;
using CQRS_Example_Employee.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Numerics;
using System.Xml.Linq;

namespace CQRS_Example_Employee.Data.Handlers
{
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommand, int>
    {
        private readonly IEmployeeRepo repo;
        public UpdateEmployeeHandler(IEmployeeRepo repo)
        {
            this.repo =repo;
        }
        public async Task<int> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee =await repo.GetEmployeeByIdAsync(request.id);
            if (employee != null)
            {
                employee.id = request.id;
                employee.name = request.name;
                employee.age = request.age;
                employee.address = request.address;
                employee.phone = request.phone;

                return await repo.UpdateEmployeeAsync(employee);
            }
            else return default;
            
        }
    }
}
