---
title: "Potential Pitfalls with PLINQ"
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
  - "PLINQ queries, pitfalls"
ms.assetid: 75a38b55-4bc4-488a-87d5-89dbdbdc76a2
caps.latest.revision: 13
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Potential Pitfalls with PLINQ
In many cases, PLINQ can provide significant performance improvements over sequential LINQ to Objects queries. However, the work of parallelizing the query execution introduces complexity that can lead to problems that, in sequential code, are not as common or are not encountered at all. This topic lists some practices to avoid when you write PLINQ queries.  
  
## Do Not Assume That Parallel Is Always Faster  
 Parallelization sometimes causes a PLINQ query to run slower than its LINQ to Objects equivalent. The basic rule of thumb is that queries that have few source elements and fast user delegates are unlikely to speedup much. However, because many factors are involved in performance, we recommend that you measure actual results before you decide whether to use PLINQ. For more information, see [Understanding Speedup in PLINQ](../../../docs/standard/parallel-programming/understanding-speedup-in-plinq.md).  
  
## Avoid Writing to Shared Memory Locations  
 In sequential code, it is not uncommon to read from or write to static variables or class fields. However, whenever multiple threads are accessing such variables concurrently, there is a big potential for race conditions. Even though you can use locks to synchronize access to the variable, the cost of synchronization can hurt performance. Therefore, we recommend that you avoid, or at least limit, access to shared state in a PLINQ query as much as possible.  
  
## Avoid Over-Parallelization  
 By using the `AsParallel` operator, you incur the overhead costs of partitioning the source collection and synchronizing the worker threads. The benefits of parallelization are further limited by the number of processors on the computer. There is no speedup to be gained by running multiple compute-bound threads on just one processor. Therefore, you must be careful not to over-parallelize a query.  
  
 The most common scenario in which over-parallelization can occur is in nested queries, as shown in the following snippet.  
  
 [!code-csharp[PLINQ#20](../../../samples/snippets/csharp/VS_Snippets_Misc/plinq/cs/plinqsamples.cs#20)]
 [!code-vb[PLINQ#20](../../../samples/snippets/visualbasic/VS_Snippets_Misc/plinq/vb/plinq2_vb.vb#20)]  
  
 In this case, it is best to parallelize only the outer data source (customers) unless one or more of the following conditions apply:  
  
-   The inner data source (cust.Orders) is known to be very long.  
  
-   You are performing an expensive computation on each order. (The operation shown in the example is not expensive.)  
  
-   The target system is known to have enough processors to handle the number of threads that will be produced by parallelizing the query on `cust.Orders`.  
  
 In all cases, the best way to determine the optimum query shape is to test and measure. For more information, see [How to: Measure PLINQ Query Performance](../../../docs/standard/parallel-programming/how-to-measure-plinq-query-performance.md).  
  
## Avoid Calls to Non-Thread-Safe Methods  
 Writing to non-thread-safe instance methods from a PLINQ query can lead to data corruption which may or may not go undetected in your program. It can also lead to exceptions. In the following example, multiple threads would be attempting to call the `Filestream.Write` method simultaneously, which is not supported by the class.  
  
```vb  
Dim fs As FileStream = File.OpenWrite(…)  
a.Where(...).OrderBy(...).Select(...).ForAll(Sub(x) fs.Write(x))  
```  
  
```csharp  
FileStream fs = File.OpenWrite(...);  
a.Where(...).OrderBy(...).Select(...).ForAll(x => fs.Write(x));  
```  
  
## Limit Calls to Thread-Safe Methods  
 Most static methods in the .NET Framework are thread-safe and can be called from multiple threads concurrently. However, even in these cases, the synchronization involved can lead to significant slowdown in the query.  
  
> [!NOTE]
>  You can test for this yourself by inserting some calls to <xref:System.Console.WriteLine%2A> in your queries. Although this method is used in the documentation examples for demonstration purposes, do not use it in PLINQ queries.  
  
## Avoid Unnecessary Ordering Operations  
 When PLINQ executes a query in parallel, it divides the source sequence into partitions that can be operated on concurrently on multiple threads. By default, the order in which the partitions are processed and the results are delivered is not predictable (except for operators such as `OrderBy`). You can instruct PLINQ to preserve the ordering of any source sequence, but this has a negative impact on performance. The best practice, whenever possible, is to structure queries so that they do not rely on order preservation. For more information, see [Order Preservation in PLINQ](../../../docs/standard/parallel-programming/order-preservation-in-plinq.md).  
  
## Prefer ForAll to ForEach When It Is Possible  
 Although PLINQ executes a query on multiple threads, if you consume the results in a `foreach` loop (`For Each` in Visual Basic), then the query results must be merged back into one thread and accessed serially by the enumerator. In some cases, this is unavoidable; however, whenever possible, use the `ForAll` method to enable each thread to output its own results, for example, by writing to a thread-safe collection such as <xref:System.Collections.Concurrent.ConcurrentBag%601?displayProperty=nameWithType>.  
  
 The same issue applies to <xref:System.Threading.Tasks.Parallel.ForEach%2A?displayProperty=nameWithType> In other words, `source.AsParallel().Where().ForAll(...)` should be strongly preferred to  
  
 `Parallel.ForEach(source.AsParallel().Where(), ...)`.  
  
## Be Aware of Thread Affinity Issues  
 Some technologies, for example, COM interoperability for Single-Threaded Apartment (STA) components, Windows Forms, and Windows Presentation Foundation (WPF), impose thread affinity restrictions that require code to run on a specific thread. For example, in both Windows Forms and WPF, a control can only be accessed on the thread on which it was created. If you try to access the shared state of a Windows Forms control in a PLINQ query, an exception is raised if you are running in the debugger. (This setting can be turned off.) However, if your query is consumed on the UI thread, then you can access the control from the `foreach` loop that enumerates the query results because that code executes on just one thread.  
  
## Do Not Assume that Iterations of ForEach, For and ForAll Always Execute in Parallel  
 It is important to keep in mind that individual iterations in a <xref:System.Threading.Tasks.Parallel.For%2A?displayProperty=nameWithType>, <xref:System.Threading.Tasks.Parallel.ForEach%2A?displayProperty=nameWithType> or <xref:System.Linq.ParallelEnumerable.ForAll%2A> loop may but do not have to execute in parallel. Therefore, you should avoid writing any code that depends for correctness on parallel execution of iterations or on the execution of iterations in any particular order.  
  
 For example, this code is likely to deadlock:  
  
```vb  
Dim mre = New ManualResetEventSlim()  
    Enumerable.Range(0, ProcessorCount * 100).AsParallel().ForAll(Sub(j)   
  
                                                     If j = Environment.ProcessorCount Then  
  
                                                         Console.WriteLine("Set on {0} with value of {1}", Thread.CurrentThread.ManagedThreadId, j)  
                                                         mre.Set()  
  
                                                     Else  
  
                                                         Console.WriteLine("Waiting on {0} with value of {1}", Thread.CurrentThread.ManagedThreadId, j)  
                                                         mre.Wait()  
                                                     End If  
    End Sub) ' deadlocks  
```  
  
```csharp  
ManualResetEventSlim mre = new ManualResetEventSlim();  
            Enumerable.Range(0, ProcessorCount * 100).AsParallel().ForAll((j) =>  
            {  
                if (j == Environment.ProcessorCount)  
                {  
                    Console.WriteLine("Set on {0} with value of {1}", Thread.CurrentThread.ManagedThreadId, j);  
                    mre.Set();  
                }  
                else  
                {  
                    Console.WriteLine("Waiting on {0} with value of {1}", Thread.CurrentThread.ManagedThreadId, j);  
                    mre.Wait();  
                }  
            }); //deadlocks  
```  
  
 In this example, one iteration sets an event, and all other iterations wait on the event. None of the waiting iterations can complete until the event-setting iteration has completed. However, it is possible that the waiting iterations block all threads that are used to execute the parallel loop, before the event-setting iteration has had a chance to execute. This results in a deadlock – the event-setting iteration will never execute, and the waiting iterations will never wake up.  
  
 In particular, one iteration of a parallel loop should never wait on another iteration of the loop to make progress. If the parallel loop decides to schedule the iterations sequentially but in the opposite order, a deadlock will occur.  
  
## See Also  
 [Parallel LINQ (PLINQ)](../../../docs/standard/parallel-programming/parallel-linq-plinq.md)
