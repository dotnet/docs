---
title: Using Subjects
TOCTitle: Using Subjects
ms:assetid: ce351802-3284-4c43-b26a-da1b3138b917
ms:mtpsurl: https://msdn.microsoft.com/en-us/library/Hh242970(v=VS.103)
ms:contentKeyID: 36068277
ms.date: 06/28/2011
mtps_version: v=VS.103
---

# Using Subjects

The Subject\<T\> type implements both IObservable\<T\> and IObserver\<T\>, in the sense that it is both an observer and an observable. You can use a subject to subscribe all the observers, and then subscribe the subject to a backend data source. In this way, the subject can act as a proxy for a group of subscribers and a source. You can use subjects to implement a custom observable with caching, buffering and time shifting. In addition, you can use subjects to broadcast data to multiple subscribers.

By default, subjects do not perform any synchronization across threads. They do not take a scheduler but rather assume that all serialization and grammatical correctness are handled by the caller of the subject.  A subject simply broadcasts to all subscribed observers in the thread-safe list of subscribers. Doing so has the advantage of reducing overhead and improving performance. If, however, you want to synchronize outgoing calls to observers using a scheduler, you can use the Synchronize method to do so.

## Using Subjects

In the following example, we create a subject, subscribe to that subject and then use the same subject to publish values to the observer. By doing so, we combine the publication and subscription into the same source.

In addition to taking an IObserver\<T\>, the Subscribe method also has an overload that takes an Action\<T\> for onNext, which means that the action will be executed every time an item is published. In our sample, whenever OnNext is invoked, the item will be written to the console.

    Subject<int> subject = new Subject<int>();
    var subscription = subject.Subscribe(
                             x => Console.WriteLine("Value published: {0}", x),
                             () => Console.WriteLine("Sequence Completed."));
    subject.OnNext(1);
    
    subject.OnNext(2);
    
    Console.WriteLine("Press any key to continue");
    Console.ReadKey();
    subject.OnCompleted();
    subscription.Dispose();

The following example illustrates the proxy and broadcast nature of a Subject. We first create a source sequence which produces an integer every 1 second. We then create a Subject, and pass it as an observer to the source so that it will receive all the values pushed out by this source sequence. After that, we create another two subscriptions, this time with the subject as the source. The `subSubject1` and `subSubject2` subscriptions will then receive any value passed down (from the source) by the Subject.

    var source = Observable.Interval(TimeSpan.FromSeconds(1));
    Subject<long> subject = new Subject<long>();
    var subSource = source.Subscribe(subject);
    var subSubject1 = subject.Subscribe(
                             x => Console.WriteLine("Value published to observer #1: {0}", x),
                             () => Console.WriteLine("Sequence Completed."));
    var subSubject2 = subject.Subscribe(
                             x => Console.WriteLine("Value published to observer #2: {0}", x),
                             () => Console.WriteLine("Sequence Completed."));
    Console.WriteLine("Press any key to continue");
    Console.ReadKey();
    subject.OnCompleted();
    subSubject1.Dispose();
    subSubject2.Dispose();

## Different types of Subjects

The Subject\<T\> type in the Rx library is a basic implementation of the ISubject\<T\> interface (you can also implement the ISubject\<T\> interface to create your own subject types). There are other implementations of ISubject\<T\> that offer different functionalities. All of these types store some (or all of) values pushed to them via OnNext, and broadcast it back to its observers. In this way, they convert a Hot Observable into a Cold one. This means that if you Subscribe to any of these more than once (i.e. Subscribe -\> Unsubscribe -\> Subscribe again), you will see at least one of the same value again. For more information on hot and cold observables, see the last section of the [Creating and Subscribing to Simple Observable Sequences](hh242977\(v=vs.103\).md) topic.

ReplaySubject stores all the values that it has published. Therefore, when you subscribe to it, you automatically receive an entire history of values that it has published, even though your subscription might have come in after certain values have been pushed out. BehaviourSubject is similar to **ReplaySubject**, except that it only stored the last value it published. **BehaviourSubject** also requires a default value of type T upon initialization. This value is sent to observers when no other value has been received by the subject yet. This means that all subscribers will receive a value instantly on Subscribe, unless the Subject has already completed. AsyncSubject is similar to the Replay and Behavior subjects, however it will only store the last value, and only publish it when the sequence is completed. You can use the **AsyncSubject** type for situations when the source observable is hot and might complete before any observer can subscribe to it. In this case, **AsyncSubject** can still provide the last value and publish it to any future subscribers.

