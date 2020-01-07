using System;
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
            EmployeeRepository.SaveEmployee(emp);

            Assert.IsTrue(File.Exists(EmployeeRepository.GetEmployeeJsonPath()));
        }

        [TestMethod]
        public void TestGetEmployee() {
            Employee emp = EmployeeRepository.GetEmployee();

            Assert.IsNotNull(emp);
            Assert.IsNotNull(emp.Name);
            Assert.IsNotNull(emp.Surname);
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
