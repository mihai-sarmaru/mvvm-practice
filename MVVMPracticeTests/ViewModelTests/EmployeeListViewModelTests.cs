using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVVMPractice.Messages;
using MVVMPractice.Models;
using MVVMPractice.Services;
using MVVMPractice.ViewModels;

namespace MVVMPracticeTests.ViewModelTests {
    [TestClass]
    public class EmployeeListViewModelTests {
        [TestMethod]
        public void TestUpdateEmployeeList() {
            EmployeeListViewModel model = new EmployeeListViewModel();
            int expected = model.EmployeeList.Count;
            Employee emp = EmployeeRepository.DefaultEmployee();
            emp.ID = "new-employee-ID";
            EmployeeRepository.SaveEmployeeToList(emp);
            model.UpdateEmployeeList(new UpdateEmployeeListMessage());

            Assert.AreNotEqual(expected, model.EmployeeList.Count);
        }

        [TestMethod]
        public void TestRemoveEmployeeFromList() {
            EmployeeListViewModel model = new EmployeeListViewModel();

            // Add 2 employees
            Employee emp = EmployeeRepository.DefaultEmployee();
            emp.ID = "new-employee-ID-number-1";
            Employee emp2 = EmployeeRepository.DefaultEmployee();
            emp2.ID = "new-employee-ID-number-2";

            EmployeeRepository.SaveEmployeeToList(emp);
            EmployeeRepository.SaveEmployeeToList(emp2);

            model.UpdateEmployeeList(new UpdateEmployeeListMessage());
            int expected = model.EmployeeList.Count;
            model.RemoveEmployeeFromList(emp2.ID);

            Assert.AreNotEqual(expected, model.EmployeeList.Count);
        }
    }
}
