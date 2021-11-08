---
title: Write a simple parallel program using Parallel.ForEach
description: In this article, learn how to enable data parallelism in .NET. Write a Parallel.ForEach loop over any IEnumerable or IEnumerable<T> data source.
ms.date: 02/23/2021
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "foreach, parallel version"
  - "parallel programming, foreach"
ms.assetid: cb5fab92-1c19-499e-ae91-8b7525dd875f
---
# How to: Write a simple Parallel.ForEach loop

This example shows how to use a <xref:System.Threading.Tasks.Parallel.ForEach%2A?displayProperty=nameWithType> loop to enable data parallelism over any <xref:System.Collections.IEnumerable?displayProperty=nameWithType> or <xref:System.Collections.Generic.IEnumerable%601?displayProperty=nameWithType> data source.

> [!NOTE]
> This documentation uses lambda expressions to define delegates in PLINQ. If you are not familiar with lambda expressions in C# or Visual Basic, see [Lambda expressions in PLINQ and TPL](lambda-expressions-in-plinq-and-tpl.md).

## Example

This example demonstrates <xref:System.Threading.Tasks.Parallel.ForEach%2A?displayProperty=nameWithType> for CPU intensive operations. When you run the example, it randomly generates 2 million numbers and tries to filter to prime numbers. The first case iterates over the collection via a `for` loop. The second case iterates over the collection via <xref:System.Threading.Tasks.Parallel.ForEach%2A?displayProperty=nameWithType>. The resulting time taken by each iteration is displayed when the application is finished.

[!code-csharp[TPL_Parallel#03](../../../samples/snippets/csharp/VS_Snippets_Misc/tpl_parallel/cs/simpleforeach.cs#03)]
[!code-vb[TPL_Parallel#03](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpl_parallel/vb/simpleforeach.vb#03)]

A <xref:System.Threading.Tasks.Parallel.ForEach%2A?displayProperty=nameWithType> loop works like a <xref:System.Threading.Tasks.Parallel.For%2A?displayProperty=nameWithType> loop. The loop partitions the source collection and schedules the work on multiple threads based on the system environment. The more processors on the system, the faster the parallel method runs. For some source collections, a sequential loop may be faster, depending on the size of the source and the kind of work the loop performs. For more information about performance, see [Potential pitfalls in data and task parallelism](potential-pitfalls-in-data-and-task-parallelism.md).

For more information about parallel loops, see [How to: Write a simple Parallel.For loop](how-to-write-a-simple-parallel-for-loop.md).

To use <xref:System.Threading.Tasks.Parallel.ForEach%2A?displayProperty=nameWithType> with a non-generic collection, you can use the <xref:System.Linq.Enumerable.Cast%2A?displayProperty=nameWithType> extension method to convert the collection to a generic collection, as shown in the following example:

[!code-csharp[TPL_Parallel#07](../../../samples/snippets/csharp/VS_Snippets_Misc/tpl_parallel/cs/nongeneric.cs#07)]
[!code-vb[TPL_Parallel#07](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpl_parallel/vb/nongeneric.vb#07)]

You can also use Parallel LINQ (PLINQ) to parallelize processing of <xref:System.Collections.Generic.IEnumerable%601> data sources. PLINQ enables you to use declarative query syntax to express the loop behavior. For more information, see [Parallel LINQ (PLINQ)](introduction-to-plinq.md).

## Compile and run the code

You can compile the code as a console application for .NET Framework or as a console application for .NET Core.

In Visual Studio, there are Visual Basic and C# console application templates for Windows Desktop and .NET Core.

From the command line, you can use either the .NET CLI commands (for example, `dotnet new console` or `dotnet new console -lang vb`), or you can create the file and use the command-line compiler for a .NET Framework application.

To run a .NET Core console application from the command line, use `dotnet run` from the folder that contains your application.

To run your console application from Visual Studio, press **F5**.

## See also

- [Data parallelism](data-parallelism-task-parallel-library.md)
- [Parallel programming](index.md)
- [Parallel LINQ (PLINQ)](introduction-to-plinq.md)
