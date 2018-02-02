---
title: "When to Use a Thread-Safe Collection"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "thread-safe collections, when to upgrade"
ms.assetid: a9babe97-e457-4ff3-b528-a1bc940d5320
caps.latest.revision: 9
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# When to Use a Thread-Safe Collection
The [!INCLUDE[net_v40_long](../../../../includes/net-v40-long-md.md)] introduces five new collection types that are specially designed to support multi-threaded add and remove operations. To achieve thread-safety, these new types use various kinds of efficient locking and lock-free synchronization mechanisms. Synchronization adds overhead to an operation. The amount of overhead depends on the kind of synchronization that is used, the kind of operations that are performed, and other factors such as the number of threads that are trying to concurrently access the collection.  
  
 In some scenarios, synchronization overhead is negligible and enables the multi-threaded type to perform significantly faster and scale far better than its non-thread-safe equivalent when protected by an external lock. In other scenarios, the overhead can cause the thread-safe type to perform and scale about the same or even more slowly than the externally-locked, non-thread-safe version of the type.  
  
 The following sections provide general guidance about when to use a thread-safe collection versus its non-thread-safe equivalent that has a user-provided lock around its read and write operations. Because performance may vary depending on many factors, the guidance is not specific and is not necessarily valid in all circumstances. If performance is very important, then the best way to determine which collection type to use is to measure performance based on representative computer configurations and loads. This document uses the following terms:  
  
 *Pure producer-consumer scenario*  
 Any given thread is either adding or removing elements, but not both.  
  
 *Mixed producer-consumer scenario*  
 Any given thread is both adding and removing elements.  
  
 *Speedup*  
 Faster algorithmic performance relative to another type in the same scenario.  
  
 *Scalability*  
 The increase in performance that is proportional to the number of cores on the computer. An algorithm that scales performs faster on eight cores than it does on two cores.  
  
## ConcurrentQueue(T) vs. Queue(T)  
 In pure producer-consumer scenarios, where the processing time for each element is very small (a few instructions), then <xref:System.Collections.Concurrent.ConcurrentQueue%601?displayProperty=nameWithType> can offer modest performance benefits over a <xref:System.Collections.Generic.Queue%601?displayProperty=nameWithType> that has an external lock. In this scenario, <xref:System.Collections.Concurrent.ConcurrentQueue%601> performs best when one dedicated thread is queuing and one dedicated thread is de-queuing. If you do not enforce this rule, then <xref:System.Collections.Generic.Queue%601> might even perform slightly faster than <xref:System.Collections.Concurrent.ConcurrentQueue%601> on computers that have multiple cores.  
  
 When processing time is around 500 FLOPS (floating point operations) or more, then the two-thread rule does not apply to <xref:System.Collections.Concurrent.ConcurrentQueue%601>, which then has very good scalability. <xref:System.Collections.Generic.Queue%601> does not scale well in this scenario.  
  
 In mixed producer-consumer scenarios, when the processing time is very small, a <xref:System.Collections.Generic.Queue%601> that has an external lock scales better than <xref:System.Collections.Concurrent.ConcurrentQueue%601> does. However, when processing time is around 500 FLOPS or more, then the <xref:System.Collections.Concurrent.ConcurrentQueue%601> scales better.  
  
## ConcurrentStack vs. Stack  
 In pure producer-consumer scenarios, when processing time is very small, then <xref:System.Collections.Concurrent.ConcurrentStack%601?displayProperty=nameWithType> and <xref:System.Collections.Generic.Stack%601?displayProperty=nameWithType> that has an external lock will probably perform about the same with one dedicated pushing thread and one dedicated popping thread. However, as the number of threads increases, both types slow down because of increased contention, and <xref:System.Collections.Generic.Stack%601> might perform better than <xref:System.Collections.Concurrent.ConcurrentStack%601>. When processing time is around 500 FLOPS or more, then both types scale at about the same rate.  
  
 In mixed producer-consumer scenarios, <xref:System.Collections.Concurrent.ConcurrentStack%601> is faster for both small and large workloads.  
  
 The use of the <xref:System.Collections.Concurrent.ConcurrentStack%601.PushRange%2A> and <xref:System.Collections.Concurrent.ConcurrentStack%601.TryPopRange%2A> may greatly speed up access times.  
  
## ConcurrentDictionary vs. Dictionary  
 In general, use a <xref:System.Collections.Concurrent.ConcurrentDictionary%602?displayProperty=nameWithType> in any scenario where you are adding and updating keys or values concurrently from multiple threads. In scenarios that involve frequent updates and relatively few reads, the <xref:System.Collections.Concurrent.ConcurrentDictionary%602> generally offers modest benefits. In scenarios that involve many reads and many updates, the <xref:System.Collections.Concurrent.ConcurrentDictionary%602> generally is significantly faster on computers that have any number of cores.  
  
 In scenarios that involve frequent updates, you can increase the degree of concurrency in the <xref:System.Collections.Concurrent.ConcurrentDictionary%602> and then measure to see whether performance increases on computers that have more cores. If you change the concurrency level, avoid global operations as much as possible.  
  
 If you are only reading key or values, the <xref:System.Collections.Generic.Dictionary%602> is faster because no synchronization is required if the dictionary is not being modified by any threads.  
  
## ConcurrentBag  
 In pure producer-consumer scenarios, <xref:System.Collections.Concurrent.ConcurrentBag%601?displayProperty=nameWithType> will probably perform more slowly than the other concurrent collection types.  
  
 In mixed producer-consumer scenarios, <xref:System.Collections.Concurrent.ConcurrentBag%601> is generally much faster and more scalable than any other concurrent collection type for both large and small workloads.  
  
## BlockingCollection  
 When bounding and blocking semantics are required, <xref:System.Collections.Concurrent.BlockingCollection%601?displayProperty=nameWithType> will probably perform faster than any custom implementation. It also supports rich cancellation, enumeration, and exception handling.  
  
## See Also  
 <xref:System.Collections.Concurrent?displayProperty=nameWithType>  
 [Thread-Safe Collections](../../../../docs/standard/collections/thread-safe/index.md)  
 [Parallel Programming](../../../../docs/standard/parallel-programming/index.md)
