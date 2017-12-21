---
title: "Managed Threading Basics"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "multiple threads"
  - "threading [.NET Framework], multiple threads"
  - "threading [.NET Framework], about threading"
  - "managed threading"
ms.assetid: b2944911-0e8f-427d-a8bb-077550618935
caps.latest.revision: 16
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Managed Threading Basics
The first five topics of this section are designed to help you determine when to use managed threading, and to explain some basic features. For information on classes that provide additional features, see [Threading Objects and Features](../../../docs/standard/threading/threading-objects-and-features.md) and [Overview of Synchronization Primitives](../../../docs/standard/threading/overview-of-synchronization-primitives.md).  
  
 The rest of the topics in this section cover advanced topics, including the interaction of managed threading with the Windows operating system.  
  
> [!NOTE]
>  In the [!INCLUDE[net_v40_long](../../../includes/net-v40-long-md.md)], the Task Parallel Library and PLINQ provide APIs for task and data parallelism in multi-threaded programs. For more information, see [Parallel Programming](../../../docs/standard/parallel-programming/index.md).  
  
## In This Section  
 [Threads and Threading](../../../docs/standard/threading/threads-and-threading.md)  
 Discusses the advantages and drawbacks of multiple threads, and outlines the scenarios in which you might create threads or use thread pool threads.  
  
 [Exceptions in Managed Threads](../../../docs/standard/threading/exceptions-in-managed-threads.md)  
 Describes the behavior of unhandled exceptions in threads for different versions of the .NET Framework, in particular the situations in which they result in termination of the application.  
  
 [Synchronizing Data for Multithreading](../../../docs/standard/threading/synchronizing-data-for-multithreading.md)  
 Describes strategies for synchronizing data in classes that will be used with multiple threads.  
  
 [Managed Thread States](../../../docs/standard/threading/managed-thread-states.md)  
 Describes the basic thread states, and explains how to detect whether a thread is running.  
  
 [Foreground and Background Threads](../../../docs/standard/threading/foreground-and-background-threads.md)  
 Explains the differences between foreground and background threads.  
  
 [Managed and Unmanaged Threading in Windows](../../../docs/standard/threading/managed-and-unmanaged-threading-in-windows.md)  
 Discusses the relationship between managed and unmanaged threading, lists managed equivalents for Windows threading APIs, and discusses the interaction of COM apartments and managed threads.  
  
 [Thread.Suspend, Garbage Collection, and Safe Points](../../../docs/standard/threading/thread-suspend-garbage-collection-and-safe-points.md)  
 Describes thread suspension and garbage collection.  
  
 [Thread Local Storage: Thread-Relative Static Fields and Data Slots](../../../docs/standard/threading/thread-local-storage-thread-relative-static-fields-and-data-slots.md)  
 Describes thread-relative storage mechanisms.  
  
 [Cancellation in Managed Threads](../../../docs/standard/threading/cancellation-in-managed-threads.md)  
 Describes how asynchronous or long-running synchronous operations can be canceled by using a cancellation token.  
  
## Reference  
 <xref:System.Threading.Thread>  
 Provides reference documentation for the **Thread** class, which represents a managed thread, whether it came from unmanaged code or was created in a managed application.  
  
 <xref:System.ComponentModel.BackgroundWorker>  
 Provides a safe way to implement multithreading in conjunction with user-interface objects.  
  
## Related Sections  
 [Overview of Synchronization Primitives](../../../docs/standard/threading/overview-of-synchronization-primitives.md)  
 Describes the managed classes used to synchronize the activities of multiple threads.  
  
 [Managed Threading Best Practices](../../../docs/standard/threading/managed-threading-best-practices.md)  
 Describes common problems with multithreading and strategies for avoiding problems.  
  
 [Parallel Programming](../../../docs/standard/parallel-programming/index.md)  
 Describes the Task Parallel Library and PLINQ, which greatly simplify the work of creating asynchronous and multi-threaded .NET Framework applications.
