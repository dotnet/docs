---
title: "How to: Write a Simple Parallel.For Loop"
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
  - "Parallel.For, How to Write"
  - "for loop, parallel construction in .NET"
  - "parallel for loops, how to use"
ms.assetid: 9029ba7f-a9d1-4526-8c84-c88716dba5d4
caps.latest.revision: 18
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# How to: Write a Simple Parallel.For Loop
This topic contains two examples that illustrate the <xref:System.Threading.Tasks.Parallel.For%2A?displayProperty=nameWithType> method. The first uses the <xref:System.Threading.Tasks.Parallel.For%28System.Int64%2CSystem.Int64%2CSystem.Action%7BSystem.Int64%7D%29?displayProperty=nameWithType> method overload, and the second uses the <xref:System.Threading.Tasks.Parallel.For%28System.Int32%2CSystem.Int32%2CSystem.Action%7BSystem.Int32%7D%29?displayProperty=nameWithType> overload, the two simplest overloads of the <xref:System.Threading.Tasks.Parallel.For%2A?displayProperty=nameWithType> method. You can use these two overloads of the <xref:System.Threading.Tasks.Parallel.For%2A?displayProperty=nameWithType> method when you do not need to cancel the loop, break out of the loop iterations, or maintain any thread-local state.  
  
> [!NOTE]
>  This documentation uses lambda expressions to define delegates in TPL. If you are not familiar with lambda expressions in C# or Visual Basic, see [Lambda Expressions in PLINQ and TPL](../../../docs/standard/parallel-programming/lambda-expressions-in-plinq-and-tpl.md).  
  
 The first example calculates the size of files in a single directory. The second computes the product of two matrices.  
  
## Example  
 This example is a simple command-line utility that calculates the total size of files in a directory. It expects a single directory path as an argument, and reports the number and total size of the files in that directory. After verifying that the directory exists, it uses the <xref:System.Threading.Tasks.Parallel.For%2A?displayProperty=nameWithType> method to enumerate the files in the directory and determine their file sizes. Each file size is then added to the `totalSize` variable. Note that the addition is performed by calling the <xref:System.Threading.Interlocked.Add%2A?displayProperty=nameWithType> so that the addition is performed as an atomic operation. Otherwise, multiple tasks could try to update the `totalSize` variable simultaneously.  
  
 [!code-csharp[Conceptual.Parallel.For#1](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.parallel.for/cs/for1.cs#1)]
 [!code-vb[Conceptual.Parallel.For#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.parallel.for/vb/for1.vb#1)]  
  
## Example  
 This example uses the <xref:System.Threading.Tasks.Parallel.For%2A?displayProperty=nameWithType> method to compute the product of two matrices. It also shows how to use the <xref:System.Diagnostics.Stopwatch?displayProperty=nameWithType> class to compare the performance of a parallel loop with a non-parallel loop. Note that, because it can generate a large volume of output, the example allows output to be redirected to a file.  
  
 [!code-csharp[TPL_Parallel#01](../../../samples/snippets/csharp/VS_Snippets_Misc/tpl_parallel/cs/simpleparallelfor.cs#01)]
 [!code-vb[TPL_Parallel#01](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpl_parallel/vb/simpleparallelfor.vb#01)]  
  
 When parallelizing any code, including loops, one important goal is to utilize the processors as much as possible without over parallelizing to the point where the overhead for parallel processing negates any performance benefits. In this particular example, only the outer loop is parallelized because there is not very much work performed in the inner loop. The combination of a small amount of work and undesirable cache effects can result in performance degradation in nested parallel loops. Therefore, parallelizing the outer loop only is the best way to maximize the benefits of concurrency on most systems.  
  
## The Delegate  
 The third parameter of this overload of <xref:System.Threading.Tasks.Parallel.For%2A> is a delegate of type `Action<int>` in C# or `Action(Of Integer)` in Visual Basic. An `Action` delegate, whether it has zero, one or sixteen type parameters, always returns void. In Visual Basic, the behavior of an `Action` is defined with a `Sub`. The example uses a lambda expression to create the delegate, but you can create the delegate in other ways as well. For more information, see [Lambda Expressions in PLINQ and TPL](../../../docs/standard/parallel-programming/lambda-expressions-in-plinq-and-tpl.md).  
  
## The Iteration Value  
 The delegate takes a single input parameter whose value is the current iteration. This iteration value is supplied by the runtime and its starting value is the index of the first element on the segment (partition) of the source that is being processed on the current thread.  
  
 If you require more control over the concurrency level, use one of the overloads that takes a <xref:System.Threading.Tasks.ParallelOptions?displayProperty=nameWithType> input parameter, such as: <xref:System.Threading.Tasks.Parallel.For%28System.Int32%2CSystem.Int32%2CSystem.Threading.Tasks.ParallelOptions%2CSystem.Action%7BSystem.Int32%2CSystem.Threading.Tasks.ParallelLoopState%7D%29?displayProperty=nameWithType>.  
  
## Return Value and Exception Handling  
 <xref:System.Threading.Tasks.Parallel.For%2A> returns a <xref:System.Threading.Tasks.ParallelLoopResult?displayProperty=nameWithType> object when all threads have completed. This return value is useful when you are stopping or breaking loop iteration manually, because the <xref:System.Threading.Tasks.ParallelLoopResult> stores information such as the last iteration that ran to completion. If one or more exceptions occur on one of the threads, a <xref:System.AggregateException?displayProperty=nameWithType> will be thrown.  
  
 In the code in this example, the return value of <xref:System.Threading.Tasks.Parallel.For%2A> is not used.  
  
## Analysis and Performance  
 You can use the Performance Wizard to view CPU usage on your computer. As an experiment, increase the number of columns and rows in the matrices. The larger the matrices, the greater the performance difference between the parallel and sequential versions of the computation. When the matrix is small, the sequential version will run faster because of the overhead in setting up the parallel loop.  
  
 Synchronous calls to shared resources, like the Console or the File System, will significantly degrade the performance of a parallel loop. When measuring performance, try to avoid calls such as <xref:System.Console.WriteLine%2A?displayProperty=nameWithType> within the loop.  
  
## Compiling the Code  
  
-   Copy and paste this code into a Visual Studio 2010 project.  
  
## See Also  
 <xref:System.Threading.Tasks.Parallel.For%2A>  
 <xref:System.Threading.Tasks.Parallel.ForEach%2A>  
 [Data Parallelism](../../../docs/standard/parallel-programming/data-parallelism-task-parallel-library.md)  
 [Parallel Programming](../../../docs/standard/parallel-programming/index.md)
