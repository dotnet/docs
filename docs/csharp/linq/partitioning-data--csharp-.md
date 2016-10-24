---
title: "Partitioning Data (C#)"
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
ms.assetid: 2a5c507b-fe22-443c-a768-dec7f9ec568d
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
# Partitioning Data (C#)
Partitioning in LINQ refers to the operation of dividing an input sequence into two sections, without rearranging the elements, and then returning one of the sections.  
  
 The following illustration shows the results of three different partitioning operations on a sequence of characters. The first operation returns the first three elements in the sequence. The second operation skips the first three elements and returns the remaining elements. The third operation skips the first two elements in the sequence and returns the next three elements.  
  
 ![LINQ Partitioning Operations](../linq/media/linq_partition.png "LINQ_Partition")  
  
 The standard query operator methods that partition sequences are listed in the following section.  
  
## Operators  
  
|Operator Name|Description|C# Query Expression Syntax|More Information|  
|-------------------|-----------------|---------------------------------|----------------------|  
|Skip|Skips elements up to a specified position in a sequence.|Not applicable.|<xref:System.Linq.Enumerable.Skip*?displayProperty=fullName><br /><br /> <xref:System.Linq.Queryable.Skip*?displayProperty=fullName>|  
|SkipWhile|Skips elements based on a predicate function until an element does not satisfy the condition.|Not applicable.|<xref:System.Linq.Enumerable.SkipWhile*?displayProperty=fullName><br /><br /> <xref:System.Linq.Queryable.SkipWhile*?displayProperty=fullName>|  
|Take|Takes elements up to a specified position in a sequence.|Not applicable.|<xref:System.Linq.Enumerable.Take*?displayProperty=fullName><br /><br /> <xref:System.Linq.Queryable.Take*?displayProperty=fullName>|  
|TakeWhile|Takes elements based on a predicate function until an element does not satisfy the condition.|Not applicable.|<xref:System.Linq.Enumerable.TakeWhile*?displayProperty=fullName><br /><br /> <xref:System.Linq.Queryable.TakeWhile*?displayProperty=fullName>|  
  
## See Also  
 <xref:System.Linq>   
 [Standard Query Operators Overview (C#)](../linq/standard-query-operators-overview--csharp-.md)