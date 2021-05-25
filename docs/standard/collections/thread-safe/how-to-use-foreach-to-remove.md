---
description: "Learn more about: Use foreach to remove items in a BlockingCollection"
title: "Use foreach to remove items in a BlockingCollection"
ms.date: 05/04/2020
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "thread-safe collections, how to enumerate blocking collection"
ms.assetid: 2096103c-22f7-420d-b631-f102bc33a6dd
---

# Use foreach to remove items in a BlockingCollection

In addition to taking items from a <xref:System.Collections.Concurrent.BlockingCollection%601> by using the <xref:System.Collections.Concurrent.BlockingCollection%601.Take%2A> and <xref:System.Collections.Concurrent.BlockingCollection%601.TryTake%2A> method, you can also use a [foreach](../../../csharp/language-reference/statements/iteration-statements.md#the-foreach-statement) ([For Each](../../../visual-basic/language-reference/statements/for-each-next-statement.md) in Visual Basic) with the <xref:System.Collections.Concurrent.BlockingCollection%601.GetConsumingEnumerable%2A?displayProperty=nameWithType> to remove items until adding is completed and the collection is empty. This is called a *mutating enumeration* or *consuming enumeration* because, unlike a typical `foreach` (`For Each`) loop, this enumerator modifies the source collection by removing items.

## Example

The following example shows how to remove all the items in a <xref:System.Collections.Concurrent.BlockingCollection%601> by using a `foreach` (`For Each`) loop.

[!code-csharp[CDS_BlockingCollection#03](../../../../samples/snippets/csharp/VS_Snippets_Misc/cds_blockingcollection/cs/example03.cs#03)]
[!code-vb[CDS_BlockingCollection#03](../../../../samples/snippets/visualbasic/VS_Snippets_Misc/cds_blockingcollection/vb/enumeratebc.vb#03)]

This example uses a `foreach` loop with the <xref:System.Collections.Concurrent.BlockingCollection%601.GetConsumingEnumerable%2A?displayProperty=nameWithType> method in the consuming thread, which causes each item to be removed from the collection as it is enumerated. <xref:System.Collections.Concurrent.BlockingCollection%601?displayProperty=nameWithType> limits the maximum number of items that are in the collection at any time. Enumerating the collection in this way blocks the consumer thread if no items are available or if the collection is empty. In this example blocking is not a concern because the producer thread adds items faster than they can be consumed.

The <xref:System.Collections.Concurrent.BlockingCollection%601.GetConsumingEnumerable%2A?displayProperty=nameWithType> returns an `IEnumerable<T>`, thus order cannot be guaranteed. However, internally a <xref:System.Collections.Concurrent.ConcurrentQueue%601?displayProperty=nameWithType> is used as the underlying collection type - which will dequeue objects following first-in-first-out (FIFO) ordering. If concurrent calls to <xref:System.Collections.Concurrent.BlockingCollection%601.GetConsumingEnumerable%2A?displayProperty=nameWithType> are made, they will compete. One item consumed (dequeued) in one enumeration cannot be observed in the other.

To enumerate the collection without modifying it, just use `foreach` (`For Each`) without the <xref:System.Collections.Concurrent.BlockingCollection%601.GetConsumingEnumerable%2A> method. However, it is important to understand that this kind of enumeration represents a snapshot of the collection at a precise point in time. If other threads are adding or removing items concurrently while you are executing the loop, then the loop might not represent the actual state of the collection.

## See also

- <xref:System.Collections.Concurrent?displayProperty=nameWithType>
- [Parallel Programming](../../parallel-programming/index.md)
