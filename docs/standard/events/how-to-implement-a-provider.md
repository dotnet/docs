---
description: "Learn how to implement an observer pattern provider in .NET by creating an IObservable<T> type that tracks subscribers and pushes notifications."
title: "How to implement a provider"
ms.date: 06/01/2026
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "observer design pattern [.NET], implementing providers"
  - "providers [.NET], in observer design pattern"
  - "observables [.NET], in observer design pattern"
ms.assetid: 790b5d8b-d546-40a6-beeb-151b574e5ee5
ms.topic: how-to
---

<!-- customer intent: As a .NET developer, I want to implement a provider so that I can use the observer design pattern to push data to registered observers. -->

# How to implement a provider

The observer design pattern requires a division between a provider, which monitors data and sends notifications, and one or more observers, which receive notifications (callbacks) from the provider. This article shows how to create a provider. For information about creating an observer, see [How to implement an observer](how-to-implement-an-observer.md).

## Define the data type

Define the data that the provider sends to observers. Although the provider and the data it sends to observers can be a single type, a different type typically represents each. For example, in a temperature monitoring application, the `Temperature` structure defines the data that the `TemperatureMonitor` class (defined in the next section) monitors and to which observers subscribe.

:::code language="csharp" source="./snippets/shared/how-to-provider-observer/csharp/data.cs" id="Temperature":::
:::code language="vb" source="./snippets/shared/how-to-provider-observer/vb/data.vb" id="Temperature":::

## Create a provider

The data provider is a type that implements the <xref:System.IObservable`1?displayProperty=nameWithType> interface. The provider's generic type argument is the type it sends to observers.

1. Define the provider class. The following example defines a `TemperatureMonitor` class, which is a constructed <xref:System.IObservable`1?displayProperty=nameWithType> implementation with a generic type argument of `Temperature`.

   :::code language="csharp" source="./snippets/shared/how-to-provider-observer/csharp/provider.cs" id="ClassDeclaration":::
   :::code language="vb" source="./snippets/shared/how-to-provider-observer/vb/provider.vb" id="ClassDeclaration":::

1. Add a field to store observer references.

   The provider needs to track each registered observer so it can send notifications later. Typically, use a collection object such as a generic <xref:System.Collections.Generic.List`1> object. The following example defines a private <xref:System.Collections.Generic.List`1> object instantiated in the `TemperatureMonitor` class constructor.

   :::code language="csharp" source="./snippets/shared/how-to-provider-observer/csharp/provider.cs" id="ObserverList":::
   :::code language="vb" source="./snippets/shared/how-to-provider-observer/vb/provider.vb" id="ObserverList":::

1. Define an <xref:System.IDisposable> implementation for unsubscribing.

   The provider returns this implementation to subscribers so they can stop receiving notifications at any time. The following example defines a nested `Unsubscriber` class that receives a reference to the subscribers collection and to the subscriber when instantiated. The `Unsubscriber` class enables the subscriber to call the object's <xref:System.IDisposable.Dispose*?displayProperty=nameWithType> implementation to remove itself from the subscribers collection.

   :::code language="csharp" source="./snippets/shared/how-to-provider-observer/csharp/provider.cs" id="Unsubscriber":::
   :::code language="vb" source="./snippets/shared/how-to-provider-observer/vb/provider.vb" id="Unsubscriber":::

1. Implement the <xref:System.IObservable`1.Subscribe*?displayProperty=nameWithType> method.

   The method receives a reference to the <xref:System.IObserver`1?displayProperty=nameWithType> interface. Store that reference in the observer collection from the previous step, then return the <xref:System.IDisposable> unsubscriber implementation. The following example shows the `Subscribe` implementation in the `TemperatureMonitor` class.

   :::code language="csharp" source="./snippets/shared/how-to-provider-observer/csharp/provider.cs" id="Subscribe":::
   :::code language="vb" source="./snippets/shared/how-to-provider-observer/vb/provider.vb" id="Subscribe":::

1. Implement the notification logic by calling observers' <xref:System.IObserver`1.OnNext*?displayProperty=nameWithType>, <xref:System.IObserver`1.OnError*?displayProperty=nameWithType>, and <xref:System.IObserver`1.OnCompleted*?displayProperty=nameWithType> methods.

   In some cases, a provider might not call <xref:System.IObserver`1.OnError*> when an error occurs. The following `GetTemperature` method simulates a monitor that reads temperature data every five seconds and notifies observers if the temperature has changed by at least .1 degree since the previous reading. If the device doesn't report a temperature (that is, if its value is null), the provider notifies observers that the transmission is complete by calling each observer's <xref:System.IObserver`1.OnCompleted*> method and clears the <xref:System.Collections.Generic.List`1> collection. In this example, the provider never calls <xref:System.IObserver`1.OnError*>.

   :::code language="csharp" source="./snippets/shared/how-to-provider-observer/csharp/provider.cs" id="Notify":::
   :::code language="vb" source="./snippets/shared/how-to-provider-observer/vb/provider.vb" id="Notify":::

## Example

The following example contains the complete source code for an <xref:System.IObservable`1> implementation for a temperature monitoring application. It includes the `Temperature` structure, which is the data the provider sends to observers, and the `TemperatureMonitor` class, which is the <xref:System.IObservable`1> implementation.

:::code language="csharp" source="./snippets/shared/how-to-provider-observer/csharp/provider.cs" id="All":::
:::code language="vb" source="./snippets/shared/how-to-provider-observer/vb/provider.vb" id="All":::

## Related content

- <xref:System.IObservable`1>
- [Observer design pattern](observer-design-pattern.md)
- [How to implement an observer](how-to-implement-an-observer.md)
- [Best practices for the observer design pattern](observer-design-pattern-best-practices.md)
