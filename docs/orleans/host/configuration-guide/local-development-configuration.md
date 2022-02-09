---
title: Local development configuration
description: Learn how to configure .NET Orleans for local development.
ms.date: 02/01/2022
---

# Local development configuration

For a working sample application that targets Orleans 3.0, see [Orleans: Hello World](https://github.com/dotnet/orleans/tree/main/samples/HelloWorld). The sample hosts the client and the silo in .NET console applications that work in different platforms, while the grains and interfaces target .NET Standard 2.0.

> [!TIP]
> For older versions of Orleans, please see [Orleans sample projects](https://github.com/dotnet/orleans/tree/main/samples).

## Silo configuration

For local development, please refer to the below example of how to configure a silo for that case. It configures and starts a silo listening on the `loopback` address, `11111` and `30000` as silo and gateway ports respectively.

Add the `Microsoft.Orleans.Server` NuGet meta-package to the project. After you get comfortable with the API, you can pick and choose which exact packages included in `Microsoft.Orleans.Server` you need, and reference them instead.

```powershell
Install-Package Microsoft.Orleans.Server
```

You need to configure `ClusterOptions` via `ISiloBuilder.Configure` method, specify that you want `DevelopmentClustering` as your clustering choice with this silo being the primary, and then configure silo endpoints.

`ConfigureApplicationParts` call explicitly adds the assembly with grain classes to the application setup. It also adds any referenced assembly due to the `WithReferences` extension. After these steps are completed, the silo host gets built and the silo gets started.

You can create an empty console application project targeting .NET Framework 4.6.1 or higher for hosting a silo, as well as a .NET console application.

Here is an example of how a local silo can be started:

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
    var builder = new SiloHostBuilder()
        .UseLocalhostClustering()
        .Configure<ClusterOptions>(options =>
        {
            options.ClusterId = "dev";
            options.ServiceId = "MyAwesomeService";
        })
        .Configure<EndpointOptions>(
            options => options.AdvertisedIPAddress = IPAddress.Loopback)
        .ConfigureLogging(logging => logging.AddConsole());
    
    var host = builder.Build();
    await host.StartAsync();

    return host;
}
```

## Client configuration

For local development, please refer to the below example of how to configure a client for that case.
It configures a client that would connect to a `loopback` silo.

Add the `Microsoft.Orleans.Client` NuGet meta-package to the project.
After you get comfortable with the API, you can pick and choose which exact packages included in `Microsoft.Orleans.Client` you actually need and reference them instead.

```powershell
Install-Package Microsoft.Orleans.Client
```

You need to configure `ClientBuilder` with a cluster ID that matches the one you specified for the local silo and specify static clustering as your clustering choice pointing it to the gateway port of the silo

`ConfigureApplicationParts` call explicitly adds the assembly with grain interfaces to the application setup.

After these steps are completed, we can build the client and `Connect()` method on it to connect to the cluster.

You can create an empty console application project targeting .NET Framework 4.6.1 or higher for running a client or reuse the console application project you created for hosting a silo.

Here is an example of how a client can connect to a local silo:

```csharp
client = new ClientBuilder()
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
