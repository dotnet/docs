---
description: "Learn more about: Order Preservation in PLINQ"
title: "Order Preservation in PLINQ"
ms.date: "03/30/2017"
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "PLINQ queries, order preservation"
ms.assetid: 10d202bc-19e1-4b5c-bbf1-9a977322a9ca
---
# Order Preservation in PLINQ

In PLINQ, the goal is to maximize performance while maintaining correctness. A query should run as fast as possible but still produce the correct results. In some cases, correctness requires the order of the source sequence to be preserved; however, ordering can be computationally expensive. Therefore, by default, PLINQ does not preserve the order of the source sequence. In this regard, PLINQ resembles [!INCLUDE[vbtecdlinq](../../../includes/vbtecdlinq-md.md)], but is unlike LINQ to Objects, which does preserve ordering.

 To override the default behavior, you can turn on order-preservation by using the <xref:System.Linq.ParallelEnumerable.AsOrdered*> operator on the source sequence. You can then turn off order preservation later in the query by using the <xref:System.Linq.ParallelEnumerable.AsUnordered*> method. With both methods, the query is processed based on the heuristics that determine whether to execute the query as parallel or as sequential. For more information, see [Understanding Speedup in PLINQ](understanding-speedup-in-plinq.md).

 The following example shows an unordered parallel query that filters for all the elements that match a condition, without trying to order the results in any way.

 [!code-csharp[PLINQ#8](../../../samples/snippets/csharp/VS_Snippets_Misc/plinq/cs/plinqsamples.cs#8)]
 [!code-vb[PLINQ#8](../../../samples/snippets/visualbasic/VS_Snippets_Misc/plinq/vb/plinq2_vb.vb#8)]

 This query does not necessarily produce the first 1000 cities in the source sequence that meet the condition, but rather some set of 1000 cities that meet the condition. PLINQ query operators partition the source sequence into multiple subsequences that are processed as concurrent tasks. If order preservation is not specified, the results from each partition are handed off to the next stage of the query in an arbitrary order. Also, a partition may yield a subset of its results before it continues to process the remaining elements. The resulting order may be different every time. Your application cannot control this because it depends on how the operating system schedules the threads.

 The following example overrides the default behavior by using the <xref:System.Linq.ParallelEnumerable.AsOrdered*> operator on the source sequence. This ensures that the <xref:System.Linq.ParallelEnumerable.Take*> method returns the first 1000 cities in the source sequence that meet the condition.

 [!code-csharp[PLINQ#9](../../../samples/snippets/csharp/VS_Snippets_Misc/plinq/cs/plinqsamples.cs#9)]
 [!code-vb[PLINQ#9](../../../samples/snippets/visualbasic/VS_Snippets_Misc/plinq/vb/plinq2_vb.vb#9)]

 However, this query probably does not run as fast as the unordered version because it must keep track of the original ordering throughout the partitions and at merge time ensure that the ordering is consistent. Therefore, we recommend that you use <xref:System.Linq.ParallelEnumerable.AsOrdered*> only when it is required, and only for those parts of the query that require it. When order preservation is no longer required, use <xref:System.Linq.ParallelEnumerable.AsUnordered*> to turn it off. The following example achieves this by composing two queries.

 [!code-csharp[PLINQ#6](../../../samples/snippets/csharp/VS_Snippets_Misc/plinq/cs/plinqsamples.cs#6)]
 [!code-vb[PLINQ#6](../../../samples/snippets/visualbasic/VS_Snippets_Misc/plinq/vb/plinq2_vb.vb#6)]

 Note that PLINQ preserves the ordering of a sequence produced by order-imposing operators for the rest of the query. In other words, operators such as <xref:System.Linq.ParallelEnumerable.OrderBy*> and <xref:System.Linq.ParallelEnumerable.ThenBy*> are treated as if they were followed by a call to <xref:System.Linq.ParallelEnumerable.AsOrdered*>.

## Query Operators and Ordering

 The following query operators introduce order preservation into all subsequent operations in a query, or until <xref:System.Linq.ParallelEnumerable.AsUnordered*> is called:

- <xref:System.Linq.ParallelEnumerable.OrderBy*>

- <xref:System.Linq.ParallelEnumerable.OrderByDescending*>

- <xref:System.Linq.ParallelEnumerable.ThenBy*>

- <xref:System.Linq.ParallelEnumerable.ThenByDescending*>

 The following PLINQ query operators may in some cases require ordered source sequences to produce correct results:

- <xref:System.Linq.ParallelEnumerable.Reverse*>

- <xref:System.Linq.ParallelEnumerable.SequenceEqual*>

- <xref:System.Linq.ParallelEnumerable.TakeWhile*>

- <xref:System.Linq.ParallelEnumerable.SkipWhile*>

- <xref:System.Linq.ParallelEnumerable.Zip*>

 Some PLINQ query operators behave differently, depending on whether their source sequence is ordered or unordered. The following table lists these operators.

|Operator|Result when the source sequence is ordered|Result when the source sequence is unordered|
|--------------|------------------------------------------------|--------------------------------------------------|
|<xref:System.Linq.ParallelEnumerable.Aggregate*>|Nondeterministic output for nonassociative or noncommutative operations|Nondeterministic output for nonassociative or noncommutative operations|
|<xref:System.Linq.ParallelEnumerable.All*>|Not applicable|Not applicable|
|<xref:System.Linq.ParallelEnumerable.Any*>|Not applicable|Not applicable|
|<xref:System.Linq.ParallelEnumerable.AsEnumerable*>|Not applicable|Not applicable|
|<xref:System.Linq.ParallelEnumerable.Average*>|Nondeterministic output for nonassociative or noncommutative operations|Nondeterministic output for nonassociative or noncommutative operations|
|<xref:System.Linq.ParallelEnumerable.Cast*>|Ordered results|Unordered results|
|<xref:System.Linq.ParallelEnumerable.Concat*>|Ordered results|Unordered results|
|<xref:System.Linq.ParallelEnumerable.Count*>|Not applicable|Not applicable|
|<xref:System.Linq.ParallelEnumerable.DefaultIfEmpty*>|Not applicable|Not applicable|
|<xref:System.Linq.ParallelEnumerable.Distinct*>|Ordered results|Unordered results|
|<xref:System.Linq.ParallelEnumerable.ElementAt*>|Return specified element|Arbitrary element|
|<xref:System.Linq.ParallelEnumerable.ElementAtOrDefault*>|Return specified element|Arbitrary element|
|<xref:System.Linq.ParallelEnumerable.Except*>|Unordered results|Unordered results|
|<xref:System.Linq.ParallelEnumerable.First*>|Return specified element|Arbitrary element|
|<xref:System.Linq.ParallelEnumerable.FirstOrDefault*>|Return specified element|Arbitrary element|
|<xref:System.Linq.ParallelEnumerable.ForAll*>|Executes nondeterministically in parallel|Executes nondeterministically in parallel|
|<xref:System.Linq.ParallelEnumerable.GroupBy*>|Ordered results|Unordered results|
|<xref:System.Linq.ParallelEnumerable.GroupJoin*>|Ordered results|Unordered results|
|<xref:System.Linq.ParallelEnumerable.Intersect*>|Ordered results|Unordered results|
|<xref:System.Linq.ParallelEnumerable.Join*>|Ordered results|Unordered results|
|<xref:System.Linq.ParallelEnumerable.Last*>|Return specified element|Arbitrary element|
|<xref:System.Linq.ParallelEnumerable.LastOrDefault*>|Return specified element|Arbitrary element|
|<xref:System.Linq.ParallelEnumerable.LongCount*>|Not applicable|Not applicable|
|<xref:System.Linq.ParallelEnumerable.Min*>|Not applicable|Not applicable|
|<xref:System.Linq.ParallelEnumerable.OrderBy*>|Reorders the sequence|Starts new ordered section|
|<xref:System.Linq.ParallelEnumerable.OrderByDescending*>|Reorders the sequence|Starts new ordered section|
|<xref:System.Linq.ParallelEnumerable.Range*>|Not applicable (same default as <xref:System.Linq.ParallelEnumerable.AsParallel*> )|Not applicable|
|<xref:System.Linq.ParallelEnumerable.Repeat*>|Not applicable (same default as <xref:System.Linq.ParallelEnumerable.AsParallel*>)|Not applicable|
|<xref:System.Linq.ParallelEnumerable.Reverse*>|Reverses|Does nothing|
|<xref:System.Linq.ParallelEnumerable.Select*>|Ordered results|Unordered results|
|<xref:System.Linq.ParallelEnumerable.Select*> (indexed)|Ordered results|Unordered results.|
|<xref:System.Linq.ParallelEnumerable.SelectMany*>|Ordered results.|Unordered results|
|<xref:System.Linq.ParallelEnumerable.SelectMany*> (indexed)|Ordered results.|Unordered results.|
|<xref:System.Linq.ParallelEnumerable.SequenceEqual*>|Ordered comparison|Unordered comparison|
|<xref:System.Linq.ParallelEnumerable.Single*>|Not applicable|Not applicable|
|<xref:System.Linq.ParallelEnumerable.SingleOrDefault*>|Not applicable|Not applicable|
|<xref:System.Linq.ParallelEnumerable.Skip*>|Skips first *n* elements|Skips any *n* elements|
|<xref:System.Linq.ParallelEnumerable.SkipWhile*>|Ordered results.|Nondeterministic. Performs SkipWhile on the current arbitrary order|
|<xref:System.Linq.ParallelEnumerable.Sum*>|Nondeterministic output for nonassociative or noncommutative operations|Nondeterministic output for nonassociative or noncommutative operations|
|<xref:System.Linq.ParallelEnumerable.Take*>|Takes first `n` elements|Takes any `n` elements|
|<xref:System.Linq.ParallelEnumerable.TakeWhile*>|Ordered results|Nondeterministic. Performs TakeWhile on the current arbitrary order|
|<xref:System.Linq.ParallelEnumerable.ThenBy*>|Supplements `OrderBy`|Supplements `OrderBy`|
|<xref:System.Linq.ParallelEnumerable.ThenByDescending*>|Supplements `OrderBy`|Supplements `OrderBy`|
|<xref:System.Linq.ParallelEnumerable.ToArray*>|Ordered results|Unordered results|
|<xref:System.Linq.ParallelEnumerable.ToDictionary*>|Not applicable|Not applicable|
|<xref:System.Linq.ParallelEnumerable.ToList*>|Ordered results|Unordered results|
|<xref:System.Linq.ParallelEnumerable.ToLookup*>|Ordered results|Unordered results|
|<xref:System.Linq.ParallelEnumerable.Union*>|Ordered results|Unordered results|
|<xref:System.Linq.ParallelEnumerable.Where*>|Ordered results|Unordered results|
|<xref:System.Linq.ParallelEnumerable.Where*> (indexed)|Ordered results|Unordered results|
|<xref:System.Linq.ParallelEnumerable.Zip*>|Ordered results|Unordered results|

 Unordered results are not actively shuffled; they simply do not have any special ordering logic applied to them. In some cases, an unordered query may retain the ordering of the source sequence. For queries that use the indexed Select operator, PLINQ guarantees that the output elements will come out in the order of increasing indices, but makes no guarantees about which indices will be assigned to which elements.

## See also

- [Parallel LINQ (PLINQ)](introduction-to-plinq.md)
- [Parallel Programming](index.md)
