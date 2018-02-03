---
title: "Order Preservation in PLINQ"
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
  - "PLINQ queries, order preservation"
ms.assetid: 10d202bc-19e1-4b5c-bbf1-9a977322a9ca
caps.latest.revision: 19
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Order Preservation in PLINQ
In PLINQ, the goal is to maximize performance while maintaining correctness. A query should run as fast as possible but still produce the correct results. In some cases, correctness requires the order of the source sequence to be preserved; however, ordering can be computationally expensive. Therefore, by default, PLINQ does not preserve the order of the source sequence. In this regard, PLINQ resembles [!INCLUDE[vbtecdlinq](../../../includes/vbtecdlinq-md.md)], but is unlike LINQ to Objects, which does preserve ordering.  
  
 To override the default behavior, you can turn on order-preservation by using the <xref:System.Linq.ParallelEnumerable.AsOrdered%2A> operator on the source sequence. You can then turn off order preservation later in the query by using the <xref:System.Linq.ParallelEnumerable.AsUnordered%2A> method. With both methods, the query is processed based on the heuristics that determine whether to execute the query as parallel or as sequential. For more information, see [Understanding Speedup in PLINQ](../../../docs/standard/parallel-programming/understanding-speedup-in-plinq.md).  
  
 The following example shows an unordered parallel query that filters for all the elements that match a condition, without trying to order the results in any way.  
  
 [!code-csharp[PLINQ#8](../../../samples/snippets/csharp/VS_Snippets_Misc/plinq/cs/plinqsamples.cs#8)]
 [!code-vb[PLINQ#8](../../../samples/snippets/visualbasic/VS_Snippets_Misc/plinq/vb/plinq2_vb.vb#8)]  
  
 This query does not necessarily produce the first 1000 cities in the source sequence that meet the condition, but rather some set of 1000 cities that meet the condition. PLINQ query operators partition the source sequence into multiple subsequences that are processed as concurrent tasks. If order preservation is not specified, the results from each partition are handed off to the next stage of the query in an arbitrary order. Also, a partition may yield a subset of its results before it continues to process the remaining elements. The resulting order may be different every time. Your application cannot control this because it depends on how the operating system schedules the threads.  
  
 The following example overrides the default behavior by using the <xref:System.Linq.ParallelEnumerable.AsOrdered%2A> operator on the source sequence. This ensures that the <xref:System.Linq.ParallelEnumerable.Take%2A> method returns the first 1000 cities in the source sequence that meet the condition.  
  
 [!code-csharp[PLINQ#9](../../../samples/snippets/csharp/VS_Snippets_Misc/plinq/cs/plinqsamples.cs#9)]
 [!code-vb[PLINQ#9](../../../samples/snippets/visualbasic/VS_Snippets_Misc/plinq/vb/plinq2_vb.vb#9)]  
  
 However, this query probably does not run as fast as the unordered version because it must keep track of the original ordering throughout the partitions and at merge time ensure that the ordering is consistent. Therefore, we recommend that you use <xref:System.Linq.ParallelEnumerable.AsOrdered%2A> only when it is required, and only for those parts of the query that require it. When order preservation is no longer required, use <xref:System.Linq.ParallelEnumerable.AsUnordered%2A> to turn it off. The following example achieves this by composing two queries.  
  
 [!code-csharp[PLINQ#6](../../../samples/snippets/csharp/VS_Snippets_Misc/plinq/cs/plinqsamples.cs#6)]
 [!code-vb[PLINQ#6](../../../samples/snippets/visualbasic/VS_Snippets_Misc/plinq/vb/plinq2_vb.vb#6)]  
  
 Note that PLINQ preserves the ordering of a sequence produced by order-imposing operators for the rest of the query. In other words, operators such as <xref:System.Linq.ParallelEnumerable.OrderBy%2A> and <xref:System.Linq.ParallelEnumerable.ThenBy%2A> are treated as if they were followed by a call to <xref:System.Linq.ParallelEnumerable.AsOrdered%2A>.  
  
## Query Operators and Ordering  
 The following query operators introduce order preservation into all subsequent operations in a query, or until <xref:System.Linq.ParallelEnumerable.AsUnordered%2A> is called:  
  
-   <xref:System.Linq.ParallelEnumerable.OrderBy%2A>  
  
-   <xref:System.Linq.ParallelEnumerable.OrderByDescending%2A>  
  
-   <xref:System.Linq.ParallelEnumerable.ThenBy%2A>  
  
-   <xref:System.Linq.ParallelEnumerable.ThenByDescending%2A>  
  
 The following PLINQ query operators may in some cases require ordered source sequences to produce correct results:  
  
-   <xref:System.Linq.ParallelEnumerable.Reverse%2A>  
  
-   <xref:System.Linq.ParallelEnumerable.SequenceEqual%2A>  
  
-   <xref:System.Linq.ParallelEnumerable.TakeWhile%2A>  
  
-   <xref:System.Linq.ParallelEnumerable.SkipWhile%2A>  
  
-   <xref:System.Linq.ParallelEnumerable.Zip%2A>  
  
 Some PLINQ query operators behave differently, depending on whether their source sequence is ordered or unordered. The following table lists these operators.  
  
|Operator|Result when the source sequence is ordered|Result when the source sequence is unordered|  
|--------------|------------------------------------------------|--------------------------------------------------|  
|<xref:System.Linq.ParallelEnumerable.Aggregate%2A>|Nondeterministic output for nonassociative or noncommutative operations|Nondeterministic output for nonassociative or noncommutative operations|  
|<xref:System.Linq.ParallelEnumerable.All%2A>|Not applicable|Not applicable|  
|<xref:System.Linq.ParallelEnumerable.Any%2A>|Not applicable|Not applicable|  
|<xref:System.Linq.ParallelEnumerable.AsEnumerable%2A>|Not applicable|Not applicable|  
|<xref:System.Linq.ParallelEnumerable.Average%2A>|Nondeterministic output for nonassociative or noncommutative operations|Nondeterministic output for nonassociative or noncommutative operations|  
|<xref:System.Linq.ParallelEnumerable.Cast%2A>|Ordered results|Unordered results|  
|<xref:System.Linq.ParallelEnumerable.Concat%2A>|Ordered results|Unordered results|  
|<xref:System.Linq.ParallelEnumerable.Count%2A>|Not applicable|Not applicable|  
|<xref:System.Linq.ParallelEnumerable.DefaultIfEmpty%2A>|Not applicable|Not applicable|  
|<xref:System.Linq.ParallelEnumerable.Distinct%2A>|Ordered results|Unordered results|  
|<xref:System.Linq.ParallelEnumerable.ElementAt%2A>|Return specified element|Arbitrary element|  
|<xref:System.Linq.ParallelEnumerable.ElementAtOrDefault%2A>|Return specified element|Arbitrary element|  
|<xref:System.Linq.ParallelEnumerable.Except%2A>|Unordered results|Unordered results|  
|<xref:System.Linq.ParallelEnumerable.First%2A>|Return specified element|Arbitrary element|  
|<xref:System.Linq.ParallelEnumerable.FirstOrDefault%2A>|Return specified element|Arbitrary element|  
|<xref:System.Linq.ParallelEnumerable.ForAll%2A>|Executes nondeterministically in parallel|Executes nondeterministically in parallel|  
|<xref:System.Linq.ParallelEnumerable.GroupBy%2A>|Ordered results|Unordered results|  
|<xref:System.Linq.ParallelEnumerable.GroupJoin%2A>|Ordered results|Unordered results|  
|<xref:System.Linq.ParallelEnumerable.Intersect%2A>|Ordered results|Unordered results|  
|<xref:System.Linq.ParallelEnumerable.Join%2A>|Ordered results|Unordered results|  
|<xref:System.Linq.ParallelEnumerable.Last%2A>|Return specified element|Arbitrary element|  
|<xref:System.Linq.ParallelEnumerable.LastOrDefault%2A>|Return specified element|Arbitrary element|  
|<xref:System.Linq.ParallelEnumerable.LongCount%2A>|Not applicable|Not applicable|  
|<xref:System.Linq.ParallelEnumerable.Min%2A>|Not applicable|Not applicable|  
|<xref:System.Linq.ParallelEnumerable.OrderBy%2A>|Reorders the sequence|Starts new ordered section|  
|<xref:System.Linq.ParallelEnumerable.OrderByDescending%2A>|Reorders the sequence|Starts new ordered section|  
|<xref:System.Linq.ParallelEnumerable.Range%2A>|Not applicable (same default as <xref:System.Linq.ParallelEnumerable.AsParallel%2A> )|Not applicable|  
|<xref:System.Linq.ParallelEnumerable.Repeat%2A>|Not applicable (same default as <xref:System.Linq.ParallelEnumerable.AsParallel%2A>)|Not applicable|  
|<xref:System.Linq.ParallelEnumerable.Reverse%2A>|Reverses|Does nothing|  
|<xref:System.Linq.ParallelEnumerable.Select%2A>|Ordered results|Unordered results|  
|<xref:System.Linq.ParallelEnumerable.Select%2A> (indexed)|Ordered results|Unordered results.|  
|<xref:System.Linq.ParallelEnumerable.SelectMany%2A>|Ordered results.|Unordered results|  
|<xref:System.Linq.ParallelEnumerable.SelectMany%2A> (indexed)|Ordered results.|Unordered results.|  
|<xref:System.Linq.ParallelEnumerable.SequenceEqual%2A>|Ordered comparison|Unordered comparison|  
|<xref:System.Linq.ParallelEnumerable.Single%2A>|Not applicable|Not applicable|  
|<xref:System.Linq.ParallelEnumerable.SingleOrDefault%2A>|Not applicable|Not applicable|  
|<xref:System.Linq.ParallelEnumerable.Skip%2A>|Skips first *n* elements|Skips any *n* elements|  
|<xref:System.Linq.ParallelEnumerable.SkipWhile%2A>|Ordered results.|Nondeterministic. Performs SkipWhile on the current arbitrary order|  
|<xref:System.Linq.ParallelEnumerable.Sum%2A>|Nondeterministic output for nonassociative or noncommutative operations|Nondeterministic output for nonassociative or noncommutative operations|  
|<xref:System.Linq.ParallelEnumerable.Take%2A>|Takes first `n` elements|Takes any `n` elements|  
|<xref:System.Linq.ParallelEnumerable.TakeWhile%2A>|Ordered results|Nondeterministic. Performs TakeWhile on the current arbitrary order|  
|<xref:System.Linq.ParallelEnumerable.ThenBy%2A>|Supplements `OrderBy`|Supplements `OrderBy`|  
|<xref:System.Linq.ParallelEnumerable.ThenByDescending%2A>|Supplements `OrderBy`|Supplements `OrderBy`|  
|<xref:System.Linq.ParallelEnumerable.ToArray%2A>|Ordered results|Unordered results|  
|<xref:System.Linq.ParallelEnumerable.ToDictionary%2A>|Not applicable|Not applicable|  
|<xref:System.Linq.ParallelEnumerable.ToList%2A>|Ordered results|Unordered results|  
|<xref:System.Linq.ParallelEnumerable.ToLookup%2A>|Ordered results|Unordered results|  
|<xref:System.Linq.ParallelEnumerable.Union%2A>|Ordered results|Unordered results|  
|<xref:System.Linq.ParallelEnumerable.Where%2A>|Ordered results|Unordered results|  
|<xref:System.Linq.ParallelEnumerable.Where%2A> (indexed)|Ordered results|Unordered results|  
|<xref:System.Linq.ParallelEnumerable.Zip%2A>|Ordered results|Unordered results|  
  
 Unordered results are not actively shuffled; they simply do not have any special ordering logic applied to them. In some cases, an unordered query may retain the ordering of the source sequence. For queries that use the indexed Select operator, PLINQ guarantees that the output elements will come out in the order of increasing indices, but makes no guarantees about which indices will be assigned to which elements.  
  
## See Also  
 [Parallel LINQ (PLINQ)](../../../docs/standard/parallel-programming/parallel-linq-plinq.md)  
 [Parallel Programming](../../../docs/standard/parallel-programming/index.md)
