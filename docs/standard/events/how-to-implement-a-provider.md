---
description: "Learn more about: How to: Implement a Provider"
title: "How to: Implement a Provider"
ms.date: "03/30/2017"
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "observer design pattern [.NET], implementing providers"
  - "providers [.NET], in observer design pattern"
  - "observables [.NET], in observer design pattern"
ms.assetid: 790b5d8b-d546-40a6-beeb-151b574e5ee5
ai-usage: ai-assisted
---
# How to: Implement a Provider

The observer design pattern requires a division between a provider, which monitors data and sends notifications, and one or more observers, which receive notifications (callbacks) from the provider. This article shows how to create a provider. For information about creating an observer, see [How to: Implement an Observer](how-to-implement-an-observer.md).

### To create a provider

1. Define the data that the provider is responsible for sending to observers. Although the provider and the data it sends to observers can be a single type, a different type typically represents each. For example, in a temperature monitoring application, the `Temperature` structure defines the data that the `TemperatureMonitor` class (defined in the next step) monitors and to which observers subscribe.

     :::code language="csharp" source="./snippets/shared/how-to-provider-observer/csharp/data.cs" id="Temperature":::
     :::code language="vb" source="./snippets/shared/how-to-provider-observer/vb/data.vb" id="Temperature":::

1. Define the data provider, which is a type that implements the <xref:System.IObservable`1?displayProperty=nameWithType> interface. The provider's generic type argument is the type that the provider sends to observers. The following example defines a `TemperatureMonitor` class, which is a constructed <xref:System.IObservable`1?displayProperty=nameWithType> implementation with a generic type argument of `Temperature`.

     :::code language="csharp" source="./snippets/shared/how-to-provider-observer/csharp/provider.cs" id="ClassDeclaration":::
     :::code language="vb" source="./snippets/shared/how-to-provider-observer/vb/provider.vb" id="ClassDeclaration":::

1. Determine how the provider stores references to observers so that it can notify each observer when appropriate. Typically, use a collection object such as a generic <xref:System.Collections.Generic.List`1> object. The following example defines a private <xref:System.Collections.Generic.List`1> object instantiated in the `TemperatureMonitor` class constructor.

     :::code language="csharp" source="./snippets/shared/how-to-provider-observer/csharp/provider.cs" id="ObserverList":::
     :::code language="vb" source="./snippets/shared/how-to-provider-observer/vb/provider.vb" id="ObserverList":::

1. Define an <xref:System.IDisposable> implementation that the provider can return to subscribers so they can stop receiving notifications at any time. The following example defines a nested `Unsubscriber` class that receives a reference to the subscribers collection and to the subscriber when instantiated. The `Unsubscriber` class enables the subscriber to call the object's <xref:System.IDisposable.Dispose*?displayProperty=nameWithType> implementation to remove itself from the subscribers collection.

     :::code language="csharp" source="./snippets/shared/how-to-provider-observer/csharp/provider.cs" id="Unsubscriber":::
     :::code language="vb" source="./snippets/shared/how-to-provider-observer/vb/provider.vb" id="Unsubscriber":::

1. Implement the <xref:System.IObservable`1.Subscribe*?displayProperty=nameWithType> method. The method receives a reference to the <xref:System.IObserver`1?displayProperty=nameWithType> interface; store that reference in the object designed for that purpose in step 3. The method then returns the <xref:System.IDisposable> implementation developed in step 4. The following example shows the implementation of the <xref:System.IObservable`1.Subscribe*> method in the `TemperatureMonitor` class.

     :::code language="csharp" source="./snippets/shared/how-to-provider-observer/csharp/provider.cs" id="Subscribe":::
     :::code language="vb" source="./snippets/shared/how-to-provider-observer/vb/provider.vb" id="Subscribe":::

1. Notify observers as appropriate by calling their <xref:System.IObserver`1.OnNext*?displayProperty=nameWithType>, <xref:System.IObserver`1.OnError*?displayProperty=nameWithType>, and <xref:System.IObserver`1.OnCompleted*?displayProperty=nameWithType> implementations. In some cases, a provider might not call the <xref:System.IObserver`1.OnError*> method when an error occurs. For example, the following `GetTemperature` method simulates a monitor that reads temperature data every five seconds and notifies observers if the temperature has changed by at least .1 degree since the previous reading. If the device doesn't report a temperature (that is, if its value is null), the provider notifies observers that the transmission is complete. In addition to calling each observer's <xref:System.IObserver`1.OnCompleted*> method, the `GetTemperature` method clears the <xref:System.Collections.Generic.List`1> collection. The provider doesn't call the <xref:System.IObserver`1.OnError*> method of its observers.

     :::code language="csharp" source="./snippets/shared/how-to-provider-observer/csharp/provider.cs" id="Notify":::
     :::code language="vb" source="./snippets/shared/how-to-provider-observer/vb/provider.vb" id="Notify":::

## Example

The following example contains the complete source code for an <xref:System.IObservable`1> implementation for a temperature monitoring application. It includes the `Temperature` structure, which is the data the provider sends to observers, and the `TemperatureMonitor` class, which is the <xref:System.IObservable`1> implementation.

:::code language="csharp" source="./snippets/shared/how-to-provider-observer/csharp/provider.cs" id="All":::
:::code language="vb" source="./snippets/shared/how-to-provider-observer/vb/provider.vb" id="All":::

## See also

- <xref:System.IObservable`1>
- [Observer Design Pattern](observer-design-pattern.md)
- [How to: Implement an Observer](how-to-implement-an-observer.md)
- [Observer Design Pattern Best Practices](observer-design-pattern-best-practices.md)
