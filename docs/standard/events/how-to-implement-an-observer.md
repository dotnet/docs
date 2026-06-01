---
title: "How to: Implement an Observer"
description: Implement an observer in .NET. The observer design pattern requires a division between an observer, which registers for notifications, and a provider.
ms.date: "03/30/2017"
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "observers [.NET], observer design pattern"
  - "observer design pattern [.NET], implementing observers"
ms.assetid: 8ecfa9f5-b500-473d-bcf0-5652ffb1e53d
---
# How to: Implement an Observer

The observer design pattern requires a division between an observer, which registers for notifications, and a provider, which monitors data and sends notifications to one or more observers. This topic discusses how to create an observer. A related topic, [How to: Implement a Provider](how-to-implement-a-provider.md), discusses how to create a provider.

### To create an observer

1. Define the observer, which is a type that implements the <xref:System.IObserver`1?displayProperty=nameWithType> interface. For example, the following code defines a type named `TemperatureReporter` that is a constructed <xref:System.IObserver`1?displayProperty=nameWithType> implementation with a generic type argument of `Temperature`.

     :::code language="csharp" source="./snippets/shared/how-to-provider-observer/csharp/observer.cs" id="ClassDeclaration":::
     :::code language="vb" source="./snippets/shared/how-to-provider-observer/vb/observer.vb" id="ClassDeclaration":::

2. If the observer can stop receiving notifications before the provider calls its <xref:System.IObserver`1.OnCompleted*?displayProperty=nameWithType> implementation, define a private variable that will hold the <xref:System.IDisposable> implementation returned by the provider's <xref:System.IObservable`1.Subscribe*?displayProperty=nameWithType> method. You should also define a subscription method that calls the provider's <xref:System.IObservable`1.Subscribe*> method and stores the returned <xref:System.IDisposable> object. For example, the following code defines a private variable named `unsubscriber` and defines a `Subscribe` method that calls the provider's <xref:System.IObservable`1.Subscribe*> method and assigns the returned object to the `unsubscriber` variable.

     :::code language="csharp" source="./snippets/shared/how-to-provider-observer/csharp/observer.cs" id="Subscribe":::
     :::code language="vb" source="./snippets/shared/how-to-provider-observer/vb/observer.vb" id="Subscribe":::

3. Define a method that enables the observer to stop receiving notifications before the provider calls its <xref:System.IObserver`1.OnCompleted*?displayProperty=nameWithType> implementation, if this feature is required. The following example defines an `Unsubscribe` method.

     :::code language="csharp" source="./snippets/shared/how-to-provider-observer/csharp/observer.cs" id="Unsubscribe":::
     :::code language="vb" source="./snippets/shared/how-to-provider-observer/vb/observer.vb" id="Unsubscribe":::

4. Provide implementations of the three methods defined by the <xref:System.IObserver`1> interface: <xref:System.IObserver`1.OnNext*?displayProperty=nameWithType>, <xref:System.IObserver`1.OnError*?displayProperty=nameWithType>, and <xref:System.IObserver`1.OnCompleted*?displayProperty=nameWithType>. Depending on the provider and the needs of the application, the <xref:System.IObserver`1.OnError*> and <xref:System.IObserver`1.OnCompleted*> methods can be stub implementations. Note that the <xref:System.IObserver`1.OnError*> method should not handle the passed <xref:System.Exception> object as an exception, and the <xref:System.IObserver`1.OnCompleted*> method is free to call the provider's <xref:System.IDisposable.Dispose*?displayProperty=nameWithType> implementation. The following example shows the <xref:System.IObserver`1> implementation of the `TemperatureReporter` class.

     :::code language="csharp" source="./snippets/shared/how-to-provider-observer/csharp/observer.cs" id="ObserverMethods":::
     :::code language="vb" source="./snippets/shared/how-to-provider-observer/vb/observer.vb" id="ObserverMethods":::

## Example

 The following example contains the complete source code for the `TemperatureReporter` class, which provides the <xref:System.IObserver`1> implementation for a temperature monitoring application.

 :::code language="csharp" source="./snippets/shared/how-to-provider-observer/csharp/observer.cs" id="All":::
 :::code language="vb" source="./snippets/shared/how-to-provider-observer/vb/observer.vb" id="All":::

## See also

- <xref:System.IObserver`1>
- [Observer Design Pattern](observer-design-pattern.md)
- [How to: Implement a Provider](how-to-implement-a-provider.md)
- [Observer Design Pattern Best Practices](observer-design-pattern-best-practices.md)
