---
title: "Aggregation Operations (C#)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
ms.assetid: 6fc035e5-7639-48b8-bc7f-b093dd31b039
caps.latest.revision: 3
author: "BillWagner"
ms.author: "wiwagn"
---
# Aggregation Operations (C#)
An aggregation operation computes a single value from a collection of values. An example of an aggregation operation is calculating the average daily temperature from a month's worth of daily temperature values.  
  
 The following illustration shows the results of two different aggregation operations on a sequence of numbers. The first operation sums the numbers. The second operation returns the maximum value in the sequence.  
  
 ![LINQ Aggregation Operations](../../../../csharp/programming-guide/concepts/linq/media/linq_aggregation.png "LINQ_Aggregation")  
  
 The standard query operator methods that perform aggregation operations are listed in the following section.  
  
## Methods  
  
|Method Name|Description|C# Query Expression Syntax|More Information|  
|-----------------|-----------------|---------------------------------|----------------------|  
|Aggregate|Performs a custom aggregation operation on the values of a collection.|Not applicable.|<xref:System.Linq.Enumerable.Aggregate%2A?displayProperty=nameWithType><br /><br /> <xref:System.Linq.Queryable.Aggregate%2A?displayProperty=nameWithType>|  
|Average|Calculates the average value of a collection of values.|Not applicable.|<xref:System.Linq.Enumerable.Average%2A?displayProperty=nameWithType><br /><br /> <xref:System.Linq.Queryable.Average%2A?displayProperty=nameWithType>|  
|Count|Counts the elements in a collection, optionally only those elements that satisfy a predicate function.|Not applicable.|<xref:System.Linq.Enumerable.Count%2A?displayProperty=nameWithType><br /><br /> <xref:System.Linq.Queryable.Count%2A?displayProperty=nameWithType>|  
|LongCount|Counts the elements in a large collection, optionally only those elements that satisfy a predicate function.|Not applicable.|<xref:System.Linq.Enumerable.LongCount%2A?displayProperty=nameWithType><br /><br /> <xref:System.Linq.Queryable.LongCount%2A?displayProperty=nameWithType>|  
|Max|Determines the maximum value in a collection.|Not applicable.|<xref:System.Linq.Enumerable.Max%2A?displayProperty=nameWithType><br /><br /> <xref:System.Linq.Queryable.Max%2A?displayProperty=nameWithType>|  
|Min|Determines the minimum value in a collection.|Not applicable.|<xref:System.Linq.Enumerable.Min%2A?displayProperty=nameWithType><br /><br /> <xref:System.Linq.Queryable.Min%2A?displayProperty=nameWithType>|  
|Sum|Calculates the sum of the values in a collection.|Not applicable.|<xref:System.Linq.Enumerable.Sum%2A?displayProperty=nameWithType><br /><br /> <xref:System.Linq.Queryable.Sum%2A?displayProperty=nameWithType>|  
  
## See Also  
 <xref:System.Linq>  
 [Standard Query Operators Overview (C#)](../../../../csharp/programming-guide/concepts/linq/standard-query-operators-overview.md)  
 [How to: Compute Column Values in a CSV Text File (LINQ) (C#)](../../../../csharp/programming-guide/concepts/linq/how-to-compute-column-values-in-a-csv-text-file-linq.md)  
 [How to: Query for the Largest File or Files in a Directory Tree (LINQ) (C#)](../../../../csharp/programming-guide/concepts/linq/how-to-query-for-the-largest-file-or-files-in-a-directory-tree-linq.md)  
 [How to: Query for the Total Number of Bytes in a Set of Folders (LINQ) (C#)](../../../../csharp/programming-guide/concepts/linq/how-to-query-for-the-total-number-of-bytes-in-a-set-of-folders-linq.md)
