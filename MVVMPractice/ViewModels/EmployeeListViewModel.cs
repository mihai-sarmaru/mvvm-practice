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

        public EmployeeListViewModel() {
            EmployeeList = new ObservableCollection<Employee>(EmployeeRepository.GetEmployeeList());
            Messenger.Default.Register<UpdateEmployeeListMessage>(this, UpdateEmployeeList);
        }

        private void UpdateEmployeeList(UpdateEmployeeListMessage message) {
            EmployeeList.Add(message.Employee);
        }
    }
}
