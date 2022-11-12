using Autofac;
using GetGroupHoldingTask.Application.Interfases.UseCases.V1_0.CustomerUseCases;
using GetGroupHoldingTask.Application.UseCases.V1_0.CustomerUseCases;
using SharedKernal.Middlewares.Basees;

namespace GetGroupHoldingTask.Infrastructure.DependencyResolution
{
    internal class ServiceModule : Module
    {
        internal static void Initialize(ContainerBuilder container)
        {
            ResolveService(container);
        }

        private static void ResolveService(ContainerBuilder builder)
        {
            var allUseCaseInterfaces = typeof(ICustomerSearchUseCase).Assembly.GetTypes()
                .Where(t => t.IsInterface && (IsAssignableToGenericType(t, typeof(IBaseUseCase<,>)) || IsAssignableToGenericType(t, typeof(IBaseUseCase<>)))).ToList();

            var allUseCaseClasses = typeof(CustomerSearchUseCase).Assembly.GetTypes()
                .Where(t => t.IsClass && t.IsAssignableTo(typeof(BaseUseCase))).ToList();

            foreach (var useCaseInterface in allUseCaseInterfaces)
            {
                var useCaseImplementation = allUseCaseClasses.FirstOrDefault(c => c.IsAssignableTo(useCaseInterface));
                if (useCaseImplementation is not null)
                {
                    builder.RegisterType(useCaseImplementation).As(useCaseInterface).PropertiesAutowired()
                        .InstancePerLifetimeScope();
                }
            }
        }

        public static bool IsAssignableToGenericType(Type givenType, Type genericType)
        {
            var interfaceTypes = givenType.GetInterfaces();

            foreach (var it in interfaceTypes)
            {
                if (it.IsGenericType && it.GetGenericTypeDefinition() == genericType)
                    return true;
            }

            if (givenType.IsGenericType && givenType.GetGenericTypeDefinition() == genericType)
                return true;

            var baseType = givenType.BaseType;
            return baseType != null && IsAssignableToGenericType(baseType, genericType);
        }

    }
}