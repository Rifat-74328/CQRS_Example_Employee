using CQRS_Example_Employee.Data.Queries;
using CQRS_Example_Employee.Models;
using CQRS_Example_Employee.Services;
using MediatR;

namespace CQRS_Example_Employee.Data.Handlers
{
    public class GetEmployeeListHandler:IRequestHandler<GetEmployeeListQuery,List<Employee>>
    {
        private readonly IEmployeeRepo employeeRepo;
        public GetEmployeeListHandler(IEmployeeRepo repo)
        {
            employeeRepo = repo;
        }

        public async Task<List<Employee>> Handle(GetEmployeeListQuery request, CancellationToken cancellationToken)
        {
            return await employeeRepo.GetEmployeeListAsync();
        }
    }
}
