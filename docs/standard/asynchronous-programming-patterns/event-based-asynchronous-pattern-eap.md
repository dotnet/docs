---
title: "Event-based Asynchronous Pattern (EAP)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "asynchronous calls"
  - "asynchronous programming, design patterns"
  - "asynchronous programming"
ms.assetid: c6baed9f-2a25-4728-9a9a-53b7b14840cf
caps.latest.revision: 20
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Event-based Asynchronous Pattern (EAP)
There are a number of ways to expose asynchronous features to client code. The Event-based Asynchronous Pattern prescribes one way for classes to present asynchronous behavior.  
  
> [!NOTE]
>  Starting with the [!INCLUDE[net_v40_long](../../../includes/net-v40-long-md.md)], the Task Parallel Library provides a new model for asynchronous and parallel programming. For more information, see [Parallel Programming](../../../docs/standard/parallel-programming/index.md).  
  
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
  
## Related Sections  
 [Task Parallel Library (TPL)](../../../docs/standard/parallel-programming/task-parallel-library-tpl.md)  
 Describes a programming model for asynchronous and parallel operations.  
  
 [Threading](../../../docs/standard/threading/index.md)  
 Describes multithreading features in the .NET Framework.  
  
 [Threading](https://msdn.microsoft.com/library/552f6c68-dbdb-4327-ae36-32cf9063d88c)  
 Describes multithreading features in the C# and Visual Basic languages.  
  
## See Also  
 [Managed Threading Best Practices](../../../docs/standard/threading/managed-threading-best-practices.md)  
 [Events](../../../docs/standard/events/index.md)  
 [Multithreading in Components](https://msdn.microsoft.com/library/2fc31e68-fb71-4544-b654-0ce720478779)  
 [Asynchronous Programming Design Patterns](../../../docs/standard/asynchronous-programming-patterns/event-based-asynchronous-pattern-eap.md)
