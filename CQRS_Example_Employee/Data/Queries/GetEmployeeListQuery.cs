using CQRS_Example_Employee.Models;
using MediatR;

namespace CQRS_Example_Employee.Data.Queries
{
    public class GetEmployeeListQuery:IRequest<List<Employee>>
    {
    }
}
