---
description: "Learn more about: How to: Implement a Partitioner for Static Partitioning"
title: "How to: Implement a Partitioner for Static Partitioning"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "tasks, how to create a static partitioner"
ms.assetid: f4410508-cac6-4ba7-bef1-c5e68b2794f3
---
# How to: Implement a Partitioner for Static Partitioning

The following example shows one way to implement a simple custom partitioner for PLINQ that performs static partitioning. Because the partitioner does not support dynamic partitions, it is not consumable from <xref:System.Threading.Tasks.Parallel.ForEach%2A?displayProperty=nameWithType>. This particular partitioner might provide speedup over the default range partitioner for data sources for which each element requires an increasing amount of processing time.  
  
## Example  

 [!code-csharp[TPL_Partitioners#05](../../../samples/snippets/csharp/VS_Snippets_Misc/tpl_partitioners/cs/partitioners.cs#05)]  
  
 The partitions in this example are based on the assumption of a linear increase in processing time for each element. In the real world, it might be difficult to predict processing times in this way. If you are using a static partitioner with a specific data source, you can optimize the partitioning formula for the source, add load-balancing logic, or use a chunk partitioning approach as demonstrated in [How to: Implement Dynamic Partitions](how-to-implement-dynamic-partitions.md).  
  
## See also

- [Custom Partitioners for PLINQ and TPL](custom-partitioners-for-plinq-and-tpl.md)
