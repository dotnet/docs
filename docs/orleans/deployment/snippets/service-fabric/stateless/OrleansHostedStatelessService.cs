using System.Fabric;
using Microsoft.Extensions.Hosting;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;

namespace ServiceFabric.HostingExample;

public sealed class OrleansHostedStatelessService : StatelessService
{
    private const string HttpsEndpoint = nameof(HttpsEndpoint);
    private const string ServiceName = nameof(OrleansHostedStatelessService);

    private readonly Func<StatelessServiceContext, Task<IHost>> _createHost;

    private int HttpsPort => GetPortFromManifest(HttpsEndpoint);

    public OrleansHostedStatelessService(
        Func<StatelessServiceContext, Task<IHost>> createHost, StatelessServiceContext serviceContext)
        : base(serviceContext) =>
        _createHost = createHost ?? throw new ArgumentNullException(nameof(createHost));

    private int GetPortFromManifest(string portName) =>
        Context.CodePackageActivationContext.GetEndpoint(portName).Port;    

    /// <inheritdoc/>
    protected sealed override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
    {
        // Create a listener which creates and runs an IHost
        yield return new ServiceInstanceListener(
            context => new HostedServiceCommunicationListener(() => _createHost(context)),
            nameof(HostedServiceCommunicationListener));
    }
}
