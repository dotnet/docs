---
title: Observers
description: Learn about observers in .NET Orleans.
ms.date: 05/23/2025
ms.topic: conceptual
---

# Observers

Sometimes, a simple message/response pattern isn't enough, and the client needs to receive asynchronous notifications. For example, a user might want notification when a friend publishes a new instant message.

Client observers are a mechanism allowing asynchronous notification of clients. Observer interfaces must inherit from <xref:Orleans.IGrainObserver>, and all methods must return either `void`, <xref:System.Threading.Tasks.Task>, <xref:System.Threading.Tasks.Task%601>, <xref:System.Threading.Tasks.ValueTask>, or <xref:System.Threading.Tasks.ValueTask%601>. We don't recommend a return type of `void` because it might encourage using `async void` in the implementation. This is a dangerous pattern, as it can cause application crashes if an exception is thrown from the method. Instead, for best-effort notification scenarios, consider applying the <xref:Orleans.Concurrency.OneWayAttribute> to the observer's interface method. This causes the receiver not to send a response for the method invocation and makes the method return immediately at the call site, without waiting for a response from the observer. A grain calls a method on an observer by invoking it like any grain interface method. The Orleans runtime ensures the delivery of requests and responses. A common use case for observers is enlisting a client to receive notifications when an event occurs in the Orleans application. A grain publishing such notifications should provide an API to add or remove observers. Additionally, it's usually convenient to expose a method allowing cancellation of an existing subscription.

You can use a utility class like <xref:Orleans.Utilities.ObserverManager%601> to simplify the development of observed grain types. Unlike grains, which Orleans automatically reactivates as needed after failure, clients aren't fault-tolerant: a client that fails might never recover. For this reason, the `ObserverManager<T>` utility removes subscriptions after a configured duration. Active clients should resubscribe on a timer to keep their subscriptions active.

To subscribe to a notification, the client must first create a local object implementing the observer interface. It then calls a method on the observer factory, <xref:Orleans.IGrainFactory.CreateObjectReference%2A>`, to turn the object into a grain reference. You can then pass this reference to the subscription method on the notifying grain.

Other grains can also use this model to receive asynchronous notifications. Grains can implement <xref:Orleans.IGrainObserver> interfaces. Unlike the client subscription case, the subscribing grain simply implements the observer interface and passes in a reference to itself (for example,, `this.AsReference<IMyGrainObserverInterface>()`). There's no need for `CreateObjectReference()` because grains are already addressable.

## Code example

Let's assume you have a grain that periodically sends messages to clients. For simplicity, the message in our example is a string. First, define the interface on the client that receives the message.

The interface looks like this:

```csharp
public interface IChat : IGrainObserver
{
    Task ReceiveMessage(string message);
}
```

The only special requirement is that the interface must inherit from `IGrainObserver`.
Now, any client wanting to observe these messages should implement a class that implements `IChat`.

The simplest case looks something like this:

```csharp
public class Chat : IChat
{
    public Task ReceiveMessage(string message)
    {
        Console.WriteLine(message);
        return Task.CompletedTask;
    }
}
```

On the server, you should next have a grain that sends these chat messages to clients. The grain should also provide a mechanism for clients to subscribe and unsubscribe from notifications. For subscriptions, the grain can use an instance of the utility class <xref:Orleans.Utilities.ObserverManager%601>.

> [!NOTE]
> <xref:Orleans.Utilities.ObserverManager%601> is part of Orleans since version 7.0. For older versions, the following [implementation](https://github.com/dotnet/orleans/blob/e997335d2d689bb39e67f6bcf6fd70862a22c02f/test/Grains/TestGrains/ObserverManager.cs#L12) can be copied.

```csharp
class HelloGrain : Grain, IHello
{
    private readonly ObserverManager<IChat> _subsManager;

    public HelloGrain(ILogger<HelloGrain> logger)
    {
        _subsManager =
            new ObserverManager<IChat>(
                TimeSpan.FromMinutes(5), logger);
    }

    // Clients call this to subscribe.
    public Task Subscribe(IChat observer)
    {
        _subsManager.Subscribe(observer, observer);

        return Task.CompletedTask;
    }

    //Clients use this to unsubscribe and no longer receive messages.
    public Task UnSubscribe(IChat observer)
    {
        _subsManager.Unsubscribe(observer);

        return Task.CompletedTask;
    }
}
```

To send a message to clients, use the `Notify` method of the `ObserverManager<IChat>` instance. The method takes an `Action<T>` method or lambda expression (where `T` is of type `IChat` here). You can call any method on the interface to send it to clients. In our case, we only have one method, `ReceiveMessage`, and our sending code on the server looks like this:

```csharp
public Task SendUpdateMessage(string message)
{
    _subsManager.Notify(s => s.ReceiveMessage(message));

    return Task.CompletedTask;
}
```

Now, our server has a method to send messages to observer clients and two methods for subscribing/unsubscribing. The client has implemented a class capable of observing the grain messages. The final step is to create an observer reference on the client using our previously implemented `Chat` class and let it receive messages after subscribing.

The code looks like this:

```csharp
//First create the grain reference
var friend = _grainFactory.GetGrain<IHello>(0);
Chat c = new Chat();

//Create a reference for chat, usable for subscribing to the observable grain.
var obj = _grainFactory.CreateObjectReference<IChat>(c);

//Subscribe the instance to receive messages.
await friend.Subscribe(obj);
```

Now, whenever our grain on the server calls the `SendUpdateMessage` method, all subscribed clients receive the message. In our client code, the `Chat` instance in the variable `c` receives the message and outputs it to the console.

> [!IMPORTANT]
> Objects passed to `CreateObjectReference` are held via a <xref:System.WeakReference%601> and are therefore garbage collected if no other references exist.

You should maintain a reference for each observer you don't want collected.

> [!NOTE]
> Observers are inherently unreliable because a client hosting an observer might fail, and observers created after recovery have different (randomized) identities. <xref:Orleans.Utilities.ObserverManager%601> relies on periodic resubscription by observers, as discussed above, so it can remove inactive observers.

## Execution model

Implementations of <xref:Orleans.IGrainObserver> are registered via a call to <xref:Orleans.IGrainFactory.CreateObjectReference%2A?displayProperty=nameWithType>. Each call to that method creates a new reference pointing to that implementation. Orleans executes requests sent to each of these references one by one, to completion. Observers are non-reentrant; therefore, Orleans doesn't interleave concurrent requests to an observer. If multiple observers receive requests concurrently, those requests can execute in parallel. Attributes such as <xref:Orleans.Concurrency.AlwaysInterleaveAttribute> or <xref:Orleans.Concurrency.ReentrantAttribute> don't affect the execution of observer methods; you cannot customize the execution model.
