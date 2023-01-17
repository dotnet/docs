---
title: Orleans clients
description: Learn how to write .NET Orleans clients.
ms.date: 01/13/2023
zone_pivot_groups: orleans-version
---

# Orleans clients

A client allows non-grain code to interact with an Orleans cluster. Clients allow application code to communicate with grains and streams hosted in a cluster. There are two ways to obtain a client, depending on where the client code is hosted: in the same process as a silo, or in a separate process. This article will discuss both options, starting with the recommended option: co-hosting the client code in the same process as the grain code.

## Co-hosted clients

If the client code is hosted in the same process as the grain code, then the client can be directly obtained from the hosting application's dependency injection container. In this case, the client communicates directly with the silo it is attached to and can take advantage of the extra knowledge that the silo has about the cluster.

This provides several benefits, including reducing network and CPU overhead as well as decreasing latency and increasing throughput and reliability. The client utilizes the silo's knowledge of the cluster topology and state and does not need to use a separate gateway. This avoids a network hop and serialization/deserialization round trip. This therefore also increases reliability, since the number of required nodes in between the client and the grain is minimized. If the grain is a [stateless worker grain](../grains/stateless-worker-grains.md) or otherwise happens to be activated on the silo where the client is hosted, then no serialization or network communication needs to be performed at all and the client can reap the additional performance and reliability gains. Co-hosting client and grain code also simplifies deployment and application topology by eliminating the need for two distinct application binaries to be deployed and monitored.

There are also detractors to this approach, primarily that the grain code is no longer isolated from the client process. Therefore, issues in client code, such as blocking IO or lock contention causing thread starvation can affect the performance of grain code. Even without code defects like the aforementioned, *noisy neighbor* effects can result simply by having the client code execute on the same processor as grain code, putting additional strain on CPU cache and additional contention for local resources in general. Additionally, identifying the source of these issues is now more difficult because monitoring systems cannot distinguish what is logically client code from grain code.

Despite these detractors, co-hosting client code with grain code is a popular option and the recommended approach for most applications. To elaborate, the aforementioned detractors are minimal in practice for the following reasons:

* Client code is often very *thin*, for example, translating incoming HTTP requests into grain calls, and therefore the *noisy neighbor* effects are minimal and comparable in cost to the otherwise required gateway.
* If a performance issue arises, the typical workflow for a developer involves tools such as CPU profilers and debuggers, which are still effective in quickly identifying the source of the issue despite having both client and grain code executing in the same process. In other words, metrics become more coarse and less able to precisely identify the source of an issue, but more detailed tools are still effective.

### Obtain a client from a host

If hosting using the [.NET Generic Host](../../core/extensions/generic-host.md), the client will be available in the host's [dependency injection](../../core/extensions/dependency-injection.md) container automatically and can be injected into services such as [ASP.NET controllers](/aspnet/core/mvc/controllers/actions) or <xref:Microsoft.Extensions.Hosting.IHostedService> implementations.

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-7-0"
<!-- markdownlint-enable MD044 -->

Alternatively, a client interface such as <xref:Orleans.IGrainFactory> can be obtained from <xref:Microsoft.Extensions.Hosting.IHost> (or the <xref:Orleans.IClusterClient.ServiceProvider?displayProperty=nameWithType>):

:::zone-end

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-3-x"
<!-- markdownlint-enable MD044 -->

Alternatively, a client interface such as <xref:Orleans.IGrainFactory> or <xref:Orleans.IClusterClient> can be obtained from <xref:Orleans.Hosting.ISiloHost>:

:::zone-end

```csharp
var client = host.Services.GetService<IClusterClient>();
await client.GetGrain<IMyGrain>(0).Ping();
```

## External clients

Client code can run outside of the Orleans cluster where grain code is hosted. Hence, an external client acts as a connector or conduit to the cluster and all grains of the application. Usually, clients are used on the frontend web servers to connect to an Orleans cluster that serves as a middle tier with grains executing business logic.

In a typical setup, a frontend webserver:

* Receives a web request.
* Performs necessary authentication and authorization validation.
* Decides which grain(s) should process the request.
* Uses the [Microsoft.Orleans.Client](https://www.nuget.org/packages/Microsoft.Orleans.Client) NuGet package to make one or more method call to the grain(s).
* Handles successful completion or failures of the grain calls and any returned values.
* Sends a response to the web request.

### Initialization of grain client

Before a grain client can be used for making calls to grains hosted in an Orleans cluster, it needs to be configured, initialized, and connected to the cluster.

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-7-0"
<!-- markdownlint-enable MD044 -->

Configuration is provided via <xref:Microsoft.Extensions.Hosting.OrleansClientGenericHostExtensions.UseOrleansClient%2A>> and several supplemental option classes that contain a hierarchy of configuration properties for programmatically configuring a client. For more information, see [Client configuration](configuration-guide/client-configuration.md).

Consider the following example of a client configuration:

```csharp
// Alternatively, call Host.CreateDefaultBuilder(args) if using the 
// Microsoft.Extensions.Hosting NuGet package.
using IHost host = new HostBuilder()
    .UseOrleansClient(clientBuilder =>
    {
        clientBuilder.Configure<ClusterOptions>(options =>
        {
            options.ClusterId = "my-first-cluster";
            options.ServiceId = "MyOrleansService";
        });

        clientBuilder.UseAzureStorageClustering(
            options => options.ConfigureTableServiceClient(connectionString))
    })
    .Build();
```

When the `host` is started, the client will be configured and is available through its constructed service provider instance.

:::zone-end

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-3-x"
<!-- markdownlint-enable MD044 -->

Configuration is provided via <xref:Orleans.ClientBuilder> and several supplemental option classes that contain a hierarchy of configuration properties for programmatically configuring a client. For more information, see [Client configuration](configuration-guide/client-configuration.md).

Example of a client configuration:

```csharp
var client = new ClientBuilder()
    .Configure<ClusterOptions>(options =>
    {
        options.ClusterId = "my-first-cluster";
        options.ServiceId = "MyOrleansService";
    })
    .UseAzureStorageClustering(
        options => options.ConnectionString = connectionString)
    .ConfigureApplicationParts(
        parts => parts.AddApplicationPart(typeof(IValueGrain).Assembly))
    .Build();
```

Lastly, we need to call `Connect()` method on the constructed client object to make it connect to the Orleans cluster. It's an asynchronous method that returns a `Task`. So we need to wait for its completion with an `await` or `.Wait()`.

```csharp
await client.Connect();
```

:::zone-end

### Make calls to grains

Making calls to grain from a client is no different from [making such calls from within grain code](../grains/index.md). The same <xref:Orleans.IGrainFactory.GetGrain%60%601(System.Type,System.Guid)?displayProperty=nameWithType> method, where `T` is the target grain interface, is used in both cases [to obtain grain references](../grains/index.md#grain-reference). The slight difference is in through what factory object we invoke <xref:Orleans.IGrainFactory.GetGrain%2A?displayProperty=nameWithType>. In client code, we do that through the connected client object as the following example shows:

```csharp
IPlayerGrain player = client.GetGrain<IPlayerGrain>(playerId);
Task joinGameTask = player.JoinGame(game)

await joinGameTask;
```

A call to a grain method returns a <xref:System.Threading.Tasks.Task> or a <xref:System.Threading.Tasks.Task%601> as required by the [grain interface rules](../grains/index.md). The client can use the `await` keyword to asynchronously await the returned `Task` without blocking the thread or in some cases the `Wait()` method to block the current thread of execution.

The major difference between making calls to grains from client code and from within another grain is the single-threaded execution model of grains. Grains are constrained to be single-threaded by the Orleans runtime, while clients may be multi-threaded. Orleans does not provide any such guarantee on the client-side, and so it is up to the client to manage its concurrency using whatever synchronization constructs are appropriate for its environment&mdash;locks, events, and `Tasks`.

### Receive notifications

There are situations in which a simple request-response pattern is not enough, and the client needs to receive asynchronous notifications. For example, a user might want to be notified when a new message has been published by someone that she is following.

The use of [Observers](../grains/observers.md) is one such mechanism that enables exposing client-side objects as grain-like targets to get invoked by grains. Calls to observers do not provide any indication of success or failure, as they are sent as a one-way best effort message. So it is the responsibility of the application code to build a higher-level reliability mechanism on top of observers where necessary.

Another mechanism that can be used for delivering asynchronous messages to clients is [Streams](../streaming/index.md). Streams expose indications of success or failure of delivery of individual messages, and hence enable reliable communication back to the client.

### Client connectivity

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-7-0"
<!-- markdownlint-enable MD044 -->

There are two scenarios in which a cluster client can experience connectivity issues:

* When the client attempts to connect to a silo.
* When making calls on grain references that were obtained from a connected cluster client.

In the first case, the client will attempt to connect to a silo. If the client is unable to connect to any silo, it will throw an exception to indicate what went wrong. You can register an <xref:Orleans.IClientConnectionRetryFilter> to handle the exception and decide whether to retry or not. If no retry filter is provided, or if the retry filter returns `false`, the client gives up for good.

:::code source="snippets/ClientConnectRetryFilter.cs":::

:::zone-end

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-3-x"
<!-- markdownlint-enable MD044 -->

There are two scenarios in which a cluster client can experience connectivity issues:

* When the <xref:Orleans.IClusterClient.Connect?displayProperty=nameWithType> method is called initially.
* When making calls on grain references that were obtained from a connected cluster client.

In the first case, the `Connect` method will throw an exception to indicate what went wrong. This is typically (but not necessarily) a <xref:Orleans.Runtime.SiloUnavailableException>. If this happens, the cluster client instance is unusable and should be disposed of. A retry filter function can optionally be provided to the `Connect` method which could, for instance, wait for a specified duration before making another attempt. If no retry filter is provided, or if the retry filter returns `false`, the client gives up for good.

If `Connect` returns successfully, the cluster client is guaranteed to be usable until it is disposed of. This means that even if the client experiences connection issues, it will attempt to recover indefinitely. The exact recovery behavior can be configured on a <xref:Orleans.Configuration.GatewayOptions> object provided by the <xref:Orleans.ClientBuilder>, e.g.:

```csharp
var client = new ClientBuilder()
    // ...
    .Configure<GatewayOptions>(
        options =>                         // Default is 1 min.
        options.GatewayListRefreshPeriod = TimeSpan.FromMinutes(10))
    .Build();
```

:::zone-end

In the second case, where a connection issue occurs during a grain call, a <xref:Orleans.Runtime.SiloUnavailableException> will be thrown on the client-side. This could be handled like so:

:::code source="snippets/Program.cs" id="siloexc":::

The grain reference is not invalidated in this situation; the call could be retried on the same reference later when a connection might have been re-established.

### Dependency injection

The recommended way to create an external client in a program that uses the .NET Generic Host is to inject an <xref:Orleans.IClusterClient> singleton instance via dependency injection, which can then be accepted as a constructor parameter in hosted services, ASP.NET controllers, and so on.

> [!NOTE]
> When co-hosting an Orleans silo in the same process that will be connecting to it, it is *not* necessary to manually create a client; Orleans will automatically provide one and manage its lifetime appropriately.

When connecting to a cluster in a different process (on a different machine), a common pattern is to create a hosted service like this:

```csharp
public class ClusterClientHostedService : IHostedService
{
    public IClusterClient Client { get; }

    public ClusterClientHostedService(ILoggerProvider loggerProvider)
    {
        Client = new ClientBuilder()
            .UseLocalhostClustering()
            .ConfigureLogging(builder => builder.AddProvider(loggerProvider))
            .Build();
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        // A retry filter could be provided here.
        await Client.Connect();
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        await Client.Close();

        Client.Dispose();
    }
}
```

The service is then registered like this:

```csharp
await new HostBuilder()
    .ConfigureServices(services =>
    {
        services.AddSingleton<ClusterClientHostedService>();
        services.AddSingleton<IHostedService>(
            sp => sp.GetService<ClusterClientHostedService>());
        services.AddSingleton<IClusterClient>(
            sp => sp.GetService<ClusterClientHostedService>().Client);
        services.AddSingleton<IGrainFactory>(
            sp => sp.GetService<ClusterClientHostedService>().Client);
    })
    .ConfigureLogging(builder => builder.AddConsole())
    .RunConsoleAsync();
```

At this point, an `IClusterClient` instance could be consumed anywhere that dependency injection is supported, such as in an ASP.NET controller:

```csharp
public class HomeController : Controller
{
    private readonly IClusterClient _client;

    public HomeController(IClusterClient client) => _client = client;

    public IActionResult Index()
    {
        var grain = _client.GetGrain<IMyGrain>();
        var model = grain.GetModel();

        return View(model);
    }
}
```

### Example

Here is an extended version of the example given above of a client application that connects to Orleans, finds the player account, subscribes for updates to the game session the player is part of with an observer, and prints out notifications until the program is manually terminated.

```csharp
await RunWatcherAsync();

// Block the main thread so that the process doesn't exit.
// Updates arrive on thread pool threads.
Console.ReadLine();

static async Task RunWatcherAsync()
{
    try
    {
        var client = new ClientBuilder()
            .Configure<ClusterOptions>(options =>
            {
                options.ClusterId = "my-first-cluster";
                options.ServiceId = "MyOrleansService";
            })
            .UseAzureStorageClustering(
                options => options.ConnectionString = connectionString)
            .ConfigureApplicationParts(
                parts => parts.AddApplicationPart(typeof(IValueGrain).Assembly))
            .Build();

            // Hardcoded player ID
            Guid playerId = new("{2349992C-860A-4EDA-9590-000000000006}");
            IPlayerGrain player = client.GetGrain<IPlayerGrain>(playerId);
            IGameGrain game = null;
            while (game is null)
            {
                Console.WriteLine(
                    $"Getting current game for player {playerId}...");

                try
                {
                    game = await player.GetCurrentGame();
                    if (game is null) // Wait until the player joins a game
                    {
                        await Task.Delay(TimeSpan.FromMilliseconds(5_000));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex.GetBaseException()}");
                }
            }

            Console.WriteLine(
                $"Subscribing to updates for game {game.GetPrimaryKey()}...");

            // Subscribe for updates
            var watcher = new GameObserver();
            await game.SubscribeForGameUpdates(
                await client.CreateObjectReference<IGameObserver>(watcher));

            Console.WriteLine(
                "Subscribed successfully. Press <Enter> to stop.");
        }
        catch (Exception e)
        {
            Console.WriteLine(
                $"Unexpected Error: {e.GetBaseException()}");
        }
    }
}

/// <summary>
/// Observer class that implements the observer interface.
/// Need to pass a grain reference to an instance of
/// this class to subscribe for updates.
/// </summary>
class GameObserver : IGameObserver
{
    public void UpdateGameScore(string score)
    {
        Console.WriteLine("New game score: {0}", score);
    }
}
```
