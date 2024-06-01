using MediatR;

namespace CQRS_Example_Employee.Data.Commands
{
    public class UpdateEmployeeCommand:IRequest<int>
    {
        public UpdateEmployeeCommand(int id,string name, int age, string address, int phone)
        {
            this.id = id;
            this.name = name;
            this.age = age;
            this.address = address;
            this.phone = phone;
        }
        public int id {  get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string address { get; set; }
        public int phone { get; set; }
    }
}
