using System.Collections.Generic;
using MVVMPractice.Models;
using MVVMPractice.Services;

namespace MVVMPractice.ViewModels {
    public class EmployeeListViewModel {
        public List<Employee> EmployeeList { get; set; }

        public EmployeeListViewModel() {
            EmployeeList = EmployeeRepository.GetEmployeeList();
        }
    }
}
