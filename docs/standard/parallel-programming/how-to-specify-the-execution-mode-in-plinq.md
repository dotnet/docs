---
title: "How to: Specify the Execution Mode in PLINQ"
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
  - "PLINQ queries, how to use execution mode"
ms.assetid: e52ff26c-c5d3-4fab-9fec-c937fb387963
caps.latest.revision: 8
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# How to: Specify the Execution Mode in PLINQ
This example shows how to force PLINQ to bypass its default heuristics and parallelize a query regardless of the query's shape.  
  
> [!WARNING]
>  This example is intended to demonstrate usage, and might not run faster than the equivalent sequential LINQ to Objects query. For more information about speedup, see [Understanding Speedup in PLINQ](../../../docs/standard/parallel-programming/understanding-speedup-in-plinq.md).  
  
## Example  
 [!code-csharp[PLINQ#22](../../../samples/snippets/csharp/VS_Snippets_Misc/plinq/cs/plinqsamples.cs#22)]
 [!code-vb[PLINQ#22](../../../samples/snippets/visualbasic/VS_Snippets_Misc/plinq/vb/plinqsnippets1.vb#22)]  
  
 PLINQ is designed to exploit opportunities for parallelization. However, not all queries benefit from parallel execution. For example, when a query contains a single user delegate that does very little work, the query will usually run faster sequentially. This is because the overhead involved in enabling parallelizing execution is more expensive than the speedup that is obtained. Therefore, PLINQ does not automatically parallelize every query. It first examines the shape of the query and the various operators that comprise it. Based on this analysis, PLINQ in the default execution mode may decide to execute some or all of the query sequentially. However, in some cases you may know more about your query than PLINQ is able to determine from its analysis. For example, you may know that a delegate is very expensive, and that the query will definitely benefit from parallelization. In such cases, you can use the <xref:System.Linq.ParallelEnumerable.WithExecutionMode%2A> method and specify the <xref:System.Linq.ParallelExecutionMode.ForceParallelism> value to instruct PLINQ to always run the query as parallel.  
  
## Compiling the Code  
 Cut and paste this code into the [PLINQ Data Sample](../../../docs/standard/parallel-programming/plinq-data-sample.md) and call the method from `Main`.  
  
## See Also  
 <xref:System.Linq.ParallelEnumerable.AsSequential%2A>  
 [Parallel LINQ (PLINQ)](../../../docs/standard/parallel-programming/parallel-linq-plinq.md)
