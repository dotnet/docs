---
description: "Learn more about: Aggregation Operations (Visual Basic)"
title: "Aggregation Operations"
ms.date: 07/20/2015
ms.assetid: 0f47e92c-5dd2-4007-baf4-c5fe5dc3b4a8
---
# Aggregation Operations (Visual Basic)

An aggregation operation computes a single value from a collection of values. An example of an aggregation operation is calculating the average daily temperature from a month's worth of daily temperature values.  
  
 The following illustration shows the results of two different aggregation operations on a sequence of numbers. The first operation sums the numbers. The second operation returns the maximum value in the sequence.  
  
 ![Illustration that shows LINQ aggregation operations.](./media/aggregation-operations/linq-aggregation-operations.png)  
  
 The standard query operator methods that perform aggregation operations are listed in the following section.  
  
## Methods  
  
|Method Name|Description|Visual Basic Query Expression Syntax|More Information|  
|-----------------|-----------------|------------------------------------------|----------------------|  
|Aggregate|Performs a custom aggregation operation on the values of a collection.|Not applicable.|<xref:System.Linq.Enumerable.Aggregate%2A?displayProperty=nameWithType><br /><br /> <xref:System.Linq.Queryable.Aggregate%2A?displayProperty=nameWithType>|  
|Average|Calculates the average value of a collection of values.|`Aggregate … In … Into Average()`|<xref:System.Linq.Enumerable.Average%2A?displayProperty=nameWithType><br /><br /> <xref:System.Linq.Queryable.Average%2A?displayProperty=nameWithType>|  
|Count|Counts the elements in a collection, optionally only those elements that satisfy a predicate function.|`Aggregate … In … Into Count()`|<xref:System.Linq.Enumerable.Count%2A?displayProperty=nameWithType><br /><br /> <xref:System.Linq.Queryable.Count%2A?displayProperty=nameWithType>|  
|LongCount|Counts the elements in a large collection, optionally only those elements that satisfy a predicate function.|`Aggregate … In … Into LongCount()`|<xref:System.Linq.Enumerable.LongCount%2A?displayProperty=nameWithType><br /><br /> <xref:System.Linq.Queryable.LongCount%2A?displayProperty=nameWithType>|  
|Max|Determines the maximum value in a collection.|`Aggregate … In … Into Max()`|<xref:System.Linq.Enumerable.Max%2A?displayProperty=nameWithType><br /><br /> <xref:System.Linq.Queryable.Max%2A?displayProperty=nameWithType>|  
|Min|Determines the minimum value in a collection.|`Aggregate … In … Into Min()`|<xref:System.Linq.Enumerable.Min%2A?displayProperty=nameWithType><br /><br /> <xref:System.Linq.Queryable.Min%2A?displayProperty=nameWithType>|  
|Sum|Calculates the sum of the values in a collection.|`Aggregate … In … Into Sum()`|<xref:System.Linq.Enumerable.Sum%2A?displayProperty=nameWithType><br /><br /> <xref:System.Linq.Queryable.Sum%2A?displayProperty=nameWithType>|  
  
## Query Expression Syntax Examples  
  
### Average  

 The following code example uses the `Aggregate Into Average` clause in Visual Basic to calculate the average temperature in an array of numbers that represent temperatures.  
  
 [!code-vb[CsLINQAggregating#1](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/CsLINQAggregating/VB/Aggregating.vb#1)]  
  
### Count  

 The following code example uses the `Aggregate Into Count` clause in Visual Basic to count the number of values in an array that are greater than or equal to 80.  
  
 [!code-vb[CsLINQAggregating#2](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/CsLINQAggregating/VB/Aggregating.vb#2)]  
  
### LongCount  

 The following code example uses the `Aggregate Into LongCount` clause to count the number of values in an array.  
  
 [!code-vb[CsLINQAggregating#3](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/CsLINQAggregating/VB/Aggregating.vb#3)]  
  
### Max  

 The following code example uses the `Aggregate Into Max` clause  to calculate the maximum temperature in an array of numbers that represent temperatures.  
  
 [!code-vb[CsLINQAggregating#4](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/CsLINQAggregating/VB/Aggregating.vb#4)]  
  
### Min  

 The following code example uses the `Aggregate Into Min` clause  to calculate the minimum temperature in an array of numbers that represent temperatures.  
  
 [!code-vb[CsLINQAggregating#5](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/CsLINQAggregating/VB/Aggregating.vb#5)]  
  
### Sum  

 The following code example uses the `Aggregate Into Sum` clause  to calculate the total expense amount from an array of values that represent expenses.  
  
 [!code-vb[CsLINQAggregating#6](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/CsLINQAggregating/VB/Aggregating.vb#6)]  
  
## See also

- <xref:System.Linq>
- [Standard Query Operators Overview (Visual Basic)](standard-query-operators-overview.md)
- [Aggregate Clause](../../../language-reference/queries/aggregate-clause.md)
- [How to: Compute Column Values in a CSV Text File (LINQ) (Visual Basic)](how-to-compute-column-values-in-a-csv-text-file-linq.md)
- [How to: Count, Sum, or Average Data](../../language-features/linq/how-to-count-sum-or-average-data-by-using-linq.md)
- [How to: Find the Minimum or Maximum Value in a Query Result](../../language-features/linq/how-to-find-the-minimum-or-maximum-value-in-a-query-result.md)
- [How to: Query for the Largest File or Files in a Directory Tree (LINQ) (Visual Basic)](how-to-query-for-the-largest-file-or-files-in-a-directory-tree.md)
- [How to: Query for the Total Number of Bytes in a Set of Folders (LINQ) (Visual Basic)](how-to-query-for-the-total-number-of-bytes-in-a-set-of-folders.md)
