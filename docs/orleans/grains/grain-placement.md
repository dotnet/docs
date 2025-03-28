---
title: Grain placement
description: Learn about grain placements in .NET Orleans.
ms.date: 07/03/2024
---

# Grain placement

Orleans ensures that when a grain call is made there is an instance of that grain available in memory on some server in the cluster to handle the request. If the grain is not currently active in the cluster, Orleans picks one of the servers to activate the grain on. This is called _grain placement_. Placement is also one way that load is balanced: even placement of busy grains helps to even the workload across the cluster.

The placement process in Orleans is fully configurable: developers can choose from a set of out-of-the-box placement policies such as random, prefer-local, and load-based, or custom logic can be configured. This allows for full flexibility in deciding where grains are created. For example, grains can be placed on a server close to resources which they need to operate on or close to other grains with which they communicate. By default, Orleans will pick a random compatible server.

The placement strategy that Orleans uses can be configured globally or per grain class.

## Random placement

A server is randomly selected from the compatible servers in the cluster. To configure this placement strategy, add the <xref:Orleans.Placement.RandomPlacementAttribute> to a grain.

## Local placement

If the local server is compatible, select the local server, otherwise select a random server. This placement strategy is configured by adding the <xref:Orleans.Placement.PreferLocalPlacementAttribute> to a grain.

## Hash-based placement

Hash the grain id to a non-negative integer and modulo it with the number of compatible servers. Select the corresponding server from the list of compatible servers ordered by server address. Note that this is not guaranteed to remain stable as the cluster membership changes. Specifically, adding, removing, or restarting servers can alter the server selected for a given grain id. Because grains placed using this strategy are registered in the grain directory, this change in placement decision as membership changes typically doesn't have a noticeable effect.

This placement strategy is configured by adding the <xref:Orleans.Placement.HashBasedPlacementAttribute> to a grain.

## Activation-count-based placement

This placement strategy intends to place new grain activations on the least heavily loaded server based on the number of recently busy grains. It includes a mechanism in which all servers periodically publish their total activation count to all other servers. The placement director then selects a server that is predicted to have the fewest activations by examining the most recently reported activation count and predicts the current activation count based on the recent activation count made by the placement director on the current server. The director selects several servers at random when making this prediction, to avoid multiple separate servers overloading the same server. By default, two servers are selected randomly, but this value is configurable via <xref:Orleans.Configuration.ActivationCountBasedPlacementOptions>.

This algorithm is based on the thesis [*The Power of Two Choices in Randomized Load Balancing* by Michael David Mitzenmacher](https://www.eecs.harvard.edu/~michaelm/postscripts/mythesis.pdf), and is also used in Nginx for distributed load balancing, as described in the article [*NGINX and the "Power of Two Choices" Load-Balancing Algorithm*](https://www.nginx.com/blog/nginx-power-of-two-choices-load-balancing-algorithm/).

This placement strategy is configured by adding the <xref:Orleans.Placement.ActivationCountBasedPlacementAttribute> to a grain.

## Stateless worker placement

Stateless worker placement is a special placement strategy used by [*stateless worker* grains](../grains/stateless-worker-grains.md). This placement operates almost identically to <xref:Orleans.Runtime.PreferLocalPlacement> except that each server can have multiple activations of the same grain and the grain is not registered in the grain directory since there's no need.

This placement strategy is configured by adding the <xref:Orleans.Concurrency.StatelessWorkerAttribute> to a grain.

## Silo-role based placement

A deterministic placement strategy that places grains on silos with a specific role. This placement strategy is configured by adding the <xref:Orleans.Placement.SiloRoleBasedPlacementAttribute> to a grain.

## Resource-optimized placement

The resource-optimized placement strategy attempts to optimize cluster resources by balancing grain activations across silos based on available memory and CPU usage. It assigns weights to runtime statistics to prioritize different resources and calculates a normalized score for each silo. The silo with the lowest score is chosen for placing the upcoming activation. Normalization ensures that each property contributes proportionally to the overall score. Weights can be adjusted via the <xref:Orleans.Configuration.ResourceOptimizedPlacementOptions> based on user-specific requirements and priorities for different resources.

Additionally, this placement strategy exposes an option to build a stronger *preference* to the local silo (*the one which got the request for making a new placement*) to be picked as the target for the activation. This is controlled via the `LocalSiloPreferenceMargin` property which is part of the options.

Also, an [*online*](https://en.wikipedia.org/wiki/Online_algorithm), [*adaptive*](https://en.wikipedia.org/wiki/Adaptive_algorithm) algorithm provides a smoothing effect which avoids rapid signal drops by transforming it into a polynomial-like decay process. This is especially important for CPU usage, and overall contributes to avoiding resource saturation on the silos, especially newly joined once.

This algorithm is based on: [*Resource-based placement with cooperative dual-mode Kalman filtering*](https://www.ledjonbehluli.com/posts/orleans_resource_placement_kalman/)

This placement strategy is configured by adding the <xref:Orleans.Placement.ResourceOptimizedPlacementAttribute> to a grain.

## Choose a placement strategy

Choosing the appropriate grain placement strategy, beyond the defaults that Orleans provides, requires monitoring and developer evaluation. The choice of placement strategy should be based on the size and complexity of the app, workload characteristics, and deployment environment.

Random placement relies on the [Law of Large Numbers](https://en.wikipedia.org/wiki/Law_of_large_numbers), so it's usually a good default when there is an unpredictable load spread across a large number of grains (10,000 plus).

Activation-count-based placement also has a random element to it, relying on the Power of Two Choices principle, which is a commonly used algorithm for distributed load balancing and is used in popular load balancers. Silos frequently publish run-time statistics to other silos in the cluster, including:

- Available memory, total physical memory, and memory usage.
- CPU usage.
- Total activation count and recent active activation count.
  - A sliding window of activations that were active in the last few seconds, sometimes referred to as the activation working set.

From these statistics, only the activation counts are currently used to determine the load on a given silo.

Ultimately, you should experiment with different strategies and monitor performance metrics to determine the best fit. By selecting the right grain placement strategy, you can optimize the performance, scalability, and cost-effectiveness of your Orleans apps.

## Configure the default placement strategy

Orleans will use random placement unless the default is overridden. The default placement strategy can be overridden by registering an implementation of <xref:Orleans.Runtime.PlacementStrategy> during configuration:

```csharp
siloBuilder.ConfigureServices(services =>
    services.AddSingleton<PlacementStrategy, MyPlacementStrategy>());
```

## Configure the placement strategy for a grain

The placement strategy for a grain type is configured by adding the appropriate attribute on the grain class.
The relevant attributes are specified in the [placement strategies](#random-placement) sections.

## Sample custom placement strategy

First define a class that implements <xref:Orleans.Runtime.Placement.IPlacementDirector> interface, requiring a single method. In this example, we assume you have a function `GetSiloNumber` defined which will return a silo number given the <xref:System.Guid> of the grain about to be created.

```csharp
public class SamplePlacementStrategyFixedSiloDirector : IPlacementDirector
{
    public Task<SiloAddress> OnAddActivation(
        PlacementStrategy strategy,
        PlacementTarget target,
        IPlacementContext context)
    {
        var silos = context.GetCompatibleSilos(target).OrderBy(s => s).ToArray();
        int silo = GetSiloNumber(target.GrainIdentity.PrimaryKey, silos.Length);

        return Task.FromResult(silos[silo]);
    }
}
```

You then need to define two classes to allow grain classes to be assigned to the strategy:

```csharp
[Serializable]
public sealed class SamplePlacementStrategy : PlacementStrategy
{
}

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public sealed class SamplePlacementStrategyAttribute : PlacementAttribute
{
    public SamplePlacementStrategyAttribute() :
        base(new SamplePlacementStrategy())
    {
    }
}
```

Then just tag any grain classes you want to use this strategy with the attribute:

```csharp
[SamplePlacementStrategy]
public class MyGrain : Grain, IMyGrain
{
    // ...
}
```

And finally, register the strategy when you build the <xref:Orleans.Runtime.Host.SiloHost>:

```csharp
private static async Task<ISiloHost> StartSilo()
{
    var builder = new HostBuilder(c =>
    {
        // normal configuration methods omitted for brevity
        c.ConfigureServices(ConfigureServices);
    });

    var host = builder.Build();
    await host.StartAsync();

    return host;
}

private static void ConfigureServices(IServiceCollection services)
{
    services.AddPlacementDirector<SamplePlacementStrategy, SamplePlacementStrategyFixedSiloDirector>();
}
```

For a second simple example showing further use of the placement context, refer to the `PreferLocalPlacementDirector` in the [Orleans source repo](https://github.com/dotnet/orleans/blob/main/src/Orleans.Runtime/Placement/PreferLocalPlacementDirector.cs).
