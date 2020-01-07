using System;
using System.IO;

namespace MVVMPractice.Services {
    public static class EmployeeRepository {

        private const string JSON_FOLDER = "json";
        private const string JSON_EMPLOYEE_FILENAME = "Employee.json";

        public static string GetEmployeeJsonPath() {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, JSON_FOLDER, JSON_EMPLOYEE_FILENAME);
        }

    }
}
