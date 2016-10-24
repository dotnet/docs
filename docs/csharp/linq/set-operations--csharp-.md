---
title: "Set Operations (C#)"
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
ms.assetid: 7c589367-ef8f-4161-9050-642c47e6bf63
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
# Set Operations (C#)
Set operations in LINQ refer to query operations that produce a result set that is based on the presence or absence of equivalent elements within the same or separate collections (or sets).  
  
 The standard query operator methods that perform set operations are listed in the following section.  
  
## Methods  
  
|Method Name|Description|C# Query Expression Syntax|More Information|  
|-----------------|-----------------|---------------------------------|----------------------|  
|Distinct|Removes duplicate values from a collection.|Not applicable.|<xref:System.Linq.Enumerable.Distinct*?displayProperty=fullName><br /><br /> <xref:System.Linq.Queryable.Distinct*?displayProperty=fullName>|  
|Except|Returns the set difference, which means the elements of one collection that do not appear in a second collection.|Not applicable.|<xref:System.Linq.Enumerable.Except*?displayProperty=fullName><br /><br /> <xref:System.Linq.Queryable.Except*?displayProperty=fullName>|  
|Intersect|Returns the set intersection, which means elements that appear in each of two collections.|Not applicable.|<xref:System.Linq.Enumerable.Intersect*?displayProperty=fullName><br /><br /> <xref:System.Linq.Queryable.Intersect*?displayProperty=fullName>|  
|Union|Returns the set union, which means unique elements that appear in either of two collections.|Not applicable.|<xref:System.Linq.Enumerable.Union*?displayProperty=fullName><br /><br /> <xref:System.Linq.Queryable.Union*?displayProperty=fullName>|  
  
## Comparison of Set Operations  
  
### Distinct  
 The following illustration depicts the behavior of the <xref:System.Linq.Enumerable.Distinct*?displayProperty=fullName> method on a sequence of characters. The returned sequence contains the unique elements from the input sequence.  
  
 ![Graphic showing the behavior of Distinct&#40;&#41;.](../linq/media/distinct.png "Distinct")  
  
### Except  
 The following illustration depicts the behavior of <xref:System.Linq.Enumerable.Except*?displayProperty=fullName>. The returned sequence contains only the elements from the first input sequence that are not in the second input sequence.  
  
 ![Graphic showing the action of Except&#40;&#41;.](../linq/media/except.png "Except")  
  
### Intersect  
 The following illustration depicts the behavior of <xref:System.Linq.Enumerable.Intersect*?displayProperty=fullName>. The returned sequence contains the elements that are common to both of the input sequences.  
  
 ![Graphic showing the intersection of two sequences.](../linq/media/intersect.png "Intersect")  
  
### Union  
 The following illustration depicts a union operation on two sequences of characters. The returned sequence contains the unique elements from both input sequences.  
  
 ![Graphic showing the union of two sequences.](../linq/media/union.png "Union")  
  
## See Also  
 <xref:System.Linq>   
 [Standard Query Operators Overview (C#)](../linq/standard-query-operators-overview--csharp-.md)   
 [How to: Combine and Compare String Collections (LINQ) (C#)](../linq/how-to--combine-and-compare-string-collections--linq---csharp-.md)   
 [How to: Find the Set Difference Between Two Lists (LINQ) (C#)](../linq/how-to--find-the-set-difference-between-two-lists--linq---csharp-.md)