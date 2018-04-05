---
title: "Data Structures for Parallel Programming"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "data structures, multi-threading"
ms.assetid: bdc82f2f-4754-45a1-a81e-fe2e9c30cef9
caps.latest.revision: 15
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Data Structures for Parallel Programming
The .NET Framework version 4 introduces several new types that are useful in parallel programming, including a set of concurrent collection classes, lightweight synchronization primitives, and types for lazy initialization. You can use these types with any multithreaded application code, including the Task Parallel Library and PLINQ.  
  
## Concurrent Collection Classes  
 The collection classes in the <xref:System.Collections.Concurrent?displayProperty=nameWithType> namespace provide thread-safe add and remove operations that avoid locks wherever possible and use fine-grained locking where locks are necessary. Unlike collections that were introduced in the .NET Framework versions 1.0 and 2.0, a concurrent collection class does not require user code to take any locks when it accesses items. The concurrent collection classes can significantly improve performance over types such as <xref:System.Collections.ArrayList?displayProperty=nameWithType> and <xref:System.Collections.Generic.List%601?displayProperty=nameWithType> (with user-implemented locking) in scenarios where multiple threads add and remove items from a collection.  
  
 The following table lists the new concurrent collection classes:  
  
|Type|Description|  
|----------|-----------------|  
|<xref:System.Collections.Concurrent.BlockingCollection%601?displayProperty=nameWithType>|Provides blocking and bounding capabilities for thread-safe collections that implement <xref:System.Collections.Concurrent.IProducerConsumerCollection%601?displayProperty=nameWithType>. Producer threads block if no slots are available or if the collection is full. Consumer threads block if the collection is empty. This type also supports non-blocking access by consumers and producers. <xref:System.Collections.Concurrent.BlockingCollection%601> can be used as a base class or backing store to provide blocking and bounding for any collection class that supports <xref:System.Collections.Generic.IEnumerable%601>.|  
|<xref:System.Collections.Concurrent.ConcurrentBag%601?displayProperty=nameWithType>|A thread-safe bag implementation that provides scalable add and get operations.|  
|<xref:System.Collections.Concurrent.ConcurrentDictionary%602?displayProperty=nameWithType>|A concurrent and scalable dictionary type.|  
|<xref:System.Collections.Concurrent.ConcurrentQueue%601?displayProperty=nameWithType>|A concurrent and scalable FIFO queue.|  
|<xref:System.Collections.Concurrent.ConcurrentStack%601?displayProperty=nameWithType>|A concurrent and scalable LIFO stack.|  
  
 For more information, see [Thread-Safe Collections](../../../docs/standard/collections/thread-safe/index.md).  
  
## Synchronization Primitives  
 The new synchronization primitives in the <xref:System.Threading?displayProperty=nameWithType> namespace enable fine-grained concurrency and faster performance by avoiding expensive locking mechanisms found in legacy multithreading code. Some of the new types, such as <xref:System.Threading.Barrier?displayProperty=nameWithType> and <xref:System.Threading.CountdownEvent?displayProperty=nameWithType> have no counterparts in earlier releases of the .NET Framework.  
  
 The following table lists the new synchronization types:  
  
|Type|Description|  
|----------|-----------------|  
|<xref:System.Threading.Barrier?displayProperty=nameWithType>|Enables multiple threads to work on an algorithm in parallel by providing a point at which each task can signal its arrival and then block until some or all tasks have arrived. For more information, see [Barrier](../../../docs/standard/threading/barrier.md).|  
|<xref:System.Threading.CountdownEvent?displayProperty=nameWithType>|Simplifies fork and join scenarios by providing an easy rendezvous mechanism. For more information, see [CountdownEvent](../../../docs/standard/threading/countdownevent.md).|  
|<xref:System.Threading.ManualResetEventSlim?displayProperty=nameWithType>|A synchronization primitive similar to <xref:System.Threading.ManualResetEvent?displayProperty=nameWithType>. <xref:System.Threading.ManualResetEventSlim> is lighter-weight but can only be used for intra-process communication. For more information, see [ManualResetEvent and ManualResetEventSlim](../../../docs/standard/threading/manualresetevent-and-manualreseteventslim.md).|  
|<xref:System.Threading.SemaphoreSlim?displayProperty=nameWithType>|A synchronization primitive that limits the number of threads that can concurrently access a resource or a pool of resources. For more information, see [Semaphore and SemaphoreSlim](../../../docs/standard/threading/semaphore-and-semaphoreslim.md).|  
|<xref:System.Threading.SpinLock?displayProperty=nameWithType>|A mutual exclusion lock primitive that causes the thread that is trying to acquire the lock to wait in a loop, or *spin*, for a period of time before yielding its quantum. In scenarios where the wait for the lock is expected to be short, <xref:System.Threading.SpinLock> offers better performance than other forms of locking. For more information, see [SpinLock](../../../docs/standard/threading/spinlock.md).|  
|<xref:System.Threading.SpinWait?displayProperty=nameWithType>|A small, lightweight type that will spin for a specified time and eventually put the thread into a wait state if the spin count is exceeded.  For more information, see [SpinWait](../../../docs/standard/threading/spinwait.md).|  
  
 For more information, see:  
  
-   [How to: Use SpinLock for Low-Level Synchronization](../../../docs/standard/threading/how-to-use-spinlock-for-low-level-synchronization.md)  
  
-   [How to: Synchronize Concurrent Operations with a Barrier](../../../docs/standard/threading/how-to-synchronize-concurrent-operations-with-a-barrier.md).  
  
## Lazy Initialization Classes  
 With lazy initialization, the memory for an object is not allocated until it is needed. Lazy initialization can improve performance by spreading object allocations evenly across the lifetime of a program. You can enable lazy initialization for any custom type by wrapping the type <xref:System.Lazy%601>.  
  
 The following table lists the lazy initialization types:  
  
|Type|Description|  
|----------|-----------------|  
|<xref:System.Lazy%601?displayProperty=nameWithType>|Provides lightweight, thread-safe lazy-initialization.|  
|<xref:System.Threading.ThreadLocal%601?displayProperty=nameWithType>|Provides a lazily-initialized value on a per-thread basis, with each thread lazily-invoking the initialization function.|  
|<xref:System.Threading.LazyInitializer?displayProperty=nameWithType>|Provides static methods that avoid the need to allocate a dedicated, lazy-initialization instance. Instead, they use references to ensure targets have been initialized as they are accessed.|  
  
 For more information, see [Lazy Initialization](../../../docs/framework/performance/lazy-initialization.md).  
  
## Aggregate Exceptions  
 The <xref:System.AggregateException?displayProperty=nameWithType> type can be used to capture multiple exceptions that are thrown concurrently on separate threads, and return them to the joining thread as a single exception. The <xref:System.Threading.Tasks.Task?displayProperty=nameWithType> and <xref:System.Threading.Tasks.Parallel?displayProperty=nameWithType> types and PLINQ use <xref:System.AggregateException> extensively for this purpose. For more information, see [NIB: How to: Handle Exceptions Thrown by Tasks](https://msdn.microsoft.com/library/d6c47ec8-9de9-4880-beb3-ff19ae51565d) and [How to: Handle Exceptions in a PLINQ Query](../../../docs/standard/parallel-programming/how-to-handle-exceptions-in-a-plinq-query.md).  
  
## See Also  
 <xref:System.Collections.Concurrent?displayProperty=nameWithType>  
 <xref:System.Threading?displayProperty=nameWithType>  
 [Parallel Programming](../../../docs/standard/parallel-programming/index.md)
