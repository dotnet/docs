---
title: "Classification of Standard Query Operators by Manner of Execution (C#)"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "CSharp"
ms.assetid: b9435ce5-a7cf-4182-9f01-f3468a5533dc
caps.latest.revision: 3
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
translation.priority.mt: 
  - "cs-cz"
  - "pl-pl"
  - "pt-br"
  - "tr-tr"
---
# Classification of Standard Query Operators by Manner of Execution (C#)
The LINQ to Objects implementations of the standard query operator methods execute in one of two main ways: immediate or deferred. The query operators that use deferred execution can be additionally divided into two categories: streaming and non-streaming. If you know how the different query operators execute, it may help you understand the results that you get from a given query. This is especially true if the data source is changing or if you are building a query on top of another query. This topic classifies the standard query operators according to their manner of execution.  
  
## Manners of Execution  
  
### Immediate  
 Immediate execution means that the data source is read and the operation is performed at the point in the code where the query is declared. All the standard query operators that return a single, non-enumerable result execute immediately.  
  
### Deferred  
 Deferred execution means that the operation is not performed at the point in the code where the query is declared. The operation is performed only when the query variable is enumerated, for example by using a `foreach` statement. This means that the results of executing the query depend on the contents of the data source when the query is executed rather than when the query is defined. If the query variable is enumerated multiple times, the results might differ every time. Almost all the standard query operators whose return type is <xref:System.Collections.Generic.IEnumerable`1> or <xref:System.Linq.IOrderedEnumerable`1> execute in a deferred manner.  
  
 Query operators that use deferred execution can be additionally classified as streaming or non-streaming.  
  
#### Streaming  
 Streaming operators do not have to read all the source data before they yield elements. At the time of execution, a streaming operator performs its operation on each source element as it is read and yields the element if appropriate. A streaming operator continues to read source elements until a result element can be produced. This means that more than one source element might be read to produce one result element.  
  
#### Non-Streaming  
 Non-streaming operators must read all the source data before they can yield a result element. Operations such as sorting or grouping fall into this category. At the time of execution, non-streaming query operators read all the source data, put it into a data structure, perform the operation, and yield the resulting elements.  
  
## Classification Table  
 The following table classifies each standard query operator method according to its method of execution.  
  
> [!NOTE]
>  If an operator is marked in two columns, two input sequences are involved in the operation, and each sequence is evaluated differently. In these cases, it is always the first sequence in the parameter list that is evaluated in a deferred, streaming manner.  
  
|Standard Query Operator|Return Type|Immediate Execution|Deferred Streaming Execution|Deferred Non-Streaming Execution|  
|-----------------------------|-----------------|-------------------------|----------------------------------|---------------------------------------|  
|<xref:System.Linq.Enumerable.Aggregate*>|TSource|X|||  
|<xref:System.Linq.Enumerable.All*>|<xref:System.Boolean>|X|||  
|<xref:System.Linq.Enumerable.Any*>|<xref:System.Boolean>|X|||  
|<xref:System.Linq.Enumerable.AsEnumerable*>|<xref:System.Collections.Generic.IEnumerable`1>||X||  
|<xref:System.Linq.Enumerable.Average*>|Single numeric value|X|||  
|<xref:System.Linq.Enumerable.Cast*>|<xref:System.Collections.Generic.IEnumerable`1>||X||  
|<xref:System.Linq.Enumerable.Concat*>|<xref:System.Collections.Generic.IEnumerable`1>||X||  
|<xref:System.Linq.Enumerable.Contains*>|<xref:System.Boolean>|X|||  
|<xref:System.Linq.Enumerable.Count*>|<xref:System.Int32>|X|||  
|<xref:System.Linq.Enumerable.DefaultIfEmpty*>|<xref:System.Collections.Generic.IEnumerable`1>||X||  
|<xref:System.Linq.Enumerable.Distinct*>|<xref:System.Collections.Generic.IEnumerable`1>||X||  
|<xref:System.Linq.Enumerable.ElementAt*>|TSource|X|||  
|<xref:System.Linq.Enumerable.ElementAtOrDefault*>|TSource|X|||  
|<xref:System.Linq.Enumerable.Empty*>|<xref:System.Collections.Generic.IEnumerable`1>|X|||  
|<xref:System.Linq.Enumerable.Except*>|<xref:System.Collections.Generic.IEnumerable`1>||X|X|  
|<xref:System.Linq.Enumerable.First*>|TSource|X|||  
|<xref:System.Linq.Enumerable.FirstOrDefault*>|TSource|X|||  
|<xref:System.Linq.Enumerable.GroupBy*>|<xref:System.Collections.Generic.IEnumerable`1>|||X|  
|<xref:System.Linq.Enumerable.GroupJoin*>|<xref:System.Collections.Generic.IEnumerable`1>||X|X|  
<xref:System.Linq.Enumerable.Intersect*>|<xref:System.Collections.Generic.IEnumerable`1>||X|X|  
|<xref:System.Linq.Enumerable.Join*>|<xref:System.Collections.Generic.IEnumerable`1>||X|X|  
|<xref:System.Linq.Enumerable.Last*>|TSource|X|||  
|<xref:System.Linq.Enumerable.LastOrDefault*>|TSource|X|||  
|<xref:System.Linq.Enumerable.LongCount*>|<xref:System.Int64>|X|||  
|<xref:System.Linq.Enumerable.Max*>|Single numeric value, TSource, or TResult|X|||  
|<xref:System.Linq.Enumerable.Min*>|Single numeric value, TSource, or TResult|X|||  
|<xref:System.Linq.Enumerable.OfType*>|<xref:System.Collections.Generic.IEnumerable`1>||X||  
|<xref:System.Linq.Enumerable.OrderBy*>|<xref:System.Linq.IOrderedEnumerable`1>|||X|  
|<xref:System.Linq.Enumerable.OrderByDescending*>|<xref:System.Linq.IOrderedEnumerable`1>|||X|  
|<xref:System.Linq.Enumerable.Range*>|<xref:System.Collections.Generic.IEnumerable`1>||X||  
|<xref:System.Linq.Enumerable.Repeat*>|<xref:System.Collections.Generic.IEnumerable`1>||X||  
|<xref:System.Linq.Enumerable.Reverse*>|<xref:System.Collections.Generic.IEnumerable`1>|||X|  
|<xref:System.Linq.Enumerable.Select*>|<xref:System.Collections.Generic.IEnumerable`1>||X||  
|<xref:System.Linq.Enumerable.SelectMany*>|<xref:System.Collections.Generic.IEnumerable`1>||X||  
|<xref:System.Linq.Enumerable.SequenceEqual*>|<xref:System.Boolean>|X|||  
|<xref:System.Linq.Enumerable.Single*>|TSource|X|||  
|<xref:System.Linq.Enumerable.SingleOrDefault*>|TSource|X|||  
|<xref:System.Linq.Enumerable.Skip*>|<xref:System.Collections.Generic.IEnumerable`1>||X||  
|<xref:System.Linq.Enumerable.SkipWhile*>|<xref:System.Collections.Generic.IEnumerable`1>||X||  
|<xref:System.Linq.Enumerable.Sum*>|Single numeric value|X|||  
|<xref:System.Linq.Enumerable.Take*>|<xref:System.Collections.Generic.IEnumerable`1>||X||  
<xref:System.Linq.Enumerable.TakeWhile*>|<xref:System.Collections.Generic.IEnumerable`1>||X||  
|<xref:System.Linq.Enumerable.ThenBy*>|<xref:System.Linq.IOrderedEnumerable`1>|||X|  
|<xref:System.Linq.Enumerable.ThenByDescending*>|<xref:System.Linq.IOrderedEnumerable`1>|||X|  
|<xref:System.Linq.Enumerable.ToArray*>|TSource array|X|||  
|<xref:System.Linq.Enumerable.ToDictionary*>|<xref:System.Collections.Generic.Dictionary`2>|X|||  
|<xref:System.Linq.Enumerable.ToList*>|<xref:System.Collections.Generic.IList`1>|X|||  
|<xref:System.Linq.Enumerable.ToLookup*>|<xref:System.Linq.ILookup`2>|X|||  
|<xref:System.Linq.Enumerable.Union*>|<xref:System.Collections.Generic.IEnumerable`1>||X||  
|<xref:System.Linq.Enumerable.Where*>|<xref:System.Collections.Generic.IEnumerable`1>||X||  
  
## See Also  
 <xref:System.Linq.Enumerable>   
 [Standard Query Operators Overview (C#)](../linq/standard-query-operators-overview--csharp-.md)   
 [Query Expression Syntax for Standard Query Operators (C#)](../linq/query-expression-syntax-for-standard-query-operators--csharp-.md)   
 [LINQ to Objects (C#)](../linq/linq-to-objects--csharp-.md)