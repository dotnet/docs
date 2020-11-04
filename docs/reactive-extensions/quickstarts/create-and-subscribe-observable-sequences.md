---
title: Creating and Subscribing to Simple Observable Sequences
description: aaa
author: IEvangelist
ms.author: dapine
ms.date: 11/03/2020
---

# Creating and Subscribing to Simple Observable Sequences

You do not need to implement the IObservable\<T\> interface manually to create an observable sequences. Similarly, you do not need to implement IObserver\<T\> either to subscribe to a sequence. By installing the Reactive Extension assemblies, you can take advantage of the [Observable](hh244252\(v=vs.103\).md) type which provides many static LINQ operators for you to create a simple sequence with zero, one or more elements. In addition, Rx provides Subscribe extension methods that take various combinations of OnNext, OnError and OnCompleted handlers in terms of delegates.

## Creating and subscribing to a simple sequence

The following sample uses the Range operator of the **Observable** type to create a simple observable collection of numbers. The observer subscribes to this collection using the Subscribe method of the **Observable** class, and provides actions that are delegates which handle OnNext, OnError and OnCompleted.

The Range operator has several overloads. In our example, it creates a sequence of integers that starts with x and produces y sequential numbers afterwards.

As soon as the subscription happens, the values are sent to the observer. The OnNext delegate then prints out the values.

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Reactive;
    using System.Reactive.Linq;
    using System.Reactive.Subjects;
    
    namespace SimpleSequence
    {
        class Program
        {
            static void Main(string[] args)
            {
                IObservable<int> source = Observable.Range(1, 10);
                IDisposable subscription = source.Subscribe(
                    x => Console.WriteLine("OnNext: {0}", x),
                    ex => Console.WriteLine("OnError: {0}", ex.Message),
                    () => Console.WriteLine("OnCompleted"));
                Console.WriteLine("Press ENTER to unsubscribe...");
                Console.ReadLine();
                subscription.Dispose();
            }
        }
    }

When an observer subscribes to an observable sequence, the thread calling the Subscribe method can be different from the thread in which the sequence runs till completion. Therefore, the Subscribe call is asynchronous in that the caller is not blocked until the observation of the sequence completes. This will be covered in more details in the [Using Schedulers](hh242963\(v=vs.103\).md) topic.

Notice that the Subscribe method returns an IDisposable, so that you can unsubscribe to a sequence and dispose of it easily. When you invoke the Dispose method on the observable sequence, the observer will stop listening to the observable for data.  Normally, you do not need to explicitly call Dispose unless you need to unsubscribe early, or when the source observable sequence has a longer life span than the observer. Subscriptions in Rx are designed for fire-and-forget scenarios without the usage of a finalizer. When the IDisposable instance is collected by the garbage collector, Rx does not automatically dispose of the subscription. However, note that the default behavior of the Observable operators is to dispose of the subscription as soon as possible (i.e, when an OnCompleted or OnError messages is published). For example, the code `var x = Observable.Zip(a,b).Subscribe();` will subscribe x to both sequences a and b. If a throws an error, x will immediately be unsubscribed from b.

You can also tweak the code sample to use the Create operator of the **Observable** type, which creates and returns an observer from specified OnNext, OnError, and OnCompleted action delegates. You can then pass this observer to the Subscribe method of the **Observable** type. The following sample shows how to do this.

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Reactive;
    using System.Reactive.Linq;
    using System.Reactive.Subjects;
    
    namespace SimpleSequence
    {
        class Program
        {
            static void Main(string[] args)
            {
                IObservable<int> source = Observable.Range(1, 10);
                IObserver<int> obsvr = Observer.Create<int>(
                    x => Console.WriteLine("OnNext: {0}", x),
                    ex => Console.WriteLine("OnError: {0}", ex.Message),
                    () => Console.WriteLine("OnCompleted"));
                IDisposable subscription = source.Subscribe(obsvr);
                Console.WriteLine("Press ENTER to unsubscribe...");
                Console.ReadLine();
                subscription.Dispose();
           }
        }
    }

In addition to creating an observable sequence from scratch, you can convert existing enumerators, .NET events and asynchronous patterns into observable sequences. The other topics in this section will show you how to do this.

Notice that this topic only shows you a few operators that can create an observable sequence from scratch. To learn more about other LINQ operators, see [Querying Observable Sequences using LINQ Operators](hh242983\(v=vs.103\).md).

## Using a timer

The following sample uses the Timer operator to create a sequence. The sequence will push out the first value after 5 second has elapsed, then it will push out subsequent values every 1 second. For illustration purpose, we chain the Timestamp operator to the query so that each value pushed out will be appended by the time when it is published. By doing so, when we subscribe to this source sequence, we can receive both its value and timestamp.

    Console.WriteLine("Current Time: " + DateTime.Now);
    
    var source = Observable.Timer(TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(1))
                           .Timestamp();
    using (source.Subscribe(x => Console.WriteLine("{0}: {1}", x.Value, x.Timestamp)))
          {
               Console.WriteLine("Press any key to unsubscribe");
               Console.ReadKey();
          }
    Console.WriteLine("Press any key to exit");
    Console.ReadKey();

The output will be similar to this:

    Current Time: 5/31/2011 5:35:08 PM

    Press any key to unsubscribe

    0: 5/31/2011 5:35:13 PM -07:00

    1: 5/31/2011 5:35:14 PM -07:00

    2: 5/31/2011 5:35:15 PM -07:00

By using the Timestamp operator, we have verified that the first item is indeed pushed out 5 seconds after the sequence has started, and each item is published 1 second later.

## Converting an Enumerable Collection to an Observable Sequence

Using the ToObservable operator, you can convert a generic enumerable collection to an observable sequence and subscribe to it.

    IEnumerable<int> e = new List<int> { 1, 2, 3, 4, 5 };
    
    IObservable<int> source = e.ToObservable();
    IDisposable subscription = source.Subscribe(
                                x => Console.WriteLine("OnNext: {0}", x),
                                ex => Console.WriteLine("OnError: {0}", ex.Message),
                                () => Console.WriteLine("OnCompleted"));
    Console.ReadKey();

## Cold vs. Hot Observables

Cold observables start running upon subscription, i.e., the observable sequence only starts pushing values to the observers when Subscribe is called. Values are also not shared among subscribers. This is different from hot observables such as mouse move events or stock tickers which are already producing values even before a subscription is active. When an observer subscribes to a hot observable sequence, it will get the current value in the stream. The hot observable sequence is shared among all subscribers, and each subscriber is pushed the next value in the sequence. For example, even if no one has subscribed to a particular stock ticker, the ticker will continue to update its value based on market movement. When a subscriber registers interest in this ticker, it will automatically get the latest tick.

The following example demonstrates a cold observable sequence. In this example, we use the Interval operator to create a simple observable sequence of numbers pumped out at specific intervals, in this case, every 1 second.

Two observers then subscribe to this sequence and print out its values. You will notice that the sequence is reset for each subscriber, in which the second subscription will restart the sequence from the first value.

    IObservable<int> source = Observable.Interval(TimeSpan.FromSeconds(1));   
    
    IDisposable subscription1 = source.Subscribe(
                    x => Console.WriteLine("Observer 1: OnNext: {0}", x),
                    ex => Console.WriteLine("Observer 1: OnError: {0}", ex.Message),
                    () => Console.WriteLine("Observer 1: OnCompleted"));
    
    IDisposable subscription2 = source.Subscribe(
                    x => Console.WriteLine("Observer 2: OnNext: {0}", x),
                    ex => Console.WriteLine("Observer 2: OnError: {0}", ex.Message),
                    () => Console.WriteLine("Observer 2: OnCompleted"));
    
    Console.WriteLine("Press any key to unsubscribe");
    Console.ReadLine();
    subscription1.Dispose();
    subscription2.Dispose();

In the following example, we convert the previous cold observable sequence `source` to a hot one using the Publish operator, which returns an IConnectableObservable instance we name `hot`. The Publish operator provides a mechanism to share subscriptions by broadcasting a single subscription to multiple subscribers. `hot` acts as a proxy and subscribes to `source`, then as it receives values from `source`, pushes them to its own subscribers. To establish a subscription to the backing `source` and start receiving values, we use the IConnectableObservable.Connect() method. Since IConnectableObservable inherits IObservable, we can use Subscribe to subscribe to this hot sequence even before it starts running. Notice that in the example, the hot sequence has not been started when `subscription1` subscribes to it. Therefore, no value is pushed to the subscriber. After calling Connect, values are then pushed to `subscription1`. After a delay of 3 seconds, `subscription2` subscribes to `hot` and starts receiving the values immediately from the current position (3 in this case) until the end. The output looks like this:

    Current Time: 6/1/2011 3:38:49 PM

    Current Time after 1st subscription: 6/1/2011 3:38:49 PM

    Current Time after Connect: 6/1/2011 3:38:52 PM

    Observer 1: OnNext: 0

    Observer 1: OnNext: 1

    Current Time just before 2nd subscription: 6/1/2011 3:38:55 PM 

    Observer 1: OnNext: 2

    Observer 1: OnNext: 3

    Observer 2: OnNext: 3

    Observer 1: OnNext: 4

    Observer 2: OnNext: 4

```

Console.WriteLine("Current Time: " + DateTime.Now);
var source = Observable.Interval(TimeSpan.FromSeconds(1));            //creates a sequence

IConnectableObservable<long> hot = Observable.Publish<long>(source);  // convert the sequence into a hot sequence

IDisposable subscription1 = hot.Subscribe(                        // no value is pushed to 1st subscription at this point
                            x => Console.WriteLine("Observer 1: OnNext: {0}", x),
                            ex => Console.WriteLine("Observer 1: OnError: {0}", ex.Message),
                            () => Console.WriteLine("Observer 1: OnCompleted"));
Console.WriteLine("Current Time after 1st subscription: " + DateTime.Now);
Thread.Sleep(3000);  //idle for 3 seconds
hot.Connect();       // hot is connected to source and starts pushing value to subscribers
Console.WriteLine("Current Time after Connect: " + DateTime.Now);
Thread.Sleep(3000);  //idle for 3 seconds
Console.WriteLine("Current Time just before 2nd subscription: " + DateTime.Now);

IDisposable subscription2 = hot.Subscribe(     // value will immediately be pushed to 2nd subscription
                            x => Console.WriteLine("Observer 2: OnNext: {0}", x),
                            ex => Console.WriteLine("Observer 2: OnError: {0}", ex.Message),
                            () => Console.WriteLine("Observer 2: OnCompleted"));
Console.ReadKey();
```
