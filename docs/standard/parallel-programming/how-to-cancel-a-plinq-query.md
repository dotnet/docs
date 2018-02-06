---
title: "How to: Cancel a PLINQ Query"
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
  - "PLINQ queries, how to cancel"
  - "cancellation, PLINQ"
ms.assetid: 80b14640-edfa-4153-be1b-3e003d3e9c1a
caps.latest.revision: 16
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# How to: Cancel a PLINQ Query
The following examples show two ways to cancel a PLINQ query. The first example shows how to cancel a query that consists mostly of data traversal. The second example shows how to cancel a query that contains a user function that is computationally expensive.  
  
> [!NOTE]
>  When "Just My Code" is enabled, Visual Studio will break on the line that throws the exception and display an error message that says "exception not handled by user code." This error is benign. You can press F5 to continue from it, and see the exception-handling behavior that is demonstrated in the examples below. To prevent Visual Studio from breaking on the first error, just uncheck the "Just My Code" checkbox under **Tools, Options, Debugging, General**.  
>   
>  This example is intended to demonstrate usage, and might not run faster than the equivalent sequential LINQ to Objects query. For more information about speedup, see [Understanding Speedup in PLINQ](../../../docs/standard/parallel-programming/understanding-speedup-in-plinq.md).  
  
## Example  
 [!code-csharp[PLINQ#16](../../../samples/snippets/csharp/VS_Snippets_Misc/plinq/cs/plinqsamples.cs#16)]
 [!code-vb[PLINQ#16](../../../samples/snippets/visualbasic/VS_Snippets_Misc/plinq/vb/plinqsnippets1.vb#16)]  
  
 The PLINQ framework does not roll a single <xref:System.OperationCanceledException> into an <xref:System.AggregateException?displayProperty=nameWithType>; the <xref:System.OperationCanceledException> must be handled in a separate catch block. If one or more user delegates throws an OperationCanceledException(externalCT) (by using an external <xref:System.Threading.CancellationToken?displayProperty=nameWithType>) but no other exception, and the query was defined as `AsParallel().WithCancellation(externalCT)`, then PLINQ will issue a single <xref:System.OperationCanceledException> (externalCT) rather than an <xref:System.AggregateException?displayProperty=nameWithType>. However, if one user delegate throws an <xref:System.OperationCanceledException>, and another delegate throws another exception type, then both exceptions will be rolled into an <xref:System.AggregateException>.  
  
 The general guidance on cancellation is as follows:  
  
1.  If you perform user-delegate cancellation you should inform PLINQ about the external <xref:System.Threading.CancellationToken> and throw an <xref:System.OperationCanceledException>(externalCT).  
  
2.  If cancellation occurs and no other exceptions are thrown, then you should handle an <xref:System.OperationCanceledException> rather than an <xref:System.AggregateException>.  
  
## Example  
 The following example shows how to handle cancellation when you have a computationally expensive function in user code.  
  
 [!code-csharp[PLINQ#17](../../../samples/snippets/csharp/VS_Snippets_Misc/plinq/cs/plinqsamples.cs#17)]
 [!code-vb[PLINQ#17](../../../samples/snippets/visualbasic/VS_Snippets_Misc/plinq/vb/plinqsnippets1.vb#17)]  
  
 When you handle the cancellation in user code, you do not have to use <xref:System.Linq.ParallelEnumerable.WithCancellation%2A> in the query definition. However, we recommended that you do this because <xref:System.Linq.ParallelEnumerable.WithCancellation%2A> has no effect on query performance and it enables the cancellation to be handled by query operators and your user code.  
  
 In order to ensure system responsiveness, we recommend that you check for cancellation around once per millisecond; however, any period up to 10 milliseconds is considered acceptable. This frequency should not have a negative impact on your code's performance.  
  
 When an enumerator is disposed, for example when code breaks out of a foreach (For Each in Visual Basic) loop that is iterating over query results, then the query is cancelled, but no exception is thrown.  
  
## See Also  
 <xref:System.Linq.ParallelEnumerable>  
 [Parallel LINQ (PLINQ)](../../../docs/standard/parallel-programming/parallel-linq-plinq.md)  
 [Cancellation in Managed Threads](../../../docs/standard/threading/cancellation-in-managed-threads.md)
