using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVVMPractice.Converters;

namespace MVVMPracticeTests.ConverterTests {
    [TestClass]
    public class EmployeeFormConverterTests {
        [TestMethod]
        public void TestConvert() {
            EmployeeFormConverter converter = new EmployeeFormConverter();
            Assert.AreEqual(7, (int)converter.Convert(7, typeof(int), null, CultureInfo.InvariantCulture));
            Assert.AreEqual(string.Empty, (string)converter.Convert(0, typeof(int), null, CultureInfo.InvariantCulture));
            Assert.AreEqual("hello", converter.Convert("hello", typeof(int), null, CultureInfo.InvariantCulture));
        }
    }
}
