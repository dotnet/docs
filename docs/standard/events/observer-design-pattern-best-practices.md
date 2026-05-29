---
title: "Observer design pattern best practices"
description: Learn about best practices for implementing the observer design pattern in .NET using the IObservable and IObserver interfaces.
ms.date: 05/29/2026
ms.topic: best-practice
helpviewer_keywords:
  - "observer design pattern [.NET], best practices"
  - "best practices [.NET], observer design pattern"
ms.assetid: c834760f-ddd4-417f-abb7-a059679d5b8c

#customer intent: As a .NET developer, I want to understand best practices for implementing the observer design pattern so that I can build reliable and thread-safe observable/observer relationships.

---
# Observer design pattern best practices

In .NET, the observer design pattern is implemented as a set of interfaces. The <xref:System.IObservable`1?displayProperty=nameWithType> interface represents the data provider, which is also responsible for providing an <xref:System.IDisposable> implementation that lets observers unsubscribe from notifications. The <xref:System.IObserver`1?displayProperty=nameWithType> interface represents the observer. This article describes best practices to follow when you implement the observer design pattern using these interfaces.

## Threading

Typically, a provider implements the <xref:System.IObservable`1.Subscribe*?displayProperty=nameWithType> method by adding a particular observer to a subscriber list represented by some collection object, and it implements the <xref:System.IDisposable.Dispose*?displayProperty=nameWithType> method by removing a particular observer from the subscriber list. An observer can call these methods at any time. The provider/observer contract doesn't specify who is responsible for unsubscribing after the <xref:System.IObserver`1.OnCompleted*?displayProperty=nameWithType> callback method, so the provider and observer might both try to remove the same member from the list. Because of this possibility, make both the <xref:System.IObservable`1.Subscribe*> and <xref:System.IDisposable.Dispose*> methods thread-safe. Typically, this involves using a [concurrent collection](../parallel-programming/data-structures-for-parallel-programming.md) or a lock. Implementations that aren't thread-safe should explicitly document that they aren't.

Specify any extra guarantees in a layer on top of the provider/observer contract. Implementers should clearly call out when they impose extra requirements to avoid user confusion about the observer contract.

## Handling exceptions

Because of the loose coupling between a data provider and an observer, exceptions in the observer design pattern are intended to be informational. This characteristic affects how providers and observers handle exceptions in the observer design pattern.

## The provider: calling the OnError method

The <xref:System.IObserver`1.OnError*> method is intended as an informational message to observers, much like the <xref:System.IObserver`1.OnNext*?displayProperty=nameWithType> method. However, the <xref:System.IObserver`1.OnNext*> method provides an observer with current or updated data, whereas the <xref:System.IObserver`1.OnError*> method indicates that the provider can't provide valid data.

Follow these best practices when you handle exceptions and call the <xref:System.IObserver`1.OnError*> method:

- The provider must handle its own exceptions if it has any specific requirements.

- The provider shouldn't expect or require that observers handle exceptions in any particular way.

- The provider should call the <xref:System.IObserver`1.OnError*> method when it handles an exception that compromises its ability to provide updates. Pass information on such exceptions to the observer. In other cases, there's no need to notify observers of an exception.

Once the provider calls the <xref:System.IObserver`1.OnError*> or <xref:System.IObserver`1.OnCompleted*?displayProperty=nameWithType> method, there should be no further notifications, and the provider can unsubscribe its observers. However, the observers can also unsubscribe themselves at any time, including both before and after they receive an <xref:System.IObserver`1.OnError*> or <xref:System.IObserver`1.OnCompleted*?displayProperty=nameWithType> notification. The observer design pattern doesn't dictate whether the provider or the observer is responsible for unsubscribing; therefore, both might attempt to unsubscribe. Typically, when observers unsubscribe, they're removed from a subscribers collection. In a single-threaded application, the <xref:System.IDisposable.Dispose*?displayProperty=nameWithType> implementation should ensure that an object reference is valid and that the object is a member of the subscribers collection before attempting to remove it. In a multithreaded application, use a lock to protect the observers collection.

## The observer: implementing the OnError method

When an observer receives an error notification from a provider, the observer should treat the exception as informational and shouldn't be required to take any particular action.

Follow these best practices when you respond to an <xref:System.IObserver`1.OnError*> method call from a provider:

- Don't throw exceptions from interface implementations, such as <xref:System.IObserver`1.OnNext*> or <xref:System.IObserver`1.OnError*>. However, if the observer does throw exceptions, expect these exceptions to go unhandled.

- To preserve the call stack, an observer that wants to throw an <xref:System.Exception> object that was passed to its <xref:System.IObserver`1.OnError*> method should wrap the exception before throwing it. Use a standard exception object for this purpose.

## Other best practices

Don't attempt to unregister in the <xref:System.IObservable`1.Subscribe*?displayProperty=nameWithType> method, because it might result in a null reference.

Although you can attach an observer to multiple providers, the recommended pattern is to attach an <xref:System.IObserver`1> instance to only one <xref:System.IObservable`1> instance.

## Related content

- [Observer design pattern](observer-design-pattern.md)
- [How to: Implement an observer](how-to-implement-an-observer.md)
- [How to: Implement a provider](how-to-implement-a-provider.md)
