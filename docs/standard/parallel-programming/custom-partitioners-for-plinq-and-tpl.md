---
title: "Custom Partitioners for PLINQ and TPL"
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
  - "tasks, partitioners"
ms.assetid: 96153688-9a01-47c4-8430-909cee9a2887
caps.latest.revision: 19
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Custom Partitioners for PLINQ and TPL
To parallelize an operation on a data source, one of the essential steps is to *partition* the source into multiple sections that can be accessed concurrently by multiple threads. PLINQ and the Task Parallel Library (TPL) provide default partitioners that work transparently when you write a parallel query or <xref:System.Threading.Tasks.Parallel.ForEach%2A> loop. For more advanced scenarios, you can plug in your own partitioner.  
  
## Kinds of Partitioning  
 There are many ways to partition a data source. In the most efficient approaches, multiple threads cooperate to process the original source sequence, rather than physically separating the source into multiple subsequences. For arrays and other indexed sources such as <xref:System.Collections.IList> collections where the length is known in advance, *range partitioning* is the simplest kind of partitioning. Every thread receives unique beginning and ending indexes, so that it can process its range of the source without overwriting or being overwritten by any other thread. The only overhead involved in range partitioning is the initial work of creating the ranges; no additional synchronization is required after that. Therefore, it can provide good performance as long as the workload is divided evenly. A disadvantage of range partitioning is that if one thread finishes early, it cannot help the other threads finish their work.  
  
 For linked lists or other collections whose length is not known, you can use *chunk partitioning*. In chunk partitioning, every thread or task in a parallel loop or query consumes some number of source elements in one chunk, processes them, and then comes back to retrieve additional elements. The partitioner ensures that all elements are distributed and that there are no duplicates. A chunk may be any size. For example, the partitioner that is demonstrated in [How to: Implement Dynamic Partitions](../../../docs/standard/parallel-programming/how-to-implement-dynamic-partitions.md) creates chunks that contain just one element. As long as the chunks are not too large, this kind of partitioning is inherently load-balancing because the assignment of elements to threads is not pre-determined. However, the partitioner does incur the synchronization overhead each time the thread needs to get another chunk. The amount of synchronization incurred in these cases is inversely proportional to the size of the chunks.  
  
 In general, range partitioning is only faster when the execution time of the delegate is small to moderate, and the source has a large number of elements, and the total work of each partition is roughly equivalent. Chunk partitioning is therefore generally faster in most cases. On sources with a small number of elements or longer execution times for the delegate, then the performance of chunk and range partitioning is about equal.  
  
 The TPL partitioners also support a dynamic number of partitions. This means they can create partitions on-the-fly, for example, when the <xref:System.Threading.Tasks.Parallel.ForEach%2A> loop spawns a new task. This feature enables the partitioner to scale together with the loop itself. Dynamic partitioners are also inherently load-balancing. When you create a custom partitioner, you must support dynamic partitioning to be consumable from a <xref:System.Threading.Tasks.Parallel.ForEach%2A> loop.  
  
### Configuring Load Balancing Partitioners for PLINQ  
 Some overloads of the <xref:System.Collections.Concurrent.Partitioner.Create%2A?displayProperty=nameWithType> method let you create a partitioner for an array or <xref:System.Collections.IList> source and specify whether it should attempt to balance the workload among the threads. When the partitioner is configured to load-balance, chunk partitioning is used, and the elements are handed off to each partition in small chunks as they are requested. This approach helps ensure that all partitions have elements to process until the entire loop or query is completed. An additional overload can be used to provide load-balancing partitioning of any <xref:System.Collections.IEnumerable> source.  
  
 In general, load balancing requires the partitions to request elements relatively frequently from the partitioner. By contrast, a partitioner that does static partitioning can assign the elements to each partitioner all at once by using either range or chunk partitioning. This requires less overhead than load balancing, but it might take longer to execute if one thread ends up with significantly more work than the others. By default when it is passed an IList or an array, PLINQ always uses range partitioning without load balancing. To enable load balancing for PLINQ, use the `Partitioner.Create` method, as shown in the following example.  
  
 [!code-csharp[TPL_Partitioners#02](../../../samples/snippets/csharp/VS_Snippets_Misc/tpl_partitioners/cs/partitioners.cs#02)]
 [!code-vb[TPL_Partitioners#02](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpl_partitioners/vb/partitionsnippets_vb.vb#02)]  
  
 The best way to determine whether to use load balancing in any given scenario is to experiment and measure how long it takes operations to complete under representative loads and computer configurations. For example, static partitioning might provide significant speedup on a multi-core computer that has only a few cores, but it might result in slowdowns on computers that have relatively many cores.  
  
 The following table lists the available overloads of the <xref:System.Collections.Concurrent.Partitioner.Create%2A> method. These partitioners are not limited to use only with PLINQ or <xref:System.Threading.Tasks.Task>. They can also be used with any custom parallel construct.  
  
|Overload|Uses load balancing|  
|--------------|-------------------------|  
|<xref:System.Collections.Concurrent.Partitioner.Create%60%601%28System.Collections.Generic.IEnumerable%7B%60%600%7D%29>|Always|  
|<xref:System.Collections.Concurrent.Partitioner.Create%60%601%28%60%600%5B%5D%2CSystem.Boolean%29>|When the Boolean argument is specified as true|  
|<xref:System.Collections.Concurrent.Partitioner.Create%60%601%28System.Collections.Generic.IList%7B%60%600%7D%2CSystem.Boolean%29>|When the Boolean argument is specified as true|  
|<xref:System.Collections.Concurrent.Partitioner.Create%28System.Int32%2CSystem.Int32%29>|Never|  
|<xref:System.Collections.Concurrent.Partitioner.Create%28System.Int32%2CSystem.Int32%2CSystem.Int32%29>|Never|  
|<xref:System.Collections.Concurrent.Partitioner.Create%28System.Int64%2CSystem.Int64%29>|Never|  
|<xref:System.Collections.Concurrent.Partitioner.Create%28System.Int64%2CSystem.Int64%2CSystem.Int64%29>|Never|  
  
### Configuring Static Range Partitioners for Parallel.ForEach  
 In a <xref:System.Threading.Tasks.Parallel.For%2A> loop, the body of the loop is provided to the method as a delegate. The cost of invoking that delegate is about the same as a virtual method call. In some scenarios, the body of a parallel loop might be small enough that the cost of the delegate invocation on each loop iteration becomes significant. In such situations, you can use one of the <xref:System.Collections.Concurrent.Partitioner.Create%2A> overloads to create an <xref:System.Collections.Generic.IEnumerable%601> of range partitions over the source elements. Then, you can pass this collection of ranges to a <xref:System.Threading.Tasks.Parallel.ForEach%2A> method whose body consists of a regular `for` loop. The benefit of this approach is that the delegate invocation cost is incurred only once per range, rather than once per element. The following example demonstrates the basic pattern.  
  
 [!code-csharp[TPL_Partitioners#01](../../../samples/snippets/csharp/VS_Snippets_Misc/tpl_partitioners/cs/partitioner01.cs#01)]
 [!code-vb[TPL_Partitioners#01](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpl_partitioners/vb/partitionercreate01.vb#01)]  
  
 Every thread in the loop receives its own <xref:System.Tuple%602> that contains the starting and ending index values in the specified sub-range. The inner `for` loop uses the `fromInclusive` and `toExclusive` values to loop over the array or the <xref:System.Collections.IList> directly.  
  
 One of the <xref:System.Collections.Concurrent.Partitioner.Create%2A> overloads lets you specify the size of the partitions, and the number of partitions. This overload can be used in scenarios where the work per element is so low that even one virtual method call per element has a noticeable impact on performance.  
  
## Custom Partitioners  
 In some scenarios, it might be worthwhile or even required to implement your own partitioner. For example, you might have a custom collection class that you can partition more efficiently than the default partitioners can, based on your knowledge of the internal structure of the class. Or, you may want to create range partitions of varying sizes based on your knowledge of how long it will take to process elements at different locations in the source collection.  
  
 To create a basic custom partitioner, derive a class from <xref:System.Collections.Concurrent.Partitioner%601?displayProperty=nameWithType> and override the virtual methods, as described in the following table.  
  
|||  
|-|-|  
|<xref:System.Collections.Concurrent.Partitioner%601.GetPartitions%2A>|This method is called once by the main thread and returns an IList(IEnumerator(TSource)). Each worker thread in the loop or query can call `GetEnumerator` on the list to retrieve a <xref:System.Collections.Generic.IEnumerator%601> over a distinct partition.|  
|<xref:System.Collections.Concurrent.Partitioner%601.SupportsDynamicPartitions%2A>|Return `true` if you implement <xref:System.Collections.Concurrent.Partitioner%601.GetDynamicPartitions%2A>, otherwise, `false`.|  
|<xref:System.Collections.Concurrent.Partitioner%601.GetDynamicPartitions%2A>|If <xref:System.Collections.Concurrent.Partitioner%601.SupportsDynamicPartitions%2A> is `true`, this method can optionally be called instead of <xref:System.Collections.Concurrent.Partitioner%601.GetPartitions%2A>.|  
  
 If the results must be sortable or you require indexed access into the elements, then derive from <xref:System.Collections.Concurrent.OrderablePartitioner%601?displayProperty=nameWithType> and override its virtual methods as described in the following table.  
  
|||  
|-|-|  
|<xref:System.Collections.Concurrent.OrderablePartitioner%601.GetPartitions%2A>|This method is called once by the main thread and returns an `IList(IEnumerator(TSource))`. Each worker thread in the loop or query can call `GetEnumerator` on the list to retrieve a <xref:System.Collections.Generic.IEnumerator%601> over a distinct partition.|  
|<xref:System.Collections.Concurrent.Partitioner%601.SupportsDynamicPartitions%2A>|Return `true` if you implement <xref:System.Collections.Concurrent.OrderablePartitioner%601.GetDynamicPartitions%2A>; otherwise, false.|  
|<xref:System.Collections.Concurrent.OrderablePartitioner%601.GetDynamicPartitions%2A>|Typically, this just calls <xref:System.Collections.Concurrent.OrderablePartitioner%601.GetOrderableDynamicPartitions%2A>.|  
|<xref:System.Collections.Concurrent.OrderablePartitioner%601.GetOrderableDynamicPartitions%2A>|If <xref:System.Collections.Concurrent.Partitioner%601.SupportsDynamicPartitions%2A> is `true`, this method can optionally be called instead of <xref:System.Collections.Concurrent.Partitioner%601.GetPartitions%2A>.|  
  
 The following table provides additional details about how the three kinds of load-balancing partitioners implement the <xref:System.Collections.Concurrent.OrderablePartitioner%601> class.  
  
|Method/Property|IList / Array without Load Balancing|IList / Array with Load Balancing|IEnumerable|  
|----------------------|-------------------------------------------|----------------------------------------|-----------------|  
|<xref:System.Collections.Concurrent.OrderablePartitioner%601.GetOrderablePartitions%2A>|Uses range partitioning|Uses chunk partitioning optimized for Lists for the partitionCount specified|Uses chunk partitioning by creating a static number of partitions.|  
|<xref:System.Collections.Concurrent.OrderablePartitioner%601.GetOrderableDynamicPartitions%2A?displayProperty=nameWithType>|Throws not-supported exception|Uses chunk partitioning optimized for Lists and dynamic partitions|Uses chunk partitioning by creating a dynamic number of partitions.|  
|<xref:System.Collections.Concurrent.OrderablePartitioner%601.KeysOrderedInEachPartition%2A>|Returns `true`|Returns `true`|Returns `true`|  
|<xref:System.Collections.Concurrent.OrderablePartitioner%601.KeysOrderedAcrossPartitions%2A>|Returns `true`|Returns `false`|Returns `false`|  
|<xref:System.Collections.Concurrent.OrderablePartitioner%601.KeysNormalized%2A>|Returns `true`|Returns `true`|Returns `true`|  
|<xref:System.Collections.Concurrent.Partitioner%601.SupportsDynamicPartitions%2A>|Returns `false`|Returns `true`|Returns `true`|  
  
### Dynamic Partitions  
 If you intend the partitioner to be used in a <xref:System.Threading.Tasks.Parallel.ForEach%2A> method, you must be able to return a dynamic number of partitions. This means that the partitioner can supply an enumerator for a new partition on-demand at any time during loop execution. Basically, whenever the loop adds a new parallel task, it requests a new partition for that task. If you require the data to be orderable, then derive from <xref:System.Collections.Concurrent.OrderablePartitioner%601?displayProperty=nameWithType> so that each item in each partition is assigned a unique index.  
  
 For more information, and an example, see [How to: Implement Dynamic Partitions](../../../docs/standard/parallel-programming/how-to-implement-dynamic-partitions.md).  
  
### Contract for Partitioners  
 When you implement a custom partitioner, follow these guidelines to help ensure correct interaction with PLINQ and <xref:System.Threading.Tasks.Parallel.ForEach%2A> in the TPL:  
  
-   If <xref:System.Collections.Concurrent.Partitioner%601.GetPartitions%2A> is called with an argument of zero or less for `partitionsCount`, throw <xref:System.ArgumentOutOfRangeException>. Although PLINQ and TPL will never pass in a `partitionCount` equal to 0, we nevertheless recommend that you guard against the possibility.  
  
-   <xref:System.Collections.Concurrent.Partitioner%601.GetPartitions%2A> and <xref:System.Collections.Concurrent.OrderablePartitioner%601.GetOrderablePartitions%2A> should always return `partitionsCount` number of partitions. If the partitioner runs out of data and cannot create as many partitions as requested, then the method should return an empty enumerator for each of the remaining partitions. Otherwise, both PLINQ and TPL will throw an <xref:System.InvalidOperationException>.  
  
-   <xref:System.Collections.Concurrent.Partitioner%601.GetPartitions%2A>, <xref:System.Collections.Concurrent.OrderablePartitioner%601.GetOrderablePartitions%2A>, <xref:System.Collections.Concurrent.Partitioner%601.GetDynamicPartitions%2A>, and <xref:System.Collections.Concurrent.OrderablePartitioner%601.GetOrderableDynamicPartitions%2A> should never return `null` (`Nothing` in Visual Basic). If they do, PLINQ / TPL will throw an <xref:System.InvalidOperationException>.  
  
-   Methods that return partitions should always return partitions that can fully and uniquely enumerate the data source. There should be no duplication in the data source or skipped items unless specifically required by the design of the partitioner. If this rule is not followed, then the output order may be scrambled.  
  
-   The following Boolean getters must always accurately return the following values so that the output order is not scrambled:  
  
    -   `KeysOrderedInEachPartition`: Each partition returns elements with increasing key indices.  
  
    -   `KeysOrderedAcrossPartitions`: For all partitions that are returned, the key indices in partition *i* are higher than the key indices in partition *i*-1.  
  
    -   `KeysNormalized`: All key indices are monotonically increasing without gaps, starting from zero.  
  
-   All indices must be unique. There may not be duplicate indices. If this rule is not followed, then the output order may be scrambled.  
  
-   All indices must be nonnegative. If this rule is not followed, then PLINQ/TPL may throw exceptions.  
  
## See Also  
 [Parallel Programming](../../../docs/standard/parallel-programming/index.md)  
 [How to: Implement Dynamic Partitions](../../../docs/standard/parallel-programming/how-to-implement-dynamic-partitions.md)  
 [How to: Implement a Partitioner for Static Partitioning](../../../docs/standard/parallel-programming/how-to-implement-a-partitioner-for-static-partitioning.md)
