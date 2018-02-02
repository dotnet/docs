---
title: "Threading (C#)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
ms.assetid: 236d157d-37c0-4ee8-89fc-721e6c596325
caps.latest.revision: 4
author: "BillWagner"
ms.author: "wiwagn"
---
# Threading (C#)
Threading enables your C# program to perform concurrent processing so that you can do more than one operation at a time. For example, you can use threading to monitor input from the user, perform background tasks, and handle simultaneous streams of input.  
  
 Threads have the following properties:  
  
-   Threads enable your program to perform concurrent processing.  
  
-   The .NET Framework <xref:System.Threading> namespace makes using threads easier.  
  
-   Threads share the application's resources. For more information, see [Using Threads and Threading](../../../../../docs/standard/threading/using-threads-and-threading.md).  
  
 By default, a C# program has one thread. However, auxiliary threads can be created and used to execute code in parallel with the primary thread. These threads are often called *worker threads*.  
  
 Worker threads can be used to perform time-consuming or time-critical tasks without tying up the primary thread. For example, worker threads are often used in server applications to fulfill incoming requests without waiting for the previous request to be completed. Worker threads are also used to perform "background" tasks in desktop applications so that the main thread--which drives user interface elements--remains responsive to user actions.  
  
 Threading solves problems with throughput and responsiveness, but it can also introduce resource-sharing issues such as deadlocks and race conditions. Multiple threads are best for tasks that require different resources such as file handles and network connections. Assigning multiple threads to a single resource is likely to cause synchronization issues, and having threads frequently blocked when waiting for other threads defeats the purpose of using multiple threads.  
  
 A common strategy is to use worker threads to perform time-consuming or time-critical tasks that do not require many of the resources used by other threads. Naturally, some resources in your program must be accessed by multiple threads. For these cases, the <xref:System.Threading> namespace provides classes for synchronizing threads. These classes include <xref:System.Threading.Mutex>, <xref:System.Threading.Monitor>, <xref:System.Threading.Interlocked>, <xref:System.Threading.AutoResetEvent>, and <xref:System.Threading.ManualResetEvent>.  
  
 You can use some or all these classes to synchronize the activities of multiple threads, but some support for threading is supported by the C# language. For example, the [Lock Statement](../../../../csharp/language-reference/keywords/lock-statement.md) provides synchronization features through implicit use of <xref:System.Threading.Monitor>.  
  
> [!NOTE]
>  Beginning with the [!INCLUDE[net_v40_long](~/includes/net-v40-long-md.md)], multithreaded programming is greatly simplified with the <xref:System.Threading.Tasks.Parallel?displayProperty=nameWithType> and <xref:System.Threading.Tasks.Task?displayProperty=nameWithType> classes, [Parallel LINQ (PLINQ)](https://msdn.microsoft.com/library/dd460688), new concurrent collection classes in the <xref:System.Collections.Concurrent?displayProperty=nameWithType> namespace, and a new programming model that is based on the concept of tasks rather than threads. For more information, see [Parallel Programming](../../../../../docs/standard/parallel-programming/index.md).  
  
## Related Topics  
  
|Title|Description|  
|-----------|-----------------|  
|[Multithreaded Applications (C#)](../../../../csharp/programming-guide/concepts/threading/multithreaded-applications.md)|Describes how to create and use threads.|  
|[Parameters and Return Values for Multithreaded Procedures (C#)](../../../../csharp/programming-guide/concepts/threading/parameters-and-return-values-for-multithreaded-procedures.md)|Describes how to pass and return parameters with multithreaded applications.|  
|[Walkthrough: Multithreading with the BackgroundWorker Component (C#)](../../../../csharp/programming-guide/concepts/threading/walkthrough-multithreading-with-the-backgroundworker-component.md)|Shows how to create a simple multithreaded application.|  
|[Thread Synchronization (C#)](../../../../csharp/programming-guide/concepts/threading/thread-synchronization.md)|Describes how to control the interactions of threads.|  
|[Thread Timers (C#)](../../../../csharp/programming-guide/concepts/threading/thread-timers.md)|Describes how to run procedures on separate threads at fixed intervals.|  
|[Thread Pooling (C#)](../../../../csharp/programming-guide/concepts/threading/thread-pooling.md)|Describes how to use a pool of worker threads that are managed by the system.|  
|[How to: Use a Thread Pool (C#)](../../../../csharp/programming-guide/concepts/threading/how-to-use-a-thread-pool.md)|Demonstrates synchronized use of multiple threads in the thread pool.|  
|[Threading](../../../../../docs/standard/threading/index.md)|Describes how to implement threading in the .NET Framework.|
