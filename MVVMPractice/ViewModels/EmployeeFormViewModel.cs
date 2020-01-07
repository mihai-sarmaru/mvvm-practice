using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using MVVMPractice.Models;

namespace MVVMPractice.ViewModels {
    public class EmployeeFormViewModel {
        public Employee Employee { get; set; }
        public ICommand SaveCommand { get; set; }

        public EmployeeFormViewModel() {
            SaveCommand = new RelayCommand(SaveEmployee);
        }

        public void SaveEmployee() {
        }
    }
}
