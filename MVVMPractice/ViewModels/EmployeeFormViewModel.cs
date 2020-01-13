using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MVVMPractice.Messages;
using MVVMPractice.Models;
using MVVMPractice.Services;
using PropertyChanged;

namespace MVVMPractice.ViewModels {
    [AddINotifyPropertyChangedInterface]
    public class EmployeeFormViewModel {
        public Employee Employee { get; set; } = new Employee();
        public ICommand SaveCommand { get; set; }
        public ICommand NewCommand { get; set; }

        public EmployeeFormViewModel() {
            SaveCommand = new RelayCommand(SaveEmployee);
            NewCommand = new RelayCommand(ClearForm);
            Messenger.Default.Register<UpdateEmployeeFormMessage>(this, UpdateEmployee);
        }

        public void UpdateEmployee(UpdateEmployeeFormMessage message) {
            Employee = message.Employee;
        }

        public void SaveEmployee() {
            EmployeeRepository.SaveEmployeeToList(Employee);
            Messenger.Default.Send(new UpdateEmployeeListMessage());
        }

        public void ClearForm() {
            Employee = new Employee();
        }
    }
}
