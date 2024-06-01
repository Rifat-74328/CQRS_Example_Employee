using CQRS_Example_Employee.Data.Queries;
using CQRS_Example_Employee.Models;
using CQRS_Example_Employee.Services;
using MediatR;

namespace CQRS_Example_Employee.Data.Handlers
{
    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery, Employee>
    {
        private readonly IEmployeeRepo repo;
        public GetEmployeeByIdHandler(IEmployeeRepo repo)
        {
            this.repo = repo;
        }
        public async Task<Employee> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            return await repo.GetEmployeeByIdAsync(request.id);   
        }
    }
}
