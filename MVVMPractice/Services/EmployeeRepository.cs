using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MVVMPractice.Models;
using Newtonsoft.Json;

namespace MVVMPractice.Services {
    public static class EmployeeRepository {

        private const string JSON_FOLDER = "json";
        private const string JSON_EMPLOYEE_FILENAME = "Employee.json";

        public static List<Employee> GetEmployeeList() {
            return EmployeeJsonFileExists() ?
                JsonConvert.DeserializeObject<List<Employee>>(File.ReadAllText(GetEmployeeJsonPath())) :
                new List<Employee>();
        }

        public static void SaveEmployeeToList(Employee employee) {
            List<Employee> employeeList = GetEmployeeList();
            SaveEmployeeList(UpdateEmployeeList(employeeList, employee));
        }

        public static List<Employee> UpdateEmployeeList(List<Employee> employeeList, Employee employee) {
            if (ShouldUpdateEmployee(employeeList, employee)) {
                Employee employeeToRemove = employeeList.Single(empID => empID.ID == employee.ID);
                employeeList[employeeList.IndexOf(employeeToRemove)] = employee;
            } else {
                employeeList.Add(employee);
            }
            return employeeList;
        }

        public static bool ShouldUpdateEmployee(List<Employee> employeeList, Employee employee) {
            return employeeList.Any(empID => empID.ID == employee.ID);
        }

        public static void SaveEmployeeList(List<Employee> employeeList) {
            File.WriteAllText(GetEmployeeJsonPath(), JsonConvert.SerializeObject(employeeList));
        }

        public static void RemoveEmployeeFromList(Employee employee) {
            List<Employee> employeeList = GetEmployeeList();
            Employee employeeToRemove = employeeList.Single(empID => empID.ID == employee.ID);
            employeeList.Remove(employeeToRemove);
            SaveEmployeeList(employeeList);
        }

        public static string GetEmployeeJsonPath() {
            CreatePathDirectory();
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, JSON_FOLDER, JSON_EMPLOYEE_FILENAME);
        }

        public static void CreatePathDirectory() {
            if (!Directory.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, JSON_FOLDER))) {
                Directory.CreateDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, JSON_FOLDER));
            }
        }

        public static bool EmployeeJsonFileExists() {
            return File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, JSON_FOLDER, JSON_EMPLOYEE_FILENAME));
        }

        public static Employee DefaultEmployee() {
            return new Employee() { ID = "f1d0f9a3-69f4-401e-bcea-83c05b08834a",
                Name = "William", Surname = "Smith", Age = 27, PhoneNumber = 1234567890, Experience = 5 };
        }

    }
}
