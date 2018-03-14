---
title: "Overview of Synchronization Primitives"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "synchronization, threads"
  - "threading [.NET Framework],synchronizing threads"
  - "managed threading"
ms.assetid: b782bcb8-da6a-4c6a-805f-2eb46d504309
caps.latest.revision: 17
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Overview of Synchronization Primitives
<a name="top"></a> The .NET Framework provides a range of synchronization primitives for controlling the interactions of threads and avoiding race conditions. These can be roughly divided into three categories: locking, signaling, and interlocked operations.  
  
 The categories are not tidy nor clearly defined: Some synchronization mechanisms have characteristics of multiple categories; events that release a single thread at a time are functionally like locks; the release of any lock can be thought of as a signal; and interlocked operations can be used to construct locks. However, the categories are still useful.  
  
 It is important to remember that thread synchronization is cooperative. If even one thread bypasses a synchronization mechanism and accesses the protected resource directly, that synchronization mechanism cannot be effective.  
  
 This overview contains the following sections:  
  
-   [Locking](#locking)  
  
-   [Signaling](#signaling)  
  
-   [Lightweight Synchronization Types](#lightweight_synchronization_types)  
  
-   [SpinWait](#spinwait)  
  
-   [Interlocked Operations](#interlocked_operations)  
  
<a name="locking"></a>   
## Locking  
 Locks give control of a resource to one thread at a time, or to a specified number of threads. A thread that requests an exclusive lock when the lock is in use blocks until the lock becomes available.  
  
### Exclusive Locks  
 The simplest form of locking is the `lock` statement in C# and the `SyncLock` statement in Visual Basic, which controls access to a block of code. Such a block is frequently referred to as a critical section. The `lock` statement is implemented by using the <xref:System.Threading.Monitor.Enter%2A?displayProperty=nameWithType> and <xref:System.Threading.Monitor.Exit%2A?displayProperty=nameWithType> methods, and it uses `try…catch…finally` block to ensure that the lock is released.  
  
 In general, using the `lock` or `SyncLock` statement to protect small blocks of code, never spanning more than a single method, is the best way to use the <xref:System.Threading.Monitor> class. Although powerful, the <xref:System.Threading.Monitor> class is prone to orphan locks and deadlocks.  
  
#### Monitor Class  
 The <xref:System.Threading.Monitor> class provides additional functionality, which can be used in conjunction with the `lock` statement:  
  
-   The <xref:System.Threading.Monitor.TryEnter%2A> method allows a thread that is blocked waiting for the resource to give up after a specified interval. It returns a Boolean value indicating success or failure, which can be used to detect and avoid potential deadlocks.  
  
-   The <xref:System.Threading.Monitor.Wait%2A> method is called by a thread in a critical section. It gives up control of the resource and blocks until the resource is available again.  
  
-   The <xref:System.Threading.Monitor.Pulse%2A> and <xref:System.Threading.Monitor.PulseAll%2A> methods allow a thread that is about to release the lock or to call <xref:System.Threading.Monitor.Wait%2A> to put one or more threads into the ready queue, so that they can acquire the lock.  
  
 Timeouts on <xref:System.Threading.Monitor.Wait%2A> method overloads allow waiting threads to escape to the ready queue.  
  
 The <xref:System.Threading.Monitor> class can provide locking in multiple application domains if the object used for the lock derives from <xref:System.MarshalByRefObject>.  
  
 <xref:System.Threading.Monitor> has thread affinity. That is, a thread that entered the monitor must exit by calling <xref:System.Threading.Monitor.Exit%2A> or <xref:System.Threading.Monitor.Wait%2A>.  
  
 The <xref:System.Threading.Monitor> class is not instantiable. Its methods are static (`Shared` in Visual Basic), and act on an instantiable lock object.  
  
 For a conceptual overview, see [Monitors](http://msdn.microsoft.com/library/33fe4aef-b44b-42fd-9e72-c908e39e75db).  
  
#### Mutex Class  
 Threads request a <xref:System.Threading.Mutex> by calling an overload of its <xref:System.Threading.WaitHandle.WaitOne%2A> method. Overloads with timeouts are provided, to allow threads to give up the wait. Unlike the <xref:System.Threading.Monitor> class, a mutex can be either local or global. Global mutexes, also called named mutexes, are visible throughout the operating system, and can be used to synchronize threads in multiple application domains or processes. Local mutexes derive from <xref:System.MarshalByRefObject>, and can be used across application domain boundaries.  
  
 In addition, <xref:System.Threading.Mutex> derives from <xref:System.Threading.WaitHandle>, which means that it can be used with the signaling mechanisms provided by <xref:System.Threading.WaitHandle>, such as the <xref:System.Threading.WaitHandle.WaitAll%2A>, <xref:System.Threading.WaitHandle.WaitAny%2A>, and <xref:System.Threading.WaitHandle.SignalAndWait%2A> methods.  
  
 Like <xref:System.Threading.Monitor>, <xref:System.Threading.Mutex> has thread affinity. Unlike <xref:System.Threading.Monitor>, a <xref:System.Threading.Mutex> is an instantiable object.  
  
 For a conceptual overview, see [Mutexes](../../../docs/standard/threading/mutexes.md).  
  
#### SpinLock Class  
 Starting with the [!INCLUDE[net_v40_long](../../../includes/net-v40-long-md.md)], you can use the <xref:System.Threading.SpinLock> class when the overhead required by <xref:System.Threading.Monitor> degrades performance. When <xref:System.Threading.SpinLock> encounters a locked critical section, it simply spins in a loop until the lock becomes available. If the lock is held for a very short time, spinning can provide better performance than blocking. However, if the lock is held for more than a few tens of cycles, <xref:System.Threading.SpinLock> performs just as well as <xref:System.Threading.Monitor>, but will use more CPU cycles and thus can degrade the performance of other threads or processes.  
  
### Other Locks  
 Locks need not be exclusive. It is often useful to allow a limited number of threads concurrent access to a resource. Semaphores and reader-writer locks are designed to control this kind of pooled resource access.  
  
#### ReaderWriterLock Class  
 The <xref:System.Threading.ReaderWriterLockSlim> class addresses the case where a thread that changes data, the writer, must have exclusive access to a resource. When the writer is not active, any number of readers can access the resource (for example, by calling the <xref:System.Threading.ReaderWriterLockSlim.EnterReadLock%2A> method). When a thread requests exclusive access, (for example, by calling the <xref:System.Threading.ReaderWriterLockSlim.EnterWriteLock%2A> method), subsequent reader requests block until all existing readers have exited the lock, and the writer has entered and exited the lock.  
  
 <xref:System.Threading.ReaderWriterLockSlim> has thread affinity.  
  
 For a conceptual overview, see [Reader-Writer Locks](../../../docs/standard/threading/reader-writer-locks.md).  
  
#### Semaphore Class  
 The <xref:System.Threading.Semaphore> class allows a specified number of threads to access a resource. Additional threads requesting the resource block until a thread releases the semaphore.  
  
 Like the <xref:System.Threading.Mutex> class, <xref:System.Threading.Semaphore> derives from <xref:System.Threading.WaitHandle>. Also like <xref:System.Threading.Mutex>, a <xref:System.Threading.Semaphore> can be either local or global. It can be used across application domain boundaries.  
  
 Unlike <xref:System.Threading.Monitor>, <xref:System.Threading.Mutex>, and <xref:System.Threading.ReaderWriterLock>, <xref:System.Threading.Semaphore> does not have thread affinity. This means it can be used in scenarios where one thread acquires the semaphore and another releases it.  
  
 For a conceptual overview, see [Semaphore and SemaphoreSlim](../../../docs/standard/threading/semaphore-and-semaphoreslim.md).  
  
 <xref:System.Threading.SemaphoreSlim?displayProperty=nameWithType> is a lightweight semaphore for synchronization within a single process boundary.  
  
 [Back to top](#top)  
  
<a name="signaling"></a>   
## Signaling  
 The simplest way to wait for a signal from another thread is to call the <xref:System.Threading.Thread.Join%2A> method, which blocks until the other thread completes. <xref:System.Threading.Thread.Join%2A> has two overloads that allow the blocked thread to break out of the wait after a specified interval has elapsed.  
  
 Wait handles provide a much richer set of waiting and signaling capabilities.  
  
### Wait Handles  
 Wait handles derive from the <xref:System.Threading.WaitHandle> class, which in turn derives from <xref:System.MarshalByRefObject>. Thus, wait handles can be used to synchronize the activities of threads across application domain boundaries.  
  
 Threads block on wait handles by calling the instance method <xref:System.Threading.WaitHandle.WaitOne%2A> or one of the static methods <xref:System.Threading.WaitHandle.WaitAll%2A>, <xref:System.Threading.WaitHandle.WaitAny%2A>, or <xref:System.Threading.WaitHandle.SignalAndWait%2A>. How they are released depends on which method was called, and on the kind of wait handles.  
  
 For a conceptual overview, see [Wait Handles](http://msdn.microsoft.com/library/48d10b6f-5fd7-407c-86ab-0179aef72489).  
  
#### Event Wait Handles  
 Event wait handles include the <xref:System.Threading.EventWaitHandle> class and its derived classes, <xref:System.Threading.AutoResetEvent> and <xref:System.Threading.ManualResetEvent>. Threads are released from an event wait handle when the event wait handle is signaled by calling its <xref:System.Threading.EventWaitHandle.Set%2A> method or by using the <xref:System.Threading.WaitHandle.SignalAndWait%2A> method.  
  
 Event wait handles either reset themselves automatically, like a turnstile that allows only one thread through each time it is signaled, or must be reset manually, like a gate that is closed until signaled and then open until someone closes it. As their names imply, <xref:System.Threading.AutoResetEvent> and <xref:System.Threading.ManualResetEvent> represent the former and latter, respectively. <xref:System.Threading.ManualResetEventSlim?displayProperty=nameWithType> is a lightweight event for synchronization within a single process boundary.  
  
 An <xref:System.Threading.EventWaitHandle> can represent either type of event, and can be either local or global. The derived classes <xref:System.Threading.AutoResetEvent> and <xref:System.Threading.ManualResetEvent> are always local.  
  
 Event wait handles do not have thread affinity. Any thread can signal an event wait handle.  
  
 For a conceptual overview, see [EventWaitHandle, AutoResetEvent, CountdownEvent, ManualResetEvent](../../../docs/standard/threading/eventwaithandle-autoresetevent-countdownevent-manualresetevent.md).  
  
#### Mutex and Semaphore Classes  
 Because the <xref:System.Threading.Mutex> and <xref:System.Threading.Semaphore> classes derive from <xref:System.Threading.WaitHandle>, they can be used with the static methods of <xref:System.Threading.WaitHandle>. For example, a thread can use the <xref:System.Threading.WaitHandle.WaitAll%2A> method to wait until all three of the following are true: an <xref:System.Threading.EventWaitHandle> is signaled, a <xref:System.Threading.Mutex> is released, and a <xref:System.Threading.Semaphore> is released. Similarly, a thread can use the <xref:System.Threading.WaitHandle.WaitAny%2A> method to wait until any one of those conditions is true.  
  
 For a <xref:System.Threading.Mutex> or a <xref:System.Threading.Semaphore>, being signaled means being released. If either type is used as the first argument of the <xref:System.Threading.WaitHandle.SignalAndWait%2A> method, it is released. In the case of a <xref:System.Threading.Mutex>, which has thread affinity, an exception is thrown if the calling thread does not own the mutex. As noted previously, semaphores do not have thread affinity.  
  
#### Barrier  
 The <xref:System.Threading.Barrier> class provides a way to cyclically synchronize multiple threads so that they all block at the same point and wait for all other threads to complete. A barrier is useful when one or more threads require the results of another thread before continuing to the next phase of an algorithm. For more information, see [Barrier](../../../docs/standard/threading/barrier.md).  
  
 [Back to top](#top)  
  
<a name="lightweight_synchronization_types"></a>   
## Lightweight Synchronization Types  
 Starting with the [!INCLUDE[net_v40_short](../../../includes/net-v40-short-md.md)], you can use synchronization primitives that provide fast performance by avoiding expensive reliance on Win32 kernel objects such as wait handles whenever possible. In general, you should use these types when wait times are short and only when the original synchronization types have been tried and found to be unsatisfactory. The lightweight types cannot be used in scenarios that require cross-process communication.  
  
-   <xref:System.Threading.SemaphoreSlim?displayProperty=nameWithType> is a lightweight version of <xref:System.Threading.Semaphore?displayProperty=nameWithType>.  
  
-   <xref:System.Threading.ManualResetEventSlim?displayProperty=nameWithType> is a lightweight version of <xref:System.Threading.ManualResetEvent?displayProperty=nameWithType>.  
  
-   <xref:System.Threading.CountdownEvent?displayProperty=nameWithType> represents an event that becomes signaled when its count is zero.  
  
-   <xref:System.Threading.Barrier?displayProperty=nameWithType> enables multiple threads to synchronize with one another without requiring control by a master thread. A barrier prevents each thread from continuing until all threads have reached a specified point.  
  
 [Back to top](#top)  
  
<a name="spinwait"></a>   
## SpinWait  
 Starting with the [!INCLUDE[net_v40_short](../../../includes/net-v40-short-md.md)], you can use the <xref:System.Threading.SpinWait?displayProperty=nameWithType> structure when a thread has to wait for an event to be signaled or a condition to be met, but when the actual wait time is expected to be less than the waiting time required by using a wait handle or by otherwise blocking the current thread. By using <xref:System.Threading.SpinWait>, you can specify a short period of time to spin while waiting, and then yield (for example, by waiting or sleeping) only if the condition was not met in the specified time.  
  
 [Back to top](#top)  
  
<a name="interlocked_operations"></a>   
## Interlocked Operations  
 Interlocked operations are simple atomic operations performed on a memory location by static methods of the <xref:System.Threading.Interlocked> class. Those atomic operations include addition, increment and decrement, exchange, conditional exchange depending on a comparison, and read operations for 64-bit values on 32-bit platforms.  
  
> [!NOTE]
>  The guarantee of atomicity is limited to individual operations; when multiple operations must be performed as a unit, a more coarse-grained synchronization mechanism must be used.  
  
 Although none of these operations are locks or signals, they can be used to construct locks and signals. Because they are native to the Windows operating system, interlocked operations are extremely fast.  
  
 Interlocked operations can be used with volatile memory guarantees to write applications that exhibit powerful non-blocking concurrency. However, they require sophisticated, low-level programming, so for most purposes, simple locks are a better choice.  
  
 For a conceptual overview, see [Interlocked Operations](../../../docs/standard/threading/interlocked-operations.md).  
  
## See Also  
 [Synchronizing Data for Multithreading](../../../docs/standard/threading/synchronizing-data-for-multithreading.md)  
 [Monitors](http://msdn.microsoft.com/library/33fe4aef-b44b-42fd-9e72-c908e39e75db)  
 [Mutexes](../../../docs/standard/threading/mutexes.md)  
 [Semaphore and SemaphoreSlim](../../../docs/standard/threading/semaphore-and-semaphoreslim.md)  
 [EventWaitHandle, AutoResetEvent, CountdownEvent, ManualResetEvent](../../../docs/standard/threading/eventwaithandle-autoresetevent-countdownevent-manualresetevent.md)  
 [Wait Handles](http://msdn.microsoft.com/library/48d10b6f-5fd7-407c-86ab-0179aef72489)  
 [Interlocked Operations](../../../docs/standard/threading/interlocked-operations.md)  
 [Reader-Writer Locks](../../../docs/standard/threading/reader-writer-locks.md)  
 [Barrier](../../../docs/standard/threading/barrier.md)  
 [SpinWait](../../../docs/standard/threading/spinwait.md)  
 [SpinLock](../../../docs/standard/threading/spinlock.md)
