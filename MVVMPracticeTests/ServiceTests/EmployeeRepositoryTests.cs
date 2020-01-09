using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVVMPractice.Models;
using MVVMPractice.Services;

namespace MVVMPracticeTests {
    [TestClass]
    public class EmployeeRepositoryTests {

        public string JSON_PATH { get; set; } = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "json", "Employee.json");

        [TestInitialize]
        public void StartUp() {
            if (File.Exists(JSON_PATH)) {
                File.Delete(JSON_PATH);
            }
        }

        [TestMethod]
        public void TestGetEmployeeJsonPath() {
            string expected = JSON_PATH;
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
            if (File.Exists(JSON_PATH)) {
                Assert.IsTrue(EmployeeRepository.EmployeeJsonFileExists());
            } else {
                Assert.IsFalse(EmployeeRepository.EmployeeJsonFileExists());
            }
        }

        [TestMethod]
        public void TestDefaultEmployee() {
            Employee emp = EmployeeRepository.DefaultEmployee();
            
            Assert.AreEqual(emp.ID, "f1d0f9a3-69f4-401e-bcea-83c05b08834a");
            Assert.AreEqual(emp.Name, "William");
            Assert.AreEqual(emp.Surname, "Smith");
            Assert.AreEqual(emp.Age, 27);
            Assert.AreEqual(emp.PhoneNumber, 1234567890);
            Assert.AreEqual(emp.Experience, 5);
        }
    }
}
