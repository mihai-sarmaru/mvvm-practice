using MVVMPractice.Containers;
using MVVMPractice.Services;
using MVVMPractice.ViewModels;
using Unity;

namespace MVVMPractice {
    public class MainWindowViewModel {
        public object LeftContent { get; private set; }
        public object RightContent { get; private set; }
        public MainWindowViewModel() {
            LeftContent = ContainerHelper.Container.Resolve<EmployeeFormViewModel>();
            RightContent = ContainerHelper.Container.Resolve<EmployeeListViewModel>();
        }

    }
}
