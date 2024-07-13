---
title: "Tutorial: Hello world"
description: Explore the hello world tutorial project written with .NET Orleans.
ms.date: 07/03/2024
---

# Tutorial: Hello world

This overview ties into the [Hello World sample application](https://github.com/dotnet/samples/tree/main/orleans/HelloWorld).

The main concepts of Orleans involve a silo, a client, and one or more grains.
Creating an Orleans app involves configuring the silo, configuring the client, and writing the grains.

## Configure the silo

Silos are configured programmatically via `SiloHostBuilder` and several supplemental option classes.
A list of all of the options can be found [here.](../host/configuration-guide/list-of-options-classes.md)

```csharp
static async Task<ISiloHost> StartSilo()
{
    var builder = new HostBuilder()
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

| Option | Used for |
|--|--|
| `.UseLocalhostClustering()` | Configures the client to connect to a silo on the localhost. |
| `ClusterOptions` | ClusterId is the name for the Orleans cluster must be the same for silo and client so they can talk to each other. ServiceId is the ID used for the application and it must not change across deployments |
| `EndpointOptions` | This tells the silo where to listen. For this example, we are using a `loopback`. |
| `ConfigureApplicationParts` | Adds the grain class and interface assembly as application parts to your Orleans application. |

After loading the configurations, the SiloHost is built and then started asynchronously.

## Configuring the client

Similar to the silo, the client is configured via `ClientBuilder` and a similar collection of option classes.

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
|-----------------------------|------------------------|
| `.UseLocalhostClustering()` | Same as for `SiloHost` |
| `ClusterOptions`            | Same as for `SiloHost` |

A more in-depth guide to configuring your client can be found [in the Client Configuration section of the Configuration Guide.](../host/configuration-guide/client-configuration.md)

## Writing a grain

Grains are the key primitives of the Orleans programming model. Grains are the building blocks of an Orleans application, they are atomic units of isolation, distribution, and persistence. Grains are objects that represent application entities. Just like in the classic Object-Oriented Programming, a grain encapsulates the state of an entity and encodes its behavior in the code logic. Grains can hold references to each other and interact by invoking each other's methods exposed via interfaces.

You can read more about them in the [Core Concepts section of the Orleans documentation.](../grains/index.md)

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

A grain class implements one or more grain interfaces, as you can read [here, in the Grains section.](../grains/index.md)

```csharp
namespace HelloWorld.Interfaces;

public interface IHello : Orleans.IGrainWithIntegerKey
{
    Task<string> SayHello(string greeting);
}
```

## How the parts work together

This programming model is built as part of our core concept of distributed Object-Oriented Programming. SiloHost is started first.
Then, the OrleansClient program is started. The Main method of OrleansClient calls the method that starts the client, `StartClientWithRetries()`. The client is passed to the `DoClientWork()` method.

```csharp
static async Task DoClientWork(IClusterClient client)
{
    var friend = client.GetGrain<IHello>(0);
    var response = await friend.SayHello("Good morning, my friend!");
    Console.WriteLine($"\n\n{response}\n\n");
}
```

At this point, `OrleansClient` creates a reference to the `IHello` grain and calls its `SayHello()` method through its interface, `IHello`. This call activates the grain in the silo. `OrleansClient` sends a greeting to the activated grain. The grain returns the greeting as a response to `OrleansClient`, which `OrleansClient` displays on the console.

## Running the sample app

To run the sample app, refer to the [Readme](https://github.com/dotnet/samples/tree/main/orleans/HelloWorld).
