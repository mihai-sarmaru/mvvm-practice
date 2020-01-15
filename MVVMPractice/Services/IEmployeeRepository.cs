using MVVMPractice.Models;
using System.Collections.Generic;

namespace MVVMPractice.Services {
    public interface IEmployeeRepository {
        List<Employee> GetEmployeeList();
        void SaveEmployeeToList(Employee employee);
        void RemoveEmployeeFromList(Employee employee);
    }
}
