---
title: Request scheduling
description: Learn about request scheduling in .NET Orleans.
ms.date: 07/03/2024
---

# Request scheduling

Grain activations have a *single-threaded* execution model and, by default, process each request from beginning to completion before the next request can begin processing. In some circumstances, it may be desirable for activation to process other requests while one request is waiting for an asynchronous operation to complete. For this and other reasons, Orleans gives the developer some control over the request interleaving behavior, as described in the [Reentrancy](#reentrancy) section. What follows is an example of non-reentrant request scheduling, which is the default behavior in Orleans.

Consider the following `PingGrain` definition:

```csharp
public interface IPingGrain : IGrainWithStringKey
{
    Task Ping();
    Task CallOther(IPingGrain other);
}

public class PingGrain : Grain, IPingGrain
{
    private readonly ILogger<PingGrain> _logger;

    public PingGrain(ILogger<PingGrain> logger) => _logger = logger;

    public Task Ping() => Task.CompletedTask;

    public async Task CallOther(IPingGrain other)
    {
        _logger.LogInformation("1");
        await other.Ping();
        _logger.LogInformation("2");
    }
}
```

Two grains of type `PingGrain` are involved in our example, *A* and *B*. A caller invokes the following call:

```csharp
var a = grainFactory.GetGrain("A");
var b = grainFactory.GetGrain("B");
await a.CallOther(b);
```

:::image type="content" source="grain-persistence/media/reentrancy-scheduling-diagram.png" alt-text="Reentrancy scheduling diagram." lightbox="grain-persistence/media/reentrancy-scheduling-diagram.png":::

The flow of execution is as follows:

1. The call arrives at *A*, which logs `"1"` and then issues a call to *B*.
1. *B* returns immediately from `Ping()` back to *A*.
1. *A* logs `"2"` and returns back to the original caller.

While *A* is awaiting the call to *B*, it can't process any incoming requests. As a result, if *A* and *B* were to call each other simultaneously, they may *deadlock* while waiting for those calls to complete. Here's an example, based on the client issuing the following call:

```csharp
var a = grainFactory.GetGrain("A");
var b = grainFactory.GetGrain("B");

// A calls B at the same time as B calls A.
// This might deadlock, depending on the non-deterministic timing of events.
await Task.WhenAll(a.CallOther(b), b.CallOther(a));
```

## Case 1: the calls don't deadlock

:::image type="content" source="grain-persistence/media/reentrancy-scheduling-diagram-01.png" alt-text="Reentrancy scheduling diagram without deadlock." lightbox="grain-persistence/media/reentrancy-scheduling-diagram-01.png":::

In this example:

1. The `Ping()` call from *A* arrives at *B* before the `CallOther(a)` call arrives at *B*.
1. Therefore, *B* processes the `Ping()` call before the `CallOther(a)` call.
1. Because *B* processes the `Ping()` call, *A* is able to return back to the caller.
1. When *B* issues its `Ping()` call to *A*, *A* is still busy logging its message (`"2"`), so the call has to wait for a short duration, but it's soon able to be processed.
1. *A* processes the `Ping()` call and returns to *B*, which returns to the original caller.

Consider a less fortunate series of events: one in which the same code results in a *deadlock* due to slightly different timing.

## Case 2: the calls deadlock

:::image type="content" source="grain-persistence/media/reentrancy-scheduling-diagram-02.png" alt-text="Reentrancy scheduling diagram with deadlock." lightbox="grain-persistence/media/reentrancy-scheduling-diagram-02.png":::

In this example:

1. The `CallOther` calls arrive at their respective grains and are processed simultaneously.
1. Both grains log `"1"` and proceed to `await other.Ping()`.
1. Since both grains are still *busy* (processing the `CallOther` request, which hasn't finished yet), the `Ping()` requests wait
1. After a while, Orleans determines that the call has **timed out** and each `Ping()` call results in an exception being thrown.
1. The `CallOther` method body doesn't handle the exception and it bubbles up to the original caller.

The following section describes how to prevent deadlocks by allowing multiple requests to interleave their execution with each other.

## Reentrancy

Orleans defaults to choosing a safe execution flow: one in which the internal state of a grain isn't modified concurrently during multiple requests. Concurrent modification of the internal state complicates logic and puts a greater burden on the developer. This protection against those kinds of concurrency bugs has a cost, which was previously discussed, primarily *liveness*: certain call patterns can lead to deadlocks. One way to avoid deadlocks is to ensure that grain calls never result in a cycle. Often, it's difficult to write code that is cycle-free and can't deadlock. Waiting for each request to run from beginning to completion before processing the next request can also hurt performance. For example, by default, if a grain method performs some asynchronous request to a database service then the grain pauses request execution until the response from the database arrives at the grain.

Each of those cases is discussed in the sections that follow. For these reasons, Orleans provides developers with options to allow some or all requests to be executed *concurrently*, interleaving their execution with each other. In Orleans, such concerns are referred to as *reentrancy* or *interleaving*. By executing requests concurrently, grains that perform asynchronous operations can process more requests in a shorter period.

Multiple requests may be interleaved in the following cases:

* The grain class is marked with <xref:Orleans.Concurrency.ReentrantAttribute>.
* The interface method is marked with <xref:Orleans.Concurrency.AlwaysInterleaveAttribute>.
* The grain's <xref:Orleans.Concurrency.MayInterleaveAttribute> predicate returns `true`.

With reentrancy, the following case becomes a valid execution and the possibility of the above deadlock is removed.

### Case 3: the grain or method is reentrant

:::image type="content" source="grain-persistence/media/reentrancy-scheduling-diagram-03.png" alt-text="Re-entrancy scheduling diagram with re-entrant grain or method." lightbox="grain-persistence/media/reentrancy-scheduling-diagram-03.png":::

In this example, grains *A* and *B* can call each other simultaneously without any potential for request scheduling deadlocks because both grains are *re-entrant*. The following sections provide more details on reentrancy.

### Re-entrant grains

The <xref:Orleans.Grain> implementation classes may be marked with the <xref:Orleans.Concurrency.ReentrantAttribute> to indicate that different requests may be freely interleaved.

In other words, a re-entrant activation may start another request while a previous request hasn't finished processing. Execution is still limited to a single thread, so the activation is still executing one turn at a time, and each turn is executing on behalf of only one of the activation's requests.

Re-entrant grain code never runs multiple pieces of grain code in parallel (execution of grain code is always single-threaded), but re-entrant grains **may** see the execution of code for different requests interleaving. That is, the continuation turns from different requests may interleave.

For example, as shown in the following pseudo-code, consider that `Foo` and `Bar` are two methods of the same grain class:

```csharp
Task Foo()
{
    await task1;    // line 1
    return Do2();   // line 2
}

Task Bar()
{
    await task2;   // line 3
    return Do2();  // line 4
}
```

If this grain is marked <xref:Orleans.Concurrency.ReentrantAttribute>, the execution of `Foo` and `Bar` may interleave.

For example, the following order of execution is possible:

Line 1, line 3, line 2 and line 4.
That is, the turns from different requests interleave.

If the grain wasn't re-entrant, the only possible executions would be: line 1, line 2, line 3, line 4 OR: line 3, line 4, line 1, line 2 (a new request can't start before the previous one finished).

The main tradeoff in choosing between reentrant and nonreentrant grains is the code complexity of making interleaving work correctly, and the difficulty to reason about it.

In a trivial case when the grains are stateless and the logic is simple, fewer (but not too few, so that all the hardware threads are used) re-entrant grains should, in general, be slightly more efficient.

If the code is more complex, then a larger number of non-reentrant grains, even if slightly less efficient overall, should save you much grief in figuring out nonobvious interleaving issues.

In the end, the answer depends on the specifics of the application.

### Interleaving methods

Grain interface methods marked with <xref:Orleans.Concurrency.AlwaysInterleaveAttribute>, always interleaves any other request and may always be interleaved with any other request, even requests for non-[AlwaysInterleave] methods.

Consider the following example:

```csharp
public interface ISlowpokeGrain : IGrainWithIntegerKey
{
    Task GoSlow();

    [AlwaysInterleave]
    Task GoFast();
}

public class SlowpokeGrain : Grain, ISlowpokeGrain
{
    public async Task GoSlow()
    {
        await Task.Delay(TimeSpan.FromSeconds(10));
    }

    public async Task GoFast()
    {
        await Task.Delay(TimeSpan.FromSeconds(10));
    }
}
```

Consider the call flow initiated by the following client request:

```csharp
var slowpoke = client.GetGrain<ISlowpokeGrain>(0);

// A. This will take around 20 seconds.
await Task.WhenAll(slowpoke.GoSlow(), slowpoke.GoSlow());

// B. This will take around 10 seconds.
await Task.WhenAll(slowpoke.GoFast(), slowpoke.GoFast(), slowpoke.GoFast());
```

Calls to `GoSlow` aren't interleaved, so the total execution time of the two `GoSlow` calls takes around 20 seconds. On the other hand, `GoFast` is marked <xref:Orleans.Concurrency.AlwaysInterleaveAttribute>, and the three calls to it are executed concurrently, completing in approximately 10 seconds total instead of requiring at least 30 seconds to complete.

### Readonly methods

When a grain method doesn't modify the grain state, it's safe to execute concurrently with other requests. The <xref:Orleans.Concurrency.ReadOnlyAttribute> indicates that a method doesn't modify the state of a grain. Marking methods as `ReadOnly` allows Orleans to process your request concurrently with other `ReadOnly` requests, which may significantly improve the performance of your app. Consider the following example:

```csharp
public interface IMyGrain : IGrainWithIntegerKey
{
    Task<int> IncrementCount(int incrementBy);

    [ReadOnly]
    Task<int> GetCount();
}
```

The `GetCount` method doesn't modify the grain state, so it's marked with `ReadOnly`. Callers awaiting this method invocation aren't blocked by other `ReadOnly` requests to the grain, and the method returns immediately.

### Call chain reentrancy

If a grain calls a method which on another grain which then calls back into the original grain, the call will result in a deadlock unless the call is reentrant. Reentrancy can be enabled on a per-call-site basis by using *call chain reentrancy*. To enable call chain reentrancy, call the <xref:Orleans.Runtime.RequestContext.AllowCallChainReentrancy> method, which returns a value that allows reentrance from any caller further down the call chain until it is disposed. This includes reentrance from the grain calling the method itself. Consider the following example:

```csharp
public interface IChatRoomGrain : IGrainWithStringKey
{
    ValueTask OnJoinRoom(IUserGrain user);
}

public interface IUserGrain : IGrainWithStringKey
{
    ValueTask JoinRoom(string roomName);
    ValueTask<string> GetDisplayName();
}

public class ChatRoomGrain : Grain<List<(string DisplayName, IUserGrain User)>>, IChatRoomGrain
{
    public async ValueTask OnJoinRoom(IUserGrain user)
    {
        var displayName = await user.GetDisplayName();
        State.Add((displayName, user));
        await WriteStateAsync();
    }
}

public class UserGrain : Grain, IUserGrain
{
    public ValueTask<string> GetDisplayName() => new(this.GetPrimaryKeyString());
    public async ValueTask JoinRoom(string roomName)
    {
        // This prevents the call below from triggering a deadlock.
        using var scope = RequestContext.AllowCallChainReentrancy();
        var roomGrain = GrainFactory.GetGrain<IChatRoomGrain>(roomName);
        await roomGrain.OnJoinRoom(this.AsReference<IUserGrain>());
    }
}
```

In the preceding example, `UserGrain.JoinRoom(roomName)` calls into `ChatRoomGrain.OnJoinRoom(user)`, which tries to call back into `UserGrain.GetDisplayName()` to get the user's display name. Since this call chain involves a cycle, this will result in a deadlock if the `UserGrain` doesn't allow reentrance using any of the supported mechanisms discussed in this article. In this instance, we are using <xref:Orleans.Runtime.RequestContext.AllowCallChainReentrancy>, which allows only `roomGrain` to call back into the `UserGrain`. This grants you fine grained control over where and how reentrancy is enabled.

If you were to instead prevent the deadlock by annotating the `GetDisplayName()` method declaration on `IUserGrain` with `[AlwaysInterleave]`, you would allow any grain to interleave a `GetDisplayName` call with any other method. Instead, you are allowing *only* `roomGrain` to call methods on our grain and only until `scope` is disposed.

#### Suppress call chain reentrancy

Call chain reentrance can also be *suppressed* using the <xref:Orleans.Runtime.RequestContext.SuppressCallChainReentrancy> method. This has limited usefulness to end developers, but it is important for internal use by libraries which extend Orleans grain functionality, such as [streaming](../streaming/index.md) and [broadcast channels](../streaming/broadcast-channel.md) to ensure that developers retain full control over when call chain reentrancy is enabled.

### Reentrancy using a predicate

Grain classes can specify a predicate to determine interleaving on a call-by-call basis by inspecting the request. The `[MayInterleave(string methodName)]` attribute provides this functionality. The argument to the attribute is the name of a static method within the grain class that accepts an <xref:Orleans.CodeGeneration.InvokeMethodRequest> object and returns a `bool` indicating whether or not the request should be interleaved.

Here's an example that allows interleaving if the request argument type has the `[Interleave]` attribute:

```csharp
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
public sealed class InterleaveAttribute : Attribute { }

// Specify the may-interleave predicate.
[MayInterleave(nameof(ArgHasInterleaveAttribute))]
public class MyGrain : Grain, IMyGrain
{
    public static bool ArgHasInterleaveAttribute(IInvokable req)
    {
        // Returning true indicates that this call should be interleaved with other calls.
        // Returning false indicates the opposite.
        return req.Arguments.Length == 1
            && req.Arguments[0]?.GetType()
                    .GetCustomAttribute<InterleaveAttribute>() != null;
    }

    public Task Process(object payload)
    {
        // Process the object.
    }
}
```
