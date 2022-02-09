---
title: Orleans silo lifecycles
description: Learn about .NET Orleans silo lifecycles.
ms.date: 02/01/2022
---

# Orleans silo lifecycle overview

Orleans silos use an observable lifecycle for ordered startup and shutdown of Orleans systems, as well as application layer components. For more information on the implementation details, see [Orleans lifecycle](../implementation/orleans-lifecycle.md).

## Stages

Orleans silo and cluster clients use a common set of service lifecycle stages.

```csharp
public static class ServiceLifecycleStage
{
    public const int First = int.MinValue;
    public const int RuntimeInitialize = 2000;
    public const int RuntimeServices = 4000;
    public const int RuntimeStorageServices = 6000;
    public const int RuntimeGrainServices = 8000;
    public const int ApplicationServices = 10000;
    public const int BecomeActive = Active-1;
    public const int Active = 20000;
    public const int Last = int.MaxValue;
}
```

- `First`: The first stage in the service's lifecycle.
- `RuntimeInitialize`: The initialization of the runtime environment, where the silo initializes threading.
- `RuntimeServices`: The start of runtime services, where the silo initializes networking and various agents.
- `RuntimeStorageServices`: The initialization of runtime storage.
- `RuntimeGrainServices`: The starting of runtime services for grains. This includes grain type management, membership service, and grain directory.
- `ApplicationServices`: The application layer services.
- `BecomeActive`: The silo joins the cluster.
- `Active`: The silo is active in the cluster and ready to accept workload.
- `Last`: The last stage in the service's lifecycle.

## Logging

Due to the inversion of control, where participants join the lifecycle rather than the lifecycle having some centralized set of initialization steps, it's not always clear from the code what the startup/shutdown order is. To help address this, logging has been added before silo startup to report what components are participating at each stage. These logs are recorded at the _Information_ log level on the `Orleans.Runtime.SiloLifecycleSubject` logger. For instance:

```Output
Information, Orleans.Runtime.SiloLifecycleSubject, "Stage 2000: Orleans.Statistics.PerfCounterEnvironmentStatistics, Orleans.Runtime.InsideRuntimeClient, Orleans.Runtime.Silo"

Information, Orleans.Runtime.SiloLifecycleSubject, "Stage 4000: Orleans.Runtime.Silo"

Information, Orleans.Runtime.SiloLifecycleSubject, "Stage 10000: Orleans.Runtime.Versions.GrainVersionStore, Orleans.Storage.AzureTableGrainStorage-Default, Orleans.Storage.AzureTableGrainStorage-PubSubStore"
```

Additionally, timing and error information are similarly logged for each component by stage. For instance:

```Output
Information, Orleans.Runtime.SiloLifecycleSubject, "Lifecycle observer Orleans.Runtime.InsideRuntimeClient started in stage 2000 which took 33 Milliseconds."

Information, Orleans.Runtime.SiloLifecycleSubject, "Lifecycle observer Orleans.Statistics.PerfCounterEnvironmentStatistics started in stage 2000 which took 17 Milliseconds."
```

## Silo lifecycle participation

Application logic can take part in the silo's lifecycle by registering a participating service in the silo's service container. The service must be registered as an `ILifecycleParticipant<ISiloLifecycle>`.

```csharp
public interface ISiloLifecycle : ILifecycleObservable
{
}

public interface ILifecycleParticipant<TLifecycleObservable>
    where TLifecycleObservable : ILifecycleObservable
{
    void Participate(TLifecycleObservable lifecycle);
}
```

When the silo starts, all participants (`ILifecycleParticipant<ISiloLifecycle>`) in the container will be allowed to participate by calling their `Participate(..)` behavior. Once all have had the opportunity to participate, the silo's observable lifecycle will start all stages in order.

### Example

With the introduction of the silo lifecycle, bootstrap providers, which used to allow application developers to inject logic at the provider initialization phase, are no longer necessary, since application logic can now be injected at any stage of silo startup. Nonetheless, we added a 'startup task' facade to aid the transition for developers who had been using bootstrap providers. As an example of how components can be developed which take part in the silo's lifecycle, we'll look at the startup task facade.

The startup task needs only to inherit from `ILifecycleParticipant<ISiloLifecycle>` and subscribe the application logic to the silo lifecycle at the specified stage.

```csharp
class StartupTask : ILifecycleParticipant<ISiloLifecycle>
{
    private readonly IServiceProvider _serviceProvider;
    private readonly Func<IServiceProvider, CancellationToken, Task> _startupTask;
    private readonly int _stage;

    public StartupTask(
        IServiceProvider serviceProvider,
        Func<IServiceProvider, CancellationToken, Task> startupTask,
        int stage)
    {
        _serviceProvider = serviceProvider;
        _startupTask = startupTask;
        _stage = stage;
    }

    public void Participate(ISiloLifecycle lifecycle)
    {
        lifecycle.Subscribe<StartupTask>(
            _stage,
            cancellation => _startupTask(_serviceProvider, cancellation));
    }
}
```

From the above implementation, we can see that in the `Participate(...)` call it subscribes to the silo lifecycle at the configured stage, passing the application callback rather than its initialization logic. Components that need to be initialized at a given stage would provide their callback, but the pattern is the same. Now that we have a `StartupTask` which will ensure that the application's hook is called at the configured stage, we need to ensure that the `StartupTask` participates in the silo lifecycle.

For this, we need only register it in the container. We do this with an extension function on the `ISiloHostBuilder`:

```csharp
public static ISiloHostBuilder AddStartupTask(
    this ISiloHostBuilder builder,
    Func<IServiceProvider, CancellationToken, Task> startupTask,
    int stage = ServiceLifecycleStage.Active)
{
    builder.ConfigureServices(services =>
        services.AddTransient<ILifecycleParticipant<ISiloLifecycle>>(
            serviceProvider =>
                new StartupTask(
                    serviceProvider, startupTask, stage)));

    return builder;
}
```

By registering the StartupTask in the silo's service container as the marker interface `ILifecycleParticipant<ISiloLifecycle>`, this signals to the silo that this component needs to take part in the silo lifecycle.
