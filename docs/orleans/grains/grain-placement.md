---
title: Grain placement
description: Learn about grain placement in .NET Orleans.
ms.date: 01/20/2026
ms.topic: article
zone_pivot_groups: orleans-version
---

# Grain placement

Orleans ensures that when a grain call is made, an instance of that grain is available in memory on some server in the cluster to handle the request. If the grain isn't currently active in the cluster, Orleans picks a server to activate the grain on. This process is called _grain placement_. Placement is also one way Orleans balances load: placing busy grains evenly helps distribute the workload across the cluster.

The placement process in Orleans is fully configurable. Choose from out-of-the-box placement policies such as random, prefer-local, and load-based, or configure custom logic. This allows full flexibility in deciding where grains are created. For example, place grains on a server close to resources they need to operate on or close to other grains they communicate with.

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-10-0,orleans-9-0"

> [!NOTE]
> Starting in Orleans 9.2, the default placement strategy changed from **random placement** to **resource-optimized placement**. This provides better load distribution based on CPU and memory utilization across silos. If you require the previous random placement behavior, explicitly configure it as described in [Configure the default placement strategy](#configure-the-default-placement-strategy).

:::zone-end

:::zone target="docs" pivot="orleans-8-0,orleans-7-0,orleans-3-x"

By default, Orleans picks a random compatible server.

:::zone-end

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

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-10-0,orleans-9-0"

> [!IMPORTANT]
> Starting in Orleans 9.2, resource-optimized placement is the **default** placement strategy. You no longer need to explicitly configure it unless you want to customize the options.

:::zone-end

:::zone target="docs" pivot="orleans-8-0"

Resource-optimized placement was introduced in Orleans 8.1. To use it, add the <xref:Orleans.Placement.ResourceOptimizedPlacementAttribute> to your grain class.

:::zone-end

:::zone target="docs" pivot="orleans-7-0,orleans-3-x"

Resource-optimized placement is not available in this version of Orleans. Consider upgrading to Orleans 8.1 or later to use this feature.

:::zone-end

:::zone target="docs" pivot="orleans-10-0,orleans-9-0,orleans-8-0"

The resource-optimized placement strategy attempts to optimize cluster resources by balancing grain activations across silos based on available memory and CPU usage. It assigns weights to runtime statistics to prioritize different resources and calculates a normalized score for each silo. The silo with the lowest score is chosen for placing the upcoming activation. Normalization ensures each property contributes proportionally to the overall score. Adjust weights via <xref:Orleans.Configuration.ResourceOptimizedPlacementOptions> based on specific requirements and priorities for different resources.

Additionally, this placement strategy exposes an option to build a stronger *preference* for the local silo (the one receiving the request to make a new placement) to be picked as the target for the activation. Control this via the `LocalSiloPreferenceMargin` property, part of the options.

Also, an [*online*](https://en.wikipedia.org/wiki/Online_algorithm), [*adaptive*](https://en.wikipedia.org/wiki/Adaptive_algorithm) algorithm provides a smoothing effect avoiding rapid signal drops by transforming the signal into a polynomial-like decay process. This is especially important for CPU usage and contributes overall to avoiding resource saturation on silos, particularly newly joined ones.

This algorithm is based on [*Resource-based placement with cooperative dual-mode Kalman filtering*](https://www.ledjonbehluli.com/posts/orleans_resource_placement_kalman/).

Configure this placement strategy by adding the <xref:Orleans.Placement.ResourceOptimizedPlacementAttribute> to the grain class.

### ResourceOptimizedPlacementOptions

Configure the resource-optimized placement strategy using <xref:Orleans.Configuration.ResourceOptimizedPlacementOptions>:

```csharp
siloBuilder.Configure<ResourceOptimizedPlacementOptions>(options =>
{
    options.CpuUsageWeight = 40;
    options.MemoryUsageWeight = 20;
    options.AvailableMemoryWeight = 20;
    options.MaxAvailableMemoryWeight = 5;
    options.ActivationCountWeight = 15;
    options.LocalSiloPreferenceMargin = 5;
});
```

| Option | Type | Default | Description |
|--------|------|---------|-------------|
| `CpuUsageWeight` | `int` | 40 | The importance of CPU usage. Higher values favor silos with lower CPU usage. Valid range: 0-100. |
| `MemoryUsageWeight` | `int` | 20 | The importance of memory usage. Higher values favor silos with lower memory usage. Valid range: 0-100. |
| `AvailableMemoryWeight` | `int` | 20 | The importance of available memory. Higher values favor silos with more available memory. Valid range: 0-100. |
| `MaxAvailableMemoryWeight` | `int` | 5 | The importance of maximum available memory. Higher values favor silos with higher physical memory capacity. Useful in clusters with unevenly distributed resources. Valid range: 0-100. |
| `ActivationCountWeight` | `int` | 15 | The importance of activation count. Higher values favor silos with fewer active grains. Valid range: 0-100. |
| `LocalSiloPreferenceMargin` | `int` | 5 | Margin for preferring the local silo. When set to 0, always selects the silo with lowest utilization. When set to 100, always prefers the local silo (equivalent to `PreferLocalPlacement`). Recommended: 5-10. Valid range: 0-100. |

:::zone-end

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

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-10-0,orleans-9-0"

Starting in Orleans 9.2, Orleans uses resource-optimized placement by default. Override the default placement strategy by registering an implementation of <xref:Orleans.Runtime.PlacementStrategy> during configuration.

To revert to the previous random placement behavior:

```csharp
siloBuilder.ConfigureServices(services =>
    services.AddSingleton<PlacementStrategy, RandomPlacement>());
```

To use a custom placement strategy:

```csharp
siloBuilder.ConfigureServices(services =>
    services.AddSingleton<PlacementStrategy, MyPlacementStrategy>());
```

:::zone-end

:::zone target="docs" pivot="orleans-8-0,orleans-7-0,orleans-3-x"

Orleans uses random placement unless the default is overridden. Override the default placement strategy by registering an implementation of <xref:Orleans.Runtime.PlacementStrategy> during configuration:

```csharp
siloBuilder.ConfigureServices(services =>
    services.AddSingleton<PlacementStrategy, MyPlacementStrategy>());
```

:::zone-end

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

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-10-0,orleans-9-0"

## Silo metadata and placement filtering

Orleans 9.0 introduced silo metadata and placement filtering, allowing you to attach custom metadata to silos and use that metadata to control grain placement decisions. This is useful for scenarios like:

- **Zone-aware placement**: Place grains on silos in the same availability zone as the client
- **Tiered deployments**: Direct certain grains to premium or standard tier silos
- **Hardware affinity**: Place compute-intensive grains on silos with GPUs or high-memory nodes

### Configure silo metadata

Attach metadata to a silo during configuration:

```csharp
// From environment variables (ORLEANS__METADATA__key=value)
builder.UseSiloMetadata();

// From IConfiguration
builder.UseSiloMetadata(configuration.GetSection("Orleans:Metadata"));

// From a dictionary
builder.UseSiloMetadata(new Dictionary<string, string>
{
    ["zone"] = "us-east-1a",
    ["tier"] = "premium",
    ["rack"] = "rack-42"
});
```

### Placement filter strategies

Orleans provides two placement filter strategies:

| Strategy | Attribute | Behavior |
|----------|-----------|----------|
| **Required match** | `[RequiredMatchSiloMetadataPlacementFilter]` | Grain is **only** placed on silos with matching metadata. Fails if no silos match. |
| **Preferred match** | `[PreferredMatchSiloMetadataPlacementFilter]` | Grain **prefers** silos with matching metadata but falls back to other silos if needed. |

### Required match filtering

Use required match filtering when a grain **must** be placed on a silo with specific metadata:

```csharp
// Grain will only be placed on silos where the "zone" metadata matches
[RequiredMatchSiloMetadataPlacementFilter(new[] { "zone" })]
public class ZoneRestrictedGrain : Grain, IZoneRestrictedGrain
{
    // This grain will only activate on silos in the same zone
}

// Multiple metadata keys can be specified
[RequiredMatchSiloMetadataPlacementFilter(new[] { "zone", "tier" })]
public class ZoneAndTierGrain : Grain, IZoneAndTierGrain
{
    // Requires both zone AND tier to match
}
```

### Preferred match filtering

Use preferred match filtering when you want to prefer certain silos but allow fallback:

```csharp
// Prefer silos with matching "zone" and "rack", but allow fallback
// minCandidates ensures at least 2 silos are considered even without matches
[PreferredMatchSiloMetadataPlacementFilter(new[] { "zone", "rack" }, minCandidates: 2)]
public class LocalityAwareGrain : Grain, ILocalityAwareGrain
{
    // Prefers local zone/rack but can activate elsewhere
}
```

### Access silo metadata at runtime

Grains can access metadata for any silo using `ISiloMetadataCache`:

```csharp
public class MyGrain : Grain, IMyGrain
{
    private readonly ISiloMetadataCache _metadataCache;

    public MyGrain(ISiloMetadataCache metadataCache)
    {
        _metadataCache = metadataCache;
    }

    public Task<string?> GetCurrentSiloZone()
    {
        var siloAddress = this.GetSiloAddress();
        var metadata = _metadataCache.GetMetadata(siloAddress);
        return Task.FromResult(metadata?.Metadata.GetValueOrDefault("zone"));
    }
}
```

:::zone-end

## Activation repartitioning

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-10-0,orleans-9-0"
<!-- markdownlint-enable MD044 -->

Activation repartitioning is a feature that automatically optimizes grain call locality by migrating grain activations to be closer to the grains they communicate with most frequently. This feature can significantly improve performance by reducing network hops for inter-grain communication.

> [!WARNING]
> Activation repartitioning is an experimental feature. Use the `#pragma warning disable ORLEANSEXP001` directive or add `<NoWarn>ORLEANSEXP001</NoWarn>` to your project file to suppress the experimental warning.

### How it works

The repartitioner monitors grain-to-grain communication patterns and builds a graph of "edges" representing how frequently grains communicate. Periodically, it analyzes this graph to identify opportunities to improve locality by migrating grains to silos where their communication partners are located, while maintaining an approximately equal distribution of activations across silos.

Key characteristics:

- **Probabilistic tracking**: Uses a probabilistic data structure to track the heaviest communication links while conserving memory
- **Balanced distribution**: Attempts to keep activation counts balanced across silos
- **Recovery period**: After migrating grains, a silo waits before participating in another repartitioning round to allow the system to stabilize
- **Anchoring filter**: Identifies well-partitioned grains (those already close to their communication partners) and avoids migrating them

### Enable activation repartitioning

Enable activation repartitioning using the `AddActivationRepartitioner` extension method:

```csharp
#pragma warning disable ORLEANSEXP001
siloBuilder.AddActivationRepartitioner();
#pragma warning restore ORLEANSEXP001
```

### Configuration options

Configure the repartitioner using <xref:Orleans.Configuration.ActivationRepartitionerOptions>:

```csharp
#pragma warning disable ORLEANSEXP001
siloBuilder.AddActivationRepartitioner();
siloBuilder.Configure<ActivationRepartitionerOptions>(options =>
{
    options.MaxEdgeCount = 10_000;
    options.MinRoundPeriod = TimeSpan.FromMinutes(1);
    options.MaxRoundPeriod = TimeSpan.FromMinutes(2);
    options.RecoveryPeriod = TimeSpan.FromMinutes(1);
    options.AnchoringFilterEnabled = true;
});
#pragma warning restore ORLEANSEXP001
```

| Option | Type | Default | Description |
|--------|------|---------|-------------|
| `MaxEdgeCount` | `int` | 10,000 | Maximum number of edges (grain communication links) to track. Higher values improve accuracy but use more memory. Values under 100 are not recommended. |
| `MaxUnprocessedEdges` | `int` | 100,000 | Maximum number of unprocessed edges to buffer. Oldest edges are discarded when exceeded. |
| `MinRoundPeriod` | `TimeSpan` | 1 minute | Minimum time between repartitioning rounds. |
| `MaxRoundPeriod` | `TimeSpan` | 2 minutes | Maximum time between repartitioning rounds. Actual timing is random between min and max. For optimal results, aim for ~10 seconds multiplied by the maximum silo count. |
| `RecoveryPeriod` | `TimeSpan` | 1 minute | Time a silo waits after a repartitioning round before participating in another. Must be less than or equal to `MinRoundPeriod`. |
| `AnchoringFilterEnabled` | `bool` | `true` | Enables tracking of well-partitioned grains to avoid unnecessarily migrating them. Reduces accuracy slightly but improves effectiveness. |
| `ProbabilisticFilteringMaxAllowedErrorRate` | `double` | 0.01 | Maximum error rate for the probabilistic filter (0.1% to 1% range). Only applies when `AnchoringFilterEnabled` is `true`. |

### Performance considerations

- **Convergence time**: The repartitioner gradually improves locality over multiple rounds. If the system isn't converging fast enough, consider increasing `MaxEdgeCount`.
- **Memory usage**: Higher `MaxEdgeCount` values consume more memory. The probabilistic data structure helps limit memory usage while maintaining reasonable accuracy.
- **Cluster stability**: Avoid very short `RecoveryPeriod` values to prevent excessive grain migration.
- **Workload patterns**: Works best with workloads that have stable communication patterns. Highly dynamic workloads may see less benefit.

### When to use activation repartitioning

Consider enabling activation repartitioning when:

- Your grains have predictable communication patterns (grain A frequently calls grain B)
- You have a multi-silo cluster where network latency between silos is significant
- Benchmarking shows improved throughput with the feature enabled

Avoid activation repartitioning when:

- Grains communicate with many different grains randomly
- Your cluster is small (2-3 silos) where migration overhead may outweigh benefits
- Your grains frequently deactivate and reactivate, preventing stable patterns from emerging

:::zone-end

:::zone target="docs" pivot="Orleans-8-0"

Activation repartitioning was introduced as an experimental feature in Orleans 8.2. For the latest documentation on this feature, see the Orleans 9.0+ documentation.

:::zone-end

:::zone target="docs" pivot="Orleans-7-0,Orleans-3-x"

Activation repartitioning is available in Orleans 8.2 and later.

:::zone-end
