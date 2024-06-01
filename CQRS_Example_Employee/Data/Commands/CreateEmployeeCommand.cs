using CQRS_Example_Employee.Models;
using MediatR;

namespace CQRS_Example_Employee.Data.Commands
{
    public class CreateEmployeeCommand:IRequest<Employee>
    {
        public CreateEmployeeCommand(string name, int age, string address, int phone)
        {
            this.name = name;
            this.age = age;
            this.address = address;
            this.phone = phone;
        }
        public string name { get; set; }
        public int age { get; set; }
        public string address { get; set; }
        public int phone { get; set; }
    }
}
