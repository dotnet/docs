---
title: "How to: Raise and Consume Events"
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
  - "cpp"
helpviewer_keywords: 
  - "events [.NET Framework], raising"
  - "raising events"
  - "events [.NET Framework], samples"
ms.assetid: 42afade7-3a02-4f2e-868b-95845f302f8f
caps.latest.revision: 13
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# How to: Raise and Consume Events
The examples in this topic show how to work with events. They include examples of the <xref:System.EventHandler> delegate, the <xref:System.EventHandler%601> delegate, and a custom delegate, to illustrate events with and without data.  
  
 The examples use concepts described in the [Events](../../../docs/standard/events/index.md) article.  
  
## Example  
 The first example shows how to raise and consume an event that doesn't have data. It contains a class named `Counter` that has an event named `ThresholdReached`. This event is raised when a counter value equals or exceeds a threshold value. The <xref:System.EventHandler> delegate is associated with the event, because no event data is provided.  
  
 [!code-csharp[EventsOverview#5](../../../samples/snippets/csharp/VS_Snippets_CLR/eventsoverview/cs/programnodata.cs#5)]
 [!code-vb[EventsOverview#5](../../../samples/snippets/visualbasic/VS_Snippets_CLR/eventsoverview/vb/module1nodata.vb#5)]  
  
## Example  
 The next example shows how to raise and consume an event that provides data. The <xref:System.EventHandler%601> delegate is associated with the event, and an instance of a custom event data object is provided.  
  
 [!code-cpp[EventsOverview#6](../../../samples/snippets/cpp/VS_Snippets_CLR/eventsoverview/cpp/programwithdata.cpp#6)]
 [!code-csharp[EventsOverview#6](../../../samples/snippets/csharp/VS_Snippets_CLR/eventsoverview/cs/programwithdata.cs#6)]
 [!code-vb[EventsOverview#6](../../../samples/snippets/visualbasic/VS_Snippets_CLR/eventsoverview/vb/module1withdata.vb#6)]  
  
## Example  
 The next example shows how to declare a delegate for an event. The delegate is named `ThresholdReachedEventHandler`. This is just an illustration. Typically, you do not have to declare a delegate for an event, because you can use either the <xref:System.EventHandler> or the <xref:System.EventHandler%601> delegate. You should declare a delegate only in rare scenarios, such as making your class available to legacy code that cannot use generics.  
  
 [!code-csharp[EventsOverview#7](../../../samples/snippets/csharp/VS_Snippets_CLR/eventsoverview/cs/programwithdelegate.cs#7)]
 [!code-vb[EventsOverview#7](../../../samples/snippets/visualbasic/VS_Snippets_CLR/eventsoverview/vb/module1withdelegate.vb#7)]  
  
## See Also  
 [Events](../../../docs/standard/events/index.md)
