---
title: Reactive Extensions (Rx)
description: Learn about Reactive Extensions (Rx) for .NET, a library for composing asynchronous and event-based observable sequences.
author: IEvangelist
ms.date: 11/09/2020
ms.author: dapine
ms.topic: overview
---

# Reactive Extensions (Rx)

Reactive Extensions is based on [ReactiveX](http://reactivex.io), which is an API for asynchronous programming with observable streams. The [Reactive Extensions (Rx) for .NET](https://www.nuget.org/packages/System.Reactive) NuGet package, is the .NET implementation. This library is used to compose asynchronous and event-based programs using observable sequences, and LINQ-style query operators. Data sequences can take many forms, such as a stream of data from a file or web service, system notifications, or a series of events from user input.

Reactive Extensions represents all these data streams as observable sequences. An application can subscribe to these observable sequences to receive asynchronous notifications as new data arrives, much like an event callback. The Rx library is available for all .NET application development, but is not always the right tool for the job. For more information on choosing this programming paradigm, see [When to use Rx](when-to-use-rx.md).

## Pull vs push data streams

In interactive programming, the application actively polls a data source for more information by pulling data from a sequence that represents the source. Such behavior is represented by the iterator pattern of <xref:System.Collections.Generic.IEnumerable%601> and <xref:System.Collections.Generic.IEnumerator%601>. The <xref:System.Collections.Generic.IEnumerable%601> interface exposes a method <xref:System.Collections.IEnumerable.GetEnumerator?displayProperty=nameWithType>, which returns an <xref:System.Collections.Generic.IEnumerator%601> to iterate through the collection. The <xref:System.Collections.Generic.IEnumerator%601> allows the consumer to get the current item through the <xref:System.Collections.IEnumerator.Current?displayProperty=nameWithType> property, and determine whether there are more items to iterate with the <xref:System.Collections.IEnumerator.MoveNext?displayProperty=nameWithType> method.

The application is active in the data retrieval process: besides getting an enumerator by calling <xref:System.Collections.IEnumerable.GetEnumerator>, it also controls the pace of the retrieval by calling <xref:System.Collections.IEnumerator.MoveNext> at its own convenience. This enumeration pattern is synchronous, which means that the application might be blocked while polling the data source. Such pulling pattern is similar to visiting your library and checking out a book. After you are done with the book, you pay another visit to check out another one.

On the other hand, in reactive programming, the application is offered more information by subscribing to a data stream (called observable sequence in Rx), and any update is handed to it from the source. The application is passive in the data retrieval process: apart from subscribing to the observable source, it does not actively poll the source, but merely react to the data being pushed to it. When the stream has no more data to offer, or when it errors, the source will send a notice to the subscriber. In this way, the application will not be blocked by waiting for the source to update.

This is the push (observable) pattern employed by Reactive Extensions. It is similar to joining a book club in which you register your interest in a particular genre, and books that match your interest are automatically sent to you as they are published. You do not need to stand in line to acquire something that you want. Employing a push pattern is helpful in many scenarios, especially in a UI-heavy environment in which the UI thread cannot be blocked while the application is waiting for some events. By using Rx, you can make your application more responsive.

## Observables

Rx exposes asynchronous and event-based data sources as push-based, observable sequences abstracted by the <xref:System.IObservable%601> interface. This <xref:System.IObservable%601> interface is a dual of the aforementioned <xref:System.Collections.Generic.IEnumerable%601> interface used for pull-based, enumerable collections. It represents a data source that can be observed, meaning that it can send data to anyone who is interested. It maintains a list of dependent <xref:System.IObserver%601> implementations representing such interested listeners, and notifies them automatically of any state changes.

An implementation of the <xref:System.IObservable%601> interface can be viewed as a collection of elements of type `T`. Therefore, an `IObservable<int>` can be viewed as a collection of integers, in which integers will be pushed to the subscribed observers.

The other half of the push model is the <xref:System.IObserver%601> interface, which represents an observer who registers an interest through a subscription. Items are subsequently handed to the observer from the observable sequence to which it subscribes.

In order to receive notifications from an observable collection, you use the <xref:System.IObservable%601.Subscribe%2A?displayProperty=nameWithType> method to hand it an <xref:System.IObserver%601> object. In return for this observer, the <xref:System.IObservable%601.Subscribe%2A> method returns an <xref:System.IDisposable> object that acts as a handle for the subscription. This allows you to clean up the subscription after you are done. Calling <xref:System.IDisposable.Dispose> on this object detaches the observer from the source so that notifications are no longer delivered. In Rx you do not need to explicitly unsubscribe from an event as in the .NET event model.

Observers support three publication events, reflected by the interface's methods. <xref:System.IObserver%601.OnNext%2A?displayProperty=nameWithType> can be called zero or more times, when the observable data source has data available. For example, an observable data source used for mouse move events can send out a Point object every time the mouse has moved. The other two methods are used to indicate completion or errors.

The <xref:System.IObservable%601> interface is defined as:

```csharp
public interface IObservable<out T>
{
    IDisposable Subscribe(IObserver<T> observer);
}
```

The <xref:System.IObserver%601> interface is defined as:

```csharp
public interface IObserver<in T>
{
    void OnCompleted();
    void OnError(Exception error);
    void OnNext(T value);
}
```

Rx also provides a `Subscribe` extension methods so that you can avoid implementing the <xref:System.IObserver%601> interface yourself. For each publication event (`OnNext`, `OnError`, and `OnCompleted`) of an observable sequence, you can specify a `delegate` that will be invoked, as shown in the following example. If you do not specify an action for an event, the default behavior will occur.

:::code language="csharp" source="snippets/observable/Program.cs":::

You treat the observable sequence (such as a sequence of mouse-over events) as if it were a normal collection. Thus you can write LINQ queries over the collection to do things like filtering, grouping, and composing. To make observable sequences more useful, the Rx library provides many factory LINQ operators so that you do not need to implement any of these on your own. For more information, see [Query observable sequences using LINQ operators](how-to/query-sequences-linq.md).

> [!TIP]
> You do not need to implement the `IObservable<T>` and `IObserver<T>` interfaces yourself. Rx provides implementations of these interfaces for you and exposes them through various extension methods provided by the `Observable` and `Observer` types. For more information, see [Create and Subscribe to observable sequences](quickstarts/create-and-subscribe-observable-sequences.md).

## See also

- [When to use Rx](when-to-use-rx.md)
- [Create and Subscribe to observable sequences](quickstarts/create-and-subscribe-observable-sequences.md)
- [Query observable sequences using LINQ operators](how-to/query-sequences-linq.md)
