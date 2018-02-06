---
title: "How to: Use ForEach to Remove Items in a BlockingCollection"
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
  - "thread-safe collections, how to enumerate blocking collectoin"
ms.assetid: 2096103c-22f7-420d-b631-f102bc33a6dd
caps.latest.revision: 13
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# How to: Use ForEach to Remove Items in a BlockingCollection
In addition to taking items from a <xref:System.Collections.Concurrent.BlockingCollection%601> by using the <xref:System.Collections.Concurrent.BlockingCollection%601.Take%2A> and <xref:System.Collections.Concurrent.BlockingCollection%601.TryTake%2A> method, you can also use a [foreach](~/docs/csharp/language-reference/keywords/foreach-in.md) ([For Each](~/docs/visual-basic/language-reference/statements/for-each-next-statement.md) in Visual Basic) to remove items until adding is completed and the collection is empty. This is called a *mutating enumeration* or *consuming enumeration* because, unlike a typical `foreach` (`For Each`) loop, this enumerator modifies the source collection by removing items.  
  
## Example  
 The following example shows how to remove all the items in a <xref:System.Collections.Concurrent.BlockingCollection%601> by using a `foreach` (`For Each`) loop.  
  
 [!code-csharp[CDS_BlockingCollection#03](../../../../samples/snippets/csharp/VS_Snippets_Misc/cds_blockingcollection/cs/example03.cs#03)]
 [!code-vb[CDS_BlockingCollection#03](../../../../samples/snippets/visualbasic/VS_Snippets_Misc/cds_blockingcollection/vb/enumeratebc.vb#03)]  
  
 This example uses a `foreach` loop with the <xref:System.Collections.Concurrent.BlockingCollection%601.GetConsumingEnumerable%2A?displayProperty=nameWithType> method in the consuming thread, which causes each item to be removed from the collection as it is enumerated. <xref:System.Collections.Concurrent.BlockingCollection%601?displayProperty=nameWithType> limits the maximum number of items that are in the collection at any time. Enumerating the collection in this way blocks the consumer thread if no items are available or if the collection is empty. In this example blocking is not a concern because the producer thread adds items faster than they can be consumed.  
  
 There is no guarantee that the items are enumerated in the same order in which they are added by the producer threads.  
  
 To enumerate the collection without modifying it, just use `foreach` (`For Each`) without the <xref:System.Collections.Concurrent.BlockingCollection%601.GetConsumingEnumerable%2A> method. However, it is important to understand that this kind of enumeration represents a snapshot of the collection at a precise point in time. If other threads are adding or removing items concurrently while you are executing the loop, then the loop might not represent the actual state of the collection.  
  
## See Also  
 <xref:System.Collections.Concurrent?displayProperty=nameWithType>  
 [Parallel Programming](../../../../docs/standard/parallel-programming/index.md)
