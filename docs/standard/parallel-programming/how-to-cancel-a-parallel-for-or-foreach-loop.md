---
title: "How to: Cancel a Parallel.For or ForEach Loop"
description: Cancel a Parallel.For or Parallel.ForEach loop in .NET by supplying a cancellation token object to the method in the ParallelOptions parameter.
ms.date: 12/08/2021
dev_langs:
 - "csharp"
 - "vb"
helpviewer_keywords:
 - "parallel foreach loop, how to cancel"
 - "parallel for loops, how to cancel"
ms.assetid: 9d19b591-ea95-4418-8ea7-b6266af9905b
---

# How to: Cancel a Parallel.For or ForEach Loop

The <xref:System.Threading.Tasks.Parallel.For%2A?displayProperty=nameWithType> and <xref:System.Threading.Tasks.Parallel.ForEach%2A?displayProperty=nameWithType> methods support cancellation through the use of cancellation tokens. For more information about cancellation in general, see [Cancellation](../threading/cancellation-in-managed-threads.md). In a parallel loop, you supply the <xref:System.Threading.CancellationToken> to the method in the <xref:System.Threading.Tasks.ParallelOptions> parameter and then enclose the parallel call in a try-catch block.

## Example

The following example shows how to cancel a call to <xref:System.Threading.Tasks.Parallel.ForEach%2A?displayProperty=nameWithType>. You can apply the same approach to a <xref:System.Threading.Tasks.Parallel.For%2A?displayProperty=nameWithType> call.

[!code-csharp[TPL_Parallel#29](../../../samples/snippets/csharp/VS_Snippets_Misc/tpl_parallel/cs/parallel_cancel.cs#29)]
[!code-vb[TPL_Parallel#29](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpl_parallel/vb/cancelloop.vb#29)]

If the token that signals the cancellation is the same token that is specified in the <xref:System.Threading.Tasks.ParallelOptions> instance, then the parallel loop will throw a single <xref:System.OperationCanceledException> on cancellation. If some other token causes cancellation, the loop will throw an <xref:System.AggregateException> with an <xref:System.OperationCanceledException> as an InnerException.

## See also

- [Data parallelism](data-parallelism-task-parallel-library.md)
- [Lambda expressions in PLINQ and TPL](lambda-expressions-in-plinq-and-tpl.md)
