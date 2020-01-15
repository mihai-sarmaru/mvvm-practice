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
        private IEmployeeRepository _employeeRepo;
        public Employee Employee { get; set; } = new Employee();
        public ICommand SaveCommand { get; set; }
        public ICommand NewCommand { get; set; }

        public EmployeeFormViewModel(IEmployeeRepository employeeRepo) {
            _employeeRepo = employeeRepo;
            SaveCommand = new RelayCommand(SaveEmployee);
            NewCommand = new RelayCommand(ClearForm);
            Messenger.Default.Register<UpdateEmployeeFormMessage>(this, UpdateEmployee);
        }

        public void UpdateEmployee(UpdateEmployeeFormMessage message) {
            if (message.Employee != null) Employee = message.Employee;
        }

        public void SaveEmployee() {
            _employeeRepo.SaveEmployeeToList(Employee);
            Messenger.Default.Send(new UpdateEmployeeListMessage());
        }

        public void ClearForm() {
            Employee = new Employee();
        }
    }
}
