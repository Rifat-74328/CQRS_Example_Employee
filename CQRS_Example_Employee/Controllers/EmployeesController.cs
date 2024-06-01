using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CQRS_Example_Employee.Data.Commands;
using CQRS_Example_Employee.Data.Queries;
using CQRS_Example_Employee.Models;
using MediatR;

namespace CQRS_Example_Employee.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private IMediator mediator;
        public EmployeeController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<List<Employee>> GetAll()
        {
            var list = await mediator.Send(new GetEmployeeListQuery());
            return list;
        }
        [HttpGet("{id}")]
        public async Task<Employee> GetById(int id)
        {
            var employee = await mediator.Send(new GetEmployeeByIdQuery() { id = id });
            return employee;
        }
        [HttpPost]
        public async Task<Employee> CreateEmployee(Employee employee)
        {
            var employe = await mediator.Send(new CreateEmployeeCommand(employee.name, employee.age, employee.address, employee.phone));
            return employe;
        }

        [HttpPut("{id}")]
        public async Task<int> UpdateEmployee(Employee employee)
        {
            var employe = await mediator.Send(new UpdateEmployeeCommand(employee.id, employee.name, employee.age, employee.address, employee.phone));
            return employe;
        }

        [HttpDelete("{id}")]
        public async Task<int> DeleteEmployee(int id)
        {
            return await mediator.Send(new DeleteEmployeeCommand() { Id = id });
        }
    }
}

