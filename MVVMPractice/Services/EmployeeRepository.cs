using System;
using System.Collections.Generic;
using System.IO;
using MVVMPractice.Models;
using Newtonsoft.Json;

namespace MVVMPractice.Services {
    public static class EmployeeRepository {

        private const string JSON_FOLDER = "json";
        private const string JSON_EMPLOYEE_FILENAME = "Employee.json";

        public static List<Employee> GetEmployeeList() {
            return JsonConvert.DeserializeObject<List<Employee>>(File.ReadAllText(GetEmployeeJsonPath()));
        }

        public static void SaveEmployeeToList(Employee employee) {
            List<Employee> employeeList = GetEmployeeList();
            employeeList.Add(employee);
            File.WriteAllText(GetEmployeeJsonPath(), JsonConvert.SerializeObject(employeeList));
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

        public static Employee DefaultEmployee() {
            return new Employee() { Name = "William", Surname = "Smith", Age = 27, PhoneNumber = 1234567890, Experience = 5 };
        }

    }
}
