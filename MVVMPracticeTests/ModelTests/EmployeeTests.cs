using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVVMPractice.Models;

namespace MVVMPracticeTests.ModelTests {
    [TestClass]
    public class EmployeeTests {
        [TestMethod]
        public void TestEmployee() {
            Employee emp = new Employee();

            Assert.IsNotNull(emp.ID);
        }
    }
}
