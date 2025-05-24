---
title: Observers
description: Learn about observers in .NET Orleans.
ms.date: 07/03/2024
---

# Observers

There are situations in which a simple message/response pattern is not enough, and the client needs to receive asynchronous notifications.
For example, a user might want to be notified when a new instant message has been published by a friend.

Client observers is a mechanism that allows notifying clients asynchronously. Observer interfaces must inherit from <xref:Orleans.IGrainObserver>, and all methods must return either `void`, <xref:System.Threading.Tasks.Task>, <xref:System.Threading.Tasks.Task%601>, <xref:System.Threading.Tasks.ValueTask>, or <xref:System.Threading.Tasks.ValueTask%601>. A return type of `void` is not recommended as it may encourage the use of `async void` on the implementation, which is a dangerous pattern since it can result in application crashes if an exception is thrown from the method. Instead, for best-effort notification scenarios, consider applying the <xref:Orleans.Concurrency.OneWayAttribute> to the observer's interface method. This will cause the receiver to not send a response for the method invocation and will cause the method to return immediately at the call site, without waiting for a response from the observer. A grain calls a method on an observer by invoking it like any grain interface method. The Orleans runtime will ensure the delivery of requests and responses. A common use case for observers is to enlist a client to receive notifications when an event occurs in the Orleans application. A grain that publishes such notifications should provide an API to add or remove observers. In addition, it is usually convenient to expose a method that allows an existing subscription to be cancelled.

Grain developers may use a utility class such as <xref:Orleans.Utilities.ObserverManager%601> to simplify development of observed grain types. Unlike grains, which are automatically reactivated as-needed after failure, clients are not fault-tolerant: a client which fails may never recover.
For this reason, the `ObserverManager<T>` utility removes subscriptions after a configured duration. Clients which are active should resubscribe on a timer to keep their subscription active.

To subscribe to a notification, the client must first create a local object that implements the observer interface. It then calls a method on the observer factory, <xref:Orleans.IGrainFactory.CreateObjectReference%2A>`, to turn the object into a grain reference, which can then be passed to the subscription method on the notifying grain.

This model can also be used by other grains to receive asynchronous notifications. Grains can also implement <xref:Orleans.IGrainObserver> interfaces. Unlike in the client subscription case, the subscribing grain simply implements the observer interface and passes in a reference to itself (for example, `this.AsReference<IMyGrainObserverInterface>()`). There is no need for `CreateObjectReference()` because grains are already addressable.

## Code example

Let's assume that we have a grain that periodically sends messages to clients. For simplicity, the message in our example will be a  string. We first define the interface on the client that will receive the message.

The interface will look like this

```csharp
public interface IChat : IGrainObserver
{
    Task ReceiveMessage(string message);
}
```

The only special thing is that the interface should inherit from `IGrainObserver`.
Now any client that wants to observe those messages should implement a class that implements `IChat`.

The simplest case would be something like this:

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

On the server, we should next have a Grain that sends these chat messages to clients. The Grain should also have a mechanism for clients to subscribe and unsubscribe themselves for notifications. For subscriptions, the grain can use an instance of the utility class <xref:Orleans.Utilities.ObserverManager%601>.

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

To send a message to clients, the `Notify` method of the `ObserverManager<IChat>` instance can be used. The method takes an `Action<T>` method or lambda expression (where `T` is of type `IChat` here). You can call any method on the interface to send it to clients. In our case we only have one method, `ReceiveMessage`, and our sending code on the server would look like this:

```csharp
public Task SendUpdateMessage(string message)
{
    _subsManager.Notify(s => s.ReceiveMessage(message));

    return Task.CompletedTask;
}
```

Now our server has a method to send messages to observer clients, two methods for subscribing/unsubscribing, and the client has implemented a class able to observe the grain messages. The last step is to create an observer reference on the client using our previously implemented `Chat` class, and let it receive the messages after subscribing to it.

The code would look like this:

```csharp
//First create the grain reference
var friend = _grainFactory.GetGrain<IHello>(0);
Chat c = new Chat();

//Create a reference for chat, usable for subscribing to the observable grain.
var obj = _grainFactory.CreateObjectReference<IChat>(c);

//Subscribe the instance to receive messages.
await friend.Subscribe(obj);
```

Now whenever our grain on the server calls the `SendUpdateMessage` method, all subscribed clients will receive the message. In our client code, the `Chat` instance in variable `c` will receive the message and output it to the console.

> [!IMPORTANT]
> Objects passed to `CreateObjectReference` are held via a <xref:System.WeakReference%601> and will therefore be garbage collected if no other references exist.

Users should maintain a reference for each observer which they do not want to be collected.

> [!NOTE]
> Observers are inherently unreliable since a client which hosts an observer may fail and observers created after recovery have different (randomized) identities. <xref:Orleans.Utilities.ObserverManager%601> relies on periodic resubscription by observers, as discussed above, so that inactive observers can be removed.

## Execution model

Implementations of <xref:Orleans.IGrainObserver> are registered via a call to <xref:Orleans.IGrainFactory.CreateObjectReference%2A?displayProperty=nameWithType> and each call to that method creates a new reference that points to that implementation. Orleans will execute requests sent to each one of these references one-by-one, to completion. Observers are non-reentrant and therefore concurrent requests to an observer will not be interleaved by Orleans. If there are multiple observers which are receiving requests concurrently, those requests can execute in parallel. Execution of observer methods are not affected by attributes such as <xref:Orleans.Concurrency.AlwaysInterleaveAttribute> or <xref:Orleans.Concurrency.ReentrantAttribute>: the execution model cannot be customized by a developer.
