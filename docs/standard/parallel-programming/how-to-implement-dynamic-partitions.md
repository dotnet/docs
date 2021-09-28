---
description: "Learn more about: How to: Implement Dynamic Partitions"
title: "How to: Implement Dynamic Partitions"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "tasks, how to create a dynamic partitioner"
ms.assetid: c875ad12-a161-43e6-ad1c-3d6927c536a7
---

# How to: Implement Dynamic Partitions

The following example shows how to implement a custom <xref:System.Collections.Concurrent.OrderablePartitioner%601?displayProperty=nameWithType> that implements dynamic partitioning and can be used from certain overloads <xref:System.Threading.Tasks.Parallel.ForEach%2A> and from PLINQ.  
  
## Example

Each time a partition calls <xref:System.Collections.IEnumerator.MoveNext%2A> on the enumerator, the enumerator provides the partition with one list element. In the case of PLINQ and <xref:System.Threading.Tasks.Parallel.ForEach%2A>, the partition is a <xref:System.Threading.Tasks.Task> instance. Because requests are happening concurrently on multiple threads, access to the current index is synchronized.  

[!code-csharp[TPL_Partitioners#04](../../../samples/snippets/csharp/VS_Snippets_Misc/tpl_partitioners/cs/partitioner02.cs#OrderableListPartitioner)]
[!code-vb[TPL_Partitioners#04](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpl_partitioners/vb/dynamicpartitioner.vb#04)]  

This is an example of chunk partitioning, with each chunk consisting of one element. By providing more elements at a time, you could reduce the contention over the lock and theoretically achieve faster performance. However, at some point, larger chunks might require additional load-balancing logic in order to keep all threads busy until all the work is done.  
  
## See also

* [Custom Partitioners for PLINQ and TPL](custom-partitioners-for-plinq-and-tpl.md)
* [How to: Implement a Partitioner for Static Partitioning](how-to-implement-a-partitioner-for-static-partitioning.md)
