---
title: Test and debug observable sequences
description: Learn how to test and debug observable sequences using Microsoft.Reactive.Testing package.
author: IEvangelist
ms.author: dapine
ms.date: 11/09/2020
---

# Test and debug observable sequences

If you have an observable sequence that publishes values over an extended period of time, testing it in real-time can be difficult. Use the [`Microsoft.Reactive.Testing`](https://www.nuget.org/packages/Microsoft.Reactive.Testing) NuGet package to test observable sequences. The `Microsoft.Reactive.Testing.TestScheduler` type can assist testing this kind of time-dependent code, without actually waiting for time to pass. The `TestScheduler` inherits `VirtualTimeScheduler`, and allows you to create, publish and subscribe to sequences in emulated time. For example, you can compact a publication which takes 5 days to complete into a 2 minute run, while maintaining the correct scale. You can also take a sequence which actually has happened in the past, and compute, or subscribe to it as if it is pushing out new values in real time.

The factory `Start` method executes all scheduled tasks until the queue is empty, or you can specify a time to so that queued-up tasks are only executed to the specified time.

## Example test source code

The following example creates a hot observable sequence with specified `OnNext` notifications. It then starts the test scheduler and specifies when to subscribe to and dispose of the hot observable sequence. The `Start` method returns an instance of the `ITestableObserver`, which contains a `Messages` property that records all notifications in a list.

:::code language="csharp" source="snippets/testing/Program.cs":::

In the preceding example, after the sequence has completed, the `ReactiveAssert.AreElementsEqual` method compares the `Messages` property, to a list of expected values. If both are identical, with the same number of items, and items are equal, and appear in the same order the assertion is valid. By doing so, you can confirm that you have indeed received the notifications that you expect. Since you only start subscribing at `150`, you will miss out the value `abc`. However, when you compare the values you have received so far at `400`, you notice that you have in fact received all the published values after you subscribed to the sequence. You also verify that the `OnCompleted` notification was fired at the right time at `500`. In addition, subscription information is also captured by the `ITestableObservable<T>` type returned by the `CreateHotObservable` method.

In the same way, you can use `ReactiveAssert.AreElementsEqual` to confirm that subscriptions indeed happened at expected times.

## Debug an Rx application

You can use the `Do` operator to debug your Rx application. The `Do` operator allows you to specify various actions to be taken for each item of observable sequence, for example: print, or log the item. This is especially helpful when you are chaining many operators and you want to know what values are produced at each level.

In the following example, we are going to reuse the buffer example which generates integers every second, while putting them into buffers that can hold `5` items each. In the [Query observable sequences using LINQ operators](../how-to/query-sequences-linq.md) example, you subscribe only to the final `Observable(IList\<\>)` sequence when the buffer is full, and before it is emptied. In this example, however, we will use the `Do` operator to print out the values when they are being pushed out by the original sequence (an integer every second). When the buffer is full, we use the Do operator to print the status, before handing over all this as the final sequence for the observer to subscribe.

    var seq1 = Observable.Interval(TimeSpan.FromSeconds(1))
               .Do(x => Console.WriteLine(x.ToString()))
               .Buffer(5)
               .Do(x => Console.WriteLine("buffer is full"))
               .Subscribe(x => Console.WriteLine("Sum of the buffer is " + x.Sum()));
    Console.ReadKey();

As you can see from this sample, a subscription is on the recipient end of a series of chained observable sequences. At first, we create an observable sequence of integers separate by a second using the Interval operator. Then, we put 5 items into a buffer using the Buffer operator, and send them out as another sequence only when the buffer is full. Lastly, this is handed over to the Subscribe operator. Data propagate down all these intermediate sequences until they are pushed to the observer. In the same way, subscriptions are propagated in the reverse direction to the source sequence. By inserting the Do operator in the middle of such propagations, you can "spy" on such data flow just like you use Console.WriteLine in .NET or printf() in C to perform debugging.

You can also use the Timestamp operator to verify the time when an item is pushed out by an observable sequence. This can help you troubleshoot time-based operations to ensure accuracy. Recall the following example from the [Creating and Subscribing to Simple Observable Sequences](hh242977\(v=vs.103\).md) topic, in which we chain the Timestamp operator to the query so that each value pushed out by the source sequence will be appended by the time when it is published. By doing so, when we subscribe to this source sequence, we can receive both its value and timestamp.

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

By using the Timestamp operator, we have verified that the first item is indeed pushed out 5 seconds after the sequence, and each item is published 1 second later.

In addition, you can also set breakpoints inside lambda expressions to assist in debugging. Normally, you can only set a breakpoint for the whole query without singling out a particular value to look it. To workaround this limitation, you can insert the Select operator in the middle of the query and set a breakpoint it, and in the Select statement, project the identical value out as its source using a return statement on its own line. You can then set a breakpoint at the `return` statement line and examine values as they make their way through the query.

    var seq = Observable.Interval(TimeSpan.FromSeconds(1))
              .Do(x => Console.WriteLine(x.ToString()))
              .Buffer(5)
              .Select(y => { 
                      return y; }) // set a breakpoint at this line
              .Do(x => Console.WriteLine("buffer is full"))
              .Subscribe(x => Console.WriteLine("Sum of the buffer is " + x.Sum()));
    Console.ReadKey();

In this example, the breakpoint is set at the `return y` line. When you debug into the program, the `y` variable shows up in the **Locals** window and you can examine its total count `(5)`. If you expand `y`, you can also examine each item in the list including its value and type.

Alternatively, you can convert a lambda expression to a statement lambda expression, format code so that a statement is on its own line, and then set a breakpoint.

You can remove any `Do` and `Select` calls after you finish debugging.

## See also

[Creating and Subscribing to Simple Observable Sequences](hh242977\(v=vs.103\).md)
[Querying Observable Sequences using LINQ Operators](hh242983\(v=vs.103\).md)
[Using Schedulers](hh242963\(v=vs.103\).md)
