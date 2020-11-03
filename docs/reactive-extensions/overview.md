---
title: Reactive Extensions
description: Getting started with the .NET family of technologies.
author: IEvangelist
ms.date: 11/03/2020
ms.author: dapine
ms.topic: overview
---

# Reactive Extensions

Reactive Extensions (Rx) is a library for composing asynchronous and event-based programs using observable sequences and LINQ-style query operators. Data sequences can take many forms, such as a stream of data from a file or web service, web service requests, system notifications, or a series of events such as user input.

Reactive Extensions represents all these data sequences as observable sequences. An application can subscribe to these observable sequences to receive asynchronous notifications as new data arrive. The Rx library is available for desktop application development in .NET. It is also released for Silverlight, Windows Phone 7 and JavaScript. For more information on these different platforms, see [Differences Between Versions of Rx](hh242987\(v=vs.103\).md) topic.

## Pull vs Push programming models

In interactive programming, the application actively polls a data source for more information by pulling data from a sequence that represents the source. Such behavior is represented by the iterator pattern of IEnumerable\<T\>/IEnumerator\<T\>. The IEnumerable\<T\> interface exposes a single method GetEnumerator() which returns an IEnumerator\<T\> to iterate through this collection.  The IEnumerator\<T\> allows us to get the current item (by returning the Current property), and determine whether there are more items to iterate (by calling the MoveNext method). 

The application is active in the data retrieval process: besides getting an enumerator by calling GetEnumerator, it also controls the pace of the retrieval by calling MoveNext at its own convenience. This enumeration pattern is synchronous, which means that the application might be blocked while polling the data source. Such pulling pattern is similar to visiting your library and checking out a book. After you are done with the book, you pay another visit to check out another one.

On the other hand, in reactive programming, the application is offered more information by subscribing to a data stream (called observable sequence in Rx), and any update is handed to it from the source. The application is passive in the data retrieval process: apart from subscribing to the observable source, it does not actively poll the source, but merely react to the data being pushed to it. When the stream has no more data to offer, or when it errs, the source will send a notice to the subscriber. In this way, the application will not be blocked by waiting for the source to update.

This is the push pattern employed by Reactive Extensions. It is similar to joining a book club in which you register your interest in a particular genre, and books that match your interest are automatically sent to you as they are published. You do not need to stand in line to acquire something that you want. Employing a push pattern is helpful in many scenarios, especially in a UI-heavy environment in which the UI thread cannot be blocked while the application is waiting for some events. This is also essential in programming environments such as Silverlight which has its own set of asynchronous requirements. In summary, by using Rx, you can make your application more responsive.

The push model implemented by Rx is represented by the observable pattern of IObservable\<T\>/IObserver\<T\>. The IObservable\<T\> interface is a dual of the familiar IEnumerable\<T\> interface. It abstracts a sequence of data, and keeps a list of IObserver\<T\> implementations that are interested in the data sequence. The IObservable will notify all the observers automatically of any state changes. To register an interest through a subscription, you use the Subscribe method of IObservable, which takes on an IObserver and returns an IDisposable. This gives you the ability to track and dispose of the subscription. In addition, Rx's LINQ implementation over observable sequences allows developers to compose complex event processing queries over push-based sequences such as .NET events, APM-based ("IAsyncResult") computations, Task\<T\>-based computations, Windows 7 Sensor and Location APIs, SQL StreamInsight temporal event streams, F\# first-class events, and asynchronous workflows. For more information on the IObservable\<T\>/IObserver\<T\> interfaces, see [Exploring The Major Interfaces in Rx](hh242974\(v=vs.103\).md). For tutorials on using the different features in Rx, see [Using Rx](hh242981\(v=vs.103\).md).
