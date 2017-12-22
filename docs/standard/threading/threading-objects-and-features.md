---
title: "Threading Objects and Features"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "threading [.NET Framework], features"
  - "managed threading"
ms.assetid: 239b2e8d-581b-4ca3-992b-0e8525b9321c
caps.latest.revision: 15
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Threading Objects and Features
The .NET Framework provides a number of objects that help you create and manage multithreaded applications. Managed threads are represented by the <xref:System.Threading.Thread> class. The <xref:System.Threading.ThreadPool> class provides easy creation and management of multithreaded background tasks. The <xref:System.ComponentModel.BackgroundWorker> class does the same for tasks that interact with the user interface. The <xref:System.Threading.Timer> class executes background tasks at timed intervals.  
  
 In addition, there are a number of classes that synchronize activities of threads, including the <xref:System.Threading.Semaphore> and <xref:System.Threading.EventWaitHandle> classes introduced in the .NET Framework version 2.0. The features of these classes are compared in [Overview of Synchronization Primitives](../../../docs/standard/threading/overview-of-synchronization-primitives.md).  
  
## In This Section  
 [The Managed Thread Pool](../../../docs/standard/threading/the-managed-thread-pool.md)  
 Explains the **ThreadPool** class, which enables you to request a thread to execute a task without having to do any thread management yourself.  
  
 [Timers](../../../docs/standard/threading/timers.md)  
 Explains how to use a **Timer** to specify a delegate to be called at a specified time.  
  
 [Monitors](http://msdn.microsoft.com/library/33fe4aef-b44b-42fd-9e72-c908e39e75db)  
 Explains how to use the **Monitor** class to synchronize access to a member or to build your own thread management types.  
  
 [Wait Handles](http://msdn.microsoft.com/library/48d10b6f-5fd7-407c-86ab-0179aef72489)  
 Describes the <xref:System.Threading.WaitHandle> class, the abstract base class for event wait handles, mutexes, and semaphores, which enables waiting for multiple synchronization events.  
  
 [EventWaitHandle, AutoResetEvent, CountdownEvent, ManualResetEvent](../../../docs/standard/threading/eventwaithandle-autoresetevent-countdownevent-manualresetevent.md)  
 Describes managed event wait handles, which are used to synchronize thread activities by signaling and waiting for signals.  
  
 [Mutexes](../../../docs/standard/threading/mutexes.md)  
 Explains how to use a <xref:System.Threading.Mutex> to synchronize access to an object or to build your own synchronization mechanisms.  
  
 [Interlocked Operations](../../../docs/standard/threading/interlocked-operations.md)  
 Explains how to use the <xref:System.Threading.Interlocked> class to increment or decrement a value and store the value in a single atomic operation.  
  
 [Reader-Writer Locks](../../../docs/standard/threading/reader-writer-locks.md)  
 Defines a lock that implements single-writer/multiple-reader semantics.  
  
 [Semaphore and SemaphoreSlim](../../../docs/standard/threading/semaphore-and-semaphoreslim.md)  
 Describes <xref:System.Threading.Semaphore> objects and explains how to use them to control access to limited resources.  
  
 [Overview of Synchronization Primitives](../../../docs/standard/threading/overview-of-synchronization-primitives.md)  
 Compares the features of the .NET Framework classes provided for locking and synchronizing managed threads.  
  
 [Barrier](../../../docs/standard/threading/barrier.md)  
 Describes <xref:System.Threading.Barrier> objects that implement the barrier pattern for coordination of threads in phased operations.  
  
 [SpinLock](../../../docs/standard/threading/spinlock.md)  
 Describes <xref:System.Threading.SpinLock>, a lightweight alternative to the Monitor class for certain low-level scenarios.  
  
 [SpinWait](../../../docs/standard/threading/spinwait.md)  
 Describes <xref:System.Threading.SpinWait>, a low level synchronization primitive that performs busy spinning prior to initiating a kernel-based wait.  
  
## Reference  
 <xref:System.Threading.Thread>  
 Provides reference documentation for the **Thread** class, which represents a managed thread, whether it came from unmanaged code or was created in a managed application.  
  
 <xref:System.ComponentModel.BackgroundWorker>  
 Enables background tasks that interact with the user interface, communicating via events raised on the user-interface thread.  
  
## Related Sections  
 [Asynchronous File I/O](../../../docs/standard/io/asynchronous-file-i-o.md)  
 Describes how I/O asynchronous completion ports use the thread pool to require processing only when an input/output operation completes.  
  
 [Task Parallel Library (TPL)](../../../docs/standard/parallel-programming/task-parallel-library-tpl.md)  
 Describes the recommended approach for multithreaded programming in the [!INCLUDE[net_v40_long](../../../includes/net-v40-long-md.md)] and later.
