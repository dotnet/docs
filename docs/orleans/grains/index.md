---
title: Develop a grain
description: Learn how to develop a grain in .NET Orleans.
ms.date: 05/23/2025
ms.topic: conceptual
---

# Develop a grain

Before writing code to implement a grain class, create a new Class Library project targeting .NET Standard or .NET Core (preferred), or .NET Framework 4.6.1 or higher (if you cannot use .NET Standard or .NET Core due to dependencies). You can define grain interfaces and grain classes in the same Class Library project or in two different projects for better separation of interfaces from implementation. In either case, the projects need to reference the [Microsoft.Orleans.Sdk](https://www.nuget.org/packages/Microsoft.Orleans.Sdk) NuGet package.

For more thorough instructions, see the [Project Setup](../tutorials-and-samples/tutorial-1.md#project-setup) section of [Tutorial One – Orleans Basics](../tutorials-and-samples/tutorial-1.md).

## Grain interfaces and classes

Grains interact with each other and are called from outside by invoking methods declared as part of their respective grain interfaces. A grain class implements one or more previously declared grain interfaces. All methods of a grain interface must return a <xref:System.Threading.Tasks.Task> (for `void` methods), a <xref:System.Threading.Tasks.Task%601>, or a <xref:System.Threading.Tasks.ValueTask%601> (for methods returning values of type `T`).

The following is an excerpt from the Orleans Presence Service sample:

```csharp
public interface IPlayerGrain : IGrainWithGuidKey
{
    Task<IGameGrain> GetCurrentGame();

    Task JoinGame(IGameGrain game);

    Task LeaveGame(IGameGrain game);
}

public class PlayerGrain : Grain, IPlayerGrain
{
    private IGameGrain _currentGame;

    // Game the player is currently in. May be null.
    public Task<IGameGrain> GetCurrentGame()
    {
       return Task.FromResult(_currentGame);
    }

    // Game grain calls this method to notify that the player has joined the game.
    public Task JoinGame(IGameGrain game)
    {
       _currentGame = game;

       Console.WriteLine(
           $"Player {GetPrimaryKey()} joined game {game.GetPrimaryKey()}");

       return Task.CompletedTask;
    }

   // Game grain calls this method to notify that the player has left the game.
   public Task LeaveGame(IGameGrain game)
   {
       _currentGame = null;

       Console.WriteLine(
           $"Player {GetPrimaryKey()} left game {game.GetPrimaryKey()}");

       return Task.CompletedTask;
   }
}
```

## Response timeout for grain methods

The Orleans runtime allows you to enforce a response timeout per grain method. If a grain method doesn't complete within the timeout, the runtime throws a <xref:System.TimeoutException>. To impose a response timeout, add the `ResponseTimeoutAttribute` to the interface's grain method definition. It's crucial to add the attribute to the interface method definition, not the method implementation in the grain class, as both the client and the silo need to be aware of the timeout.

Extending the previous `PlayerGrain` implementation, the following example shows how to impose a response timeout on the `LeaveGame` method:

```csharp
public interface IPlayerGrain : IGrainWithGuidKey
{
    Task<IGameGrain> GetCurrentGame();

    Task JoinGame(IGameGrain game);

    [ResponseTimeout("00:00:05")] // 5s timeout
    Task LeaveGame(IGameGrain game);
}
```

The preceding code sets a response timeout of five seconds on the `LeaveGame` method. When leaving a game, if it takes longer than five seconds a <xref:System.TimeoutException> is thrown.

### Configure response timeout

Similar to individual grain method response timeouts, you can configure a default response timeout for all grain methods. Calls to grain methods time out if a response isn't received within the specified period. By default, this period is **30 seconds**. You can configure the default response timeout:

- By configuring <xref:Orleans.Configuration.MessagingOptions.ResponseTimeout> on <xref:Orleans.Configuration.ClientMessagingOptions>, on an external client.
- By configuring <xref:Orleans.Configuration.MessagingOptions.ResponseTimeout> on <xref:Orleans.Configuration.SiloMessagingOptions>, on a server.

For more information on configuring Orleans, see [Client configuration](../host/configuration-guide/client-configuration.md) or [Server configuration](../host/configuration-guide/server-configuration.md).

## Return values from grain methods

Define a grain method that returns a value of type `T` in a grain interface as returning a `Task<T>`.
For grain methods not marked with the `async` keyword, when the return value is available, you usually return it using the following statement:

```csharp
public Task<SomeType> GrainMethod1()
{
    return Task.FromResult(GetSomeType());
}
```

Define a grain method that returns no value (effectively a void method) in a grain interface as returning a `Task`. The returned `Task` indicates the asynchronous execution and completion of the method. For grain methods not marked with the `async` keyword, when a "void" method completes its execution, it needs to return the special value <xref:System.Threading.Tasks.Task.CompletedTask?displayProperty=nameWithType>:

```csharp
public Task GrainMethod2()
{
    return Task.CompletedTask;
}
```

A grain method marked as `async` returns the value directly:

```csharp
public async Task<SomeType> GrainMethod3()
{
    return await GetSomeTypeAsync();
}
```

A `void` grain method marked as `async` that returns no value simply returns at the end of its execution:

```csharp
public async Task GrainMethod4()
{
    return;
}
```

If a grain method receives the return value from another asynchronous method call (to a grain or not) and doesn't need to perform error handling for that call, it can simply return the `Task` it receives from that asynchronous call:

```csharp
public Task<SomeType> GrainMethod5()
{
    Task<SomeType> task = CallToAnotherGrain();

    return task;
}
```

Similarly, a `void` grain method can return a `Task` returned to it by another call instead of awaiting it.

```csharp
public Task GrainMethod6()
{
    Task task = CallToAsyncAPI();
    return task;
}
```

`ValueTask<T>` can be used instead of `Task<T>`.

## Grain references

A grain reference is a proxy object implementing the same grain interface as the corresponding grain class. It encapsulates the logical identity (type and unique key) of the target grain. You use grain references to make calls to the target grain. Each grain reference points to a single grain (a single instance of the grain class), but you can create multiple independent references to the same grain.

Since a grain reference represents the logical identity of the target grain, it's independent of the grain's physical location and remains valid even after a complete system restart. You can use grain references like any other .NET object. You can pass it to a method, use it as a method return value, etc., and even save it to persistent storage.

You can obtain a grain reference by passing the identity of a grain to the <xref:Orleans.IGrainFactory.GetGrain%60%601(System.Type,System.Guid)?displayProperty=nameWithType> method, where `T` is the grain interface and `key` is the unique key of the grain within its type.

The following examples show how to obtain a grain reference for the `IPlayerGrain` interface defined previously.

From inside a grain class:

```csharp
IPlayerGrain player = GrainFactory.GetGrain<IPlayerGrain>(playerId);
```

From Orleans client code.

```csharp
IPlayerGrain player = client.GetGrain<IPlayerGrain>(playerId);
```

For more information about grain references, see the [grain reference article](grain-references.md).

### Grain method invocation

The Orleans programming model is based on [asynchronous programming](../../csharp/asynchronous-programming/index.md). Using the grain reference from the previous example, here's how you perform a grain method invocation:

```csharp
// Invoking a grain method asynchronously
Task joinGameTask = player.JoinGame(this);

// The await keyword effectively makes the remainder of the
// method execute asynchronously at a later point
// (upon completion of the Task being awaited) without blocking the thread.
await joinGameTask;

// The next line will execute later, after joinGameTask has completed.
players.Add(playerId);
```

You can join two or more `Tasks`. The join operation creates a new `Task` that resolves when all its constituent `Tasks` complete. This pattern is useful when a grain needs to start multiple computations and wait for all of them to complete before proceeding. For example, a front-end grain generating a web page made of many parts might make multiple back-end calls (one for each part) and receive a `Task` for each result. The grain would then await the join of all these `Tasks`. When the joined `Task` resolves, the individual `Tasks` have completed, and all the data required to format the web page has been received.

Example:

```csharp
List<Task> tasks = new List<Task>();
Message notification = CreateNewMessage(text);

foreach (ISubscriber subscriber in subscribers)
{
    tasks.Add(subscriber.Notify(notification));
}

// WhenAll joins a collection of tasks, and returns a joined
// Task that will be resolved when all of the individual notification Tasks are resolved.
Task joinedTask = Task.WhenAll(tasks);

await joinedTask;

// Execution of the rest of the method will continue
// asynchronously after joinedTask is resolve.
```

### Error propagation

When a grain method throws an exception, Orleans propagates that exception up the calling stack, across hosts as necessary. For this to work as intended, exceptions must be serializable by Orleans, and hosts handling the exception must have the exception type available. If an exception type isn't available, Orleans throws the exception as an instance of <xref:Orleans.Serialization.UnavailableExceptionFallbackException?displayProperty=nameWithType>, preserving the message, type, and stack trace of the original exception.

Exceptions thrown from grain methods don't cause the grain to be deactivated unless the exception inherits from <xref:Orleans.Storage.InconsistentStateException?displayProperty=nameWithType>. Storage operations throw `InconsistentStateException` when they discover that the grain's in-memory state is inconsistent with the state in the database. Aside from the special handling of `InconsistentStateException`, this behavior is similar to throwing an exception from any .NET object: exceptions don't cause an object to be destroyed.

### Virtual methods

A grain class can optionally override the <xref:Orleans.Grain.OnActivateAsync%2A> and <xref:Orleans.Grain.OnDeactivateAsync%2A> virtual methods. The Orleans runtime invokes these methods upon activation and deactivation of each grain of the class. This gives your grain code a chance to perform additional initialization and cleanup operations. An exception thrown by `OnActivateAsync` fails the activation process.

While `OnActivateAsync` (if overridden) is always called as part of the grain activation process, `OnDeactivateAsync` isn't guaranteed to be called in all situations (for example, in case of a server failure or other abnormal events). Because of this, your applications shouldn't rely on `OnDeactivateAsync` for performing critical operations, such as persisting state changes. Use it only for best-effort operations.

## See also

- [Grain extensions](grain-extensions.md)
- [Grain identity](grain-identity.md)
- [Grain references](grain-references.md)
- [Grain persistence](grain-persistence/index.md)
- [Grain lifecycle overview](grain-lifecycle.md)
- [Grain placement](grain-placement.md)
