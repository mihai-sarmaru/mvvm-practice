using System;
using System.Globalization;
using System.Windows.Controls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVVMPractice.ValidationRules;

namespace MVVMPracticeTests.ValidationRuleTests {
    [TestClass]
    public class IntegerMinMaxRuleTests {
        [TestMethod]
        public void TestValidate() {
            IntegerMinMaxRule minMaxRule = new IntegerMinMaxRule() { Min = 20, Max = 100 };

            ValidationResult result = minMaxRule.Validate(50, CultureInfo.InvariantCulture);
            Assert.IsFalse(result.IsValid);

            result = minMaxRule.Validate("10", CultureInfo.InvariantCulture);
            Assert.IsFalse(result.IsValid);

            result = minMaxRule.Validate("110", CultureInfo.InvariantCulture);
            Assert.IsFalse(result.IsValid);

            result = minMaxRule.Validate(true, CultureInfo.InvariantCulture);
            Assert.IsFalse(result.IsValid);

            result = minMaxRule.Validate("50", CultureInfo.InvariantCulture);
            Assert.IsTrue(result.IsValid);
        }
    }
}
