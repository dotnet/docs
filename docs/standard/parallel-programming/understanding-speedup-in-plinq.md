---
title: "Understanding Speedup in PLINQ"
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
  - "PLINQ queries, performance tuning"
ms.assetid: 53706c7e-397d-467a-98cd-c0d1fd63ba5e
caps.latest.revision: 14
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Understanding Speedup in PLINQ
The primary purpose of PLINQ is to speed up the execution of LINQ to Objects queries by executing the query delegates in parallel on multi-core computers. PLINQ performs best when the processing of each element in a source collection is independent, with no shared state involved among the individual delegates. Such operations are common in LINQ to Objects and PLINQ, and are often called "*delightfully parallel*" because they lend themselves easily to scheduling on multiple threads. However, not all queries consist entirely of delightfully parallel operations; in most cases, a query involves some operators that either cannot be parallelized, or that slow down parallel execution. And even with queries that are entirely delightfully parallel, PLINQ must still partition the data source and schedule the work on the threads, and usually merge the results when the query completes. All these operations add to the computational cost of parallelization; these costs of adding parallelization are called *overhead*. To achieve optimum performance in a PLINQ query, the goal is to maximize the parts that are delightfully parallel and minimize the parts that require overhead. This article provides information that will help you write PLINQ queries that are as efficient as possible while still yielding correct results.  
  
## Factors that Impact PLINQ Query Performance  
 The following sections lists some of the most important factors that impact parallel query performance. These are general statements that by themselves are not sufficient to predict query performance in all cases. As always, it is important to measure actual performance of specific queries on computers with a range of representative configurations and loads.  
  
1.  Computational cost of the overall work.  
  
     To achieve speedup, a PLINQ query must have enough delightfully parallel work to offset the overhead. The work can be expressed as the computational cost of each delegate multiplied by the number of elements in the source collection. Assuming that an operation can be parallelized, the more computationally expensive it is, the greater the opportunity for speedup. For example, if a function takes one millisecond to execute, a sequential query over 1000 elements will take one second to perform that operation, whereas a parallel query on a computer with four cores might take only 250 milliseconds. This yields a speedup of 750 milliseconds. If the function required one second to execute for each element, then the speedup would be 750 seconds. If the delegate is very expensive, then PLINQ might offer significant speedup with only a few items in the source collection. Conversely, small source collections with trivial delegates are generally not good candidates for PLINQ.  
  
     In the following example, queryA is probably a good candidate for PLINQ, assuming that its Select function involves a lot of work. queryB is probably not a good candidate because there is not enough work in the Select statement, and the overhead of parallelization will offset most or all of the speedup.  
  
    ```vb  
    Dim queryA = From num In numberList.AsParallel()  
                 Select ExpensiveFunction(num); 'good for PLINQ  
  
    Dim queryB = From num In numberList.AsParallel()  
                 Where num Mod 2 > 0  
                 Select num; 'not as good for PLINQ  
    ```  
  
    ```csharp  
    var queryA = from num in numberList.AsParallel()  
                 select ExpensiveFunction(num); //good for PLINQ  
  
    var queryB = from num in numberList.AsParallel()  
                 where num % 2 > 0  
                 select num; //not as good for PLINQ  
    ```  
  
2.  The number of logical cores on the system (degree of parallelism).  
  
     This point is an obvious corollary to the previous section, queries that are delightfully parallel run faster on machines with more cores because the work can be divided among more concurrent threads. The overall amount of speedup depends on what percentage of the overall work of the query is parallelizable. However, do not assume that all queries will run twice as fast on an eight core computer as a four core computer. When tuning queries for optimal performance, it is important to measure actual results on computers with various numbers of cores. This point is related to point #1: larger datasets are required to take advantage of greater computing resources.  
  
3.  The number and kind of operations.  
  
     PLINQ provides the AsOrdered operator for situations in which it is necessary to maintain the order of elements in the source sequence. There is a cost associated with ordering, but this cost is usually modest. GroupBy and Join operations likewise incur overhead. PLINQ performs best when it is allowed to process elements in the source collection in any order, and pass them to the next operator as soon as they are ready. For more information, see [Order Preservation in PLINQ](../../../docs/standard/parallel-programming/order-preservation-in-plinq.md).  
  
4.  The form of query execution.  
  
     If you are storing the results of a query by calling ToArray or ToList, then the results from all parallel threads must be merged into the single data structure. This involves an unavoidable computational cost. Likewise, if you iterate the results by using a foreach (For Each in Visual Basic) loop, the results from the worker threads need to be serialized onto the enumerator thread. But if you just want to perform some action based on the result from each thread, you can use the ForAll method to perform this work on multiple threads.  
  
5.  The type of merge options.  
  
     PLINQ can be configured to either buffer its output, and produce it in chunks or all at once after the entire result set is produced, or else to stream individual results as they are produced. The former result is decreased overall execution time and the latter results in decreased latency between yielded elements.  While the merge options do not always have a major impact on overall query performance, they can impact perceived performance because they control how long a user must wait to see results. For more information, see [Merge Options in PLINQ](../../../docs/standard/parallel-programming/merge-options-in-plinq.md).  
  
6.  The kind of partitioning.  
  
     In some cases, a PLINQ query over an indexable source collection may result in an unbalanced work load. When this occurs, you might be able to increase the query performance by creating a custom partitioner. For more information, see [Custom Partitioners for PLINQ and TPL](../../../docs/standard/parallel-programming/custom-partitioners-for-plinq-and-tpl.md).  
  
## When PLINQ Chooses Sequential Mode  
 PLINQ will always attempt to execute a query at least as fast as the query would run sequentially. Although PLINQ does not look at how computationally expensive the user delegates are, or how big the input source is, it does look for certain query "shapes." Specifically, it looks for query operators or combinations of operators that typically cause a query to execute more slowly in parallel mode. When it finds such shapes, PLINQ by default falls back to sequential mode.  
  
 However, after measuring a specific query's performance, you may determine that it actually runs faster in parallel mode. In such cases you can use the <xref:System.Linq.ParallelExecutionMode.ForceParallelism?displayProperty=nameWithType> flag via the <xref:System.Linq.ParallelEnumerable.WithExecutionMode%2A> method to instruct PLINQ to parallelize the query. For more information, see [How to: Specify the Execution Mode in PLINQ](../../../docs/standard/parallel-programming/how-to-specify-the-execution-mode-in-plinq.md).  
  
 The following list describes the query shapes that PLINQ by default will execute in sequential mode:  
  
-   Queries that contain a Select, indexed Where, indexed SelectMany, or ElementAt clause after an ordering or filtering operator that has removed or rearranged original indices.  
  
-   Queries that contain a Take, TakeWhile, Skip, SkipWhile operator and where indices in the source sequence are not in the original order.  
  
-   Queries that contain Zip or SequenceEquals, unless one of the data sources has an originally ordered index and the other data source is indexable (i.e. an array or IList(T)).  
  
-   Queries that contain Concat, unless it is applied to indexable data sources.  
  
-   Queries that contain Reverse, unless applied to an indexable data source.  
  
## See Also  
 [Parallel LINQ (PLINQ)](../../../docs/standard/parallel-programming/parallel-linq-plinq.md)
