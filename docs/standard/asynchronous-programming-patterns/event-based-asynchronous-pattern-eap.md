---
title: "Event-based Asynchronous Pattern (EAP)"
ms.date: "07/23/2018"
ms.technology: dotnet-standard
helpviewer_keywords: 
  - "asynchronous calls"
  - "asynchronous programming, design patterns"
  - "asynchronous programming"
ms.assetid: c6baed9f-2a25-4728-9a9a-53b7b14840cf
author: "rpetrusha"
ms.author: "ronpet"
---
# Event-based Asynchronous Pattern (EAP)

There are a number of ways to expose asynchronous features to client code. The Event-based Asynchronous Pattern prescribes one way for classes to present asynchronous behavior.  
  
> [!NOTE]
> Starting with the .NET Framework 4, the Task Parallel Library provides a new model for asynchronous and parallel programming. For more information, see [Task Parallel Library (TPL)](../parallel-programming/task-parallel-library-tpl.md) and [Task-based Asynchronous Pattern (TAP)](task-based-asynchronous-pattern-tap.md).
  
## In This Section

 [Event-based Asynchronous Pattern Overview](event-based-asynchronous-pattern-overview.md)  
 Describes how the Event-based Asynchronous Pattern makes available the advantages of multithreaded applications while hiding many of the complex issues inherent in multithreaded design.  
  
 [Implementing the Event-based Asynchronous Pattern](implementing-the-event-based-asynchronous-pattern.md)  
 Describes the standardized way to package a class that has asynchronous features.  
  
 [Best Practices for Implementing the Event-based Asynchronous Pattern](best-practices-for-implementing-the-event-based-asynchronous-pattern.md)  
 Describes the requirements for exposing asynchronous features according to the Event-based Asynchronous Pattern.  
  
 [Deciding When to Implement the Event-based Asynchronous Pattern](deciding-when-to-implement-the-event-based-asynchronous-pattern.md)  
 Describes how to determine when you should choose to implement the Event-based Asynchronous Pattern instead of the <xref:System.IAsyncResult> pattern represented by the [Asynchronous Programming Model (APM)](asynchronous-programming-model-apm.md)
  
 [How to: Implement a Component That Supports the Event-based Asynchronous Pattern](component-that-supports-the-event-based-asynchronous-pattern.md)  
 Describes how to create a component that implements the Event-based Asynchronous Pattern. It is implemented using helper classes from the <xref:System.ComponentModel?displayProperty=nameWithType> namespace, which ensures that the component works correctly under any application model.  

 [How to: Implement a Client of the Event-based Asynchronous Pattern](how-to-implement-a-client-of-the-event-based-asynchronous-pattern.md)  
 Describes how to create a client that uses a component that implements the Event-based Asynchronous Pattern.
  
 [How to: Use Components That Support the Event-based Asynchronous Pattern](how-to-use-components-that-support-the-event-based-asynchronous-pattern.md)  
 Describes how to use a component that supports the Event-based Asynchronous Pattern.  
  
## Reference

 <xref:System.ComponentModel.AsyncOperation>  
 Describes the <xref:System.ComponentModel.AsyncOperation> class and has links to all its members.  
  
 <xref:System.ComponentModel.AsyncOperationManager>  
 Describes the <xref:System.ComponentModel.AsyncOperationManager> class and has links to all its members.  
  
 <xref:System.ComponentModel.BackgroundWorker>  
 Describes the <xref:System.ComponentModel.BackgroundWorker> component and has links to all its members.  
  
## Related Sections

 [Task Parallel Library (TPL)](../parallel-programming/task-parallel-library-tpl.md)  
 Describes a programming model for asynchronous and parallel operations.  
  
 [Threading](../../../docs/standard/threading/index.md)  
 Describes multithreading features in .NET.  
  
## See also

 [Managed Threading Best Practices](../threading/managed-threading-best-practices.md)  
 [Events](../events/index.md)  
 [Asynchronous Programming Design Patterns](index.md)
