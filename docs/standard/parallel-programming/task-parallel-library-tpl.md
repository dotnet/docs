---
title: "Task Parallel Library (TPL)"
description: Explore the Task Parallel Library (TPL), a set of public types and APIs to simplify the process of adding parallelism & concurrency to applications in .NET.
ms.date: "08/01/2022"
ms.custom: devdivchpfy22
helpviewer_keywords: 
  - ".NET, concurrency in"
  - ".NET, parallel programming in"
  - "Parallel Programming"
ms.assetid: b8f99f43-9104-45fd-9bff-385a20488a23
---
# Task Parallel Library (TPL)

The Task Parallel Library (TPL) is a set of public types and APIs in the <xref:System.Threading?displayProperty=nameWithType> and <xref:System.Threading.Tasks?displayProperty=nameWithType> namespaces. The purpose of the TPL is to make developers more productive by simplifying the process of adding parallelism and concurrency to applications. The TPL dynamically scales the degree of concurrency to use all the available processors most efficiently. In addition, the TPL handles the partitioning of the work, the scheduling of threads on the <xref:System.Threading.ThreadPool>, cancellation support, state management, and other low-level details. By using TPL, you can maximize the performance of your code while focusing on the work that your program is designed to accomplish.  
  
 In .NET Framework 4, the TPL is the preferred way to write multithreaded and parallel code. However, not all code is suitable for parallelization. For example, if a loop performs only a small amount of work on each iteration, or it doesn't run for many iterations, then the overhead of parallelization can cause the code to run more slowly. Furthermore, parallelization, like any multithreaded code, adds complexity to your program execution. Although the TPL simplifies multithreaded scenarios, we recommend that you have a basic understanding of threading concepts, for example, locks, deadlocks, and race conditions, so that you can use the TPL effectively.  
  
## Related articles  
  
|Title|Description|  
|-|-|  
|[Data Parallelism](data-parallelism-task-parallel-library.md)|Describes how to create parallel `for` and `foreach` loops (`For` and `For Each` in Visual Basic).|  
|[Task-based Asynchronous Programming](task-based-asynchronous-programming.md)|Describes how to create and run tasks implicitly by using <xref:System.Threading.Tasks.Parallel.Invoke%2A?displayProperty=nameWithType> or explicitly by using <xref:System.Threading.Tasks.Task> objects directly.|  
|[Dataflow](dataflow-task-parallel-library.md)|Describes how to use the dataflow components in the TPL Dataflow Library to handle multiple operations. These operations must communicate with one another and process data as it becomes available.|
|[Potential Pitfalls in Data and Task Parallelism](potential-pitfalls-in-data-and-task-parallelism.md)|Describes some common pitfalls and how to avoid them.|  
|[Parallel LINQ (PLINQ)](introduction-to-plinq.md)|Describes how to achieve data parallelism with LINQ queries.|  
|[Parallel Programming](index.md)|Top-level node for .NET parallel programming.|  
  
## See also

- [Samples for Parallel Programming with the .NET Core & .NET Standard](/samples/browse/?products=dotnet-core%2Cdotnet-standard&term=parallel)
