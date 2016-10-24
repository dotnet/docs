---
title: "Aggregation Operations (C#)"
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
ms.assetid: 6fc035e5-7639-48b8-bc7f-b093dd31b039
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
# Aggregation Operations (C#)
An aggregation operation computes a single value from a collection of values. An example of an aggregation operation is calculating the average daily temperature from a month's worth of daily temperature values.  
  
 The following illustration shows the results of two different aggregation operations on a sequence of numbers. The first operation sums the numbers. The second operation returns the maximum value in the sequence.  
  
 ![LINQ Aggregation Operations](../linq/media/linq_aggregation.png "LINQ_Aggregation")  
  
 The standard query operator methods that perform aggregation operations are listed in the following section.  
  
## Methods  
  
|Method Name|Description|C# Query Expression Syntax|More Information|  
|-----------------|-----------------|---------------------------------|----------------------|  
|Aggregate|Performs a custom aggregation operation on the values of a collection.|Not applicable.|<xref:System.Linq.Enumerable.Aggregate*?displayProperty=fullName><br /><br /> <xref:System.Linq.Queryable.Aggregate*?displayProperty=fullName>|  
|Average|Calculates the average value of a collection of values.|Not applicable.|<xref:System.Linq.Enumerable.Average*?displayProperty=fullName><br /><br /> <xref:System.Linq.Queryable.Average*?displayProperty=fullName>|  
|Count|Counts the elements in a collection, optionally only those elements that satisfy a predicate function.|Not applicable.|<xref:System.Linq.Enumerable.Count*?displayProperty=fullName><br /><br /> <xref:System.Linq.Queryable.Count*?displayProperty=fullName>|  
|LongCount|Counts the elements in a large collection, optionally only those elements that satisfy a predicate function.|Not applicable.|<xref:System.Linq.Enumerable.LongCount*?displayProperty=fullName><br /><br /> <xref:System.Linq.Queryable.LongCount*?displayProperty=fullName>|  
|Max|Determines the maximum value in a collection.|Not applicable.|<xref:System.Linq.Enumerable.Max*?displayProperty=fullName><br /><br /> <xref:System.Linq.Queryable.Max*?displayProperty=fullName>|  
|Min|Determines the minimum value in a collection.|Not applicable.|<xref:System.Linq.Enumerable.Min*?displayProperty=fullName><br /><br /> <xref:System.Linq.Queryable.Min*?displayProperty=fullName>|  
|Sum|Calculates the sum of the values in a collection.|Not applicable.|<xref:System.Linq.Enumerable.Sum*?displayProperty=fullName><br /><br /> <xref:System.Linq.Queryable.Sum*?displayProperty=fullName>|  
  
## See Also  
 <xref:System.Linq>   
 [Standard Query Operators Overview (C#)](../linq/standard-query-operators-overview--csharp-.md)   
 [How to: Compute Column Values in a CSV Text File (LINQ) (C#)](../linq/how-to--compute-column-values-in-a-csv-text-file--linq---csharp-.md)   
 [How to: Query for the Largest File or Files in a Directory Tree (LINQ) (C#)](../linq/how-to--query-for-the-largest-file-or-files-in-a-directory-tree--linq---csharp-.md)   
 [How to: Query for the Total Number of Bytes in a Set of Folders (LINQ) (C#)](../linq/how-to--query-for-the-total-number-of-bytes-in-a-set-of-folders--linq---csharp-.md)