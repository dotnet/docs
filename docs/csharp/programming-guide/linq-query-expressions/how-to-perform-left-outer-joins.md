---
title: "How to: Perform Left Outer Joins (C# Programming Guide) | Microsoft Docs"
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
  - "left outer joins [LINQ in C#]"
  - "joins [C#], left outer"
  - "query expressions [LINQ in C#], joins"
  - "queries [LINQ in C#], joins"
ms.assetid: 18e32be8-93db-4d30-8dea-ec6596e18f43
caps.latest.revision: 23
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# How to: Perform Left Outer Joins (C# Programming Guide)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

A left outer join is a join in which each element of the first collection is returned, regardless of whether it has any correlated elements in the second collection. You can use [!INCLUDE[vbteclinq](../../../includes/vbteclinq-md.md)] to perform a left outer join by calling the <xref:System.Linq.Enumerable.DefaultIfEmpty%2A> method on the results of a group join.  
  
## Example  
 The following example demonstrates how to use the <xref:System.Linq.Enumerable.DefaultIfEmpty%2A> method on the results of a group join to perform a left outer join.  
  
 The first step in producing a left outer join of two collections is to perform an inner join by using a group join. (See [How to: Perform Inner Joins](../../../csharp/programming-guide/linq-query-expressions/how-to-perform-inner-joins.md) for an explanation of this process.) In this example, the list of `Person` objects is inner-joined to the list of `Pet` objects based on a `Person` object that matches `Pet.Owner`.  
  
 The second step is to include each element of the first (left) collection in the result set even if that element has no matches in the right collection. This is accomplished by calling <xref:System.Linq.Enumerable.DefaultIfEmpty%2A> on each sequence of matching elements from the group join. In this example, <xref:System.Linq.Enumerable.DefaultIfEmpty%2A> is called on each sequence of matching `Pet` objects. The method returns a collection that contains a single, default value if the sequence of matching `Pet` objects is empty for any `Person` object, thereby ensuring that each `Person` object is represented in the result collection.  
  
> [!NOTE]
>  The default value for a reference type is `null`; therefore, the example checks for a null reference before accessing each element of each `Pet` collection.  
  
 [!code-csharp[CsLINQProgJoining#7](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/CsLINQProgJoining/CS/joins.cs#7)]  
  
## Compiling the Code  
  
-   Create a new Console Application project in [!INCLUDE[vs_current_short](../../../includes/vs-current-short-md.md)].  
  
-   Add a reference to System.Core.dll if it is not already referenced.  
  
-   Include the <xref:System.Linq> namespace.  
  
-   Copy and paste the code from the example into the program.cs file, below the `Main` method in the `Program` class. Add a line of code to the `Main` method to call the `LeftOuterJoinExample` method.  
  
-   Run the program.  
  
## See Also  
 <xref:System.Linq.Enumerable.Join%2A>   
 <xref:System.Linq.Enumerable.GroupJoin%2A>   
 [Join Operations](../Topic/Join%20Operations.md)   
 [How to: Perform Inner Joins](../../../csharp/programming-guide/linq-query-expressions/how-to-perform-inner-joins.md)   
 [How to: Perform Grouped Joins](../../../csharp/programming-guide/linq-query-expressions/how-to-perform-grouped-joins.md)   
 [Anonymous Types](../../../csharp/programming-guide/classes-and-structs/anonymous-types.md)   
 [Anonymous Types](../../../visual-basic/programming-guide/language-features/objects-and-classes/anonymous-types.md)