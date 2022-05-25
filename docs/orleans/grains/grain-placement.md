---
title: Grain placement
description: Learn about grain placements in .NET Orleans.
ms.date: 03/16/2022
---

# Grain placement

Orleans ensures that when a grain call is made there is an instance of that grain available in memory on some server in the cluster to handle the request. If the grain is not currently active in the cluster, Orleans picks one of the servers to activate the grain on. This is called grain placement. Placement is also one way that load is balanced: even placement of busy grains helps to even the workload across the cluster.

The placement process in Orleans is fully configurable: developers can choose from a set of out-of-the-box placement policies such as random, prefer-local, and load-based, or custom logic can be configured. This allows for full flexibility in deciding where grains are created. For example, grains can be placed on a server close to resources which they need to operate on or close to other grains with which they communicate. By default, Orleans will pick a random compatible server.

The placement strategy which Orleans uses can be configured globally or per-grain-class.

## Random placement

A server is randomly selected from the set of compatible servers. This placement strategy is configured by adding the <xref:Orleans.Placement.RandomPlacementAttribute> to a grain.

## Local placement

If the local server is compatible, select the local server, otherwise select a random server. This placement strategy is configured by adding the <xref:Orleans.Placement.PreferLocalPlacementAttribute> to a grain.

## Hash-based placement

Hash the grain id to a non-negative integer and modulo it with the number of compatible servers. Select the corresponding server from the list of compatible servers ordered by server address. Note that this is not guaranteed to remain stable as the cluster membership changes. Specifically, adding, removing, or restarting servers can alter the server selected for a given grain id. Because grains placed using this strategy are registered in the grain directory, this change in placement decision as membership changes typically doesn't have a noticeable effect.

This placement strategy is configured by adding the <xref:Orleans.Placement.HashBasedPlacementAttribute> to a grain.

## Activation-count-based placement

This placement strategy intends to place new grain activations on the least heavily loaded server based on the number of recently busy grains. It includes a mechanism in which all servers periodically publish their total activation count to all other servers. The placement director then selects a server that is predicted to have the fewest activations by examining the most recently reported activation count and a making prediction of the current activation count based upon the recent activation count made by the placement director on the current server. The director selects several servers at random when making this prediction, in an attempt to avoid multiple separate servers overloading the same server. By default, two servers are selected at random, but this value is configurable via <xref:Orleans.Configuration.ActivationCountBasedPlacementOptions>.

This algorithm is based on the thesis [*The Power of Two Choices in Randomized Load Balancing* by Michael David Mitzenmacher](https://www.eecs.harvard.edu/~michaelm/postscripts/mythesis.pdf), and is also used in Nginx for distributed load balancing, as described in the article [*NGINX and the "Power of Two Choices" Load-Balancing Algorithm*](https://www.nginx.com/blog/nginx-power-of-two-choices-load-balancing-algorithm/).

This placement strategy is configured by adding the <xref:Orleans.Placement.ActivationCountBasedPlacementAttribute> to a grain.

## Stateless worker placement

This is a special placement strategy used by [*stateless worker* grains](../grains/stateless-worker-grains.md). This operates almost identically to `PreferLocalPlacement` except that each server can have multiple activations of the same grain and the grain is not registered in the grain directory since there is no need.

This placement strategy is configured by adding the <xref:Orleans.Concurrency.StatelessWorkerAttribute> to a grain.

## Configure the default placement strategy

Orleans will use random placement unless the default is overridden. The default placement strategy can be overridden by registering an implementation of <xref:Orleans.Runtime.PlacementStrategy> during configuration:

```csharp
siloBuilder.ConfigureServices(services =>
    services.AddSingleton<PlacementStrategy, MyPlacementStrategy>());
```

## Configuring the placement strategy for a grain

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
    ...
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
    services.AddSingletonNamedService<
        PlacementStrategy, SamplePlacementStrategy>(
            nameof(SamplePlacementStrategy));

    services.AddSingletonKeyedService<
        Type, IPlacementDirector, SamplePlacementStrategyFixedSiloDirector>(
            typeof(SamplePlacementStrategy));
}
```

For a second simple example showing further use of the placement context, refer to the `PreferLocalPlacementDirector` in the [Orleans source repo](https://github.com/dotnet/orleans/blob/main/src/Orleans.Runtime/Placement/PreferLocalPlacementDirector.cs)
