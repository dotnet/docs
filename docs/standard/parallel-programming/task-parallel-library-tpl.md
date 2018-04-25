---
title: "Task Parallel Library (TPL)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - ".NET, concurrency in"
  - ".NET, parallel programming in"
  - "Parallel Programming"
ms.assetid: b8f99f43-9104-45fd-9bff-385a20488a23
caps.latest.revision: 37
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Task Parallel Library (TPL)
The Task Parallel Library (TPL) is a set of public types and APIs in the <xref:System.Threading?displayProperty=nameWithType> and <xref:System.Threading.Tasks?displayProperty=nameWithType> namespaces. The purpose of the TPL is to make developers more productive by simplifying the process of adding parallelism and concurrency to applications. The TPL scales the degree of concurrency dynamically to most efficiently use all the processors that are available. In addition, the TPL handles the partitioning of the work, the scheduling of threads on the <xref:System.Threading.ThreadPool>, cancellation support, state management, and other low-level details. By using TPL, you can maximize the performance of your code while focusing on the work that your program is designed to accomplish.  
  
 Starting with the [!INCLUDE[net_v40_short](../../../includes/net-v40-short-md.md)], the TPL is the preferred way to write multithreaded and parallel code. However, not all code is suitable for parallelization; for example, if a loop performs only a small amount of work on each iteration, or it doesn't run for many iterations, then the overhead of parallelization can cause the code to run more slowly. Furthermore, parallelization like any multithreaded code adds complexity to your program execution. Although the TPL simplifies multithreaded scenarios, we recommend that you have a basic understanding of threading concepts, for example, locks, deadlocks, and race conditions, so that you can use the TPL effectively.  
  
## Related Topics  
  
|Title|Description|  
|-|-|  
|[Data Parallelism](../../../docs/standard/parallel-programming/data-parallelism-task-parallel-library.md)|Describes how to create parallel `for` and `foreach` loops (`For` and `For Each` in Visual Basic).|  
|[Task-based Asynchronous Programming](../../../docs/standard/parallel-programming/task-based-asynchronous-programming.md)|Describes how to create and run tasks implicitly by using <xref:System.Threading.Tasks.Parallel.Invoke%2A?displayProperty=nameWithType> or explicitly by using <xref:System.Threading.Tasks.Task> objects directly.|  
|[Dataflow](../../../docs/standard/parallel-programming/dataflow-task-parallel-library.md)|Describes how to use the dataflow components in the TPL Dataflow Library to handle multiple operations that must communicate with one another or to process data as it becomes available.|  
|[Using TPL with Other Asynchronous Patterns](../../../docs/standard/parallel-programming/using-tpl-with-other-asynchronous-patterns.md)|Describes how to use TPL with other asynchronous patterns in .NET|  
|[Potential Pitfalls in Data and Task Parallelism](../../../docs/standard/parallel-programming/potential-pitfalls-in-data-and-task-parallelism.md)|Describes some common pitfalls and how to avoid them.|  
|[Parallel LINQ (PLINQ)](../../../docs/standard/parallel-programming/parallel-linq-plinq.md)|Describes how to achieve data parallelism with LINQ queries.|  
|[Parallel Programming](../../../docs/standard/parallel-programming/index.md)|Top level node for .NET parallel programming.|  
  
## See Also  
 [Samples for Parallel Programming with the .NET Framework](https://code.msdn.microsoft.com/Samples-for-Parallel-b4b76364)
