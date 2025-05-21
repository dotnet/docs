---
title: "Parallel Programming in .NET: A guide to the documentation"
description: A list of articles about parallel programming in .NET.
ms.date: 03/03/2022
helpviewer_keywords:
  - "parallel programming"
ms.topic: article
---
# Parallel programming in .NET: A guide to the documentation

Many personal computers and workstations have multiple CPU cores that enable multiple threads to be executed simultaneously. To take advantage of the hardware, you can parallelize your code to distribute work across multiple processors.

In the past, parallelization required low-level manipulation of threads and locks. Visual Studio and .NET enhance support for parallel programming by providing a runtime, class library types, and diagnostic tools. These features, which were introduced in .NET Framework 4, simplify parallel development. You can write efficient, fine-grained, and scalable parallel code in a natural idiom without having to work directly with threads or the thread pool.

The following illustration provides a high-level overview of the parallel programming architecture in .NET.

![.NET Parallel Programming Architecture](./media/tpl-architecture.png)

## Related Topics

|Technology|Description|
|----------------|-----------------|
|[Task Parallel Library (TPL)](task-parallel-library-tpl.md)|Provides documentation for the <xref:System.Threading.Tasks.Parallel?displayProperty=nameWithType> class, which includes parallel versions of `For` and `ForEach` loops, and also for the <xref:System.Threading.Tasks.Task?displayProperty=nameWithType> class, which represents the preferred way to express asynchronous operations.|
|[Parallel LINQ (PLINQ)](introduction-to-plinq.md)|A parallel implementation of LINQ to Objects that significantly improves performance in many scenarios.|
|[Data Structures for Parallel Programming](data-structures-for-parallel-programming.md)|Provides links to documentation for thread-safe collection classes, lightweight synchronization types, and types for lazy initialization.|
|[Parallel Diagnostic Tools](parallel-diagnostic-tools.md)|Provides links to documentation for Visual Studio debugger windows for tasks and parallel stacks, and for the [Concurrency Visualizer](/visualstudio/profiling/concurrency-visualizer).|
|[Custom Partitioners for PLINQ and TPL](custom-partitioners-for-plinq-and-tpl.md)|Describes how partitioners work and how to configure the default partitioners or create a new partitioner.|
|[Task Schedulers](xref:System.Threading.Tasks.TaskScheduler)|Describes how schedulers work and how the default schedulers may be configured.|
|[Lambda Expressions in PLINQ and TPL](lambda-expressions-in-plinq-and-tpl.md)|Provides a brief overview of lambda expressions in C# and Visual Basic, and shows how they are used in PLINQ and the Task Parallel Library.|
|[For Further Reading](for-further-reading-parallel-programming.md)|Provides links to additional information and sample resources for parallel programming in .NET.|

## See also

- [Managed Threading](../threading/managed-threading-basics.md)
- [Asynchronous programming patterns](../asynchronous-programming-patterns/index.md)
