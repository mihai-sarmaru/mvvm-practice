using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVVMPractice.Models;
using MVVMPractice.Services;

namespace MVVMPracticeTests {
    [TestClass]
    public class EmployeeRepositoryTests {

        [TestMethod]
        public void TestGetEmployeeJsonPath() {
            string expected = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "json", "Employee.json");
            string result = EmployeeRepository.GetEmployeeJsonPath();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestCreatePathDirectory() {
            EmployeeRepository.CreatePathDirectory();
            Assert.IsTrue(Directory.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "json")));
        }

        [TestMethod]
        public void TestSaveEmployee() {
            Employee emp = EmployeeRepository.DefaultEmployee();
            EmployeeRepository.SaveEmployeeToList(emp);

            Assert.IsTrue(File.Exists(EmployeeRepository.GetEmployeeJsonPath()));
        }

        [TestMethod]
        public void TestGetEmployee() {
            List<Employee> emp = EmployeeRepository.GetEmployeeList();
            Assert.IsNotNull(emp);
        }

        [TestMethod]
        public void TestEmployeeJsonFileExists() {
            Assert.IsTrue(EmployeeRepository.EmployeeJsonFileExists());
        }

        [TestMethod]
        public void TestDefaultEmployee() {
            Employee emp = EmployeeRepository.DefaultEmployee();

            Assert.AreEqual(emp.Name, "William");
            Assert.AreEqual(emp.Surname, "Smith");
            Assert.AreEqual(emp.Age, 27);
            Assert.AreEqual(emp.PhoneNumber, 1234567890);
            Assert.AreEqual(emp.Experience, 5);
        }
    }
}
