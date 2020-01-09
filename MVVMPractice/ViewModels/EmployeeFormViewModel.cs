using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MVVMPractice.Messages;
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
            EmployeeRepository.SaveEmployeeToList(Employee);
            Messenger.Default.Send(new UpdateEmployeeListMessage { Employee = this.Employee });
        }
    }
}
