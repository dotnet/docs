---
title: "How to implement an Observer"
description: Implement an observer in .NET. The observer design pattern requires a division between an observer, which registers for notifications, and a provider.
ms.date: 06/01/2026
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "observers [.NET], observer design pattern"
  - "observer design pattern [.NET], implementing observers"
ms.assetid: 8ecfa9f5-b500-473d-bcf0-5652ffb1e53d
ms.topic: how-to
---

<!-- customer intent: As a .NET developer, I want to implement an observer so that I can use the observer design pattern to receive data pushed from a registered provider. -->

# How to implement an observer

The observer design pattern requires a division between an observer, which registers for notifications, and a provider, which monitors data and sends notifications to one or more observers. This article discusses how to create an observer. A related article, [How to implement a provider](how-to-implement-a-provider.md), discusses how to create a provider.

## Create an observer

To create an observer, implement the <xref:System.IObserver`1?displayProperty=nameWithType> interface. The following steps describe each member you need to define.

1. Define the observer type that implements the <xref:System.IObserver`1?displayProperty=nameWithType> interface.

   The following code defines a type named `TemperatureReporter` that is a constructed <xref:System.IObserver`1?displayProperty=nameWithType> implementation with a generic type argument of `Temperature`.

   :::code language="csharp" source="./snippets/shared/how-to-provider-observer/csharp/observer.cs" id="ClassDeclaration":::
   :::code language="vb" source="./snippets/shared/how-to-provider-observer/vb/observer.vb" id="ClassDeclaration":::

1. If the observer needs to unsubscribe before the provider calls <xref:System.IObserver`1.OnCompleted*?displayProperty=nameWithType>, define a private variable to hold the <xref:System.IDisposable> returned by <xref:System.IObservable`1.Subscribe*?displayProperty=nameWithType>, and define a subscription method.

   The private variable `unsubscriber` stores the <xref:System.IDisposable> object. The `Subscribe` method calls the provider's <xref:System.IObservable`1.Subscribe*> method and assigns the returned object to `unsubscriber`.

   :::code language="csharp" source="./snippets/shared/how-to-provider-observer/csharp/observer.cs" id="Subscribe":::
   :::code language="vb" source="./snippets/shared/how-to-provider-observer/vb/observer.vb" id="Subscribe":::

1. Define an `Unsubscribe` method that lets the observer stop receiving notifications before the provider calls <xref:System.IObserver`1.OnCompleted*?displayProperty=nameWithType>.

   :::code language="csharp" source="./snippets/shared/how-to-provider-observer/csharp/observer.cs" id="Unsubscribe":::
   :::code language="vb" source="./snippets/shared/how-to-provider-observer/vb/observer.vb" id="Unsubscribe":::

1. Implement the three methods defined by <xref:System.IObserver`1>: <xref:System.IObserver`1.OnNext*?displayProperty=nameWithType>, <xref:System.IObserver`1.OnError*?displayProperty=nameWithType>, and <xref:System.IObserver`1.OnCompleted*?displayProperty=nameWithType>.

   The <xref:System.IObserver`1.OnError*> and <xref:System.IObserver`1.OnCompleted*> methods can be stub implementations. The <xref:System.IObserver`1.OnError*> method shouldn't handle the passed <xref:System.Exception> as an exception, and <xref:System.IObserver`1.OnCompleted*> can call the provider's <xref:System.IDisposable.Dispose*?displayProperty=nameWithType> implementation.

   :::code language="csharp" source="./snippets/shared/how-to-provider-observer/csharp/observer.cs" id="ObserverMethods":::
   :::code language="vb" source="./snippets/shared/how-to-provider-observer/vb/observer.vb" id="ObserverMethods":::

## Complete example

 The following example shows the complete source code for the `TemperatureReporter` class, which provides the <xref:System.IObserver`1> implementation for a temperature monitoring application.

 :::code language="csharp" source="./snippets/shared/how-to-provider-observer/csharp/observer.cs" id="All":::
 :::code language="vb" source="./snippets/shared/how-to-provider-observer/vb/observer.vb" id="All":::

## Related content

- <xref:System.IObserver`1>
- [Observer design pattern](observer-design-pattern.md)
- [How to implement a provider](how-to-implement-a-provider.md)
- [Best practices for the observer design pattern](observer-design-pattern-best-practices.md)
