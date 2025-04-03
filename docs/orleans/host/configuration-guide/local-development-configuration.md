---
title: Local development configuration
description: Learn how to configure .NET Orleans for local development.
ms.date: 07/03/2024
zone_pivot_groups: orleans-version
---

# Local development configuration

For a working sample application that targets Orleans 7.0, see [Orleans: Hello World](https://github.com/dotnet/samples/tree/main/orleans/HelloWorld). The sample hosts the client and the silo in .NET console applications that work in different platforms, while the grains and interfaces target .NET Standard 2.0.

> [!TIP]
> For older versions of Orleans, please see [Orleans sample projects](https://github.com/dotnet/samples/tree/main/orleans).

## Silo configuration

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-7-0"
<!-- markdownlint-enable MD044 -->

It's recommended to use the [Microsoft.Extensions.Hosting](https://www.nuget.org/packages/Microsoft.Extensions.Hosting) NuGet package to configure and run the silo. Also, when developing an Orleans silo you need the [Microsoft.Orleans.Server](https://www.nuget.org/packages/Microsoft.Orleans.Server) NuGet package. For local Orleans silo development, you configure localhost clustering, which is configured to use the loopback address. To use localhost clustering, call the <xref:Orleans.Hosting.CoreHostingExtensions.UseLocalhostClustering%2A> extension method. Consider this example _Program.cs_ file of the silo host:

```csharp
using Microsoft.Extensions.Hosting;

await Host.CreateDefaultBuilder(args)
    .UseOrleans(siloBuilder =>
    {
        siloBuilder.UseLocalhostClustering();
    })
    .RunConsoleAsync();
```

The preceding code:

- Creates a default host builder.
- Calls the `UseOrleans` extension method to configure the silo.
- Calls the `UseLocalhostClustering` extension method on the given <xref:Orleans.Hosting.ISiloBuilder> to configure the silo to use localhost clustering.
- Chains the `RunConsoleAsync` method to run the silo as a console application.

:::zone-end

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-3-x"
<!-- markdownlint-enable MD044 -->

For local development, refer to the below example of how to configure a silo for that case. It configures and starts a silo listening on the `loopback` address, `11111` and `30000` as silo and gateway ports respectively.

Add the `Microsoft.Orleans.Server` NuGet meta-package to the project.

```dotnetcli
dotnet package add Microsoft.Orleans.Server
```

You need to configure <xref:Orleans.Configuration.ClusterOptions> via <xref:Orleans.Hosting.ISiloBuilder> `Configure` method, specify that you want `LocalhostClustering` as your clustering choice with this silo being the primary, and then configure silo endpoints.

The <xref:Orleans.Hosting.SiloHostBuilderExtensions.ConfigureApplicationParts%2A> call explicitly adds the assembly with grain classes to the application setup. It also adds any referenced assembly due to the <xref:Orleans.ApplicationPartManagerExtensions.WithReferences%2A> extension. After these steps are completed, the silo host gets built and the silo gets started.

You can create an empty console application project targeting .NET Framework 4.6.1 or higher for hosting a silo, and a .NET console application.

Here's an example of how a local silo can be started:

```csharp
try
{
    var host = await BuildAndStartSiloAsync();

    Console.WriteLine("Press Enter to terminate...");
    Console.ReadLine();

    await host.StopAsync();
}
catch (Exception ex)
{
    Console.WriteLine(ex);
}

static async Task<ISiloHost> BuildAndStartSiloAsync()
{
    var host = new HostBuilder()
      .UseOrleans(builder =>
      {
          builder.UseLocalhostClustering()
              .Configure<ClusterOptions>(options =>
              {
                  options.ClusterId = "dev";
                  options.ServiceId = "MyAwesomeService";
              })
              .Configure<EndpointOptions>(
                  options => options.AdvertisedIPAddress = IPAddress.Loopback)
              .ConfigureLogging(logging => logging.AddConsole());
      })
      .Build();

    await host.StartAsync();

    return host;
}
```

:::zone-end

## Client configuration

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-7-0"
<!-- markdownlint-enable MD044 -->

It's recommended to use the [Microsoft.Extensions.Hosting](https://www.nuget.org/packages/Microsoft.Extensions.Hosting) NuGet package to configure and run clients (in addition to the silo). You also need the [Microsoft.Orleans.Client](https://www.nuget.org/packages/Microsoft.Orleans.Client) NuGet package. To use localhost clustering on the consuming client, call the <xref:Orleans.Hosting.ClientBuilderExtensions.UseLocalhostClustering%2A> extension method. Consider this example _Program.cs_ file of the client host:

```csharp
using Microsoft.Extensions.Hosting;

using IHost host = Host.CreateDefaultBuilder(args)
    .UseOrleansClient(client =>
    {
        client.UseLocalhostClustering();
    })
    .UseConsoleLifetime()
    .Build();

await host.StartAsync();
```

The preceding code:

- Creates a default host builder.
- Calls the `UseOrleansClient` extension method to configure the client.
- Calls the `UseLocalhostClustering` extension method on the given <xref:Orleans.Hosting.IClientBuilder> to configure the client to use localhost clustering.
- Calls the `UseConsoleLifetime` extension method to configure the client to use the console lifetime.
- Calls the `StartAsync` method on the `host` variable to start the client.

:::zone-end

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-3-x"
<!-- markdownlint-enable MD044 -->

For local development, refer to the below example of how to configure a client for that case. It configures a client that would connect to a `loopback` silo.

Add the `Microsoft.Orleans.Client` NuGet meta-package to the project. After you get comfortable with the API, you can pick and choose which exact packages included in `Microsoft.Orleans.Client` you actually need and reference them instead.

```powershell
Install-Package Microsoft.Orleans.Client
```

You need to configure <xref:Orleans.ClientBuilder> with a cluster ID that matches the one you specified for the local silo and specify static clustering as your clustering choice pointing it to the gateway port of the silo

`ConfigureApplicationParts` call explicitly adds the assembly with grain interfaces to the application setup.

After these steps are completed, we can build the client and `Connect()` method on it to connect to the cluster.

You can create an empty console application project targeting .NET Framework 4.6.1 or higher for running a client or reuse the console application project you created for hosting a silo.

Here's an example of how a client can connect to a local silo:

```csharp
var client = new ClientBuilder()
    .UseLocalhostClustering()
    .Configure<ClusterOptions>(options =>
    {
        options.ClusterId = "dev";
        options.ServiceId = "MyAwesomeService";
    })
    .ConfigureLogging(logging => logging.AddConsole())
var client = builder.Build();

await client.Connect();
```

:::zone-end
