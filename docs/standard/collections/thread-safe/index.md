---
title: "Thread-Safe Collections"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "thread-safe collections, overview"
ms.assetid: 2e7ca21f-786c-4367-96be-0cf3f3dcc6bd
caps.latest.revision: 24
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Thread-Safe Collections
The [!INCLUDE[net_v40_short](../../../../includes/net-v40-short-md.md)] introduces the <xref:System.Collections.Concurrent?displayProperty=nameWithType> namespace, which includes several collection classes that are both thread-safe and scalable. Multiple threads can safely and efficiently add or remove items from these collections, without requiring additional synchronization in user code. When you write new code, use the concurrent collection classes whenever the collection will be writing to multiple threads concurrently. If you are only reading from a shared collection, then you can use the classes in the <xref:System.Collections.Generic?displayProperty=nameWithType> namespace. We recommend that you do not use 1.0 collection classes unless you are required to target the .NET Framework 1.1 or earlier runtime.  
  
## Thread Synchronization in the .NET Framework 1.0 and 2.0 Collections  
 The collections introduced in the .NET Framework 1.0 are found in the <xref:System.Collections?displayProperty=nameWithType> namespace. These collections, which include the commonly used <xref:System.Collections.ArrayList> and <xref:System.Collections.Hashtable>, provide some thread-safety through the `Synchronized` property, which returns a thread-safe wrapper around the collection. The wrapper works by locking the entire collection on every add or remove operation. Therefore, each thread that is attempting to access the collection must wait for its turn to take the one lock. This is not scalable and can cause significant performance degradation for large collections. Also, the design is not completely protected from race conditions. For more information, see [Synchronization in Generic Collections](http://go.microsoft.com/fwlink/?LinkID=161130) on the MSDN Web site.  
  
 The collection classes introduced in the .NET Framework 2.0 are found in the <xref:System.Collections.Generic?displayProperty=nameWithType> namespace. These include <xref:System.Collections.Generic.List%601>, <xref:System.Collections.Generic.Dictionary%602>, and so on. These classes provide improved type safety and performance compared to the .NET Framework 1.0 classes. However, the .NET Framework 2.0 collection classes do not provide any thread synchronization; user code must provide all synchronization when items are added or removed on multiple threads concurrently.  
  
 We recommend the concurrent collections classes in the [!INCLUDE[net_v40_short](../../../../includes/net-v40-short-md.md)] because they provide not only the type safety of the .NET Framework 2.0 collection classes, but also more efficient and more complete thread safety than the [!INCLUDE[net_v10_short](../../../../includes/net-v10-short-md.md)] collections provide.  
  
## Fine-Grained Locking and Lock-Free Mechanisms  
 Some of the concurrent collection types use lightweight synchronization mechanisms such as <xref:System.Threading.SpinLock>, <xref:System.Threading.SpinWait>, <xref:System.Threading.SemaphoreSlim>, and <xref:System.Threading.CountdownEvent>, which are new in the [!INCLUDE[net_v40_short](../../../../includes/net-v40-short-md.md)]. These synchronization types typically use *busy spinning* for brief periods before they put the thread into a true Wait state. When wait times are expected to be very short, spinning is far less computationally expensive than waiting, which involves an expensive kernel transition. For collection classes that use spinning, this efficiency means that multiple threads can add and remove items at a very high rate. For more information about spinning vs. blocking, see [SpinLock](../../../../docs/standard/threading/spinlock.md) and [SpinWait](../../../../docs/standard/threading/spinwait.md).  
  
 The <xref:System.Collections.Concurrent.ConcurrentQueue%601> and <xref:System.Collections.Concurrent.ConcurrentStack%601> classes do not use locks at all. Instead, they rely on <xref:System.Threading.Interlocked> operations to achieve thread-safety.  
  
> [!NOTE]
>  Because the concurrent collections classes support <xref:System.Collections.ICollection>, they provide implementations for the <xref:System.Collections.ICollection.IsSynchronized%2A> and <xref:System.Collections.ICollection.SyncRoot%2A> properties, even though these properties are irrelevant. `IsSynchronized` always returns `false` and `SyncRoot` is always `null` (`Nothing` in Visual Basic).  
  
 The following table lists the collection types in the <xref:System.Collections.Concurrent?displayProperty=nameWithType> namespace.  
  
|Type|Description|  
|----------|-----------------|  
|<xref:System.Collections.Concurrent.BlockingCollection%601>|Provides bounding and blocking functionality for any type that implements <xref:System.Collections.Concurrent.IProducerConsumerCollection%601>. For more information, see [BlockingCollection Overview](../../../../docs/standard/collections/thread-safe/blockingcollection-overview.md).|  
|<xref:System.Collections.Concurrent.ConcurrentDictionary%602>|Thread-safe implementation of a dictionary of key-value pairs.|  
|<xref:System.Collections.Concurrent.ConcurrentQueue%601>|Thread-safe implementation of a FIFO (first-in, first-out) queue.|  
|<xref:System.Collections.Concurrent.ConcurrentStack%601>|Thread-safe implementation of a LIFO (last-in, first-out) stack.|  
|<xref:System.Collections.Concurrent.ConcurrentBag%601>|Thread-safe implementation of an unordered collection of elements.|  
|<xref:System.Collections.Concurrent.IProducerConsumerCollection%601>|The interface that a type must implement to be used in a `BlockingCollection`.|  
  
## Related Topics  
  
|Title|Description|  
|-----------|-----------------|  
|[BlockingCollection Overview](../../../../docs/standard/collections/thread-safe/blockingcollection-overview.md)|Describes the functionality provided by the <xref:System.Collections.Concurrent.BlockingCollection%601> type.|  
|[How to: Add and Remove Items from a ConcurrentDictionary](../../../../docs/standard/collections/thread-safe/how-to-add-and-remove-items.md)|Describes how to add and remove elements from a <xref:System.Collections.Concurrent.ConcurrentDictionary%602>|  
|[How to: Add and Take Items Individually from a BlockingCollection](../../../../docs/standard/collections/thread-safe/how-to-add-and-take-items.md)|Describes how to add and retrieve items from a blocking collection without using the read-only enumerator.|  
|[How to: Add Bounding and Blocking Functionality to a Collection](../../../../docs/standard/collections/thread-safe/how-to-add-bounding-and-blocking.md)|Describes how to use any collection class as the underlying storage mechanism for an <xref:System.Collections.Concurrent.IProducerConsumerCollection%601> collection.|  
|[How to: Use ForEach to Remove Items in a BlockingCollection](../../../../docs/standard/collections/thread-safe/how-to-use-foreach-to-remove.md)|Describes how to use `foreach`, (`For Each` in Visual Basic) to remove all items in a blocking collection.|  
|[How to: Use Arrays of Blocking Collections in a Pipeline](../../../../docs/standard/collections/thread-safe/how-to-use-arrays-of-blockingcollections.md)|Describes how to use multiple blocking collections at the same time to implement a pipeline.|  
|[How to: Create an Object Pool by Using a ConcurrentBag](../../../../docs/standard/collections/thread-safe/how-to-create-an-object-pool.md)|Shows how to use a concurrent bag to improve performance in scenarios where you can reuse objects instead of continually creating new ones.|  
  
## Reference  
 <xref:System.Collections.Concurrent?displayProperty=nameWithType>
