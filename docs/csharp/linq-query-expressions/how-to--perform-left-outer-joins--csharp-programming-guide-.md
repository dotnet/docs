---
title: "How to: Perform Left Outer Joins (C# Programming Guide)"
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
translation.priority.ht: 
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "ru-ru"
  - "zh-cn"
  - "zh-tw"
translation.priority.mt: 
  - "cs-cz"
  - "pl-pl"
  - "pt-br"
  - "tr-tr"
---
# How to: Perform Left Outer Joins (C# Programming Guide)
A left outer join is a join in which each element of the first collection is returned, regardless of whether it has any correlated elements in the second collection. You can use [!INCLUDE[vbteclinq](../classes-and-structs/includes/vbteclinq_md.md)] to perform a left outer join by calling the <xref:System.Linq.Enumerable.DefaultIfEmpty*> method on the results of a group join.  
  
## Example  
 The following example demonstrates how to use the <xref:System.Linq.Enumerable.DefaultIfEmpty*> method on the results of a group join to perform a left outer join.  
  
 The first step in producing a left outer join of two collections is to perform an inner join by using a group join. (See [How to: Perform Inner Joins](../linq-query-expressions/how-to--perform-inner-joins--csharp-programming-guide-.md) for an explanation of this process.) In this example, the list of `Person` objects is inner-joined to the list of `Pet` objects based on a `Person` object that matches `Pet.Owner`.  
  
 The second step is to include each element of the first (left) collection in the result set even if that element has no matches in the right collection. This is accomplished by calling <xref:System.Linq.Enumerable.DefaultIfEmpty*> on each sequence of matching elements from the group join. In this example, <xref:System.Linq.Enumerable.DefaultIfEmpty*> is called on each sequence of matching `Pet` objects. The method returns a collection that contains a single, default value if the sequence of matching `Pet` objects is empty for any `Person` object, thereby ensuring that each `Person` object is represented in the result collection.  
  
> [!NOTE]
>  The default value for a reference type is `null`; therefore, the example checks for a null reference before accessing each element of each `Pet` collection.  
  
 [!code[CsLINQProgJoining#7](../linq-query-expressions/codesnippet/CSharp/how-to--perform-left-outer-joins--csharp-programming-guide-_1.cs)]  
  
## Compiling the Code  
  
-   Create a new Console Application project in [!INCLUDE[vs_current_short](../classes-and-structs/includes/vs_current_short_md.md)].  
  
-   Add a reference to System.Core.dll if it is not already referenced.  
  
-   Include the <xref:System.Linq> namespace.  
  
-   Copy and paste the code from the example into the program.cs file, below the `Main` method in the `Program` class. Add a line of code to the `Main` method to call the `LeftOuterJoinExample` method.  
  
-   Run the program.  
  
## See Also  
 <xref:System.Linq.Enumerable.Join*>   
 <xref:System.Linq.Enumerable.GroupJoin*>   
 [Join Operations](../Topic/Join%20Operations.md)   
 [How to: Perform Inner Joins](../linq-query-expressions/how-to--perform-inner-joins--csharp-programming-guide-.md)   
 [How to: Perform Grouped Joins](../linq-query-expressions/how-to--perform-grouped-joins--csharp-programming-guide-.md)   
 [Anonymous Types](../classes-and-structs/anonymous-types--csharp-programming-guide-.md)   
 [Anonymous Types](../Topic/Anonymous%20Types%20\(Visual%20Basic\).md)