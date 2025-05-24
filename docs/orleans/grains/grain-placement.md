---
title: Grain placement
description: Learn about grain placement in .NET Orleans.
ms.date: 03/31/2025
ms.topic: conceptual
---

# Grain placement

Orleans ensures that when a grain call is made, an instance of that grain is available in memory on some server in the cluster to handle the request. If the grain isn't currently active in the cluster, Orleans picks a server to activate the grain on. This process is called _grain placement_. Placement is also one way Orleans balances load: placing busy grains evenly helps distribute the workload across the cluster.

The placement process in Orleans is fully configurable. Choose from out-of-the-box placement policies such as random, prefer-local, and load-based, or configure custom logic. This allows full flexibility in deciding where grains are created. For example, place grains on a server close to resources they need to operate on or close to other grains they communicate with. By default, Orleans picks a random compatible server.

Configure the placement strategy Orleans uses globally or per grain class.

## Random placement

Orleans randomly selects a server from the compatible servers in the cluster. To configure this placement strategy, add the <xref:Orleans.Placement.RandomPlacementAttribute> to the grain class.

## Local placement

If the local server is compatible, Orleans selects the local server; otherwise, it selects a random server. Configure this placement strategy by adding the <xref:Orleans.Placement.PreferLocalPlacementAttribute> to the grain class.

## Hash-based placement

Orleans hashes the grain ID to a non-negative integer and applies a modulo operation with the number of compatible servers. It then selects the corresponding server from the list of compatible servers ordered by server address. Note that this placement isn't guaranteed to remain stable as cluster membership changes. Specifically, adding, removing, or restarting servers can alter the server selected for a given grain ID. Because grains placed using this strategy register in the grain directory, this change in placement decision as membership changes typically doesn't have a noticeable effect.

Configure this placement strategy by adding the <xref:Orleans.Placement.HashBasedPlacementAttribute> to the grain class.

## Activation-count-based placement

This placement strategy attempts to place new grain activations on the least heavily loaded server based on the number of recently busy grains. It includes a mechanism where all servers periodically publish their total activation count to all other servers. The placement director then selects a server predicted to have the fewest activations by examining the most recently reported activation count and predicting the current count based on recent activations made by the placement director on the current server. The director selects several servers randomly when making this prediction to avoid multiple separate servers overloading the same server. By default, two servers are selected randomly, but this value can be configured via <xref:Orleans.Configuration.ActivationCountBasedPlacementOptions>.

This algorithm is based on the thesis [*The Power of Two Choices in Randomized Load Balancing* by Michael David Mitzenmacher](https://www.eecs.harvard.edu/~michaelm/postscripts/mythesis.pdf). It's also used in Nginx for distributed load balancing, as described in the article [*NGINX and the "Power of Two Choices" Load-Balancing Algorithm*](https://www.nginx.com/blog/nginx-power-of-two-choices-load-balancing-algorithm/).

Configure this placement strategy by adding the <xref:Orleans.Placement.ActivationCountBasedPlacementAttribute> to the grain class.

## Stateless worker placement

Stateless worker placement is a special placement strategy used by [*stateless worker* grains](stateless-worker-grains.md). This placement operates almost identically to `PreferLocalPlacement`, except each server can have multiple activations of the same grain, and the grain isn't registered in the grain directory since there's no need.

Configure this placement strategy by adding the <xref:Orleans.Concurrency.StatelessWorkerAttribute> to the grain class.

## Silo-role-based placement

This is a deterministic placement strategy placing grains on silos with a specific role. Configure this placement strategy by adding the <xref:Orleans.Placement.SiloRoleBasedPlacementAttribute> to the grain class.

## Resource-optimized placement

The resource-optimized placement strategy attempts to optimize cluster resources by balancing grain activations across silos based on available memory and CPU usage. It assigns weights to runtime statistics to prioritize different resources and calculates a normalized score for each silo. The silo with the lowest score is chosen for placing the upcoming activation. Normalization ensures each property contributes proportionally to the overall score. Adjust weights via <xref:Orleans.Configuration.ResourceOptimizedPlacementOptions> based on specific requirements and priorities for different resources.

Additionally, this placement strategy exposes an option to build a stronger *preference* for the local silo (the one receiving the request to make a new placement) to be picked as the target for the activation. Control this via the `LocalSiloPreferenceMargin` property, part of the options.

Also, an [*online*](https://en.wikipedia.org/wiki/Online_algorithm), [*adaptive*](https://en.wikipedia.org/wiki/Adaptive_algorithm) algorithm provides a smoothing effect avoiding rapid signal drops by transforming the signal into a polynomial-like decay process. This is especially important for CPU usage and contributes overall to avoiding resource saturation on silos, particularly newly joined ones.

This algorithm is based on [*Resource-based placement with cooperative dual-mode Kalman filtering*](https://www.ledjonbehluli.com/posts/orleans_resource_placement_kalman/).

Configure this placement strategy by adding the <xref:Orleans.Placement.ResourceOptimizedPlacementAttribute> to the grain class.

## Choose a placement strategy

Choosing the appropriate grain placement strategy, beyond the defaults Orleans provides, requires monitoring and evaluation. The choice should be based on the app's size and complexity, workload characteristics, and deployment environment.

Random placement relies on the [Law of Large Numbers](https://en.wikipedia.org/wiki/Law_of_large_numbers), so it's usually a good default for unpredictable loads spread across many grains (10,000 or more).

Activation-count-based placement also has a random element, relying on the Power of Two Choices principle. This is a commonly used algorithm for distributed load balancing and is used in popular load balancers. Silos frequently publish runtime statistics to other silos in the cluster, including:

- Available memory, total physical memory, and memory usage.
- CPU usage.
- Total activation count and recent active activation count.
  - A sliding window of activations active in the last few seconds, sometimes referred to as the activation working set.

From these statistics, only activation counts are currently used to determine the load on a given silo.

Ultimately, experiment with different strategies and monitor performance metrics to determine the best fit. Selecting the right grain placement strategy optimizes the performance, scalability, and cost-effectiveness of Orleans apps.

## Configure the default placement strategy

Orleans uses random placement unless the default is overridden. Override the default placement strategy by registering an implementation of <xref:Orleans.Runtime.PlacementStrategy> during configuration:

```csharp
siloBuilder.ConfigureServices(services =>
    services.AddSingleton<PlacementStrategy, MyPlacementStrategy>());
```

## Configure the placement strategy for a grain

Configure the placement strategy for a grain type by adding the appropriate attribute to the grain class. Relevant attributes are specified in the [placement strategies](#random-placement) sections above.

## Sample custom placement strategy

First, define a class implementing the <xref:Orleans.Runtime.Placement.IPlacementDirector> interface, requiring a single method. In this example, assume a function `GetSiloNumber` is defined that returns a silo number given the <xref:System.Guid> of the grain about to be created.

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

Then, define two classes to allow assigning grain classes to the strategy:

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

Then, tag any grain classes intended to use this strategy with the attribute:

```csharp
[SamplePlacementStrategy]
public class MyGrain : Grain, IMyGrain
{
    // ...
}
```

Finally, register the strategy when building the `ISiloHost`:

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

For a second simple example showing further use of the placement context, refer to `PreferLocalPlacementDirector` in the [Orleans source repository](https://github.com/dotnet/orleans/blob/main/src/Orleans.Runtime/Placement/PreferLocalPlacementDirector.cs).
