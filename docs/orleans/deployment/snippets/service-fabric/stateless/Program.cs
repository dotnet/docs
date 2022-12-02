using Microsoft.ServiceFabric.Services.Runtime;
using ServiceFabric.HostingExample;

try
{
    // The ServiceManifest.XML file defines one or more service type names.
    // Registering a service maps a service type name to a .NET type.
    // When Service Fabric creates an instance of this service type,
    // an instance of the class is created in this host process.
    await ServiceRuntime.RegisterServiceAsync(
        "Orleans.ServiceFabric.Stateless",
        context => new Stateless(context));

    ServiceEventSource.Current.ServiceTypeRegistered(
        Environment.ProcessId, typeof(Stateless).Name);

    // Prevents this host process from terminating so services keep running.
    await Task.Delay(Timeout.Infinite);
}
catch (Exception ex)
{
    ServiceEventSource.Current.ServiceHostInitializationFailed(ex.ToString());
    throw;
}
