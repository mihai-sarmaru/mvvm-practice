using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVVMPractice.Containers;
using MVVMPractice.Messages;
using MVVMPractice.Models;
using MVVMPractice.Services;
using MVVMPractice.ViewModels;
using System.Collections.Generic;
using Unity;

namespace MVVMPracticeTests.ViewModelTests {
    [TestClass]
    public class EmployeeFormViewModelTests {
        private EmployeeRepository _repo;
        private PrivateObject _privateRepo;

        [TestInitialize]
        public void StartUp() {
            _repo = new EmployeeRepository();
            _privateRepo = new PrivateObject(_repo);
        }

        [TestMethod]
        public void TestClearForm() {
            EmployeeFormViewModel model = ContainerHelper.Container.Resolve<EmployeeFormViewModel>();
            string expected = model.Employee.ID;
            model.ClearForm();

            Assert.AreNotEqual(expected, model.Employee.ID);
        }

        [TestMethod]
        public void TestSaveEmployee() {
            EmployeeFormViewModel model = ContainerHelper.Container.Resolve<EmployeeFormViewModel>();
            model.Employee = (Employee)_privateRepo.Invoke("DefaultEmployee");
            
            int expected = ((List<Employee>)_privateRepo.Invoke("GetEmployeeList")).Count;
            model.SaveEmployee();

            Assert.AreNotEqual(expected, ((List<Employee>)_privateRepo.Invoke("GetEmployeeList")).Count);
        }

        [TestMethod]
        public void TestUpdateEmployee() {
            EmployeeFormViewModel model = ContainerHelper.Container.Resolve<EmployeeFormViewModel>();
            model.UpdateEmployee(new UpdateEmployeeFormMessage() { Employee = (Employee)_privateRepo.Invoke("DefaultEmployee")});

            Assert.AreEqual(model.Employee.ID, ((Employee)_privateRepo.Invoke("DefaultEmployee")).ID);
        }
    }
}
