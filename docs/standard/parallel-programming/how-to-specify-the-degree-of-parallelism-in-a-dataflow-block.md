---
title: "How to: Specify the Degree of Parallelism in a Dataflow Block"
ms.date: "03/30/2017"
ms.technology: dotnet-standard
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "dataflow block, specifying parallelism in TPL"
  - "Task Parallel Library, dataflows"
  - "TPL dataflow library, specifying parallelism"
ms.assetid: e4088541-ee05-40db-95f5-147cfe62fde7
---
# How to: Specify the Degree of Parallelism in a Dataflow Block
This document describes how to set the <xref:System.Threading.Tasks.Dataflow.ExecutionDataflowBlockOptions.MaxDegreeOfParallelism%2A?displayProperty=nameWithType> property to enable an execution dataflow block to process more than one message at a time. Doing this is useful when you have a dataflow block that performs a long-running computation and can benefit from processing messages in parallel. This example uses the <xref:System.Threading.Tasks.Dataflow.ActionBlock%601?displayProperty=nameWithType> class to perform multiple dataflow operations concurrently; however, you can specify the maximum degree of parallelism in any of the predefined execution block types that the TPL Dataflow Library provides, <xref:System.Threading.Tasks.Dataflow.ActionBlock%601>, <xref:System.Threading.Tasks.Dataflow.TransformBlock%602?displayProperty=nameWithType>, and <xref:System.Threading.Tasks.Dataflow.TransformManyBlock%602?displayProperty=nameWithType>.

[!INCLUDE [tpl-install-instructions](../../../includes/tpl-install-instructions.md)]

## Example  
 The following example performs two dataflow computations and prints the elapsed time that is required for each computation. The first computation specifies a maximum degree of parallelism of 1, which is the default. A maximum degree of parallelism of 1 causes the dataflow block to process messages serially. The second computation resembles the first, except that it specifies a maximum degree of parallelism that is equal to the number of available processors. This enables the dataflow block to perform multiple operations in parallel.  
  
 [!code-csharp[TPLDataflow_DegreeOfParallelism#1](../../../samples/snippets/csharp/VS_Snippets_Misc/tpldataflow_degreeofparallelism/cs/dataflowdegreeofparallelism.cs#1)]
 [!code-vb[TPLDataflow_DegreeOfParallelism#1](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpldataflow_degreeofparallelism/vb/dataflowdegreeofparallelism.vb#1)]  
  
## Robust Programming  
 By default, each predefined dataflow block propagates out messages in the order in which the messages are received.  Although multiple messages are processed simultaneously when you specify a maximum degree of parallelism that is greater than 1, they are still propagated out in the order in which they are received.  
  
 Because the <xref:System.Threading.Tasks.Dataflow.ExecutionDataflowBlockOptions.MaxDegreeOfParallelism%2A> property represents the maximum degree of parallelism, the dataflow block might execute with a lesser degree of parallelism than you specify. The dataflow block can use a lesser degree of parallelism to meet its functional requirements or to account for a lack of available system resources. A dataflow block never chooses a greater degree of parallelism than you specify.  
  
## See also

- [Dataflow](../../../docs/standard/parallel-programming/dataflow-task-parallel-library.md)
