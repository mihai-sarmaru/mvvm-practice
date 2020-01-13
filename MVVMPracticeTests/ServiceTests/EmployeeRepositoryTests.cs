﻿using System;
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
        public void TestSaveEmployeeList() {
            List<Employee> empList = EmployeeRepository.GetEmployeeList();
            empList.Add(EmployeeRepository.DefaultEmployee());
            EmployeeRepository.SaveEmployeeList(empList);

            Assert.IsTrue(File.Exists(EmployeeRepository.GetEmployeeJsonPath()));
        }

        [TestMethod]
        public void TestUpdateEmployeeList() {
            List<Employee> empList = new List<Employee>();
            Employee defaultEmployee = EmployeeRepository.DefaultEmployee();
            empList.Add(defaultEmployee);

            Assert.AreEqual(1, empList.Count);

            defaultEmployee.Age = 20;
            empList = EmployeeRepository.UpdateEmployeeList(empList, defaultEmployee);

            Assert.AreEqual(1, empList.Count);

            defaultEmployee = EmployeeRepository.DefaultEmployee();
            defaultEmployee.ID = "new-test-ID";
            empList = EmployeeRepository.UpdateEmployeeList(empList, defaultEmployee);

            Assert.AreEqual(2, empList.Count);
        }

        [TestMethod]
        public void TestShouldUpdateEmployee() {
            List<Employee> empList = new List<Employee>();
            Employee defaultEmployee = EmployeeRepository.DefaultEmployee();
            empList.Add(defaultEmployee);

            Assert.AreEqual(1, empList.Count);

            defaultEmployee.Age = 20;

            Assert.IsTrue(EmployeeRepository.ShouldUpdateEmployee(empList, defaultEmployee));

            defaultEmployee = EmployeeRepository.DefaultEmployee();
            defaultEmployee.ID = "new-test-ID";

            Assert.IsFalse(EmployeeRepository.ShouldUpdateEmployee(empList, defaultEmployee));
        }

        [TestMethod]
        public void TestGetEmployeeList() {
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

        [TestMethod]
        public void TestRemoveEmployeeFromList() {
            List<Employee> empList = EmployeeRepository.GetEmployeeList();
            int employeeCount = empList.Count;

            Employee emp = EmployeeRepository.DefaultEmployee();
            EmployeeRepository.SaveEmployeeToList(emp);
            EmployeeRepository.RemoveEmployeeFromList(emp);
            empList = EmployeeRepository.GetEmployeeList();

            Assert.AreEqual(empList.Count, employeeCount);
        }
    }
}
