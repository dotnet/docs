---
title: "Tutorial: Hello world"
description: Explore the hello world tutorial project written with .NET Orleans.
ms.date: 03/30/2025
ms.topic: tutorial
ms.service: orleans
---

# Tutorial: Hello world

This overview ties into the [Hello World sample application](https://github.com/dotnet/samples/tree/main/orleans/HelloWorld).

The main concepts of Orleans involve a silo, a client, and one or more grains. Creating an Orleans app involves configuring the silo, configuring the client, and writing the grains.

## Configure the silo

Configure silos programmatically via `ISiloBuilder` and several supplemental option classes. You can find a list of all options at [List of options classes](../host/configuration-guide/list-of-options-classes.md).

```csharp
static async Task<ISiloHost> StartSilo(string[] args)
{
    var builder = Host.CreateApplicationbuilder(args)
        UseOrleans(c =>
        {
            c.UseLocalhostClustering()
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
        });

    var host = builder.Build();
    await host.StartAsync();

    return host;
}
```

| Option                      | Used for |
| --------------------------- | -------- |
| `.UseLocalhostClustering()` | Configures the client to connect to a silo on the localhost. |
| `ClusterOptions`            | `ClusterId` is the name for the Orleans cluster; it must be the same for the silo and client so they can communicate. `ServiceId` is the ID used for the application and must not change across deployments. |
| `EndpointOptions`           | Tells the silo where to listen. For this example, use `loopback`. |
| `ConfigureApplicationParts` | Adds the grain class and interface assembly as application parts to your Orleans application. |

After loading the configurations, build the `ISiloHost` and then start it asynchronously.

## Configure the client

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

| Option                      | Used for               |
| --------------------------- | ---------------------- |
| `.UseLocalhostClustering()` | Same as for `SiloHost` |
| `ClusterOptions`            | Same as for `SiloHost` |

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
