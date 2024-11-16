---
title: Develop a grain
description: Learn how to develop a grain in .NET Orleans.
ms.date: 07/03/2024
---

# Develop a grain

Before you write code to implement a grain class, create a new Class Library project targeting .NET Standard or .NET Core (preferred) or .NET Framework 4.6.1 or higher (if you cannot use .NET Standard or .NET Core due to dependencies). Grain interfaces and grain classes can be defined in the same Class Library project, or in two different projects for better separation of interfaces from implementation. In either case, the projects need to reference [Microsoft.Orleans.Core.Abstractions](https://www.nuget.org/packages/Microsoft.Orleans.Core.Abstractions) and [Microsoft.Orleans.CodeGenerator.MSBuild](https://www.nuget.org/packages/Microsoft.Orleans.CodeGenerator.MSBuild) NuGet packages.

For more thorough instructions, see the [Project Setup](../tutorials-and-samples/tutorial-1.md#project-setup) section of [Tutorial One – Orleans Basics](../tutorials-and-samples/tutorial-1.md).

## Grain interfaces and classes

Grains interact with each other and get called from outside by invoking methods declared as part of the respective grain interfaces. A grain class implements one or more previously declared grain interfaces. All methods of a grain interface must return a <xref:System.Threading.Tasks.Task> (for `void` methods), a <xref:System.Threading.Tasks.Task%601> or a <xref:System.Threading.Tasks.ValueTask%601> (for methods returning values of type `T`).

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

The Orleans runtime allows you to enforce a response timeout per grain method. If a grain method doesn't complete within the timeout, the runtime throws the <xref:System.TimeoutException>. To impose a response timeout, add the `ResponseTimeoutAttribute` to the interface's grain method definition. It's very important that the attribute is added to the interface method definition, not to the method implementation in the grain class, as both the client and the silo need to be aware of the timeout.

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

Much like individual grain method response timeouts, you can configure a default response timeout for all grain methods. Calls to grain methods will timeout if a response isn't received within a specified time period. By default, this period is **30 seconds**. You can configure the default response timeout:

- By configuring <xref:Orleans.Configuration.MessagingOptions.ResponseTimeout> on <xref:Orleans.Configuration.ClientMessagingOptions>, on an external client.
- By configuring <xref:Orleans.Configuration.MessagingOptions.ResponseTimeout> on <xref:Orleans.Configuration.SiloMessagingOptions>, on a server.

For more information on configuring Orleans, see [Client configuration](../host/configuration-guide/client-configuration.md) or [Server configuration](../host/configuration-guide/server-configuration.md).

## Return values from grain methods

A grain method that returns a value of type `T` is defined in a grain interface as returning a `Task<T>`.
For grain methods not marked with the `async` keyword, when the return value is available, it is usually returned via the following statement:

```csharp
public Task<SomeType> GrainMethod1()
{
    return Task.FromResult(GetSomeType());
}
```

A grain method that returns no value, effectively a void method, is defined in a grain interface as returning a `Task`. The returned `Task` indicates asynchronous execution and completion of the method. For grain methods not marked with the `async` keyword, when a "void" method completes its execution, it needs to return the special value of <xref:System.Threading.Tasks.Task.CompletedTask?displayProperty=nameWithType>:

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

If a grain method receives the return value from another asynchronous method call, to a grain or not, and doesn't need to perform error handling of that call, it can simply return the `Task` it receives from that asynchronous call:

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

A Grain reference is a proxy object that implements the same grain interface as the corresponding grain class. It encapsulates the logical identity (type and unique key) of the target grain. Grain references are used for making calls to the target grain. Each grain reference is to a single grain (a single instance of the grain class), but one can create multiple independent references to the same grain.

Since a grain reference represents the logical identity of the target grain, it is independent of the physical location of the grain, and stays valid even after a complete restart of the system. Developers can use grain references like any other .NET object. It can be passed to a method, used as a method return value, etc., and even saved to persistent storage.

A grain reference can be obtained by passing the identity of a grain to the <xref:Orleans.IGrainFactory.GetGrain%60%601(System.Type,System.Guid)?displayProperty=nameWithType> method, where `T` is the grain interface and `key` is the unique key of the grain within the type.

The following are examples of how to obtain a grain reference of the `IPlayerGrain` interface defined above.

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

The Orleans programming model is based on [asynchronous programming](../../csharp/asynchronous-programming/index.md). Using the grain reference from the previous example, here's how to perform a grain method invocation:

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

It is possible to join two or more `Tasks`; the join operation creates a new `Task` that is resolved when all of its constituent `Task`s are completed. This is a useful pattern when a grain needs to start multiple computations and wait for all of them to complete before proceeding. For example, a front-end grain that generates a web page made of many parts might make multiple back-end calls, one for each part, and receive a `Task` for each result. The grain would then await the join of all of these `Tasks`; when the join `Task` is resolved, the individual `Task`s have been completed, and all the data required to format the web page has been received.

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

When a grain method throws an exception, Orleans propagates that exception up the calling stack, across hosts as necessary. For this to work as intended, exceptions must be serializable by Orleans and hosts which are handling the exception must have the exception type available. If an exception type isn't available, the exception will be thrown as an instance of <xref:Orleans.Serialization.UnavailableExceptionFallbackException?displayProperty=nameWithType>, preserving the message, type, and stack trace of the original exception.

Exceptions thrown from grain methods don't cause the grain to be deactivated unless the exception inherits from <xref:Orleans.Storage.InconsistentStateException?displayProperty=nameWithType>. `InconsistentStateException` is thrown by storage operations which discover that the grain's in-memory state is inconsistent with the state in the database. Aside from the special-casing of `InconsistentStateException`, this behavior is similar to throwing an exception from any .NET object: exceptions don't cause an object to be destroyed.

### Virtual methods

A grain class can optionally override the <xref:Orleans.Grain.OnActivateAsync%2A> and <xref:Orleans.Grain.OnDeactivateAsync%2A> virtual methods; these methods are invoked by the Orleans runtime upon activation and deactivation of each grain of the class. This gives the grain code a chance to perform additional initialization and cleanup operations. An exception thrown by `OnActivateAsync` fails the activation process.

While `OnActivateAsync`, if overridden, is always called as part of the grain activation process, `OnDeactivateAsync` is not guaranteed to get called in all situations, for example, in case of a server failure or other abnormal event. Because of that, applications should not rely on `OnDeactivateAsync` for performing critical operations such as the persistence of state changes. They should use it only for best-effort operations.

## See also

- [Grain extensions](grain-extensions.md)
- [Grain identity](grain-identity.md)
- [Grain references](grain-references.md)
- [Grain persistence](grain-persistence/index.md)
- [Grain lifecycle overview](grain-lifecycle.md)
- [Grain placement](grain-placement.md)
