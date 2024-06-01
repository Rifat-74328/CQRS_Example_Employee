using CQRS_Example_Employee.Models;

namespace CQRS_Example_Employee.Services
{
    public interface IEmployeeRepo
    {
        public Task<List<Employee>> GetEmployeeListAsync();
        public Task<Employee> GetEmployeeByIdAsync(int id);
        public Task<Employee> AddEmployeeAsync(Employee employee);
        public Task<int> UpdateEmployeeAsync(Employee employee);
        public Task<int> DeleteEmployeeAsync(int id);


    }
}
