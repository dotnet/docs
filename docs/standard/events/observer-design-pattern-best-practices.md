---
title: "Observer Design Pattern Best Practices"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "observer design pattern [.NET Framework], best practices"
  - "best practices [.NET Framework], observer design pattern"
ms.assetid: c834760f-ddd4-417f-abb7-a059679d5b8c
caps.latest.revision: 9
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Observer Design Pattern Best Practices
In the .NET Framework, the observer design pattern is implemented as a set of interfaces. The <xref:System.IObservable%601?displayProperty=nameWithType> interface represents the data provider, which is also responsible for providing an <xref:System.IDisposable> implementation that lets observers unsubscribe from notifications. The <xref:System.IObserver%601?displayProperty=nameWithType> interface represents the observer. This topic describes the best practices that developers should follow when implementing the observer design pattern using these interfaces.  
  
## Threading  
 Typically, a provider implements the <xref:System.IObservable%601.Subscribe%2A?displayProperty=nameWithType> method by adding a particular observer to a subscriber list that is represented by some collection object, and it implements the <xref:System.IDisposable.Dispose%2A?displayProperty=nameWithType> method by removing a particular observer from the subscriber list. An observer can call these methods at any time. In addition, because the provider/observer contract does not specify who is responsible for unsubscribing after the <xref:System.IObserver%601.OnCompleted%2A?displayProperty=nameWithType> callback method, the provider and observer may both try to remove the same member from the list. Because of this possibility, both the <xref:System.IObservable%601.Subscribe%2A> and <xref:System.IDisposable.Dispose%2A> methods should be thread-safe. Typically, this involves using a [concurrent collection](../../../docs/standard/parallel-programming/data-structures-for-parallel-programming.md) or a lock. Implementations that are not thread-safe should explicitly document that they are not.  
  
 Any additional guarantees have to be specified in a layer on top of the provider/observer contract. Implementers should clearly call out when they impose additional requirements to avoid user confusion about the observer contract.  
  
## Handling Exceptions  
 Because of the loose coupling between a data provider and an observer, exceptions in the observer design pattern are intended to be informational. This affects how providers and observers handle exceptions in the observer design pattern.  
  
### The Provider -- Calling the OnError Method  
 The <xref:System.IObserver%601.OnError%2A> method is intended as an informational message to observers, much like the <xref:System.IObserver%601.OnNext%2A?displayProperty=nameWithType> method. However, the <xref:System.IObserver%601.OnNext%2A> method is designed to provide an observer with current or updated data, whereas the <xref:System.IObserver%601.OnError%2A> method is designed to indicate that the provider is unable to provide valid data.  
  
 The provider should follow these best practices when handling exceptions and calling the <xref:System.IObserver%601.OnError%2A> method:  
  
-   The provider must handle its own exceptions if it has any specific requirements.  
  
-   The provider should not expect or require that observers handle exceptions in any particular way.  
  
-   The provider should call the <xref:System.IObserver%601.OnError%2A> method when it handles an exception that compromises its ability to provide updates. Information on such exceptions can be passed to the observer. In other cases, there is no need to notify observers of an exception.  
  
 Once the provider calls the <xref:System.IObserver%601.OnError%2A> or <xref:System.IObserver%601.OnCompleted%2A?displayProperty=nameWithType> method, there should be no further notifications, and the provider can unsubscribe its observers. However, the observers can also unsubscribe themselves at any time, including both before and after they receive an <xref:System.IObserver%601.OnError%2A> or <xref:System.IObserver%601.OnCompleted%2A?displayProperty=nameWithType> notification. The observer design pattern does not dictate whether the provider or the observer is responsible for unsubscribing; therefore, there is a possibility that both may attempt to unsubscribe. Typically, when observers unsubscribe, they are removed from a subscribers collection. In a single-threaded application, the <xref:System.IDisposable.Dispose%2A?displayProperty=nameWithType> implementation should ensure that an object reference is valid and that the object is a member of the subscribers collection before attempting to remove it. In a multithreaded application, a thread-safe collection object, such as a <xref:System.Collections.Concurrent.BlockingCollection%601?displayProperty=nameWithType> object, should be used.  
  
### The Observer -- Implementing the OnError Method  
 When an observer receives an error notification from a provider, the observer should treat the exception as informational and should not be required to take any particular action.  
  
 The observer should follow these best practices when responding to an <xref:System.IObserver%601.OnError%2A> method call from a provider:  
  
-   The observer should not throw exceptions from its interface implementations, such as <xref:System.IObserver%601.OnNext%2A> or <xref:System.IObserver%601.OnError%2A>. However, if the observer does throw exceptions, it should expect these exceptions to go unhandled.  
  
-   To preserve the call stack, an observer that wishes to throw an <xref:System.Exception> object that was passed to its <xref:System.IObserver%601.OnError%2A> method should wrap the exception before throwing it. A standard exception object should be used for this purpose.  
  
## Additional Best Practices  
 Attempting to unregister in the <xref:System.IObservable%601.Subscribe%2A?displayProperty=nameWithType> method may result in a null reference. Therefore, we recommend that you avoid this practice.  
  
 Although it is possible to attach an observer to multiple providers, the recommended pattern is to attach an <xref:System.IObserver%601> instance to only one <xref:System.IObservable%601> instance.  
  
## See Also  
 [Observer Design Pattern](../../../docs/standard/events/observer-design-pattern.md)  
 [How to: Implement an Observer](../../../docs/standard/events/how-to-implement-an-observer.md)  
 [How to: Implement a Provider](../../../docs/standard/events/how-to-implement-a-provider.md)
