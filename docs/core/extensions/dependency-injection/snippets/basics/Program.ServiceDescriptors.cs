using Microsoft.Extensions.DependencyInjection;

internal partial class Program
{
    internal static void AddConsole(IServiceCollection services)
    {
        // <console>
        services.Add(ServiceDescriptor.Describe(
            serviceType: typeof(IConsole),
            implementationFactory: static _ => new DefaultConsole
            {
                IsEnabled = true
            },
            lifetime: ServiceLifetime.Singleton));
        // </console>
    }

    public static void AddGreetingService(IServiceCollection services)
    {
        // <greeting>
        services.Add(ServiceDescriptor.Describe(
            serviceType: typeof(IGreetingService),
            implementationType: typeof(DefaultGreetingService),
            lifetime: ServiceLifetime.Singleton));
        // </greeting>
    }

    public static void AddFarewellService(IServiceCollection services)
    {
        // <farewell>
        services.Add(ServiceDescriptor.Describe(
            serviceType: typeof(FarewellService),
            implementationType: typeof(FarewellService),
            lifetime: ServiceLifetime.Singleton));
        // </farewell>
    }
}
