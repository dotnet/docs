---
title: "How to: Use Parallel.Invoke to Execute Parallel Operations"
description: See how to use the Parallel.Invoke method in the Task Parallel Library (TPL), which does parallel operations on a shared data source in .NET.
ms.date: "03/30/2017"
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "task parallelism in .NET"
  - "parallel programming, task parallelism"
ms.assetid: 6b3ecd79-dec9-4ce1-abf4-62e5392a59c6
---
# How to: Use Parallel.Invoke to Execute Parallel Operations

This example shows how to parallelize operations by using <xref:System.Threading.Tasks.Parallel.Invoke%2A> in the Task Parallel Library. Three operations are performed on a shared data source. The operations can be executed in parallel in a straightforward manner, because none of them modifies the source.

> [!NOTE]
> This documentation uses lambda expressions to define delegates in TPL. If you aren't familiar with lambda expressions in C# or Visual Basic, see [Lambda Expressions in PLINQ and TPL](lambda-expressions-in-plinq-and-tpl.md).

## Example

[!code-csharp[TPL_Parallel#06](../../../samples/snippets/csharp/VS_Snippets_Misc/tpl_parallel/cs/parallelinvoke.cs#06)]
[!code-vb[TPL_Parallel#06](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpl_parallel/vb/parallelinvoke.vb#06)]

With <xref:System.Threading.Tasks.Parallel.Invoke%2A>, you simply express which actions you want to run concurrently, and the runtime handles all thread scheduling details, including scaling automatically to the number of cores on the host computer.

This example parallelizes the operations, not the data. As an alternate approach, you can parallelize the LINQ queries by using PLINQ and run the queries sequentially. Alternatively, you could parallelize the data by using PLINQ. Another option is to parallelize both the queries and the tasks. Although the resulting overhead might degrade performance on host computers with relatively few processors, it scales better on computers with many processors.

## Compile the Code

Copy and paste the entire example into a Microsoft Visual Studio project and press <kbd>F5</kbd>.

## See also

- [Parallel Programming](index.md)
- [How to: Cancel a Task and Its Children](how-to-cancel-a-task-and-its-children.md)
- [Parallel LINQ (PLINQ)](introduction-to-plinq.md)
