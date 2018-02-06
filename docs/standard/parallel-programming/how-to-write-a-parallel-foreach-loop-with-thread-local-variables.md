---
title: "How to: Write a Parallel.ForEach Loop with Thread-Local Variables"
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
  - "parallel foreach loop, how to use local state"
ms.assetid: 24b10041-b30b-45cb-aa65-66cf568ca76d
caps.latest.revision: 18
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# How to: Write a Parallel.ForEach Loop with Thread-Local Variables
The following example shows how to write a <xref:System.Threading.Tasks.Parallel.ForEach%2A> method that uses thread-local variables. When a <xref:System.Threading.Tasks.Parallel.ForEach%2A> loop executes, it divides its source collection into multiple partitions. Each partition will get its own copy of the "thread-local" variable. (The term "thread-local" is slightly inaccurate here, because in some cases two partitions may run on the same thread.)  
  
 The code and parameters in this example closely resemble the corresponding <xref:System.Threading.Tasks.Parallel.For%2A> method. For more information, see [How to: Write a Parallel.For Loop with Thread-Local Variables](../../../docs/standard/parallel-programming/how-to-write-a-parallel-for-loop-with-thread-local-variables.md).  
  
 To use a thread-local variable in a <xref:System.Threading.Tasks.Parallel.ForEach%2A> loop, you must call one of the method overloads that takes two type parameters. The first type parameter, `TSource`, specifies the type of the source element, and the second type parameter, `TLocal`, specifies the type of the thread-local variable.  
  
## Example  
 The following example calls <xref:System.Threading.Tasks.Parallel.ForEach%60%602%28System.Collections.Generic.IEnumerable%7B%60%600%7D%2CSystem.Func%7B%60%601%7D%2CSystem.Func%7B%60%600%2CSystem.Threading.Tasks.ParallelLoopState%2C%60%601%2C%60%601%7D%2CSystem.Action%7B%60%601%7D%29?displayProperty=nameWithType> overload to compute the sum of an array of one million elements. This overload has four parameters:  
  
-   `source`, which is the data source. It must implement <xref:System.Collections.Generic.IEnumerable%601>. The data source in our example is the one million member `IEnumerable<Int32>` object returned by the <xref:System.Linq.Enumerable.Range%2A?displayProperty=nameWithType> method.  
  
-   `localInit`, or the function that initializes the thread-local variable. This function is called once for each partition in which the <xref:System.Threading.Tasks.Parallel.ForEach%2A?displayProperty=nameWithType> operation executes. Our example initializes the thread-local variable to zero.  
  
-   `body`, a <xref:System.Func%604> that is invoked by the parallel loop on each iteration of the loop. Its signature is `Func\<TSource, ParallelLoopState, TLocal, TLocal>`. You supply the code for the delegate, and the loop passes in the input parameters, which are:  
  
    -   The current element of the <xref:System.Collections.Generic.IEnumerable%601>.  
  
    -   A <xref:System.Threading.Tasks.ParallelLoopState> variable that you can use in your delegate's code to examine the state of the loop.  
  
    -   The thread-local variable.  
  
     Your delegate returns the thread-local variable, which is then passed to the next iteration of the loop that executes in that particular partition. Each loop partition maintains a separate instance of this variable.  
  
     In the example, the delegate adds the value of each integer to the thread-local variable, which maintains a running total of the values of the integer elements in that partition.  
  
-   `localFinally`, an `Action<TLocal>` delegate that the <xref:System.Threading.Tasks.Parallel.ForEach%2A?displayProperty=nameWithType> invokes when the looping operations in each partition have completed. The <xref:System.Threading.Tasks.Parallel.ForEach%2A?displayProperty=nameWithType> method passes your `Action<TLocal>` delegate the final value of the thread-local variable for this thread (or loop partition), and you provide the code that performs the required action for combining the result from this partition with the results from the other partitions. This delegate can be invoked concurrently by multiple tasks. Because of this, the example uses the <xref:System.Threading.Interlocked.Add%28System.Int32%40%2CSystem.Int32%29?displayProperty=nameWithType> method to synchronize access to the `total` variable. Because the delegate type is an <xref:System.Action%601>, there is no return value.  
  
 [!code-csharp[TPL_Parallel#04](../../../samples/snippets/csharp/VS_Snippets_Misc/tpl_parallel/cs/foreachthreadlocal.cs#04)]
 [!code-vb[TPL_Parallel#04](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpl_parallel/vb/foreachthreadlocal.vb#04)]  
  
## See Also  
 [Data Parallelism](../../../docs/standard/parallel-programming/data-parallelism-task-parallel-library.md)  
 [How to: Write a Parallel.For Loop with Thread-Local Variables](../../../docs/standard/parallel-programming/how-to-write-a-parallel-for-loop-with-thread-local-variables.md)  
 [Lambda Expressions in PLINQ and TPL](../../../docs/standard/parallel-programming/lambda-expressions-in-plinq-and-tpl.md)
