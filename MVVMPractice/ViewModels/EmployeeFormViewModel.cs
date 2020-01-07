using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using MVVMPractice.Models;
using MVVMPractice.Services;

namespace MVVMPractice.ViewModels {
    public class EmployeeFormViewModel {
        public Employee Employee { get; set; } = new Employee();
        public ICommand SaveCommand { get; set; }

        public EmployeeFormViewModel() {
            SaveCommand = new RelayCommand(SaveEmployee);
        }

        public void SaveEmployee() {
            EmployeeRepository.SaveEmployee(Employee);
        }
    }
}
