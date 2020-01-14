using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVVMPractice.Messages;
using MVVMPractice.Services;
using MVVMPractice.ViewModels;

namespace MVVMPracticeTests.ViewModelTests {
    [TestClass]
    public class EmployeeFormViewModelTests {
        [TestMethod]
        public void TestClearForm() {
            EmployeeFormViewModel model = new EmployeeFormViewModel();
            string expected = model.Employee.ID;
            model.ClearForm();

            Assert.AreNotEqual(expected, model.Employee.ID);
        }

        [TestMethod]
        public void TestSaveEmployee() {
            EmployeeFormViewModel model = new EmployeeFormViewModel();
            model.Employee = EmployeeRepository.DefaultEmployee();
            int expected = EmployeeRepository.GetEmployeeList().Count;
            model.SaveEmployee();

            Assert.AreNotEqual(expected, EmployeeRepository.GetEmployeeList().Count);
        }

        [TestMethod]
        public void TestUpdateEmployee() {
            EmployeeFormViewModel model = new EmployeeFormViewModel();
            model.UpdateEmployee(new UpdateEmployeeFormMessage() { Employee = EmployeeRepository.DefaultEmployee() });

            Assert.AreEqual(model.Employee.ID, EmployeeRepository.DefaultEmployee().ID);
        }
    }
}
