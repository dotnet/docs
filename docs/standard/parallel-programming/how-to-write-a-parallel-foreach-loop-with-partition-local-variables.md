---
title: "How to: Write a Parallel.ForEach loop with partition-local variables"
description: See an example of how to write a Parallel.ForEach loop that uses partition-local variables in .NET.
ms.date: "06/26/2018"
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "parallel foreach loop, how to use local state"
ms.assetid: 24b10041-b30b-45cb-aa65-66cf568ca76d
---
# How to: Write a Parallel.ForEach loop with partition-local variables

The following example shows how to write a <xref:System.Threading.Tasks.Parallel.ForEach%2A> method that uses partition-local variables. When a <xref:System.Threading.Tasks.Parallel.ForEach%2A> loop executes, it divides its source collection into multiple partitions. Each partition has its own copy of the partition-local variable. A partition-local variable is similar to a [thread-local variable](xref:System.Threading.ThreadLocal%601), except that multiple partitions can run on a single thread.

The code and parameters in this example closely resemble the corresponding <xref:System.Threading.Tasks.Parallel.For%2A> method. For more information, see [How to: Write a Parallel.For Loop with Thread-Local Variables](how-to-write-a-parallel-for-loop-with-thread-local-variables.md).

To use a partition-local variable in a <xref:System.Threading.Tasks.Parallel.ForEach%2A> loop, you must call one of the method overloads that takes two type parameters. The first type parameter, `TSource`, specifies the type of the source element, and the second type parameter, `TLocal`, specifies the type of the partition-local variable.

## Example

The following example calls the <xref:System.Threading.Tasks.Parallel.ForEach%60%602%28System.Collections.Generic.IEnumerable%7B%60%600%7D%2CSystem.Func%7B%60%601%7D%2CSystem.Func%7B%60%600%2CSystem.Threading.Tasks.ParallelLoopState%2C%60%601%2C%60%601%7D%2CSystem.Action%7B%60%601%7D%29?displayProperty=nameWithType> overload to compute the sum of an array of one million elements. This overload has four parameters:

- `source`, which is the data source. It must implement <xref:System.Collections.Generic.IEnumerable%601>. The data source in our example is the one million member `IEnumerable<Int32>` object returned by the <xref:System.Linq.Enumerable.Range%2A?displayProperty=nameWithType> method.

- `localInit`, or the function that initializes the partition-local variable. This function is called once for each partition in which the <xref:System.Threading.Tasks.Parallel.ForEach%2A?displayProperty=nameWithType> operation executes. Our example initializes the partition-local variable to zero.

- `body`, a <xref:System.Func%604> that is invoked by the parallel loop on each iteration of the loop. Its signature is `Func\<TSource, ParallelLoopState, TLocal, TLocal>`. You supply the code for the delegate, and the loop passes in the input parameters, which are:

  - The current element of the <xref:System.Collections.Generic.IEnumerable%601>.

  - A <xref:System.Threading.Tasks.ParallelLoopState> variable that you can use in your delegate's code to examine the state of the loop.

  - The partition-local variable.

  Your delegate returns the partition-local variable, which is then passed to the next iteration of the loop that executes in that particular partition. Each loop partition maintains a separate instance of this variable.

  In the example, the delegate adds the value of each integer to the partition-local variable, which maintains a running total of the values of the integer elements in that partition.

- `localFinally`, an `Action<TLocal>` delegate that the <xref:System.Threading.Tasks.Parallel.ForEach%2A?displayProperty=nameWithType> invokes when the looping operations in each partition have completed. The <xref:System.Threading.Tasks.Parallel.ForEach%2A?displayProperty=nameWithType> method passes your `Action<TLocal>` delegate the final value of the partition-local variable for this loop partition, and you provide the code that performs the required action for combining the result from this partition with the results from the other partitions. This delegate can be invoked concurrently by multiple tasks. Because of this, the example uses the <xref:System.Threading.Interlocked.Add%28System.Int32%40%2CSystem.Int32%29?displayProperty=nameWithType> method to synchronize access to the `total` variable. Because the delegate type is an <xref:System.Action%601>, there is no return value.

[!code-csharp[TPL_Parallel#04](../../../samples/snippets/csharp/VS_Snippets_Misc/tpl_parallel/cs/foreachthreadlocal.cs#04)]
[!code-vb[TPL_Parallel#04](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpl_parallel/vb/foreachthreadlocal.vb#04)]

## See also

- [Data Parallelism](data-parallelism-task-parallel-library.md)
- [How to: Write a Parallel.For Loop with Thread-Local Variables](how-to-write-a-parallel-for-loop-with-thread-local-variables.md)
- [Lambda Expressions in PLINQ and TPL](lambda-expressions-in-plinq-and-tpl.md)
