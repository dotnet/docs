---
title: "Parallel Programming in .NET"
ms.date: 09/12/2018
ms.technology: dotnet-standard
helpviewer_keywords:
  - "parallel programming"
ms.assetid: 4d83c690-ad2d-489e-a2e0-b85b898a672d
author: "rpetrusha"
ms.author: "ronpet"
---
# Parallel Programming in .NET

Many personal computers and workstations have multiple CPU cores that enable multiple threads to be executed simultaneously. To take advantage of the hardware, you can parallelize your code to distribute work across multiple processors.

In the past, parallelization required low-level manipulation of threads and locks. Visual Studio and the .NET Framework enhance support for parallel programming by providing a runtime, class library types, and diagnostic tools. These features, which were introduced with the .NET Framework 4, simplify parallel development. You can write efficient, fine-grained, and scalable parallel code in a natural idiom without having to work directly with threads or the thread pool.

The following illustration provides a high-level overview of the parallel programming architecture in the .NET Framework:

![.NET Parallel Programming Architecture](./media/tpl-architecture.png)

## Related Topics

|Technology|Description|
|----------------|-----------------|
|[Task Parallel Library (TPL)](../../../docs/standard/parallel-programming/task-parallel-library-tpl.md)|Provides documentation for the <xref:System.Threading.Tasks.Parallel?displayProperty=nameWithType> class, which includes parallel versions of `For` and `ForEach` loops, and also for the <xref:System.Threading.Tasks.Task?displayProperty=nameWithType> class, which represents the preferred way to express asynchronous operations.|
|[Parallel LINQ (PLINQ)](../../../docs/standard/parallel-programming/parallel-linq-plinq.md)|A parallel implementation of LINQ to Objects that significantly improves performance in many scenarios.|
|[Data Structures for Parallel Programming](../../../docs/standard/parallel-programming/data-structures-for-parallel-programming.md)|Provides links to documentation for thread-safe collection classes, lightweight synchronization types, and types for lazy initialization.|
|[Parallel Diagnostic Tools](../../../docs/standard/parallel-programming/parallel-diagnostic-tools.md)|Provides links to documentation for Visual Studio debugger windows for tasks and parallel stacks, and for the [Concurrency Visualizer](/visualstudio/profiling/concurrency-visualizer).|
|[Custom Partitioners for PLINQ and TPL](../../../docs/standard/parallel-programming/custom-partitioners-for-plinq-and-tpl.md)|Describes how partitioners work and how to configure the default partitioners or create a new partitioner.|
|[Task Schedulers](https://msdn.microsoft.com/library/638f8ea5-21db-47a2-a934-86e1e961bf65)|Describes how schedulers work and how the default schedulers may be configured.|
|[Lambda Expressions in PLINQ and TPL](../../../docs/standard/parallel-programming/lambda-expressions-in-plinq-and-tpl.md)|Provides a brief overview of lambda expressions in C# and Visual Basic, and shows how they are used in PLINQ and the Task Parallel Library.|
|[For Further Reading](../../../docs/standard/parallel-programming/for-further-reading-parallel-programming.md)|Provides links to additional information and sample resources for parallel programming in .NET.|

## See also

- [Async Overview](../async.md)
- [Managed Threading](../threading/index.md)
