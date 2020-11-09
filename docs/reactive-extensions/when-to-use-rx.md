---
title: When to use Reactive Extensions (Rx)
description: Learn what scenarios are appropriate to apply Reactive Extensions functionality.
author: IEvangelist
ms.date: 11/09/2020
ms.author: dapine
ms.topic: concept
---

# When to use Reactive Extensions (Rx)

This topic describes the advantages of using Rx for users who are currently using the .NET event model for asynchronous programming.

## Advantages of using Rx

Whether you are authoring a [desktop](/dotnet/desktop) or [web-based](/aspnet/core) application, you have to use asynchronous programming. Desktop applications have I/O or UI threads that might take a long time to complete, and potentially block all other active threads. However, a user of the modern asynchronous programming model has to manage exceptions, and cancellation of events manually. To compose or filter events, you have to write custom code that is hard to decipher and maintain.

In addition, if your application interacts with multiple sources of data, the conventional way to manage all of these interactions is to implement separate methods as event handlers for each of these data streams. For example, as soon as a user types a character, a keydown event is pushed to your keydown event handler method. Inside this keydown event handler, you have to provide code to react to this event, or to coordinate between all of the different data streams, and process this data into a useable form.

Currently, if you want to subscribe to an event, you first create an event handler, then you can subscribe to the event as in the following code.

```csharp
public event EventHandler<MouseEventArgs> MouseMove;

MouseMove += (sender, args) => Display(args)

MouseMove(this, args);
```

Using Rx you can represent multiple asynchronous data streams, coming from diverse sources, e.g., stock quote, tweets, computer events, web service requests, and subscribe to the event stream using the <xref:System.IObserver%601> interface. The <xref:System.IObservable%601> interface maintains a list of dependent <xref:System.IObserver%601> interfaces, and notifies them automatically of any state changes. You can query observable sequences using standard LINQ query operators implemented by the `Observable` type. You can filter, project, aggregate, compose, and perform time-based operations on multiple events easily by using LINQ operators. Cancellation and exceptions can also be handled gracefully by using extension methods provided by Rx.

The following example creates an `ISubject` instance (which inherits both `IObservable<T>` and `IObserver<T>`) representing the event stream. It then uses the same object to publish and receive data. For more information on using subjects, [How to use Subjects](use-subjects.md).

```csharp
public ISubject<MouseEventArgs> MouseMove;

MouseMove.Subscribe(args => Display(args));

MouseMove.OnNext(args);
```

You can also use schedulers to control when the subscription starts, and when notifications are pushed to subscribers. For more information, see [Use schedulers with observables](how-to/use-schedulers.md).

### Event filtering

One drawback of the .NET event-based model is that your event handler is always called every time an event is raised, and events arrive exactly as they were sent out by the source. To filter out events that you are *not* interested in, or transform data before your handler is called, you have to add custom filter logic to your handler.

Take an application that detects mouse-down as an example. In the current event programming model, you have to write an event handler that takes MouseEventArgs as an argument. The application can react to the event raised by displaying a message. In Rx, such mouse-down events are treated as a stream of information about clicks. Whenever you click the mouse, information (e.g., cursor position) about this click appears in a stream, ready to be processed. In this paradigm, events (or event streams) are very similar to lists or other collections. This means that we can use techniques for working with collections to process events. For example, you can filter out those clicks that appear outside a specific area, and only display a message when the user clicks inside an area. Or you can wait a specific period of time, and inform the user the number of "valid" clicks during this period. Similarly, you can capture a stream of stock ticks and only respond to those ticks that have changed for a specific range during a particular time window. All these can be done easily by using static LINQ-query style operators provided by Rx.

In this way, a function can take an event, process it, and then pass out the processed stream to an application. This gives you flexibility that is not available in the current programming model. Moreover, as Rx is performing all the plumbing work at the background for filtering, synchronizing, and transforming the data, your handler can just react to the data it receives and do something with it. This results in cleaner code that is easier to read and maintain. For more information on filtering, see [Query observable sequences using LINQ operators](how-to/query-sequences-linq.md).

### Composition as streams

In the .NET event-based model, events cannot be composed easily. You cannot subscribe to multiple events and synthesize the results based on output. In the world of Rx, generic LINQ operators such as `SelectMany`, and `Merge`, are implemented in the assemblies. Such operators enable you to combine multiple event streams to return something meaningful to the subscriber. For example, you can create an observable sequence which listens to both a mouse-down and mouse-move event. You can then subscribe to this observable sequence so that what you get essentially is a composed mouse drag event. For more information on composition, see [Query observable sequences using LINQ operators](how-to/query-sequences-linq.md).

### Manipulate events

In the .NET event-based model, events are hidden data sources that cannot be handed out to another service, application or function for storage or further processing. As we have discussed earlier, Rx represents events as a collection of objects: e.g., a `MouseMove` event contains a collection of Point values. Due to the first-class object nature of observables, they can be passed around as function parameters and returns, or stored in a variable.

### Unsubscribe from events

In the .NET event-based model, to stop receiving notifications of an event, you have to explicitly deregister your event handler. Rx makes this task simpler by allowing you to specify the length of time you are interested in a data source. For example, when you subscribe to an observable sequence representing an event stream, you can specify how long you would like to be notified of changes from the sequence (e.g., n iterations, or for a time interval similar to "do not push between 3-5pm", or when some other event happens). In addition, when you subscribe to an observable sequence, you get an <xref:System.IDisposable> handle which you can use to unsubscribe (by calling <xref:System.IDisposable.Dispose>) to the sequence later.

## See also

- [Create and Subscribe to observable sequences](quickstarts/create-and-subscribe-observable-sequences.md)
