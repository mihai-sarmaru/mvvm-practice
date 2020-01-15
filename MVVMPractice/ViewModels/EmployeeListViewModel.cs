using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
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
        private ICollectionView employeeListView;
        private string employeeFilter;

        public EmployeeRepository EmployeeRepo { get; set; }

        public ObservableCollection<Employee> EmployeeList { get; set; }
        public ICommand ListSelectionChanged { get; set; }
        public ICommand RemoveEmployeeCommand { get; set; }

        public string EmployeeFilter {
            get { return employeeFilter; }
            set {
                if (value != employeeFilter) {
                    employeeFilter = value;
                    employeeListView.Refresh();
                }
            }
        }

        public EmployeeListViewModel() {
            EmployeeRepo = new EmployeeRepository();
            EmployeeList = new ObservableCollection<Employee>(EmployeeRepo.GetEmployeeList());
            Messenger.Default.Register<UpdateEmployeeListMessage>(this, UpdateEmployeeList);

            ListSelectionChanged = new RelayCommand<Employee>((emp) => EmployeeListSelectionChanged(emp));
            RemoveEmployeeCommand = new RelayCommand<string>((empID) => RemoveEmployeeFromList(empID));

            SetEmployeeFilter();
        }

        public void EmployeeListSelectionChanged(Employee employee) {
            Messenger.Default.Send(new UpdateEmployeeFormMessage { Employee = employee });
        }

        public void RemoveEmployeeFromList(string employeeID) {
            Employee employeeToRemove = EmployeeList.Single(empID => empID.ID == employeeID);
            EmployeeList.Remove(employeeToRemove);
            EmployeeRepo.RemoveEmployeeFromList(employeeToRemove);
        }

        public void UpdateEmployeeList(UpdateEmployeeListMessage message) {
            EmployeeList = new ObservableCollection<Employee>(EmployeeRepo.GetEmployeeList());
            SetEmployeeFilter();
        }

        private void SetEmployeeFilter() {
            employeeListView = CollectionViewSource.GetDefaultView(EmployeeList);
            employeeListView.Filter = o => string.IsNullOrEmpty(EmployeeFilter) ? true : ((Employee)o).Name.ToLower().Contains(EmployeeFilter);
        }
    }
}
