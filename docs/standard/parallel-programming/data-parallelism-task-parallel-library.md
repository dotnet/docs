---
title: "Data Parallelism (Task Parallel Library)"
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
  - "parallelism, data"
ms.assetid: 3f05f33f-f1da-4b16-81c2-9ceff1bef449
caps.latest.revision: 25
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Data Parallelism (Task Parallel Library)
*Data parallelism* refers to scenarios in which the same operation is performed concurrently (that is, in parallel) on elements in a source collection or array. In data parallel operations, the source collection is partitioned so that multiple threads can operate on different segments concurrently.  
  
 The Task Parallel Library (TPL) supports data parallelism through the <xref:System.Threading.Tasks.Parallel?displayProperty=nameWithType> class. This class provides method-based parallel implementations of [for](~/docs/csharp/language-reference/keywords/for.md) and [foreach](~/docs/csharp/language-reference/keywords/foreach-in.md) loops (`For` and `For Each` in Visual Basic). You write the loop logic for a <xref:System.Threading.Tasks.Parallel.For%2A?displayProperty=nameWithType> or <xref:System.Threading.Tasks.Parallel.ForEach%2A?displayProperty=nameWithType> loop much as you would write a sequential loop. You do not have to create threads or queue work items. In basic loops, you do not have to take locks. The TPL handles all the low-level work for you. For in-depth information about the use of <xref:System.Threading.Tasks.Parallel.For%2A?displayProperty=nameWithType> and <xref:System.Threading.Tasks.Parallel.ForEach%2A?displayProperty=nameWithType>, download the document [Patterns for Parallel Programming: Understanding and Applying Parallel Patterns with the .NET Framework 4](http://www.microsoft.com/download/details.aspx?id=19222). The following code example shows a simple `foreach` loop and its parallel equivalent.  
  
> [!NOTE]
>  This documentation uses lambda expressions to define delegates in TPL. If you are not familiar with lambda expressions in C# or Visual Basic, see [Lambda Expressions in PLINQ and TPL](../../../docs/standard/parallel-programming/lambda-expressions-in-plinq-and-tpl.md).  
  
 [!code-csharp[TPL#20](../../../samples/snippets/csharp/VS_Snippets_Misc/tpl/cs/tpl.cs#20)]
 [!code-vb[TPL#20](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpl/vb/tpl_vb.vb#20)]  
  
 When a parallel loop runs, the TPL partitions the data source so that the loop can operate on multiple parts concurrently. Behind the scenes, the Task Scheduler partitions the task based on system resources and workload. When possible, the scheduler redistributes work among multiple threads and processors if the workload becomes unbalanced.  
  
> [!NOTE]
>  You can also supply your own custom partitioner or scheduler. For more information, see [Custom Partitioners for PLINQ and TPL](../../../docs/standard/parallel-programming/custom-partitioners-for-plinq-and-tpl.md) and [Task Schedulers](http://msdn.microsoft.com/library/638f8ea5-21db-47a2-a934-86e1e961bf65).  
  
 Both the <xref:System.Threading.Tasks.Parallel.For%2A?displayProperty=nameWithType> and <xref:System.Threading.Tasks.Parallel.ForEach%2A?displayProperty=nameWithType> methods have several overloads that let you stop or break loop execution, monitor the state of the loop on other threads, maintain thread-local state, finalize thread-local objects, control the degree of concurrency, and so on. The helper types that enable this functionality include <xref:System.Threading.Tasks.ParallelLoopState>, <xref:System.Threading.Tasks.ParallelOptions>, <xref:System.Threading.Tasks.ParallelLoopResult>, <xref:System.Threading.CancellationToken>, and <xref:System.Threading.CancellationTokenSource>.  
  
 For more information, see [Patterns for Parallel Programming: Understanding and Applying Parallel Patterns with the .NET Framework 4](https://www.microsoft.com/download/details.aspx?id=19222).  
  
 Data parallelism with declarative, or query-like, syntax is supported by PLINQ. For more information, see [Parallel LINQ (PLINQ)](../../../docs/standard/parallel-programming/parallel-linq-plinq.md).  
  
## Related Topics  
  
|Title|Description|  
|-----------|-----------------|  
|[How to: Write a Simple Parallel.For Loop](../../../docs/standard/parallel-programming/how-to-write-a-simple-parallel-for-loop.md)|Describes how to write a <xref:System.Threading.Tasks.Parallel.For%2A> loop over any array or indexable <xref:System.Collections.Generic.IEnumerable%601> source collection.|  
|[How to: Write a Simple Parallel.ForEach Loop](../../../docs/standard/parallel-programming/how-to-write-a-simple-parallel-foreach-loop.md)|Describes how to write a <xref:System.Threading.Tasks.Parallel.ForEach%2A> loop over any <xref:System.Collections.Generic.IEnumerable%601> source collection.|  
|[How to: Stop or Break from a Parallel.For Loop](https://msdn.microsoft.com/library/de52e4f1-9346-4ad5-b582-1a4d54dc7f7e)|Describes how to stop or break from a parallel loop so that all threads are informed of the action.|  
|[How to: Write a Parallel.For Loop with Thread-Local Variables](../../../docs/standard/parallel-programming/how-to-write-a-parallel-for-loop-with-thread-local-variables.md)|Describes how to write a <xref:System.Threading.Tasks.Parallel.For%2A> loop in which each thread maintains a private variable that is not visible to any other threads, and how to synchronize the results from all threads when the loop completes.|  
|[How to: Write a Parallel.ForEach Loop with Thread-Local Variables](../../../docs/standard/parallel-programming/how-to-write-a-parallel-foreach-loop-with-thread-local-variables.md)|Describes how to write a <xref:System.Threading.Tasks.Parallel.ForEach%2A> loop in which each thread maintains a private variable that is not visible to any other threads, and how to synchronize the results from all threads when the loop completes.|  
|[How to: Cancel a Parallel.For or ForEach Loop](../../../docs/standard/parallel-programming/how-to-cancel-a-parallel-for-or-foreach-loop.md)|Describes how to cancel a parallel loop by using a <xref:System.Threading.CancellationToken?displayProperty=nameWithType>|  
|[How to: Speed Up Small Loop Bodies](../../../docs/standard/parallel-programming/how-to-speed-up-small-loop-bodies.md)|Describes one way to speed up execution when a loop body is very small.|  
|[Task Parallel Library (TPL)](../../../docs/standard/parallel-programming/task-parallel-library-tpl.md)|Provides an overview of the Task Parallel Library.|  
|[Parallel Programming](../../../docs/standard/parallel-programming/index.md)|Introduces Parallel Programming in the .NET Framework.|  
  
## See Also  
 [Parallel Programming](../../../docs/standard/parallel-programming/index.md)
