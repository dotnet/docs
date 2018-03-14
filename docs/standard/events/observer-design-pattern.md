---
title: "Observer Design Pattern"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "IObserver(Of T) interface"
  - "IObservable<T> interface"
  - "IObserver<T> interface"
  - "IObservable(Of T) interface"
  - "observer design pattern [.NET Framework]"
ms.assetid: 3680171f-f522-453c-aa4a-54f755a78f88
caps.latest.revision: 14
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Observer Design Pattern
The observer design pattern enables a subscriber to register with and receive notifications from a provider. It is suitable for any scenario that requires push-based notification. The pattern defines a *provider* (also known as a *subject* or an *observable*) and zero, one, or more *observers*. Observers register with the provider, and whenever a predefined condition, event, or state change occurs, the provider automatically notifies all observers by calling one of their methods. In this method call, the provider can also provide current state information to observers. In the .NET Framework, the observer design pattern is applied by implementing the generic <xref:System.IObservable%601?displayProperty=nameWithType> and <xref:System.IObserver%601?displayProperty=nameWithType> interfaces. The generic type parameter represents the type that provides notification information.  
  
## Applying the Pattern  
 The observer design pattern is suitable for distributed push-based notifications, because it supports a clean separation between two different components or application layers, such as a data source (business logic) layer and a user interface (display) layer. The pattern can be implemented whenever a provider uses callbacks to supply its clients with current information.  
  
 Implementing the pattern requires that you provide the following:  
  
-   A provider or subject, which is the object that sends notifications to observers. A provider is a class or structure that implements the <xref:System.IObservable%601> interface. The provider must implement a single method, <xref:System.IObservable%601.Subscribe%2A?displayProperty=nameWithType>, which is called by observers that wish to receive notifications from the provider.  
  
-   An observer, which is an object that receives notifications from a provider. An observer is a class or structure that implements the <xref:System.IObserver%601> interface. The observer must implement three methods, all of which are called by the provider:  
  
    -   <xref:System.IObserver%601.OnNext%2A?displayProperty=nameWithType>, which supplies the observer with new or current information.  
  
    -   <xref:System.IObserver%601.OnError%2A?displayProperty=nameWithType>, which informs the observer that an error has occurred.  
  
    -   <xref:System.IObserver%601.OnCompleted%2A?displayProperty=nameWithType>, which indicates that the provider has finished sending notifications.  
  
-   A mechanism that allows the provider to keep track of observers. Typically, the provider uses a container object, such as a <xref:System.Collections.Generic.List%601?displayProperty=nameWithType> object, to hold references to the <xref:System.IObserver%601> implementations that have subscribed to notifications. Using a storage container for this purpose enables the provider to handle zero to an unlimited number of observers. The order in which observers receive notifications is not defined; the provider is free to use any method to determine the order.  
  
-   An <xref:System.IDisposable> implementation that enables the provider to remove observers when notification is complete. Observers receive a reference to the <xref:System.IDisposable> implementation from the <xref:System.IObservable%601.Subscribe%2A> method, so they can also call the <xref:System.IDisposable.Dispose%2A?displayProperty=nameWithType> method to unsubscribe before the provider has finished sending notifications.  
  
-   An object that contains the data that the provider sends to its observers. The type of this object corresponds to the generic type parameter of the <xref:System.IObservable%601> and <xref:System.IObserver%601> interfaces. Although this object can be the same as the <xref:System.IObservable%601> implementation, most commonly it is a separate type.  
  
> [!NOTE]
>  In addition to implementing the observer design pattern, you may be interested in exploring libraries that are built using the <xref:System.IObservable%601> and <xref:System.IObserver%601> interfaces. For example, [Reactive Extensions for .NET (Rx)](https://msdn.microsoft.com/library/hh242985.aspx) consist of a set of extension methods and LINQ standard sequence operators to support asynchronous programming.  
  
## Implementing the Pattern  
 The following example uses the observer design pattern to implement an airport baggage claim information system. A `BaggageInfo` class provides information about arriving flights and the carousels where baggage from each flight is available for pickup. It is shown in the following example.  
  
 [!code-csharp[Conceptual.ObserverDesignPattern#1](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.observerdesignpattern/cs/provider.cs#1)]
 [!code-vb[Conceptual.ObserverDesignPattern#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.observerdesignpattern/vb/provider.vb#1)]  
  
 A `BaggageHandler` class is responsible for receiving information about arriving flights and baggage claim carousels. Internally, it maintains two collections:  
  
-   `observers` - A collection of clients that will receive updated information.  
  
-   `flights` - A collection of flights and their assigned carousels.  
  
 Both collections are represented by generic <xref:System.Collections.Generic.List%601> objects that are instantiated in the `BaggageHandler` class constructor. The source code for the `BaggageHandler` class is shown in the following example.  
  
 [!code-csharp[Conceptual.ObserverDesignPattern#2](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.observerdesignpattern/cs/provider.cs#2)]
 [!code-vb[Conceptual.ObserverDesignPattern#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.observerdesignpattern/vb/provider.vb#2)]  
  
 Clients that wish to receive updated information call the `BaggageHandler.Subscribe` method. If the client has not previously subscribed to notifications, a reference to the client's <xref:System.IObserver%601> implementation is added to the `observers` collection.  
  
 The overloaded `BaggageHandler.BaggageStatus` method can be called to indicate that baggage from a flight either is being unloaded or is no longer being unloaded. In the first case, the method is passed a flight number, the airport from which the flight originated, and the carousel where baggage is being unloaded. In the second case, the method is passed only a flight number. For baggage that is being unloaded, the method checks whether the `BaggageInfo` information passed to the method exists in the `flights` collection. If it does not, the method adds the information and calls each observer's `OnNext` method. For flights whose baggage is no longer being unloaded, the method checks whether information on that flight is stored in the `flights` collection. If it is, the method calls each observer's `OnNext` method and removes the `BaggageInfo` object from the `flights` collection.  
  
 When the last flight of the day has landed and its baggage has been processed, the `BaggageHandler.LastBaggageClaimed` method is called. This method calls each observer's `OnCompleted` method to indicate that all notifications have completed, and then clears the `observers` collection.  
  
 The provider's <xref:System.IObservable%601.Subscribe%2A> method returns an <xref:System.IDisposable> implementation that enables observers to stop receiving notifications before the <xref:System.IObserver%601.OnCompleted%2A> method is called. The source code for this `Unsubscriber(Of BaggageInfo)` class is shown in the following example. When the class is instantiated in the `BaggageHandler.Subscribe` method, it is passed a reference to the `observers` collection and a reference to the observer that is added to the collection. These references are assigned to local variables. When the object's `Dispose` method is called, it checks whether the observer still exists in the `observers` collection, and, if it does, removes the observer.  
  
 [!code-csharp[Conceptual.ObserverDesignPattern#3](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.observerdesignpattern/cs/provider.cs#3)]
 [!code-vb[Conceptual.ObserverDesignPattern#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.observerdesignpattern/vb/provider.vb#3)]  
  
 The following example provides an <xref:System.IObserver%601> implementation named `ArrivalsMonitor`, which is a base class that displays baggage claim information. The information is displayed alphabetically, by the name of the originating city. The methods of `ArrivalsMonitor` are marked as `overridable` (in Visual Basic) or `virtual` (in C#), so they can all be overridden by a derived class.  
  
 [!code-csharp[Conceptual.ObserverDesignPattern#4](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.observerdesignpattern/cs/observer.cs#4)]
 [!code-vb[Conceptual.ObserverDesignPattern#4](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.observerdesignpattern/vb/observer.vb#4)]  
  
 The `ArrivalsMonitor` class includes the `Subscribe` and `Unsubscribe` methods. The `Subscribe` method enables the class to save the <xref:System.IDisposable> implementation returned by the call to <xref:System.IObservable%601.Subscribe%2A> to a private variable. The `Unsubscribe` method enables the class to unsubscribe from notifications by calling the provider's <xref:System.IDisposable.Dispose%2A> implementation. `ArrivalsMonitor` also provides implementations of the <xref:System.IObserver%601.OnNext%2A>, <xref:System.IObserver%601.OnError%2A>, and <xref:System.IObserver%601.OnCompleted%2A> methods. Only the <xref:System.IObserver%601.OnNext%2A> implementation contains a significant amount of code. The method works with a private, sorted, generic <xref:System.Collections.Generic.List%601> object that maintains information about the airports of origin for arriving flights and the carousels on which their baggage is available. If the `BaggageHandler` class reports a new flight arrival, the <xref:System.IObserver%601.OnNext%2A> method implementation adds information about that flight to the list. If the `BaggageHandler` class reports that the flight's baggage has been unloaded, the <xref:System.IObserver%601.OnNext%2A> method removes that flight from the list. Whenever a change is made, the list is sorted and displayed to the console.  
  
 The following example contains the application entry point that instantiates the `BaggageHandler` class as well as two instances of the `ArrivalsMonitor` class, and uses the `BaggageHandler.BaggageStatus` method to add and remove information about arriving flights. In each case, the observers receive updates and correctly display baggage claim information.  
  
 [!code-csharp[Conceptual.ObserverDesignPattern#5](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.observerdesignpattern/cs/program.cs#5)]
 [!code-vb[Conceptual.ObserverDesignPattern#5](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.observerdesignpattern/vb/module1.vb#5)]  
  
## Related Topics  
  
|Title|Description|  
|-----------|-----------------|  
|[Observer Design Pattern Best Practices](../../../docs/standard/events/observer-design-pattern-best-practices.md)|Describes best practices to adopt when developing applications that implement the observer design pattern.|  
|[How to: Implement a Provider](../../../docs/standard/events/how-to-implement-a-provider.md)|Provides a step-by-step implementation of a provider for a temperature monitoring application.|  
|[How to: Implement an Observer](../../../docs/standard/events/how-to-implement-an-observer.md)|Provides a step-by-step implementation of an observer for a temperature monitoring application.|
