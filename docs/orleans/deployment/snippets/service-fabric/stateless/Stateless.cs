using System.Fabric;
using Microsoft.Extensions.Hosting;

namespace ServiceFabric.HostingExample;

/// <summary>
/// An instance of this class is created for each service instance by the Service Fabric runtime.
/// </summary>
internal sealed class Stateless : HostedStatelessService
{
    public Stateless(StatelessServiceContext context)
        : base(context)
    { }

    protected override string ServiceName => nameof(Stateless);

    protected override async Task<IHost> CreateHostAsync(StatelessServiceContext context)
    {
        await Task.CompletedTask;
        
        return Host.CreateDefaultBuilder()
            .UseOrleans((_, builder) =>
            {
                // Realistically, you'd want to use table storage
                // or SQL Server for clustering.
                builder.UseLocalhostClustering();                

                // Service Fabric manages port allocations, so update the configuration using those ports.
                // Gather configuration from Service Fabric.
                var activation = Context.CodePackageActivationContext;
                var endpoints = activation.GetEndpoints();

                // These endpoint names correspond to TCP endpoints specified in ServiceManifest.xml
                var siloEndpoint = endpoints["OrleansSiloEndpoint"];
                var gatewayEndpoint = endpoints["OrleansProxyEndpoint"];
                var hostname = Context.NodeContext.IPAddressOrFQDN;
                builder.ConfigureEndpoints(hostname, siloEndpoint.Port, gatewayEndpoint.Port);
            })
            .Build();
    }
}
