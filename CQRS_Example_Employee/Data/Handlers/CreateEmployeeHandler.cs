using CQRS_Example_Employee.Data.Commands;
using CQRS_Example_Employee.Models;
using CQRS_Example_Employee.Services;
using MediatR;

namespace CQRS_Example_Employee.Data.Handlers
{
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, Employee>
    {
        private readonly IEmployeeRepo repo;
        public CreateEmployeeHandler(IEmployeeRepo repo)
        {
            this.repo = repo;
        }

        public async Task<Employee> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            Employee employee = new Employee
            {
                name=request.name,
                address=request.address,
                phone=request.phone,
                age= request.age

            };
            return await repo.AddEmployeeAsync(employee);
        }
    }
}
