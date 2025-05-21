---
description: "Learn more about: Data Structures for Parallel Programming"
title: "Data Structures for Parallel Programming"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "data structures, multi-threading"
ms.assetid: bdc82f2f-4754-45a1-a81e-fe2e9c30cef9
ms.topic: article
---
# Data Structures for Parallel Programming

.NET provides several types that are useful in parallel programming, including a set of concurrent collection classes, lightweight synchronization primitives, and types for lazy initialization. You can use these types with any multithreaded application code, including the Task Parallel Library and PLINQ.  
  
## Concurrent Collection Classes  

 The collection classes in the <xref:System.Collections.Concurrent?displayProperty=nameWithType> namespace provide thread-safe add and remove operations that avoid locks wherever possible and use fine-grained locking where locks are necessary. A concurrent collection class does not require user code to take any locks when it accesses items. The concurrent collection classes can significantly improve performance over types such as <xref:System.Collections.ArrayList?displayProperty=nameWithType> and <xref:System.Collections.Generic.List%601?displayProperty=nameWithType> (with user-implemented locking) in scenarios where multiple threads add and remove items from a collection.  
  
 The following table lists the concurrent collection classes:  
  
|Type|Description|  
|----------|-----------------|  
|<xref:System.Collections.Concurrent.BlockingCollection%601?displayProperty=nameWithType>|Provides blocking and bounding capabilities for thread-safe collections that implement <xref:System.Collections.Concurrent.IProducerConsumerCollection%601?displayProperty=nameWithType>. Producer threads block if no slots are available or if the collection is full. Consumer threads block if the collection is empty. This type also supports non-blocking access by consumers and producers. <xref:System.Collections.Concurrent.BlockingCollection%601> can be used as a base class or backing store to provide blocking and bounding for any collection class that supports <xref:System.Collections.Generic.IEnumerable%601>.|  
|<xref:System.Collections.Concurrent.ConcurrentBag%601?displayProperty=nameWithType>|A thread-safe bag implementation that provides scalable add and get operations.|  
|<xref:System.Collections.Concurrent.ConcurrentDictionary%602?displayProperty=nameWithType>|A concurrent and scalable dictionary type.|  
|<xref:System.Collections.Concurrent.ConcurrentQueue%601?displayProperty=nameWithType>|A concurrent and scalable FIFO queue.|  
|<xref:System.Collections.Concurrent.ConcurrentStack%601?displayProperty=nameWithType>|A concurrent and scalable LIFO stack.|  
  
 For more information, see [Thread-Safe Collections](../collections/thread-safe/index.md).  
  
## Synchronization Primitives  

 The synchronization primitives in the <xref:System.Threading?displayProperty=nameWithType> namespace enable fine-grained concurrency and faster performance by avoiding expensive locking mechanisms found in legacy multithreading code.
  
 The following table lists the synchronization types:  
  
|Type|Description|  
|----------|-----------------|  
|<xref:System.Threading.Barrier?displayProperty=nameWithType>|Enables multiple threads to work on an algorithm in parallel by providing a point at which each task can signal its arrival and then block until some or all tasks have arrived. For more information, see [Barrier](../threading/barrier.md).|  
|<xref:System.Threading.CountdownEvent?displayProperty=nameWithType>|Simplifies fork and join scenarios by providing an easy rendezvous mechanism. For more information, see [CountdownEvent](../threading/countdownevent.md).|  
|<xref:System.Threading.ManualResetEventSlim?displayProperty=nameWithType>|A synchronization primitive similar to <xref:System.Threading.ManualResetEvent?displayProperty=nameWithType>. <xref:System.Threading.ManualResetEventSlim> is lighter-weight but can only be used for intra-process communication.|  
|<xref:System.Threading.SemaphoreSlim?displayProperty=nameWithType>|A synchronization primitive that limits the number of threads that can concurrently access a resource or a pool of resources. For more information, see [Semaphore and SemaphoreSlim](../threading/semaphore-and-semaphoreslim.md).|  
|<xref:System.Threading.SpinLock?displayProperty=nameWithType>|A mutual exclusion lock primitive that causes the thread that is trying to acquire the lock to wait in a loop, or *spin*, for a period of time before yielding its quantum. In scenarios where the wait for the lock is expected to be short, <xref:System.Threading.SpinLock> offers better performance than other forms of locking. For more information, see [SpinLock](../threading/spinlock.md).|  
|<xref:System.Threading.SpinWait?displayProperty=nameWithType>|A small, lightweight type that will spin for a specified time and eventually put the thread into a wait state if the spin count is exceeded.  For more information, see [SpinWait](../threading/spinwait.md).|  
  
 For more information, see:  
  
- [How to: Use SpinLock for Low-Level Synchronization](../threading/how-to-use-spinlock-for-low-level-synchronization.md)  
  
- [How to: Synchronize Concurrent Operations with a Barrier](../threading/how-to-synchronize-concurrent-operations-with-a-barrier.md).  
  
## Lazy Initialization Classes  

 With lazy initialization, the memory for an object is not allocated until it is needed. Lazy initialization can improve performance by spreading object allocations evenly across the lifetime of a program. You can enable lazy initialization for any custom type by wrapping the type <xref:System.Lazy%601>.  
  
 The following table lists the lazy initialization types:  
  
|Type|Description|  
|----------|-----------------|  
|<xref:System.Lazy%601?displayProperty=nameWithType>|Provides lightweight, thread-safe lazy-initialization.|  
|<xref:System.Threading.ThreadLocal%601?displayProperty=nameWithType>|Provides a lazily-initialized value on a per-thread basis, with each thread lazily-invoking the initialization function.|  
|<xref:System.Threading.LazyInitializer?displayProperty=nameWithType>|Provides static methods that avoid the need to allocate a dedicated, lazy-initialization instance. Instead, they use references to ensure targets have been initialized as they are accessed.|  
  
 For more information, see [Lazy Initialization](../../framework/performance/lazy-initialization.md).  
  
## Aggregate Exceptions  

 The <xref:System.AggregateException?displayProperty=nameWithType> type can be used to capture multiple exceptions that are thrown concurrently on separate threads, and return them to the joining thread as a single exception. The <xref:System.Threading.Tasks.Task?displayProperty=nameWithType> and <xref:System.Threading.Tasks.Parallel?displayProperty=nameWithType> types and PLINQ use <xref:System.AggregateException> extensively for this purpose. For more information, see [Exception Handling](exception-handling-task-parallel-library.md) and [How to: Handle Exceptions in a PLINQ Query](how-to-handle-exceptions-in-a-plinq-query.md).  
  
## See also

- <xref:System.Collections.Concurrent?displayProperty=nameWithType>
- <xref:System.Threading?displayProperty=nameWithType>
- [Parallel Programming](index.md)
