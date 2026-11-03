---
description: "Learn more about: Query Expression Syntax for Standard Query Operators (Visual Basic)"
title: "Query Expression Syntax for Standard Query Operators"
ms.date: 07/20/2015
ms.assetid: eb978d86-d3b5-497b-95ce-a054bea8f510
---
# Query Expression Syntax for Standard Query Operators (Visual Basic)

Some of the more frequently used standard query operators have dedicated Visual Basic language keyword syntax that enables them to be called as part of a *query expression*. A query expression is a different, more readable form of expressing a query than its *method-based*  equivalent. Query expression clauses are translated into calls to the query methods at compile time.

## Query Expression Syntax Table

 The following table lists the standard query operators that have equivalent query expression clauses.

|Method|Visual Basic Query Expression Syntax|
|------------|------------------------------------------|
|<xref:System.Linq.Enumerable.All*>|`Aggregate … In … Into All(…)`<br /><br /> (For more information, see [Aggregate Clause](../../../language-reference/queries/aggregate-clause.md).)|
|<xref:System.Linq.Enumerable.Any*>|`Aggregate … In … Into Any()`<br /><br /> (For more information, see [Aggregate Clause](../../../language-reference/queries/aggregate-clause.md).)|
|<xref:System.Linq.Enumerable.Average*>|`Aggregate … In … Into Average()`<br /><br /> (For more information, see [Aggregate Clause](../../../language-reference/queries/aggregate-clause.md).)|
|<xref:System.Linq.Enumerable.Cast*>|`From … As …`<br /><br /> (For more information, see [From Clause](../../../language-reference/queries/from-clause.md).)|
|<xref:System.Linq.Enumerable.Count*>|`Aggregate … In … Into Count()`<br /><br /> (For more information, see [Aggregate Clause](../../../language-reference/queries/aggregate-clause.md).)|
|<xref:System.Linq.Enumerable.Distinct``1%28System.Collections.Generic.IEnumerable%7B``0%7D%29>|`Distinct`<br /><br /> (For more information, see [Distinct Clause](../../../language-reference/queries/distinct-clause.md).)|
|<xref:System.Linq.Enumerable.GroupBy*>|`Group … By … Into …`<br /><br /> (For more information, see [Group By Clause](../../../language-reference/queries/group-by-clause.md).)|
|<xref:System.Linq.Enumerable.GroupJoin``4%28System.Collections.Generic.IEnumerable%7B``0%7D%2CSystem.Collections.Generic.IEnumerable%7B``1%7D%2CSystem.Func%7B``0%2C``2%7D%2CSystem.Func%7B``1%2C``2%7D%2CSystem.Func%7B``0%2CSystem.Collections.Generic.IEnumerable%7B``1%7D%2C``3%7D%29>|`Group Join … In … On …`<br /><br /> (For more information, see [Group Join Clause](../../../language-reference/queries/group-join-clause.md).)|
|<xref:System.Linq.Enumerable.Join``4%28System.Collections.Generic.IEnumerable%7B``0%7D%2CSystem.Collections.Generic.IEnumerable%7B``1%7D%2CSystem.Func%7B``0%2C``2%7D%2CSystem.Func%7B``1%2C``2%7D%2CSystem.Func%7B``0%2C``1%2C``3%7D%29>|`From x In …, y In … Where x.a = b.a`<br /><br /> -or-<br /><br /> `Join … [As …]In … On …`<br /><br /> (For more information, see [Join Clause](../../../language-reference/queries/join-clause.md).)|
|<xref:System.Linq.Enumerable.LongCount*>|`Aggregate … In … Into LongCount()`<br /><br /> (For more information, see [Aggregate Clause](../../../language-reference/queries/aggregate-clause.md).)|
|<xref:System.Linq.Enumerable.Max*>|`Aggregate … In … Into Max()`<br /><br /> (For more information, see [Aggregate Clause](../../../language-reference/queries/aggregate-clause.md).)|
|<xref:System.Linq.Enumerable.Min*>|`Aggregate … In … Into Min()`<br /><br /> (For more information, see [Aggregate Clause](../../../language-reference/queries/aggregate-clause.md).)|
|<xref:System.Linq.Enumerable.OrderBy``2%28System.Collections.Generic.IEnumerable%7B``0%7D%2CSystem.Func%7B``0%2C``1%7D%29>|`Order By`<br /><br /> (For more information, see [Order By Clause](../../../language-reference/queries/order-by-clause.md).)|
|<xref:System.Linq.Enumerable.OrderByDescending``2%28System.Collections.Generic.IEnumerable%7B``0%7D%2CSystem.Func%7B``0%2C``1%7D%29>|`Order By … Descending`<br /><br /> (For more information, see [Order By Clause](../../../language-reference/queries/order-by-clause.md).)|
|<xref:System.Linq.Enumerable.Select*>|`Select`<br /><br /> (For more information, see [Select Clause](../../../language-reference/queries/select-clause.md).)|
|<xref:System.Linq.Enumerable.SelectMany*>|Multiple `From` clauses<br /><br /> (For more information, see [From Clause](../../../language-reference/queries/from-clause.md).)|
|<xref:System.Linq.Enumerable.Skip*>|`Skip`<br /><br /> (For more information, see [Skip Clause](../../../language-reference/queries/skip-clause.md).)|
|<xref:System.Linq.Enumerable.SkipWhile*>|`Skip While`<br /><br /> (For more information, see [Skip While Clause](../../../language-reference/queries/skip-while-clause.md).)|
|<xref:System.Linq.Enumerable.Sum*>|`Aggregate … In … Into Sum()`<br /><br /> (For more information, see [Aggregate Clause](../../../language-reference/queries/aggregate-clause.md).)|
|<xref:System.Linq.Enumerable.Take*>|`Take`<br /><br /> (For more information, see [Take Clause](../../../language-reference/queries/take-clause.md).)|
|<xref:System.Linq.Enumerable.TakeWhile*>|`Take While`<br /><br /> (For more information, see [Take While Clause](../../../language-reference/queries/take-while-clause.md).)|
|<xref:System.Linq.Enumerable.ThenBy``2%28System.Linq.IOrderedEnumerable%7B``0%7D%2CSystem.Func%7B``0%2C``1%7D%29>|`Order By …, …`<br /><br /> (For more information, see [Order By Clause](../../../language-reference/queries/order-by-clause.md).)|
|<xref:System.Linq.Enumerable.ThenByDescending``2%28System.Linq.IOrderedEnumerable%7B``0%7D%2CSystem.Func%7B``0%2C``1%7D%29>|`Order By …, … Descending`<br /><br /> (For more information, see [Order By Clause](../../../language-reference/queries/order-by-clause.md).)|
|<xref:System.Linq.Enumerable.Where*>|`Where`<br /><br /> (For more information, see [Where Clause](../../../language-reference/queries/where-clause.md).)|

## See also

- <xref:System.Linq.Enumerable>
- <xref:System.Linq.Queryable>
- [Standard Query Operators Overview (Visual Basic)](standard-query-operators-overview.md)
- [Classification of Standard Query Operators by Manner of Execution (Visual Basic)](classification-of-standard-query-operators-by-manner-of-execution.md)
