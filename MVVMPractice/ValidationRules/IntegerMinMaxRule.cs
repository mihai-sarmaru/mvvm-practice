using System;
using System.Globalization;
using System.Windows.Controls;

namespace MVVMPractice.ValidationRules {
    public class IntegerMinMaxRule : ValidationRule {

        public int Min { get; set; }
        public int Max { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo) {
            int integerValue = 0;
            try {
                if (((string)value).Length > 0) integerValue = int.Parse((string)value);
            } catch (Exception e) {
                return new ValidationResult(false, $"Illegal characters or {e.Message}");
            }

            if (integerValue < Min || integerValue > Max) {
                return new ValidationResult(false, $"Please enter a value in the range: {Min}-{Max}.");
            }

            return ValidationResult.ValidResult;
        }
    }
}
