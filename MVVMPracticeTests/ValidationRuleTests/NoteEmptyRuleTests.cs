using System.Globalization;
using System.Windows.Controls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVVMPractice.ValidationRules;

namespace MVVMPracticeTests.ValidationRuleTests {
    [TestClass]
    public class NoteEmptyRuleTests {
        [TestMethod]
        public void TestValidate() {
            NotEmptyRule minMaxRule = new NotEmptyRule();

            ValidationResult result = minMaxRule.Validate(null, CultureInfo.InvariantCulture);
            Assert.IsFalse(result.IsValid);

            result = minMaxRule.Validate("", CultureInfo.InvariantCulture);
            Assert.IsFalse(result.IsValid);

            result = minMaxRule.Validate("Hello", CultureInfo.InvariantCulture);
            Assert.IsTrue(result.IsValid);
        }
    }
}
