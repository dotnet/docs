---
title: Orleans lifecycle
description: Learn the various lifecycles of .NET Orleans apps.
ms.date: 02/01/2022
---

# Orleans lifecycle overview

Some Orleans behaviors are sufficiently complex that they need ordered startup and shutdown. Some components with such behaviors include grains, silos, and clients. To address this, a general component lifecycle pattern has been introduced. This pattern consists of an observable lifecycle, which is responsible for signaling on stages of a component's startup and shutdown, and lifecycle observers which are responsible for performing startup or shutdown operations at specific stages.

For more information, see [Grain lifecycle](../grains/grain-lifecycle.md) and [Silo lifecycle](../host/silo-lifecycle.md).

## Observable lifecycle

Components that need ordered startup and shutdown can use an observable lifecycle which allows other components to observe the lifecycle and receive a notification when a stage is reached during startup or shutdown.

```csharp
public interface ILifecycleObservable
{
    IDisposable Subscribe(
        string observerName,
        int stage,
        ILifecycleObserver observer);
}
```

The subscribe call registers an observer for notification when a stage is reached while starting or stopping. The observer's name is for reporting purposes. The stage indicated at which point in the startup/shutdown sequence the observer will be notified. Each stage of the lifecycle is observable. All observers will be notified when the stage is reached when starting and stopping. Stages are started in ascending order and stopped in descending order. The observer can unsubscribe by disposing of the returned disposable.

## Lifecycle observer

Components that need to take part in another component's lifecycle need to provide hooks for their startup and shutdown behaviors and subscribe to a specific stage of an observable lifecycle.

```csharp
public interface ILifecycleObserver
{
    Task OnStart(CancellationToken ct);
    Task OnStop(CancellationToken ct);
}
```

`OnStart/OnStop` will be called when the stage subscribed to is reached during startup/shutdown.

## Utilities

For convenience, helper functions have been created for common lifecycle usage patterns.

### Extensions

Extension functions exist for subscribing to observable lifecycle which doesn't require that the subscribing component implement ILifecycleObserver. Instead, these allow components to pass in lambdas or members function to be called at the subscribed stages.

```csharp
IDisposable Subscribe(
    this ILifecycleObservable observable,
    string observerName,
    int stage,
    Func<CancellationToken, Task> onStart,
    Func<CancellationToken, Task> onStop);

IDisposable Subscribe(
    this ILifecycleObservable observable,
    string observerName,
    int stage,
    Func<CancellationToken, Task> onStart);
```

Similar extension functions allow generic type arguments to be used in place of the observer name.

```csharp
IDisposable Subscribe<TObserver>(
    this ILifecycleObservable observable,
    int stage,
    Func<CancellationToken, Task> onStart,
    Func<CancellationToken, Task> onStop);

IDisposable Subscribe<TObserver>(
    this ILifecycleObservable observable,
    int stage,
    Func<CancellationToken, Task> onStart);
```

### Lifecycle participation

Some extensibility points need a way of recognizing what components are interested in participating in a lifecycle. A lifecycle participant marker interface has been introduced for this purpose. More about how this is used will be covered when exploring silo and grain lifecycles.

```csharp
public interface ILifecycleParticipant<TLifecycleObservable>
    where TLifecycleObservable : ILifecycleObservable
{
    void Participate(TLifecycleObservable lifecycle);
}
```

## Example

From our lifecycle tests, below is an example of a component that takes part in an observable lifecycle at multiple stages of the lifecycle.

```csharp
enum TestStages
{
    Down,
    Initialize,
    Configure,
    Run,
};

class MultiStageObserver : ILifecycleParticipant<ILifecycleObservable>
{
    public Dictionary<TestStages,bool> Started { get; } = new();
    public Dictionary<TestStages, bool> Stopped { get; } = new();

    private Task OnStartStage(TestStages stage)
    {
        Started[stage] = true;

        return Task.CompletedTask;
    }

    private Task OnStopStage(TestStages stage)
    {
        Stopped[stage] = true;

        return Task.CompletedTask;
    }

    public void Participate(ILifecycleObservable lifecycle)
    {
        lifecycle.Subscribe<MultiStageObserver>(
            (int)TestStages.Down,
            _ => OnStartStage(TestStages.Down),
            _ => OnStopStage(TestStages.Down));

        lifecycle.Subscribe<MultiStageObserver>(
            (int)TestStages.Initialize,
            _ => OnStartStage(TestStages.Initialize),
            _ => OnStopStage(TestStages.Initialize));

        lifecycle.Subscribe<MultiStageObserver>(
            (int)TestStages.Configure,
            _ => OnStartStage(TestStages.Configure),
            _ => OnStopStage(TestStages.Configure));

        lifecycle.Subscribe<MultiStageObserver>(
            (int)TestStages.Run,
            _ => OnStartStage(TestStages.Run),
            _ => OnStopStage(TestStages.Run));
    }
}
```
