using System;
using System.IO;
using MVVMPractice.Models;
using Newtonsoft.Json;

namespace MVVMPractice.Services {
    public static class EmployeeRepository {

        private const string JSON_FOLDER = "json";
        private const string JSON_EMPLOYEE_FILENAME = "Employee.json";

        public static Employee GetEmployee() {
            return JsonConvert.DeserializeObject<Employee>(File.ReadAllText(GetEmployeeJsonPath()));
        }

        public static void SaveEmployee(Employee employee) {
            string serializedEmployee = JsonConvert.SerializeObject(employee);
            File.WriteAllText(GetEmployeeJsonPath(), serializedEmployee);
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
