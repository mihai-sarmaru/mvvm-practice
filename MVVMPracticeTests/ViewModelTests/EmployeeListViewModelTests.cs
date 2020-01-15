using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVVMPractice.Messages;
using MVVMPractice.Models;
using MVVMPractice.Services;
using MVVMPractice.ViewModels;

namespace MVVMPracticeTests.ViewModelTests {
    [TestClass]
    public class EmployeeListViewModelTests {
        private EmployeeRepository _repo;
        private PrivateObject _privateRepo;

        [TestInitialize]
        public void StartUp() {
            _repo = new EmployeeRepository();
            _privateRepo = new PrivateObject(_repo);
        }

        [TestMethod]
        public void TestUpdateEmployeeList() {
            EmployeeListViewModel model = new EmployeeListViewModel();
            int expected = model.EmployeeList.Count;
            Employee emp = (Employee)_privateRepo.Invoke("DefaultEmployee");
            emp.ID = "new-employee-ID";
            _privateRepo.Invoke("SaveEmployeeToList", emp);
            model.UpdateEmployeeList(new UpdateEmployeeListMessage());

            Assert.AreNotEqual(expected, model.EmployeeList.Count);
        } 

        [TestMethod]
        public void TestRemoveEmployeeFromList() {
            EmployeeListViewModel model = new EmployeeListViewModel();

            // Add 2 employees
            Employee emp = (Employee)_privateRepo.Invoke("DefaultEmployee");
            emp.ID = "new-employee-ID-number-1";
            Employee emp2 = (Employee)_privateRepo.Invoke("DefaultEmployee");
            emp2.ID = "new-employee-ID-number-2";

            _privateRepo.Invoke("SaveEmployeeToList", emp);
            _privateRepo.Invoke("SaveEmployeeToList", emp2);

            model.UpdateEmployeeList(new UpdateEmployeeListMessage());
            int expected = model.EmployeeList.Count;
            model.RemoveEmployeeFromList(emp2.ID);

            Assert.AreNotEqual(expected, model.EmployeeList.Count);
        }
    }
}
