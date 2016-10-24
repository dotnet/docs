---
title: "Element Operations (C#)"
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
ms.assetid: 283206c9-3246-4c48-b01a-d9de409a7231
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
# Element Operations (C#)
Element operations return a single, specific element from a sequence.  
  
 The standard query operator methods that perform element operations are listed in the following section.  
  
## Methods  
  
|Method Name|Description|C# Query Expression Syntax|More Information|  
|-----------------|-----------------|---------------------------------|----------------------|  
|ElementAt|Returns the element at a specified index in a collection.|Not applicable.|<xref:System.Linq.Enumerable.ElementAt*?displayProperty=fullName><br /><br /> <xref:System.Linq.Queryable.ElementAt*?displayProperty=fullName>|  
|ElementAtOrDefault|Returns the element at a specified index in a collection or a default value if the index is out of range.|Not applicable.|<xref:System.Linq.Enumerable.ElementAtOrDefault*?displayProperty=fullName><br /><br /> <xref:System.Linq.Queryable.ElementAtOrDefault*?displayProperty=fullName>|  
|First|Returns the first element of a collection, or the first element that satisfies a condition.|Not applicable.|<xref:System.Linq.Enumerable.First*?displayProperty=fullName><br /><br /> <xref:System.Linq.Queryable.First*?displayProperty=fullName>|  
|FirstOrDefault|Returns the first element of a collection, or the first element that satisfies a condition. Returns a default value if no such element exists.|Not applicable.|<xref:System.Linq.Enumerable.FirstOrDefault*?displayProperty=fullName><br /><br /> <xref:System.Linq.Queryable.FirstOrDefault*?displayProperty=fullName><br /><br /> <xref:System.Linq.Queryable.FirstOrDefault``1(System.Linq.IQueryable{``0})?displayProperty=fullName>|  
|Last|Returns the last element of a collection, or the last element that satisfies a condition.|Not applicable.|<xref:System.Linq.Enumerable.Last*?displayProperty=fullName><br /><br /> <xref:System.Linq.Queryable.Last*?displayProperty=fullName>|  
|LastOrDefault|Returns the last element of a collection, or the last element that satisfies a condition. Returns a default value if no such element exists.|Not applicable.|<xref:System.Linq.Enumerable.LastOrDefault*?displayProperty=fullName><br /><br /> <xref:System.Linq.Queryable.LastOrDefault*?displayProperty=fullName>|  
|Single|Returns the only element of a collection, or the only element that satisfies a condition.|Not applicable.|<xref:System.Linq.Enumerable.Single*?displayProperty=fullName><br /><br /> <xref:System.Linq.Queryable.Single*?displayProperty=fullName>|  
|SingleOrDefault|Returns the only element of a collection, or the only element that satisfies a condition. Returns a default value if no such element exists or the collection does not contain exactly one element.|Not applicable.|<xref:System.Linq.Enumerable.SingleOrDefault*?displayProperty=fullName><br /><br /> <xref:System.Linq.Queryable.SingleOrDefault*?displayProperty=fullName>|  
  
## See Also  
 <xref:System.Linq>   
 [Standard Query Operators Overview (C#)](../linq/standard-query-operators-overview--csharp-.md)   
 [How to: Query for the Largest File or Files in a Directory Tree (LINQ) (C#)](../linq/how-to--query-for-the-largest-file-or-files-in-a-directory-tree--linq---csharp-.md)