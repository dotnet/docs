---
title: "How to: Implement a Provider"
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
  - "observer design pattern [.NET Framework], implementing providers"
  - "providers [.NET Framework], in observer design pattern"
  - "observables [.NET Framework], in observer design pattern"
ms.assetid: 790b5d8b-d546-40a6-beeb-151b574e5ee5
caps.latest.revision: 8
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# How to: Implement a Provider
The observer design pattern requires a division between a provider, which monitors data and sends notifications, and one or more observers, which receive notifications (callbacks) from the provider. This topic discusses how to create a provider. A related topic, [How to: Implement an Observer](../../../docs/standard/events/how-to-implement-an-observer.md), discusses how to create an observer.  
  
### To create a provider  
  
1.  Define the data that the provider is responsible for sending to observers. Although the provider and the data that it sends to observers can be a single type, they are generally represented by different types. For example, in a temperature monitoring application, the `Temperature` structure defines the data that the provider (which is represented by the `TemperatureMonitor` class defined in the next step) monitors and to which observers subscribe.  
  
     [!code-csharp[Conceptual.ObserverDesign.HowTo#1](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.observerdesign.howto/cs/data.cs#1)]
     [!code-vb[Conceptual.ObserverDesign.HowTo#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.observerdesign.howto/vb/data.vb#1)]  
  
2.  Define the data provider, which is a type that implements the <xref:System.IObservable%601?displayProperty=nameWithType> interface. The provider's generic type argument is the type that the provider sends to observers. The following example defines a `TemperatureMonitor` class, which is a constructed <xref:System.IObservable%601?displayProperty=nameWithType> implementation with a generic type argument of `Temperature`.  
  
     [!code-csharp[Conceptual.ObserverDesign.HowTo#2](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.observerdesign.howto/cs/provider.cs#2)]
     [!code-vb[Conceptual.ObserverDesign.HowTo#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.observerdesign.howto/vb/provider.vb#2)]  
  
3.  Determine how the provider will store references to observers so that each observer can be notified when appropriate. Most commonly, a collection object such as a generic <xref:System.Collections.Generic.List%601> object is used for this purpose. The following example defines a private <xref:System.Collections.Generic.List%601> object that is instantiated in the `TemperatureMonitor` class constructor.  
  
     [!code-csharp[Conceptual.ObserverDesign.HowTo#3](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.observerdesign.howto/cs/provider.cs#3)]
     [!code-vb[Conceptual.ObserverDesign.HowTo#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.observerdesign.howto/vb/provider.vb#3)]  
  
4.  Define an <xref:System.IDisposable> implementation that the provider can return to subscribers so that they can stop receiving notifications at any time. The following example defines a nested `Unsubscriber` class that is passed a reference to the subscribers collection and to the subscriber when the class is instantiated. This code enables the subscriber to call the object's <xref:System.IDisposable.Dispose%2A?displayProperty=nameWithType> implementation to remove itself from the subscribers collection.  
  
     [!code-csharp[Conceptual.ObserverDesign.HowTo#4](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.observerdesign.howto/cs/provider.cs#4)]
     [!code-vb[Conceptual.ObserverDesign.HowTo#4](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.observerdesign.howto/vb/provider.vb#4)]  
  
5.  Implement the <xref:System.IObservable%601.Subscribe%2A?displayProperty=nameWithType> method. The method is passed a reference to the <xref:System.IObserver%601?displayProperty=nameWithType> interface and should be stored in the object designed for that purpose in step 3. The method should then return the <xref:System.IDisposable> implementation developed in step 4. The following example shows the implementation of the <xref:System.IObservable%601.Subscribe%2A> method in the `TemperatureMonitor` class.  
  
     [!code-csharp[Conceptual.ObserverDesign.HowTo#5](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.observerdesign.howto/cs/provider.cs#5)]
     [!code-vb[Conceptual.ObserverDesign.HowTo#5](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.observerdesign.howto/vb/provider.vb#5)]  
  
6.  Notify observers as appropriate by calling their <xref:System.IObserver%601.OnNext%2A?displayProperty=nameWithType>, <xref:System.IObserver%601.OnError%2A?displayProperty=nameWithType>, and <xref:System.IObserver%601.OnCompleted%2A?displayProperty=nameWithType> implementations. In some cases, a provider may not call the <xref:System.IObserver%601.OnError%2A> method when an error occurs. For example, the following `GetTemperature` method simulates a monitor that reads temperature data every five seconds and notifies observers if the temperature has changed by at least .1 degree since the previous reading. If the device does not report a temperature (that is, if its value is null), the provider notifies observers that the transmission is complete. Note that, in addition to calling each observer's <xref:System.IObserver%601.OnCompleted%2A> method, the `GetTemperature` method clears the <xref:System.Collections.Generic.List%601> collection. In this case, the provider makes no calls to the <xref:System.IObserver%601.OnError%2A> method of its observers.  
  
     [!code-csharp[Conceptual.ObserverDesign.HowTo#6](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.observerdesign.howto/cs/provider.cs#6)]
     [!code-vb[Conceptual.ObserverDesign.HowTo#6](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.observerdesign.howto/vb/provider.vb#6)]  
  
## Example  
 The following example contains the complete source code for defining an <xref:System.IObservable%601> implementation for a temperature monitoring application. It includes the `Temperature` structure, which is the data sent to observers, and the `TemperatureMonitor` class, which is the <xref:System.IObservable%601> implementation.  
  
 [!code-csharp[Conceptual.ObserverDesign.HowTo#7](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.observerdesign.howto/cs/provider.cs#7)]
 [!code-vb[Conceptual.ObserverDesign.HowTo#7](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.observerdesign.howto/vb/provider.vb#7)]  
  
## See Also  
 <xref:System.IObservable%601>  
 [Observer Design Pattern](../../../docs/standard/events/observer-design-pattern.md)  
 [How to: Implement an Observer](../../../docs/standard/events/how-to-implement-an-observer.md)  
 [Observer Design Pattern Best Practices](../../../docs/standard/events/observer-design-pattern-best-practices.md)
