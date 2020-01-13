using System;
using System.Globalization;
using System.Windows.Controls;

namespace MVVMPractice.ValidationRules {
    public class NotEmptyRule : ValidationRule {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo) {
            if (value == null || ((string)value).Length == 0) return new ValidationResult(false, $"Field cannot be empty.");
            return ValidationResult.ValidResult;
        }
    }
}
