---
title: "Tutorial: Hello world"
description: Explore the hello world tutorial project written with .NET Orleans.
ms.date: 01/21/2026
ms.topic: tutorial
zone_pivot_groups: orleans-version
---

# Tutorial: Hello world

This overview ties into the [Hello World sample application](https://github.com/dotnet/samples/tree/main/orleans/HelloWorld).

The main concepts of Orleans involve a silo, a client, and one or more grains. Creating an Orleans app involves configuring the silo, configuring the client, and writing the grains.

## Configure the silo

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-10-0,orleans-9-0,orleans-8-0,orleans-7-0"
<!-- markdownlint-enable MD044 -->

Configure silos programmatically via `ISiloBuilder` and several supplemental option classes. You can find a list of all options at [List of options classes](../host/configuration-guide/list-of-options-classes.md).

```csharp
using Microsoft.Extensions.Hosting;

await Host.CreateDefaultBuilder(args)
    .UseOrleans(siloBuilder =>
    {
        siloBuilder.UseLocalhostClustering()
            .Configure<ClusterOptions>(options =>
            {
                options.ClusterId = "dev";
                options.ServiceId = "HelloWorldApp";
            })
            .Configure<EndpointOptions>(
                options => options.AdvertisedIPAddress = IPAddress.Loopback)
            .ConfigureLogging(logging => logging.AddConsole());
    })
    .RunConsoleAsync();
```

The preceding code:

- Creates a default host builder.
- Calls `UseOrleans` to configure the silo.
- Uses localhost clustering for local development.
- Configures the cluster and service IDs.
- Configures the endpoint to listen on loopback.
- Adds console logging.

:::zone-end

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-3-x"
<!-- markdownlint-enable MD044 -->

Configure silos programmatically via `ISiloHostBuilder` and several supplemental option classes. You can find a list of all options at [List of options classes](../host/configuration-guide/list-of-options-classes.md).

```csharp
static async Task<ISiloHost> StartSilo(string[] args)
{
    var siloHostBuilder = new SiloHostBuilder()
        .UseLocalhostClustering()
        .Configure<ClusterOptions>(options =>
        {
            options.ClusterId = "dev";
            options.ServiceId = "HelloWorldApp";
        })
        .Configure<EndpointOptions>(
            options => options.AdvertisedIPAddress = IPAddress.Loopback)
        .ConfigureApplicationParts(
            parts => parts.AddApplicationPart(typeof(HelloGrain).Assembly).WithReferences())
        .ConfigureLogging(logging => logging.AddConsole());

    var host = siloHostBuilder.Build();
    await host.StartAsync();

    return host;
}
```

:::zone-end

| Option                      | Used for |
| --------------------------- | -------- |
| `.UseLocalhostClustering()` | Configures the client to connect to a silo on the localhost. |
| `ClusterOptions`            | `ClusterId` is the name for the Orleans cluster; it must be the same for the silo and client so they can communicate. `ServiceId` is the ID used for the application and must not change across deployments. |
| `EndpointOptions`           | Tells the silo where to listen. For this example, use `loopback`. |

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-3-x"
<!-- markdownlint-enable MD044 -->

| Option                      | Used for |
| --------------------------- | -------- |
| `ConfigureApplicationParts` | Adds the grain class and interface assembly as application parts to your Orleans application. This is not needed in Orleans 7.0+ as source generators handle this automatically. |

:::zone-end

After loading the configurations, build the host and then start it asynchronously.

## Configure the client

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-10-0,orleans-9-0,orleans-8-0,orleans-7-0"
<!-- markdownlint-enable MD044 -->

Similar to the silo, configure the client via `IClientBuilder` and a similar collection of option classes.

```csharp
using Microsoft.Extensions.Hosting;

using IHost host = Host.CreateDefaultBuilder(args)
    .UseOrleansClient(clientBuilder =>
    {
        clientBuilder.UseLocalhostClustering()
            .Configure<ClusterOptions>(options =>
            {
                options.ClusterId = "dev";
                options.ServiceId = "HelloWorldApp";
            })
            .ConfigureLogging(logging => logging.AddConsole());
    })
    .Build();

await host.StartAsync();

var client = host.Services.GetRequiredService<IClusterClient>();
Console.WriteLine("Client successfully connected to silo host");
```

The preceding code:

- Creates a default host builder.
- Calls `UseOrleansClient` to configure the client.
- Uses localhost clustering to connect to the local silo.
- Configures the cluster and service IDs to match the silo.
- Starts the host and retrieves the `IClusterClient` from the service provider.

:::zone-end

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-3-x"
<!-- markdownlint-enable MD044 -->

Similar to the silo, configure the client via `IClientBuilder` and a similar collection of option classes.

```csharp
static async Task<IClusterClient> StartClientWithRetries()
{
    attempt = 0;
    var client = new ClientBuilder()
        .UseLocalhostClustering()
        .Configure<ClusterOptions>(options =>
        {
            options.ClusterId = "dev";
            options.ServiceId = "HelloWorldApp";
        })
        .ConfigureLogging(logging => logging.AddConsole())
        .Build();

    await client.Connect(RetryFilter);
    Console.WriteLine("Client successfully connect to silo host");
    return client;
}
```

:::zone-end

| Option                      | Used for               |
| --------------------------- | ---------------------- |
| `.UseLocalhostClustering()` | Same as for the silo |
| `ClusterOptions`            | Same as for the silo |

Find a more in-depth guide to configuring your client in the [Client configuration](../host/configuration-guide/client-configuration.md) section of the Configuration Guide.

## Write a grain

Grains are the key primitives of the Orleans programming model. They are the building blocks of an Orleans application, serving as atomic units of isolation, distribution, and persistence. Grains are objects representing application entities. Just like in classic Object-Oriented Programming, a grain encapsulates an entity's state and encodes its behavior in code logic. Grains can hold references to each other and interact by invoking methods exposed via interfaces.

Read more about them in the [Grains](../grains/index.md) section of the Orleans documentation.

This is the main body of code for the Hello World grain:

```csharp
namespace HelloWorld.Grains;

public class HelloGrain : Orleans.Grain, IHello
{
    Task<string> IHello.SayHello(string greeting)
    {
        logger.LogInformation($"SayHello message received: greeting = '{greeting}'");
        return Task.FromResult($"You said: '{greeting}', I say: Hello!");
    }
}
```

A grain class implements one or more grain interfaces. For more information, see the [Grains](../grains/index.md) section.

```csharp
namespace HelloWorld.Interfaces;

public interface IHello : Orleans.IGrainWithIntegerKey
{
    Task<string> SayHello(string greeting);
}
```

## How the parts work together

This programming model builds on the core concept of distributed Object-Oriented Programming. Start the `ISiloHost` first. Then, start the `OrleansClient` program. The `Main` method of `OrleansClient` calls the method that starts the client, `StartClientWithRetries()`. Pass the client to the `DoClientWork()` method.

```csharp
static async Task DoClientWork(IClusterClient client)
{
    var friend = client.GetGrain<IHello>(0);
    var response = await friend.SayHello("Good morning, my friend!");
    Console.WriteLine($"\n\n{response}\n\n");
}
```

At this point, `OrleansClient` creates a reference to the `IHello` grain and calls its `SayHello()` method via the `IHello` interface. This call activates the grain in the silo. `OrleansClient` sends a greeting to the activated grain. The grain returns the greeting as a response to `OrleansClient`, which then displays it on the console.

## Run the sample app

To run the sample app, refer to the [Readme](https://github.com/dotnet/samples/tree/main/orleans/HelloWorld).
