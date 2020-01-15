using MVVMPractice.Services;
using Unity;
using Unity.Lifetime;

namespace MVVMPractice.Containers {
    public static class ContainerHelper {
        public static IUnityContainer Container { get; private set; }

        static ContainerHelper() {
            Container = new UnityContainer();
            Container.RegisterType<IEmployeeRepository, EmployeeRepository>(new ContainerControlledLifetimeManager());
        }
    }
}
