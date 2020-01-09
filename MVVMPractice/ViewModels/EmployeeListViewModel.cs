using System.Collections.ObjectModel;
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

        public EmployeeListViewModel() {
            EmployeeList = new ObservableCollection<Employee>(EmployeeRepository.GetEmployeeList());
            Messenger.Default.Register<UpdateEmployeeListMessage>(this, UpdateEmployeeList);

            ListSelectionChanged = new RelayCommand<Employee>((emp) => EmployeeListSelectionChanged(emp));

        private void EmployeeListSelectionChanged(Employee employee) {
            Messenger.Default.Send(new UpdateEmployeeFormMessage { Employee = employee });
        }
        }

        private void UpdateEmployeeList(UpdateEmployeeListMessage message) {
            EmployeeList.Add(message.Employee);
        }
    }
}
