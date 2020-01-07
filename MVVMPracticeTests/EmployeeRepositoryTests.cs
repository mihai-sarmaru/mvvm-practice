using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    }
}
