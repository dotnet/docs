---
description: "Learn more about: How to: Specify the Execution Mode in PLINQ"
title: "How to: Specify the Execution Mode in PLINQ"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "PLINQ queries, how to use execution mode"
ms.assetid: e52ff26c-c5d3-4fab-9fec-c937fb387963
---
# How to: Specify the Execution Mode in PLINQ

This example shows how to force PLINQ to bypass its default heuristics and parallelize a query regardless of the query's shape.  
  
> [!NOTE]
> This example is intended to demonstrate usage and might not run faster than the equivalent sequential LINQ to Objects query. For more information about speedup, see [Understanding Speedup in PLINQ](understanding-speedup-in-plinq.md).  
  
## Example  

 [!code-csharp[PLINQ#22](../../../samples/snippets/csharp/VS_Snippets_Misc/plinq/cs/plinqsamples.cs#22)]
 [!code-vb[PLINQ#22](../../../samples/snippets/visualbasic/VS_Snippets_Misc/plinq/vb/plinqsnippets1.vb#22)]  
  
 PLINQ is designed to exploit opportunities for parallelization. However, not all queries benefit from parallel execution. For example, when a query contains a single user delegate that does little work, the query will usually run faster sequentially. Sequential execution is faster because the overhead involved in enabling parallelizing execution is more expensive than the speedup that's obtained. Therefore, PLINQ does not automatically parallelize every query. It first examines the shape of the query and the various operators that comprise it. Based on this analysis, PLINQ in the default execution mode may decide to execute some or all of the query sequentially. However, in some cases you may know more about your query than PLINQ is able to determine from its analysis. For example, you may know that a delegate is expensive and that the query will definitely benefit from parallelization. In such cases, you can use the <xref:System.Linq.ParallelEnumerable.WithExecutionMode%2A> method and specify the <xref:System.Linq.ParallelExecutionMode.ForceParallelism> value to instruct PLINQ to always run the query as parallel.  
  
## Compiling the Code  

 Cut and paste this code into the [PLINQ Data Sample](plinq-data-sample.md) and call the method from `Main`.  
  
## See also

- <xref:System.Linq.ParallelEnumerable.AsSequential%2A>
- [Parallel LINQ (PLINQ)](introduction-to-plinq.md)
