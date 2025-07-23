---
title: Migrate from Orleans 3.x to 7.0
description: Learn about the new features in Orleans 7.0 and how to migrate your application from version 3.x.
ms.date: 03/30/2025
ms.topic: how-to
ms.custom: migration-guide
---

# Migrate from Orleans 3.x to 7.0

Orleans 7.0 introduces several beneficial changes, including improvements to hosting, custom serialization, immutability, and grain abstractions.

## Migration

Due to changes in how Orleans identifies grains and streams, migrating existing applications using reminders, streams, or grain persistence to Orleans 7.0 isn't currently straightforward.

Smoothly upgrading applications running previous Orleans versions via a rolling upgrade to Orleans 7.0 isn't possible. Therefore, use a different upgrade strategy, such as deploying a new cluster and decommissioning the previous one. Orleans 7.0 changes the wire protocol incompatibly, meaning clusters cannot contain a mix of Orleans 7.0 hosts and hosts running previous Orleans versions.

Such breaking changes have been avoided for many years, even across major releases. Why now? There are two major reasons: identities and serialization. Regarding identities, grain and stream identities now consist of strings. This allows grains to encode generic type information properly and makes mapping streams to the application domain easier. Previously, Orleans identified grain types using a complex data structure that couldn't represent generic grains, leading to corner cases. Streams were identified by a `string` namespace and a <xref:System.Guid> key, which was efficient but difficult to map to the application domain. Serialization is now version-tolerant. This means types can be modified in certain compatible ways, following a set of rules, with confidence that the application can be upgraded without serialization errors. This capability is especially helpful when application types persist in streams or grain storage. The following sections detail the major changes and discuss them further.

### Packaging changes

When upgrading a project to Orleans 7.0, perform the following actions:

- All clients should reference [Microsoft.Orleans.Client](https://nuget.org/packages/Microsoft.Orleans.Client).
- All silos (servers) should reference [Microsoft.Orleans.Server](https://nuget.org/packages/Microsoft.Orleans.Server).
- All other packages should reference [Microsoft.Orleans.Sdk](https://nuget.org/packages/Microsoft.Orleans.Sdk).
  - Both _client_ and _server_ packages include a reference to [Microsoft.Orleans.Sdk](https://nuget.org/packages/Microsoft.Orleans.Sdk).
- Remove all references to `Microsoft.Orleans.CodeGenerator.MSBuild` and `Microsoft.Orleans.OrleansCodeGenerator.Build`.
  - Replace usages of `KnownAssembly` with <xref:Orleans.GenerateCodeForDeclaringAssemblyAttribute>.
  - The `Microsoft.Orleans.Sdk` package references the C# Source Generator package (`Microsoft.Orleans.CodeGenerator`).
- Remove all references to `Microsoft.Orleans.OrleansRuntime`.
  - The [Microsoft.Orleans.Server](https://nuget.org/packages/Microsoft.Orleans.Server) packages reference its replacement, `Microsoft.Orleans.Runtime`.
- Remove calls to `ConfigureApplicationParts`.
    _Application Parts_ have been removed. The C# Source Generator for Orleans is added to all packages (including the client and server) and automatically generates the equivalent of _Application Parts_.
- Replace references to `Microsoft.Orleans.OrleansServiceBus` with [Microsoft.Orleans.Streaming.EventHubs](https://nuget.org/packages/Microsoft.Orleans.Streaming.EventHubs).
- If using reminders, add a reference to [Microsoft.Orleans.Reminders](https://nuget.org/packages/Microsoft.Orleans.Reminders).
- If using streams, add a reference to [Microsoft.Orleans.Streaming](https://nuget.org/packages/Microsoft.Orleans.Streaming).

> [!TIP]
> All of the Orleans samples have been upgraded to Orleans 7.0 and can be used as a reference for what changes were made. For more information, see [Orleans issue #8035](https://github.com/dotnet/orleans/issues/8035) that itemizes the changes made to each sample.

## Orleans global using directives

All Orleans projects either directly or indirectly reference the `Microsoft.Orleans.Sdk` NuGet package. When an Orleans project is configured to _enable_ implicit usings (for example, `<ImplicitUsings>enable</ImplicitUsings>`), the project implicitly uses both the `Orleans` and `Orleans.Hosting` namespaces. This means app code doesn't need these `using` directives.

<!-- markdownlint-disable MD044 -->
For more information, see [ImplicitUsings](../core/project-sdk/msbuild-props.md#implicitusings) and [dotnet/orleans/src/Orleans.Sdk/build/Microsoft.Orleans.Sdk.targets](https://github.com/dotnet/orleans/blob/main/src/Orleans.Sdk/build/Microsoft.Orleans.Sdk.targets#L4-L5).
<!-- markdownlint-enable MD044 -->

## Hosting

The <xref:Orleans.ClientBuilder> type is replaced with the <xref:Microsoft.Extensions.Hosting.OrleansClientGenericHostExtensions.UseOrleansClient%2A> extension method on <xref:Microsoft.Extensions.Hosting.IHostBuilder>. The `IHostBuilder` type comes from the [Microsoft.Extensions.Hosting](https://www.nuget.org/packages/Microsoft.Extensions.Hosting) NuGet package. This means an Orleans client can be added to an existing host without creating a separate dependency injection container. The client connects to the cluster during startup. Once <xref:Microsoft.Extensions.Hosting.IHost.StartAsync%2A?displayProperty=nameWithType> completes, the client connects automatically. Services added to the `IHostBuilder` start in the order of registration. Calling `UseOrleansClient` before calling <xref:Microsoft.Extensions.Hosting.GenericHostBuilderExtensions.ConfigureWebHostDefaults%2A>, for example, ensures Orleans starts before ASP.NET Core starts, allowing immediate access to the client from the ASP.NET Core application.

To emulate the previous `ClientBuilder` behavior, create a separate `HostBuilder` and configure it with an Orleans client. An `IHostBuilder` can be configured with either an Orleans client or an Orleans silo. All silos register an instance of <xref:Orleans.IGrainFactory> and <xref:Orleans.IClusterClient> that the application can use, so configuring a client separately is unnecessary and unsupported.

## `OnActivateAsync` and `OnDeactivateAsync` signature change

Orleans allows grains to execute code during activation and deactivation. Use this capability to perform tasks such as reading state from storage or logging lifecycle messages. In Orleans 7.0, the signature of these lifecycle methods changed:

- <xref:Orleans.Grain.OnActivateAsync> now accepts a <xref:System.Threading.CancellationToken> parameter. When the <xref:System.Threading.CancellationToken> is canceled, abandon the activation process.
- <xref:Orleans.Grain.OnDeactivateAsync> now accepts a <xref:Orleans.DeactivationReason> parameter and a `CancellationToken` parameter. The `DeactivationReason` indicates why the activation is being deactivated. Use this information for logging and diagnostics purposes. When the `CancellationToken` is canceled, complete the deactivation process promptly. Note that since any host can fail at any time, relying on `OnDeactivateAsync` to perform important actions, such as persisting critical state, isn't recommended.

Consider the following example of a grain overriding these new methods:

```csharp
public sealed class PingGrain : Grain, IPingGrain
{
    private readonly ILogger<PingGrain> _logger;

    public PingGrain(ILogger<PingGrain> logger) =>
        _logger = logger;

    public override Task OnActivateAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("OnActivateAsync()");
        return Task.CompletedTask;
    }

    public override Task OnDeactivateAsync(DeactivationReason reason, CancellationToken token)
    {
        _logger.LogInformation("OnDeactivateAsync({Reason})", reason);
        return Task.CompletedTask;
    }

    public ValueTask Ping() => ValueTask.CompletedTask;
}
```

## POCO grains and `IGrainBase`

Grains in Orleans no longer need to inherit from the <xref:Orleans.Grain> base class or any other class. This functionality is referred to as [POCO](../standard/glossary.md#poco) grains. To access extension methods such as any of the following:

- <xref:Orleans.GrainBaseExtensions.DeactivateOnIdle%2A>
- <xref:Orleans.GrainExtensions.AsReference%2A>
- <xref:Orleans.GrainExtensions.Cast%2A>
- <xref:Orleans.GrainExtensions.GetPrimaryKey%2A>
- <xref:Orleans.GrainReminderExtensions.GetReminder%2A>
- <xref:Orleans.GrainReminderExtensions.GetReminders%2A>
- <xref:Orleans.GrainReminderExtensions.RegisterOrUpdateReminder%2A>
- <xref:Orleans.GrainReminderExtensions.UnregisterReminder%2A>
- <xref:Orleans.GrainStreamingExtensions.GetStreamProvider%2A>

The grain must either implement <xref:Orleans.IGrainBase> or inherit from <xref:Orleans.Grain>. Here's an example of implementing `IGrainBase` on a grain class:

```csharp
public sealed class PingGrain : IGrainBase, IPingGrain
{
    public PingGrain(IGrainContext context) => GrainContext = context;

    public IGrainContext GrainContext { get; }

    public ValueTask Ping() => ValueTask.CompletedTask;
}
```

`IGrainBase` also defines `OnActivateAsync` and `OnDeactivateAsync` with default implementations, allowing the grain to participate in its lifecycle if desired:

```csharp
public sealed class PingGrain : IGrainBase, IPingGrain
{
    private readonly ILogger<PingGrain> _logger;

    public PingGrain(IGrainContext context, ILogger<PingGrain> logger)
    {
        _logger = logger;
        GrainContext = context;
    }

    public IGrainContext GrainContext { get; }

    public Task OnActivateAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("OnActivateAsync()");
        return Task.CompletedTask;
    }

    public Task OnDeactivateAsync(DeactivationReason reason, CancellationToken token)
    {
        _logger.LogInformation("OnDeactivateAsync({Reason})", reason);
        return Task.CompletedTask;
    }

    public ValueTask Ping() => ValueTask.CompletedTask;
}
```

## Serialization

The most burdensome change in Orleans 7.0 is the introduction of the version-tolerant serializer. This change was made because applications tend to evolve, which led to a significant pitfall for developers since the previous serializer couldn't tolerate adding properties to existing types. On the other hand, the previous serializer was flexible, allowing representation of most .NET types without modification, including features such as generics, polymorphism, and reference tracking. A replacement was long overdue, but high-fidelity representation of types is still needed. Therefore, Orleans 7.0 introduces a replacement serializer supporting high-fidelity representation of .NET types while also allowing types to evolve. The new serializer is much more efficient than the previous one, resulting in up to 170% higher end-to-end throughput.

For more information, see the following articles as it relates to Orleans 7.0:

- [Serialization overview](host/configuration-guide/serialization.md?pivots=orleans-7.0)
- [Serialization configuration](host/configuration-guide/serialization-configuration.md?pivots=orleans-7.0)
- [Serialization customization](host/configuration-guide/serialization-customization.md?pivots=orleans-7.0)

## Grain identities

Grains each have a unique identity comprised of the grain's type and its key. Previous Orleans versions used a compound type for `GrainId`s to support grain keys of either:

- <xref:System.Guid>
- [`long`](xref:System.Int64)
- [string](xref:System.String)
- <xref:System.Guid>+ [string](xref:System.String)
- [`long`](xref:System.Int64) + [string](xref:System.String)

This approach involves some complexity when dealing with grain keys. Grain identities consist of two components: a type and a key. The type component previously consisted of a numeric type code, a category, and 3 bytes of generic type information.

Grain identities now take the form `type/key`, where both `type` and `key` are strings. The most commonly used grain key interface is <xref:Orleans.IGrainWithStringKey>. This greatly simplifies how grain identity works and improves support for generic grain types.

Grain interfaces are now also represented using a human-readable name, rather than a combination of a hash code and a string representation of any generic type parameters.

The new system is more customizable, and these customizations can be driven with attributes.

- <xref:Orleans.GrainTypeAttribute.%23ctor(System.String)> on a grain `class` specifies the *Type* portion of its grain ID.
- <xref:Orleans.Metadata.DefaultGrainTypeAttribute.%23ctor(System.String)> on a grain `interface` specifies the *Type* of the grain that <xref:Orleans.IGrainFactory> should resolve by default when getting a grain reference. For example, when calling `IGrainFactory.GetGrain<IMyGrain>("my-key")`, the grain factory returns a reference to the grain `"my-type/my-key"` if `IMyGrain` has the aforementioned attribute specified.
- <xref:Orleans.Runtime.GrainInterfaceTypeAttribute.%23ctor(System.String)> allows overriding the interface name. Specifying a name explicitly using this mechanism allows renaming the interface type without breaking compatibility with existing grain references. Note that the interface should also have the <xref:Orleans.AliasAttribute> in this case, since its identity might be serialized. For more information on specifying a type alias, see the section on serialization.

As mentioned above, overriding the default grain class and interface names for types allows renaming the underlying types without breaking compatibility with existing deployments.

## Stream identities

When Orleans streams were first released, streams could only be identified using a <xref:System.Guid>. This approach was efficient in terms of memory allocation but made creating meaningful stream identities difficult, often requiring some encoding or indirection to determine the appropriate stream identity for a given purpose.

In Orleans 7.0, streams are identified using strings. The <xref:Orleans.Runtime.StreamId?displayProperty=fullName> `struct` contains three properties: <xref:Orleans.Runtime.StreamId.Namespace?displayProperty=nameWithType>, <xref:Orleans.Runtime.StreamId.Key?displayProperty=nameWithType>, and <xref:Orleans.Runtime.StreamId.FullKey?displayProperty=nameWithType>. These property values are encoded UTF-8 strings. For example, see <xref:Orleans.Runtime.StreamId.Create(System.String,System.String)?displayProperty=nameWithType>.

### Replacement of SimpleMessageStreams with BroadcastChannel

`SimpleMessageStreams` (also called SMS) is removed in 7.0. SMS had the same interface as <xref:Orleans.Providers.Streams.PersistentStreams?displayProperty=fullName>, but its behavior was very different because it relied on direct grain-to-grain calls. To avoid confusion, SMS was removed and a new replacement called <xref:Orleans.BroadcastChannel?displayProperty=fullName> was introduced.

`BroadcastChannel` only supports implicit subscriptions and can be a direct replacement in this case. If explicit subscriptions are needed or the `PersistentStream` interface must be used (for example, if SMS was used in tests while `EventHub` was used in production), then `MemoryStream` is the best candidate.

`BroadcastChannel` has the same behaviors as SMS, while `MemoryStream` behaves like other stream providers. Consider the following Broadcast Channel usage example:

```csharp
// Configuration
builder.AddBroadcastChannel(
    "my-provider",
    options => options.FireAndForgetDelivery = false);

// Publishing
var grainKey = Guid.NewGuid().ToString("N");
var channelId = ChannelId.Create("some-namespace", grainKey);
var stream = provider.GetChannelWriter<int>(channelId);

await stream.Publish(1);
await stream.Publish(2);
await stream.Publish(3);

// Simple implicit subscriber example
[ImplicitChannelSubscription]
public sealed class SimpleSubscriberGrain : Grain, ISubscriberGrain, IOnBroadcastChannelSubscribed
{
    // Called when a subscription is added to the grain
    public Task OnSubscribed(IBroadcastChannelSubscription streamSubscription)
    {
        streamSubscription.Attach<int>(
          item => OnPublished(streamSubscription.ChannelId, item),
          ex => OnError(streamSubscription.ChannelId, ex));

        return Task.CompletedTask;

        // Called when an item is published to the channel
        static Task OnPublished(ChannelId id, int item)
        {
            // Do something
            return Task.CompletedTask;
        }

        // Called when an error occurs
        static Task OnError(ChannelId id, Exception ex)
        {
            // Do something
            return Task.CompletedTask;
        }
    }
}
```

Migration to `MemoryStream` is easier since only the configuration needs changing. Consider the following `MemoryStream` configuration:

```csharp
builder.AddMemoryStreams<DefaultMemoryMessageBodySerializer>(
    "in-mem-provider",
    _ =>
    {
        // Number of pulling agent to start.
        // DO NOT CHANGE this value once deployed, if you do rolling deployment
        _.ConfigurePartitioning(partitionCount: 8);
    });
```

## OpenTelemetry

The telemetry system is updated in Orleans 7.0, and the previous system is removed in favor of standardized .NET APIs such as .NET Metrics for metrics and <xref:System.Diagnostics.ActivitySource> for tracing.

As part of this, the existing `Microsoft.Orleans.TelemetryConsumers.*` packages are removed. A new set of packages is being considered to streamline integrating metrics emitted by Orleans into the monitoring solution of choice. As always, feedback and contributions are welcome.

The `dotnet-counters` tool features performance monitoring for ad-hoc health monitoring and first-level performance investigation. For Orleans counters, use the [dotnet-counters](../core/diagnostics/dotnet-counters.md) tool to monitor them:

```dotnetcli
dotnet counters monitor -n MyApp --counters Microsoft.Orleans
```

Similarly, add the `Microsoft.Orleans` meters to OpenTelemetry metrics, as shown in the following code:

```csharp
builder.Services.AddOpenTelemetry()
    .WithMetrics(metrics => metrics
        .AddPrometheusExporter()
        .AddMeter("Microsoft.Orleans"));
```

To enable distributed tracing, configure OpenTelemetry as shown in the following code:

```csharp
builder.Services.AddOpenTelemetry()
    .WithTracing(tracing =>
    {
        tracing.SetResourceBuilder(ResourceBuilder.CreateDefault()
            .AddService(serviceName: "ExampleService", serviceVersion: "1.0"));

        tracing.AddAspNetCoreInstrumentation();
        tracing.AddSource("Microsoft.Orleans.Runtime");
        tracing.AddSource("Microsoft.Orleans.Application");

        tracing.AddZipkinExporter(options =>
        {
            options.Endpoint = new Uri("http://localhost:9411/api/v2/spans");
        });
    });
```

In the preceding code, OpenTelemetry is configured to monitor:

- `Microsoft.Orleans.Runtime`
- `Microsoft.Orleans.Application`

To propagate activity, call <xref:Orleans.Hosting.ClientBuilderExtensions.AddActivityPropagation%2A>:

```csharp
builder.Host.UseOrleans((_, clientBuilder) =>
{
    clientBuilder.AddActivityPropagation();
});
```

## Refactor features from core package into separate packages

In Orleans 7.0, extensions were factored into separate packages that don't rely on <xref:Orleans.Core?displayName=fullName>. Namely, <xref:Orleans.Streaming?displayName=fullName>, <xref:Orleans.Reminders?displayName=fullName>, and <xref:Orleans.Transactions?displayName=fullName> were separated from the core. This means these packages are entirely *pay* for what is _used_, and no code in the Orleans core is dedicated to these features. This approach slims down the core API surface and assembly size, simplifies the core, and improves performance. Regarding performance, transactions in Orleans previously required some code executing for every method to coordinate potential transactions. That coordination logic is now moved to a per-method basis.

This is a compilation-breaking change. Existing code interacting with reminders or streams by calling methods previously defined on the <xref:Orleans.Grain> base class might break because these are now extension methods. Update such calls that don't specify `this` (e.g., <xref:Orleans.GrainReminderExtensions.GetReminders%2A>) to include `this` (e.g., `this.GetReminders()`) because extension methods must be qualified. A compilation error occurs if these calls aren't updated, and the required code change might not be obvious without knowing what changed.

## Transaction client

Orleans 7.0 introduces a new abstraction for coordinating transactions: <xref:Orleans.ITransactionClient?displayProperty=fullName>. Previously, only grains could coordinate transactions. With `ITransactionClient`, available via dependency injection, clients can also coordinate transactions without needing an intermediary grain. The following example withdraws credits from one account and deposits them into another within a single transaction. Call this code from within a grain or from an external client that retrieved the `ITransactionClient` from the dependency injection container.

```csharp
await transactionClient.RunTransaction(
  TransactionOption.Create,
  () => Task.WhenAll(from.Withdraw(100), to.Deposit(100)));
```

For transactions coordinated by the client, the client must add the required services during configuration:

``` csharp
clientBuilder.UseTransactions();
```

The [BankAccount](https://github.com/dotnet/samples/tree/main/orleans/BankAccount) sample demonstrates the usage of `ITransactionClient`. For more information, see [Orleans transactions](grains/transactions.md).

## Call chain reentrancy

Grains are single-threaded and process requests one by one from beginning to completion by default. In other words, grains are not reentrant by default. Adding the <xref:Orleans.Concurrency.ReentrantAttribute> to a grain class allows the grain to process multiple requests concurrently in an interleaving fashion while still being single-threaded. This capability can be useful for grains holding no internal state or performing many asynchronous operations, such as issuing HTTP calls or writing to a database. Extra care is needed when requests can interleave: it's possible that a grain's state observed before an `await` statement changes by the time the asynchronous operation completes and the method resumes execution.

For example, the following grain represents a counter. It's marked `Reentrant`, allowing multiple calls to interleave. The `Increment()` method should increment the internal counter and return the observed value. However, because the `Increment()` method body observes the grain's state before an `await` point and updates it afterward, multiple interleaving executions of `Increment()` can result in a `_value` less than the total number of `Increment()` calls received. This is an error introduced by improper use of reentrancy.

Removing the <xref:Orleans.Concurrency.ReentrantAttribute> is enough to fix this problem.

```csharp
[Reentrant]
public sealed class CounterGrain : Grain, ICounterGrain
{
    int _value;

    /// <summary>
    /// Increments the grain's value and returns the previous value.
    /// </summary>
    public Task<int> Increment()
    {
        // Do not copy this code, it contains an error.
        var currentVal = _value;
        await Task.Delay(TimeSpan.FromMilliseconds(1_000));
        _value = currentVal + 1;
        return currentValue;
    }
}
```

To prevent such errors, grains are non-reentrant by default. The downside is reduced throughput for grains performing asynchronous operations in their implementation, since the grain cannot process other requests while waiting for an asynchronous operation to complete. To alleviate this, Orleans offers several options to allow reentrancy in certain cases:

- For an entire class: Placing the <xref:Orleans.Concurrency.ReentrantAttribute> on the grain allows any request to the grain to interleave with any other request.
- For a subset of methods: Placing the <xref:Orleans.Concurrency.AlwaysInterleaveAttribute> on the grain *interface* method allows requests to that method to interleave with any other request and allows any other request to interleave requests to that method.
- For a subset of methods: Placing the <xref:Orleans.Concurrency.ReadOnlyAttribute> on the grain *interface* method allows requests to that method to interleave with any other `ReadOnly` request and allows any other `ReadOnly` request to interleave requests to that method. In this sense, it's a more restricted form of `AlwaysInterleave`.
- For any request within a call chain: <xref:Orleans.Runtime.RequestContext.AllowCallChainReentrancy?displayProperty=nameWithType> and <xref:Orleans.Runtime.RequestContext.SuppressCallChainReentrancy?displayProperty=nameWithType> allow opting in and out of allowing downstream requests to reenter the grain. Both calls return a value that _must_ be disposed of when exiting the request. Therefore, use them as follows:

``` csharp
public Task<int> OuterCall(IMyGrain other)
{
    // Allow call-chain reentrancy for this grain, for the duration of the method.
    using var _ = RequestContext.AllowCallChainReentrancy();
    await other.CallMeBack(this.AsReference<IMyGrain>());
}

public Task CallMeBack(IMyGrain grain)
{
    // Because OuterCall allowed reentrancy back into that grain, this method
    // will be able to call grain.InnerCall() without deadlocking.
    await grain.InnerCall();
}

public Task InnerCall() => Task.CompletedTask;
```

Opt-in to call-chain reentrancy per-grain, per-call-chain. For example, consider two grains, A and B. If grain A enables call chain reentrancy before calling grain B, grain B can call back into grain A in that call. However, grain A cannot call back into grain B if grain B hasn't *also* enabled call chain reentrancy. It's enabled per-grain, per-call-chain.

Grains can also suppress call chain reentrancy information from flowing down a call chain using `using var _ = RequestContext.SuppressCallChainReentrancy()`. This prevents subsequent calls from reentering.

### ADO.NET migration scripts

To ensure forward compatibility with Orleans clustering, persistence, and reminders relying on ADO.NET, the appropriate SQL migration script is needed:

- [Clustering](https://github.com/dotnet/orleans/tree/main/src/AdoNet/Orleans.Clustering.AdoNet/Migrations)
- [Persistence](https://github.com/dotnet/orleans/tree/main/src/AdoNet/Orleans.Persistence.AdoNet/Migrations)
- [Reminders](https://github.com/dotnet/orleans/tree/main/src/AdoNet/Orleans.Reminders.AdoNet/Migrations)

Select the files for the database used and apply them in order.
