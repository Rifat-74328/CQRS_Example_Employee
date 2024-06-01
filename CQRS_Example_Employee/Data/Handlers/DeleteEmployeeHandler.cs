using CQRS_Example_Employee.Data.Commands;
using CQRS_Example_Employee.Services;
using MediatR;

namespace CQRS_Example_Employee.Data.Handlers
{
    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeCommand, int>
    {
        private readonly IEmployeeRepo repo;
        public DeleteEmployeeHandler(IEmployeeRepo repo)
        {
            this.repo = repo;
        }
        public async Task<int> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await repo.GetEmployeeByIdAsync(request.Id);
            if (employee != null)
            {
                await repo.DeleteEmployeeAsync(request.Id);
            }
            return default;
        }
    }
}
