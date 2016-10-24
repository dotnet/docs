---
title: "Quantifier Operations (C#)"
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
ms.assetid: 84ac2ac2-7a63-4581-bc4c-14e34be1493b
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
# Quantifier Operations (C#)
Quantifier operations return a <xref:System.Boolean> value that indicates whether some or all of the elements in a sequence satisfy a condition.  
  
 The following illustration depicts two different quantifier operations on two different source sequences. The first operation asks if one or more of the elements are the character 'A', and the result is `true`. The second operation asks if all the elements are the character 'A', and the result is `true`.  
  
 ![LINQ Quantifier Operations](../linq/media/linq_quantifier.png "LINQ_Quantifier")  
  
 The standard query operator methods that perform quantifier operations are listed in the following section.  
  
## Methods  
  
|Method Name|Description|C# Query Expression Syntax|More Information|  
|-----------------|-----------------|---------------------------------|----------------------|  
|All|Determines whether all the elements in a sequence satisfy a condition.|Not applicable.|<xref:System.Linq.Enumerable.All*?displayProperty=fullName><br /><br /> <xref:System.Linq.Queryable.All*?displayProperty=fullName>|  
|Any|Determines whether any elements in a sequence satisfy a condition.|Not applicable.|<xref:System.Linq.Enumerable.Any*?displayProperty=fullName><br /><br /> <xref:System.Linq.Queryable.Any*?displayProperty=fullName>|  
|Contains|Determines whether a sequence contains a specified element.|Not applicable.|<xref:System.Linq.Enumerable.Contains*?displayProperty=fullName><br /><br /> <xref:System.Linq.Queryable.Contains*?displayProperty=fullName>|  
  
## See Also  
 <xref:System.Linq>   
 [Standard Query Operators Overview (C#)](../linq/standard-query-operators-overview--csharp-.md)   
 [How to: Dynamically Specify Predicate Filters at Runtime](../linq-query-expressions/52f2dc7a-8353-4c6e-98d3-eec99a907a5f.md)   
 [How to: Query for Sentences that Contain a Specified Set of Words (LINQ) (C#)](../linq/0724b429-4b87-4d26-a7b1-409358f3fc20.md)