---
title: "How to: Perform a Subquery on a Grouping Operation (C# Programming Guide) | Microsoft Docs"
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
helpviewer_keywords: 
  - "queries [LINQ in C#], subqueires"
  - "query expressions [LINQ in C#], subqueries"
  - "groups [C#], LINQ query expressions"
  - "subqueries [C#]"
  - "queries [LINQ in C#], grouping"
  - "grouping LINQ queries [C#]"
  - "query expressions [LINQ in C#], grouping"
  - "groups [LINQ in C#], subqueries"
ms.assetid: 7b0805cd-53b4-429d-86b6-d37fb08f2c95
caps.latest.revision: 15
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# How to: Perform a Subquery on a Grouping Operation (C# Programming Guide)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

This topic shows two different ways to create a query that orders the source data into groups, and then performs a subquery over each group individually. The basic technique in each example is to group the source elements by using a *continuation* named `newGroup`, and then generating a new subquery against `newGroup`. This subquery is run against each new group that is created by the outer query. Note that in this particular example the final output is not a group, but a flat sequence of anonymous types.  
  
 For more information about how to group, see [group clause](../../../csharp/language-reference/keywords/group-clause.md).  
  
 For more information about continuations, see [into](../../../csharp/language-reference/keywords/into.md). The following example uses an in-memory data structure as the data source, but the same principles apply for any kind of [!INCLUDE[vbteclinq](../../../includes/vbteclinq-md.md)] data source.  
  
## Example  
 [!code-csharp[csProgGuideLINQ#23](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideLINQ/CS/csrefLINQHowTos.cs#23)]  
  
## Compiling the Code  
 This example contains references to objects that are defined in the sample application in [How to: Query a Collection of Objects](../../../csharp/programming-guide/linq-query-expressions/how-to-query-a-collection-of-objects.md). To compile and run this method, paste it into the `StudentClass` class in that application and add a call to it from the `Main` method.  
  
 When you adapt this method to your own application, remember that LINQ requires version 3.5 of the [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)], and the project must contain a reference to System.Core.dll and a using directive for System.Linq. LINQ to SQL, LINQ to XML and LINQ to DataSet types require additional usings and references. For more information, see [How to: Create a LINQ Project](http://msdn.microsoft.com/library/a929e653-09a3-44be-881f-68ca33f192b2).  
  
## See Also  
 [LINQ Query Expressions](../../../csharp/programming-guide/linq-query-expressions/index.md)