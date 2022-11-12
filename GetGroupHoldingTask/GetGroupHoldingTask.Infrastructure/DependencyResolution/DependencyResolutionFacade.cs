using Autofac;

namespace GetGroupHoldingTask.Infrastructure.DependencyResolution
{
    public static class DependencyResolutionFacade
    {
        public static void Initialize(ContainerBuilder container)
        {
            DataModule.Initialize(container);
            CommonModule.Initialize(container);
            ServiceModule.Initialize(container);
        }
    }
}