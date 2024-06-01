using MediatR;

namespace CQRS_Example_Employee.Data.Commands
{
    public class DeleteEmployeeCommand:IRequest<int>
    {
        public int Id { get; set; }

    }
}
