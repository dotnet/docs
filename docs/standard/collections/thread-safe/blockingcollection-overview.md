---
title: "BlockingCollection Overview"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "BlockingCollection, overview"
ms.assetid: 987ea3d7-0ad5-4238-8b64-331ce4eb3f0b
caps.latest.revision: 12
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# BlockingCollection Overview
<xref:System.Collections.Concurrent.BlockingCollection%601> is a thread-safe collection class that provides the following features:  
  
-   An implementation of the Producer-Consumer pattern.  
  
-   Concurrent adding and taking of items from multiple threads.  
  
-   Optional maximum capacity.  
  
-   Insertion and removal operations that block when collection is empty or full.  
  
-   Insertion and removal "try" operations that do not block or that block up to a specified period of time.  
  
-   Encapsulates any collection type that implements <xref:System.Collections.Concurrent.IProducerConsumerCollection%601>  
  
-   Cancellation with cancellation tokens.  
  
-   Two kinds of enumeration with `foreach` (`For Each` in Visual Basic):  
  
    1.  Read-only enumeration.  
  
    2.  Enumeration that removes items as they are enumerated.  
  
## Bounding and Blocking Support  
 <xref:System.Collections.Concurrent.BlockingCollection%601> supports bounding and blocking. Bounding means you can set the maximum capacity of the collection. Bounding is important in certain scenarios because it enables you to control the maximum size of the collection in memory, and it prevents the producing threads from moving too far ahead of the consuming threads.  
  
 Multiple threads or tasks can add items to the collection concurrently, and if the collection reaches its specified maximum capacity, the producing threads will block until an item is removed. Multiple consumers can remove items concurrently, and if the collection becomes empty, the consuming threads will block until a producer adds an item. A producing thread can call <xref:System.Collections.Concurrent.BlockingCollection%601.CompleteAdding%2A> to indicate that no more items will be added. Consumers monitor the <xref:System.Collections.Concurrent.BlockingCollection%601.IsCompleted%2A> property to know when the collection is empty and no more items will be added. The following example shows a simple BlockingCollection with a bounded capacity of 100. A producer task adds items to the collection as long as some external condition is true, and then calls <xref:System.Collections.Concurrent.BlockingCollection%601.CompleteAdding%2A>. The consumer task takes items until the <xref:System.Collections.Concurrent.BlockingCollection%601.IsCompleted%2A> property is true.  
  
 [!code-csharp[CDS_BlockingCollection#04](../../../../samples/snippets/csharp/VS_Snippets_Misc/cds_blockingcollection/cs/blockingcollection.cs#04)]
 [!code-vb[CDS_BlockingCollection#04](../../../../samples/snippets/visualbasic/VS_Snippets_Misc/cds_blockingcollection/vb/introsnippetsbc.vb#04)]  
  
 For a complete example, see [How to: Add and Take Items Individually from a BlockingCollection](../../../../docs/standard/collections/thread-safe/how-to-add-and-take-items.md).  
  
## Timed Blocking Operations  
 In timed blocking <xref:System.Collections.Concurrent.BlockingCollection%601.TryAdd%2A> and <xref:System.Collections.Concurrent.BlockingCollection%601.TryTake%2A> operations on bounded collections, the method tries to add or take an item. If an item is available it is placed into the variable that was passed in by reference, and the method returns true. If no item is retrieved after a specified time-out period the method returns false. The thread is then free to do some other useful work before trying again to access the collection. For an example of timed blocking access, see the second example in [How to: Add and Take Items Individually from a BlockingCollection](../../../../docs/standard/collections/thread-safe/how-to-add-and-take-items.md).  
  
## Cancelling Add and Take Operations  
 Add and Take operations are typically performed in a loop. You can cancel a loop by passing in a <xref:System.Threading.CancellationToken> to the <xref:System.Collections.Concurrent.BlockingCollection%601.TryAdd%2A> or <xref:System.Collections.Concurrent.BlockingCollection%601.TryTake%2A> method, and then checking the value of the token's <xref:System.Threading.CancellationToken.IsCancellationRequested%2A> property on each iteration. If the value is true, then it is up to you to respond the cancellation request by cleaning up any resources and exiting the loop. The following example shows an overload of <xref:System.Collections.Concurrent.BlockingCollection%601.TryAdd%2A> that takes a cancellation token, and the code that uses it:  
  
 [!code-csharp[CDS_BlockingCollection#05](../../../../samples/snippets/csharp/VS_Snippets_Misc/cds_blockingcollection/cs/blockingcollection.cs#05)]
 [!code-vb[CDS_BlockingCollection#05](../../../../samples/snippets/visualbasic/VS_Snippets_Misc/cds_blockingcollection/vb/introsnippetsbc.vb#05)]  
  
 For an example of how to add cancellation support, see the second example in [How to: Add and Take Items Individually from a BlockingCollection](../../../../docs/standard/collections/thread-safe/how-to-add-and-take-items.md).  
  
## Specifying the Collection Type  
 When you create a <xref:System.Collections.Concurrent.BlockingCollection%601>, you can specify not only the bounded capacity but also the type of collection to use. For example, you could specify a <xref:System.Collections.Concurrent.ConcurrentQueue%601> for first in-first out (FIFO) behavior, or a <xref:System.Collections.Concurrent.ConcurrentStack%601> for last in-first out (LIFO) behavior. You can use any collection class that implements the <xref:System.Collections.Concurrent.IProducerConsumerCollection%601> interface. The default collection type for <xref:System.Collections.Concurrent.BlockingCollection%601> is <xref:System.Collections.Concurrent.ConcurrentQueue%601>. The following code example shows how to create a <xref:System.Collections.Concurrent.BlockingCollection%601> of strings that has a capacity of 1000 and uses a <xref:System.Collections.Concurrent.ConcurrentBag%601>:  
  
```vb  
Dim bc = New BlockingCollection(Of String)(New ConcurrentBag(Of String()), 1000)  
```  
  
```csharp  
BlockingCollection<string> bc = new BlockingCollection<string>(new ConcurrentBag<string>(), 1000 );  
```  
  
 For more information, see [How to: Add Bounding and Blocking Functionality to a Collection](../../../../docs/standard/collections/thread-safe/how-to-add-bounding-and-blocking.md).  
  
## IEnumerable Support  
 <xref:System.Collections.Concurrent.BlockingCollection%601> provides a <xref:System.Collections.Concurrent.BlockingCollection%601.GetConsumingEnumerable%2A> method that enables consumers to use `foreach` (`For Each` in [!INCLUDE[vbprvb](../../../../includes/vbprvb-md.md)]) to remove items until the collection is completed, which means it is empty and no more items will be added. For more information, see [How to: Use ForEach to Remove Items in a BlockingCollection](../../../../docs/standard/collections/thread-safe/how-to-use-foreach-to-remove.md).  
  
## Using Many BlockingCollections As One  
 For scenarios in which a consumer needs to take items from multiple collections simultaneously, you can create arrays of <xref:System.Collections.Concurrent.BlockingCollection%601> and use the static methods such as <xref:System.Collections.Concurrent.BlockingCollection%601.TakeFromAny%2A> and <xref:System.Collections.Concurrent.BlockingCollection%601.AddToAny%2A> that will add to or take from any of the collections in the array. If one collection is blocking, the method immediately tries another until it finds one that can perform the operation. For more information, see [How to: Use Arrays of Blocking Collections in a Pipeline](../../../../docs/standard/collections/thread-safe/how-to-use-arrays-of-blockingcollections.md).  
  
## See Also  
 <xref:System.Collections.Concurrent?displayProperty=nameWithType>  
 [Collections and Data Structures](../../../../docs/standard/collections/index.md)  
 [Thread-Safe Collections](../../../../docs/standard/collections/thread-safe/index.md)
