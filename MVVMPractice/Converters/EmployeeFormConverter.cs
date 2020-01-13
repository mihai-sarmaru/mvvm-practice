using System;
using System.Globalization;
using System.Windows.Data;

namespace MVVMPractice.Converters {
    public class EmployeeFormConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return ConvertValues(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return ConvertValues(value);
        }

        private object ConvertValues(object value) {
            if (value is string) return value;
            return ((int)value == 0) ? string.Empty : value;
        }
    }
}
