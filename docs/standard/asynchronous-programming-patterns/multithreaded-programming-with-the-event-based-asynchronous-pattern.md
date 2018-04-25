---
title: "Multithreaded Programming with the Event-based Asynchronous Pattern"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "Event-based Asynchronous Pattern"
  - "ProgressChangedEventArgs class"
  - "BackgroundWorker component"
  - "events [.NET Framework], asynchronous"
  - "AsyncOperationManager class"
  - "threading [.NET Framework], asynchronous features"
  - "components [.NET Framework], asynchronous"
  - "AsyncOperation class"
  - "AsyncCompletedEventArgs class"
ms.assetid: 958d6617-5e70-4b36-b5db-63c16dc35e43
caps.latest.revision: 19
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Multithreaded Programming with the Event-based Asynchronous Pattern
There are a number of ways to expose asynchronous features to client code. The Event-based Asynchronous Pattern prescribes the recommended way for classes to present asynchronous behavior.  
  
## In This Section  
 [Event-based Asynchronous Pattern Overview](../../../docs/standard/asynchronous-programming-patterns/event-based-asynchronous-pattern-overview.md)  
 Describes how the Event-based Asynchronous Pattern makes available the advantages of multithreaded applications while hiding many of the complex issues inherent in multithreaded design.  
  
 [Implementing the Event-based Asynchronous Pattern](../../../docs/standard/asynchronous-programming-patterns/implementing-the-event-based-asynchronous-pattern.md)  
 Describes the standardized way to package a class that has asynchronous features.  
  
 [Best Practices for Implementing the Event-based Asynchronous Pattern](../../../docs/standard/asynchronous-programming-patterns/best-practices-for-implementing-the-event-based-asynchronous-pattern.md)  
 Describes the requirements for exposing asynchronous features according to the Event-based Asynchronous Pattern.  
  
 [Deciding When to Implement the Event-based Asynchronous Pattern](../../../docs/standard/asynchronous-programming-patterns/deciding-when-to-implement-the-event-based-asynchronous-pattern.md)  
 Describes how to determine when you should choose to implement the Event-based Asynchronous Pattern instead of the <xref:System.IAsyncResult> pattern.  
  
 [Walkthrough: Implementing a Component That Supports the Event-based Asynchronous Pattern](../../../docs/standard/asynchronous-programming-patterns/component-that-supports-the-event-based-asynchronous-pattern.md)  
 Illustrates how to create a component that implements the Event-based Asynchronous Pattern. It is implemented using helper classes from the <xref:System.ComponentModel?displayProperty=nameWithType> namespace, which ensures that the component works correctly under any application model.  
  
 [How to: Use Components That Support the Event-based Asynchronous Pattern](../../../docs/standard/asynchronous-programming-patterns/how-to-use-components-that-support-the-event-based-asynchronous-pattern.md)  
 Describes how to use a component that supports the Event-based Asynchronous Pattern.  
  
## Reference  
 <xref:System.ComponentModel.AsyncOperation>  
 Describes the <xref:System.ComponentModel.AsyncOperation> class and has links to all its members.  
  
 <xref:System.ComponentModel.AsyncOperationManager>  
 Describes the <xref:System.ComponentModel.AsyncOperationManager> class and has links to all its members.  
  
 <xref:System.ComponentModel.BackgroundWorker>  
 Describes the <xref:System.ComponentModel.BackgroundWorker> component and has links to all its members.  
  
## See Also  
 [Managed Threading Best Practices](../../../docs/standard/threading/managed-threading-best-practices.md)  
 [Events](../../../docs/standard/events/index.md)  
 [Multithreading in Components](https://msdn.microsoft.com/library/2fc31e68-fb71-4544-b654-0ce720478779)  
 [Event-based Asynchronous Pattern (EAP)](../../../docs/standard/asynchronous-programming-patterns/event-based-asynchronous-pattern-eap.md)
