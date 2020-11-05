---
title: How to use Subjects
description: Learn how to use Subjects with Reactive Extensions for .NET.
author: IEvangelist
ms.author: dapine
ms.date: 11/05/2020
---

# How to use Subjects

The `Subject<T>` type implements both <xref:System.IObservable%601> and <xref:System.IObserver%601>, in the sense that it is both an observer and an observable. You can use a subject to subscribe all the observers, and then subscribe the subject to a backend data source. In this way, the subject can act as a proxy for a group of subscribers and a source. You can use subjects to implement a custom observable with caching, buffering and time-shifting. In addition, you can use subjects to broadcast data to multiple subscribers.

By default, subjects do not perform any synchronization across threads. They do not take a scheduler but rather assume that all serialization and grammatical correctness are handled by the caller of the subject.  A subject simply broadcasts to all subscribed observers in the thread-safe list of subscribers. Doing so has the advantage of reducing overhead and improving performance. If, however, you want to synchronize outgoing calls to observers using a scheduler, you can use the `Synchronize` method to do so.

## Example Subject source code

In the following example, we create a subject, subscribe to that subject and then use the same subject to publish values to the observer. By doing so, we combine the publication and subscription into the same source.

In addition to taking an <xref:System.IObservable%601>, the `Subscribe` method also has an overload that takes an <xref:System.Action%601> for `onNext`, which means that the action will be executed every time an item is published. In our sample, whenever <xref:System.IObserver%601.OnNext%2A?displayProperty=nameWithType> is invoked, the item will be written to the console.

:::code language="csharp" source="snippets/subjects/Program.cs":::

The following example illustrates the proxy and broadcast nature of a subject. You create a source sequence which produces an integer every 1 second. We then create a `Subject`, and pass it as an observer to the source so that it will receive all the values pushed out by this source sequence. After that, we create another two subscriptions, this time with the subject as the source. The `subSubject1` and `subSubject2` subscriptions will then receive any value passed down (from the source) by the Subject.

:::code language="csharp" source="snippets/schedules/Program.cs":::

## Subject types

The `Subject<T>`type is a basic implementation of the `ISubject<T>` interface. There are other implementations of `ISubject<T>` that offer different functionalities. All of these types store some (or all of) values pushed to them via `OnNext`, and broadcast it back to its observers. In this way, they convert a "hot" `Observable` into a "cold" one. This means that if you `Subscribe` to any of these more than once (i.e. `Subscribe` -> `Unsubscribe` -> `Subscribe` again), you will see at least one of the same value again. For more information on hot and cold observables, see [Hot and cold Observables](quickstarts/create-and-subscribe-observable-sequences.md#hot-and-cold-observables).

The `ReplaySubject<T>` stores all the values that it has published. Therefore, when you subscribe to it, you automatically receive an entire history of values that it has published, even though your subscription might have come in after certain values have been pushed out. The `BehaviorSubject<T>` is similar to `ReplaySubject<T>`, except that it only stores the last value it published. The `BehaviorSubject<T>` also requires a default value of type `T` upon initialization. This value is sent to observers when no other value has been received by the subject yet. This means that all subscribers will receive a value instantly on `Subscribe`, unless the `Subject` has already completed. The `AsyncSubject<T>` is similar to the `ReplaySubject<T>` and `BehaviorSubject<T>` types, however it will only store the last value, and only publish it when the sequence is completed. Use the `AsyncSubject<T>` type for situations when the source observable is "hot" and might complete before any observer can subscribe to it. In this case, `AsyncSubject<T>` can still provide the last value and publish it to any future subscribers.
