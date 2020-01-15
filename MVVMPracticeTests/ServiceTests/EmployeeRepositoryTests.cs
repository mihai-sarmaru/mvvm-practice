using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVVMPractice.Models;
using MVVMPractice.Services;

namespace MVVMPracticeTests {
    [TestClass]
    public class EmployeeRepositoryTests {
        private EmployeeRepository _repo;
        private PrivateObject _privateRepo;

        private string JSON_PATH { get; set; } = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "json", "Employee.json");

        [TestInitialize]
        public void StartUp() {
            if (File.Exists(JSON_PATH)) {
                File.Delete(JSON_PATH);
            }
            _repo = new EmployeeRepository();
            _privateRepo = new PrivateObject(_repo);
        }

        [TestMethod]
        public void TestGetEmployeeJsonPath() {
            string expected = JSON_PATH;
            string result = (string)_privateRepo.Invoke("GetEmployeeJsonPath");

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestCreatePathDirectory() {
            _privateRepo.Invoke("CreatePathDirectory");
            Assert.IsTrue(Directory.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "json")));
        }

        [TestMethod]
        public void TestSaveEmployee() {
            Employee emp = (Employee)_privateRepo.Invoke("DefaultEmployee");
            _repo.SaveEmployeeToList(emp);

            Assert.IsTrue(File.Exists((string)_privateRepo.Invoke("GetEmployeeJsonPath")));
        }

        [TestMethod]
        public void TestSaveEmployeeList() {
            List<Employee> empList = _repo.GetEmployeeList();
            empList.Add((Employee)_privateRepo.Invoke("DefaultEmployee"));
            _privateRepo.Invoke("SaveEmployeeList", empList);

            Assert.IsTrue(File.Exists((string)_privateRepo.Invoke("GetEmployeeJsonPath")));
        }

        [TestMethod]
        public void TestUpdateEmployeeList() {
            List<Employee> empList = new List<Employee>();
            Employee defaultEmployee = (Employee)_privateRepo.Invoke("DefaultEmployee");
            empList.Add(defaultEmployee);

            Assert.AreEqual(1, empList.Count);

            defaultEmployee.Age = 20;
            empList = (List<Employee>)_privateRepo.Invoke("UpdateEmployeeList", empList, defaultEmployee);
            Assert.AreEqual(1, empList.Count);

            defaultEmployee = (Employee)_privateRepo.Invoke("DefaultEmployee");
            defaultEmployee.ID = "new-test-ID";
            empList = (List<Employee>)_privateRepo.Invoke("UpdateEmployeeList", empList, defaultEmployee);

            Assert.AreEqual(2, empList.Count);
        }

        [TestMethod]
        public void TestShouldUpdateEmployee() {
            List<Employee> empList = new List<Employee>();
            Employee defaultEmployee = (Employee)_privateRepo.Invoke("DefaultEmployee");
            empList.Add(defaultEmployee);

            Assert.AreEqual(1, empList.Count);

            defaultEmployee.Age = 20;

            Assert.IsTrue((bool)_privateRepo.Invoke("ShouldUpdateEmployee", empList, defaultEmployee));

            defaultEmployee = (Employee)_privateRepo.Invoke("DefaultEmployee");
            defaultEmployee.ID = "new-test-ID";

            Assert.IsFalse((bool)_privateRepo.Invoke("ShouldUpdateEmployee", empList, defaultEmployee));
        }

        [TestMethod]
        public void TestGetEmployeeList() {
            List<Employee> emp = _repo.GetEmployeeList();
            Assert.IsNotNull(emp);
        }

        [TestMethod]
        public void TestEmployeeJsonFileExists() {
            if (File.Exists(JSON_PATH)) {
                Assert.IsTrue((bool)_privateRepo.Invoke("EmployeeJsonFileExists"));
            } else {
                Assert.IsFalse((bool)_privateRepo.Invoke("EmployeeJsonFileExists"));
            }
        }

        [TestMethod]
        public void TestDefaultEmployee() {
            Employee emp = (Employee)_privateRepo.Invoke("DefaultEmployee");

            Assert.AreEqual(emp.ID, "f1d0f9a3-69f4-401e-bcea-83c05b08834a");
            Assert.AreEqual(emp.Name, "William");
            Assert.AreEqual(emp.Surname, "Smith");
            Assert.AreEqual(emp.Age, 27);
            Assert.AreEqual(emp.PhoneNumber, 1234567890);
            Assert.AreEqual(emp.Experience, 5);
        }

        [TestMethod]
        public void TestRemoveEmployeeFromList() {
            List<Employee> empList = _repo.GetEmployeeList();
            int employeeCount = empList.Count;

            Employee emp = (Employee)_privateRepo.Invoke("DefaultEmployee");
            _repo.SaveEmployeeToList(emp);
            _repo.RemoveEmployeeFromList(emp);
            empList = _repo.GetEmployeeList();

            Assert.AreEqual(empList.Count, employeeCount);
        }
    }
}
