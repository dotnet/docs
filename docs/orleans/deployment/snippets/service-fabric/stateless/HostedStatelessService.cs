using System.Fabric;
using Microsoft.Extensions.Hosting;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;

namespace ServiceFabric.HostingExample;

public abstract class HostedStatelessService : StatelessService
{
    private const string HttpsEndpoint = nameof(HttpsEndpoint);

    protected abstract string ServiceName { get; }

    protected int HttpsPort => GetPortFromManifest(HttpsEndpoint);

    protected HostedStatelessService(StatelessServiceContext serviceContext) : base(serviceContext)
    {
    }

    protected int GetPortFromManifest(string portName) =>
        Context.CodePackageActivationContext.GetEndpoint(portName).Port;

    protected abstract Task<IHost> CreateHostAsync(StatelessServiceContext context);

    /// <inheritdoc/>
    protected sealed override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
    {
        // Create a listener which creates and runs an IHost
        yield return new ServiceInstanceListener(
            context =>
            new HostedServiceCommunicationListener(
                () => CreateHostAsync(context)), nameof(HostedServiceCommunicationListener));
    }
}
