using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MVVMPractice.Messages;
using MVVMPractice.Models;
using MVVMPractice.Services;
using PropertyChanged;

namespace MVVMPractice.ViewModels {
    [AddINotifyPropertyChangedInterface]
    public class EmployeeListViewModel {
        public ObservableCollection<Employee> EmployeeList { get; set; }
        public ICommand ListSelectionChanged { get; set; }
        public ICommand RemoveEmployeeCommand { get; set; }

        public EmployeeListViewModel() {
            EmployeeList = new ObservableCollection<Employee>(EmployeeRepository.GetEmployeeList());
            Messenger.Default.Register<UpdateEmployeeListMessage>(this, UpdateEmployeeList);

            ListSelectionChanged = new RelayCommand<Employee>((emp) => EmployeeListSelectionChanged(emp));
            RemoveEmployeeCommand = new RelayCommand<string>((empID) => RemoveEmployeeFromList(empID));
        }

        public void EmployeeListSelectionChanged(Employee employee) {
            Messenger.Default.Send(new UpdateEmployeeFormMessage { Employee = employee });
        }

        public void RemoveEmployeeFromList(string employeeID) {
            Employee employeeToRemove = EmployeeList.Single(empID => empID.ID == employeeID);
            EmployeeList.Remove(employeeToRemove);
            EmployeeRepository.RemoveEmployeeFromList(employeeToRemove);
        }

        public void UpdateEmployeeList(UpdateEmployeeListMessage message) {
            EmployeeList.Add(message.Employee);
        }
    }
}
