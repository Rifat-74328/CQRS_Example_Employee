using CQRS_Example_Employee.Data;
using CQRS_Example_Employee.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Example_Employee.Services
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly EmployeeContext db;
        public EmployeeRepo(EmployeeContext context)
        {
            db=context;
        }
        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
           var result= db.employees.Add(employee);
            await db.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> DeleteEmployeeAsync(int id)
        {
            var employee = db.employees.FirstOrDefault(e => e.id == id);
            db.employees.Remove(employee);
            return await db.SaveChangesAsync();

        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            var employee = await db.employees.FirstOrDefaultAsync(e => e.id == id);
            return  employee;
        }

        public async Task<List<Employee>> GetEmployeeListAsync()
        {
            var List =await db.employees.ToListAsync();
            return List;
        }

        public async Task<int> UpdateEmployeeAsync(Employee employee)
        {
            db.employees.Update(employee);
            return await db.SaveChangesAsync();

        }
    }
}
