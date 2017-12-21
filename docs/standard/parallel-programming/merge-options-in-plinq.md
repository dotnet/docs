---
title: "Merge Options in PLINQ"
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
  - "PLINQ queries, merge options"
ms.assetid: e8f7be3b-88de-4f33-ab14-dc008e76c1ba
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Merge Options in PLINQ
When a query is executing as parallel, PLINQ partitions the source sequence so that multiple threads can work on different parts concurrently, typically on separate threads. If the results are to be consumed on one thread, for example, in a `foreach` (`For Each` in [!INCLUDE[vbprvb](../../../includes/vbprvb-md.md)]) loop, then the results from every thread must be merged back into one sequence. The kind of merge that PLINQ performs depends on the operators that are present in the query. For example, operators that impose a new order on the results must buffer all elements from all threads. From the perspective of the consuming thread (which is also that of the application user) a fully buffered query might run for a noticeable period of time before it produces its first result. Other operators, by default, are partially buffered; they yield their results in batches. One operator, <xref:System.Linq.ParallelEnumerable.ForAll%2A> is not buffered by default. It yields all elements from all threads immediately.  
  
 By using the <xref:System.Linq.ParallelEnumerable.WithMergeOptions%2A> method, as shown in the following example, you can provide a hint to PLINQ that indicates what kind of merging to perform.  
  
 [!code-csharp[PLINQ#26](../../../samples/snippets/csharp/VS_Snippets_Misc/plinq/cs/plinqsamples.cs#26)]
 [!code-vb[PLINQ#26](../../../samples/snippets/visualbasic/VS_Snippets_Misc/plinq/vb/plinq2_vb.vb#26)]  
  
 For the complete example, see [How to: Specify Merge Options in PLINQ](../../../docs/standard/parallel-programming/how-to-specify-merge-options-in-plinq.md).  
  
 If the particular query cannot support the requested option, then the option will just be ignored. In most cases, you do not have to specify a merge option for a PLINQ query. However, in some cases you may find by testing and measurement that a query executes best in a non-default mode. A common use of this option is to force a chunk-merging operator to stream its results in order to provide a more responsive user interface.  
  
## ParallelMergeOptions  
 The <xref:System.Linq.ParallelMergeOptions> enumeration includes the following options that specify, for supported query shapes, how the final output of the query is yielded when the results are consumed on one thread:  
  
-   `Not Buffered`  
  
     The <xref:System.Linq.ParallelMergeOptions.NotBuffered> option causes each processed element to be returned from each thread as soon as it is produced. This behavior is analogous to "streaming" the output. If the <xref:System.Linq.ParallelEnumerable.AsOrdered%2A> operator is present in the query, `NotBuffered` preserves the order of the source elements. Although `NotBuffered` starts yielding results as soon as they're available,, the total time to produce all the results might still be longer than using one of the other merge options.  
  
-   `Auto Buffered`  
  
     The <xref:System.Linq.ParallelMergeOptions.AutoBuffered> option causes the query to collect elements into a buffer and then periodically yield the buffer contents all at once to the consuming thread. This is analogous to yielding the source data in "chunks" instead of using the "streaming" behavior of `NotBuffered`. `AutoBuffered` may take longer than `NotBuffered` to make the first element available on the consuming thread. The size of the buffer and the exact yielding behavior are not configurable and may vary, depending on various factors that relate to the query.  
  
-   `FullyBuffered`  
  
     The <xref:System.Linq.ParallelMergeOptions.FullyBuffered> option causes the output of the whole query to be buffered before any of the elements are yielded. When you use this option, it can take longer before the first element is available on the consuming thread, but the complete results might still be produced faster than by using the other options.  
  
## Query Operators that Support Merge Options  
 The following table lists the operators that support all merge option modes, subject to the specified restrictions.  
  
|Operator|Restrictions|  
|--------------|------------------|  
|<xref:System.Linq.ParallelEnumerable.AsEnumerable%2A>|None|  
|<xref:System.Linq.ParallelEnumerable.Cast%2A>|None|  
|<xref:System.Linq.ParallelEnumerable.Concat%2A>|Non-ordered queries that have an Array or List source only.|  
|<xref:System.Linq.ParallelEnumerable.DefaultIfEmpty%2A>|None|  
|<xref:System.Linq.ParallelEnumerable.OfType%2A>|None|  
|<xref:System.Linq.ParallelEnumerable.Reverse%2A>|Non-ordered queries that have an Array or List source only.|  
|<xref:System.Linq.ParallelEnumerable.Select%2A>|None|  
|<xref:System.Linq.ParallelEnumerable.SelectMany%2A>|None|  
|<xref:System.Linq.ParallelEnumerable.Skip%2A>|None|  
|<xref:System.Linq.ParallelEnumerable.Take%2A>|None|  
|<xref:System.Linq.ParallelEnumerable.Where%2A>|None|  
  
 All other PLINQ query operators might ignore user-provided merge options. Some query operators, for example, <xref:System.Linq.ParallelEnumerable.Reverse%2A> and <xref:System.Linq.ParallelEnumerable.OrderBy%2A>, cannot yield any elements until all have been produced and reordered. Therefore, when <xref:System.Linq.ParallelMergeOptions> is used in a query that also contains an operator such as <xref:System.Linq.ParallelEnumerable.Reverse%2A>, the merge behavior will not be applied in the query until after that operator has produced its results.  
  
 The ability of some operators to handle merge options depends on the type of the source sequence, and whether the <xref:System.Linq.ParallelEnumerable.AsOrdered%2A> operator was used earlier in the query. <xref:System.Linq.ParallelEnumerable.ForAll%2A> is always <xref:System.Linq.ParallelMergeOptions.NotBuffered> ; it yields its elements immediately. <xref:System.Linq.ParallelEnumerable.OrderBy%2A> is always <xref:System.Linq.ParallelMergeOptions.FullyBuffered>; it must sort the whole list before it yields.  
  
## See Also  
 [Parallel LINQ (PLINQ)](../../../docs/standard/parallel-programming/parallel-linq-plinq.md)  
 [How to: Specify Merge Options in PLINQ](../../../docs/standard/parallel-programming/how-to-specify-merge-options-in-plinq.md)
