using SingletonPattern.Domain.Entities;

namespace SingletonPattern.Domain.Interfaces
{
    public interface IEmployeeRepository
    {
         List<Employee> GetAllEmployees();
        //Employee GetEmployeeById(int employeeId);
        void AddEmployee(Employee employee);
        //void UpdateEmployee(Employee employee);
        //void DeleteEmployee(int employeeId);

    }
}
