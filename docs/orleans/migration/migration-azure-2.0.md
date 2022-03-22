---
title: Migration from Orleans 1.5 to 2.0 when using Azure
description: Learn how to migrate forward from Orleans 1.5 to 2.0 when using Azure.
ms.date: 03/21/2022
---

# Migration from Orleans 1.5 to 2.0 when using Azure

In Orleans 2.0, the configuration of silos and clients has changed. In Orleans 1.5 we used to have a monolith object that handled all the configuration pieces. Providers were added to that configuration object too. In Orleans 2.0, the configuration process is organized around <xref:Orleans.Hosting.SiloHostBuilder>, similar to how it is done in ASP.NET Core with the <xref:Microsoft.AspNetCore.Hosting.WebHostBuilder>.

In Orleans 1.5, the configuration for Azure looked like this:

```csharp
var config = AzureSilo.DefaultConfiguration();
config.AddMemoryStorageProvider();
config.AddAzureTableStorageProvider(
    "AzureStore",
    RoleEnvironment.GetConfigurationSettingValue("DataConnectionString"));
```

The `AzureSilo` class exposes a static method named DefaultConfiguration() that was used for loading configuration XML file.
This way of configuring a silo is deprecated but still supported via the [legacy support package](https://www.nuget.org/packages/Microsoft.Orleans.Core.Legacy/).

In Orleans 2.0, the configuration is completely programmatic. The new configuration API  looks like this:

```csharp
var proxyPort =
    RoleEnvironment.CurrentRoleInstance
        .InstanceEndpoints["OrleansProxyEndpoint"]
        .IPEndpoint
        .Port;

var siloEndpoint =
    RoleEnvironment.CurrentRoleInstance
        .InstanceEndpoints["OrleansSiloEndpoint"]
        .IPEndpoint;

var connectionString =
    RoleEnvironment.GetConfigurationSettingValue("DataConnectionString");
var deploymentId = RoleEnvironment.DeploymentId;

var builder = new HostBuilder()
    .UseOrleans(c =>
    {
        c.Configure<ClusterOptions>(options =>
            {
                options.ClusterId = deploymentId;
                options.ServiceIs = "my-app";
            })
        .Configure<SiloOptions>(options => options.SiloName = Name)
        .ConfigureEndpoints(siloEndpoint.Address, siloEndpoint.Port, proxyPort)
        .UseAzureStorageClustering(options => options.ConnectionString = connectionString)
        .UseAzureTableReminderService(connectionString)
        .AddAzureQueueStreams<AzureQueueDataAdapterV2>(
            "StreamProvider",
            configurator => configurator.Configure(configure =>
            {
                configure.ConnectionString = connectionString;
            }))
        .AddAzureTableGrainStorage("AzureTableStore");
    });
```

## Migrate from `AzureSilo` to `ISiloHost`

In Orleans 1.5, the `AzureSilo` class was the recommended way to host a silo in an Azure Worker role. This is still supported via the [`Microsoft.Orleans.Hosting.AzureCloudServices` NuGet package](https://www.nuget.org/packages/Microsoft.Orleans.Hosting.AzureCloudServices/).

```csharp
public class WorkerRole : RoleEntryPoint
{
    AzureSilo _silo;

    public override bool OnStart()
    {
        // Other silo initialization, for example: Azure diagnostics
        return base.OnStart();
    }

    public override void OnStop()
    {
        _silo.Stop();
        base.OnStop();
    }

    public override void Run()
    {
        var config = AzureSilo.DefaultConfiguration();
        config.AddMemoryStorageProvider();
        config.AddAzureTableStorageProvider(
            "AzureStore",
            RoleEnvironment.GetConfigurationSettingValue("DataConnectionString"));

        // Configure storage providers
        _silo = new AzureSilo();
        bool ok = _silo.Start(config);

        _silo.Run(); // Call will block until silo is shutdown
    }
}
```

Orleans 2.0 provides a more flexible and modular API for configuring and hosting a silo via <xref:Orleans.Hosting.SiloHostBuilder> and <xref:Orleans.Hosting.ISiloHost>.

```csharp
public class WorkerRole : RoleEntryPoint
{
    private readonly CancellationTokenSource _cancellationTokenSource = new();
    private readonly ManualResetEvent _runCompleteEvent = new(false);

    private ISiloHost _host;
    private ISiloHostBuilder _builder;

    public override void Run()
    {
        try
        {
            RunAsync(_cancellationTokenSource.Token).Wait();
            _runCompleteEvent.WaitOne();
        }
        finally
        {
            _runCompleteEvent.Set();
        }
    }

    public override bool OnStart()
    {
        //builder is the SiloHostBuilder from the first section
        // Build silo host, so that any errors will restart the role instance
        _host = _builder.Build();

        return base.OnStart();
    }

    public override void OnStop()
    {
        _cancellationTokenSource.Cancel();
        _runCompleteEvent.WaitOne();

        _host.StopAsync().Wait();

        base.OnStop();
    }

    private Task RunAsync(CancellationToken cancellationToken)
    {
        return _host.StartAsync(cancellationToken);
    }
}
```
