---
title: "How to: Store the Results of a Query in Memory (C# Programming Guide) | Microsoft Docs"
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
  - "LINQ query result storage [LINQ in C#]"
  - "query expressions [LINQ in C#], storing results"
ms.assetid: 7271597f-3523-4f7b-b088-1eeffe913b2d
caps.latest.revision: 13
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# How to: Store the Results of a Query in Memory (C# Programming Guide)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

A query is basically a set of instructions for how to retrieve and organize data. To execute the query requires a call to its <xref:System.Collections.Generic.IEnumerable%601.GetEnumerator%2A> method. This call is made when you use a `foreach` loop to iterate over the elements. To evaluate a query and store its results without executing a `foreach` loop, just call one of the following methods on the query variable:  
  
-   <xref:System.Linq.Enumerable.ToList%2A>  
  
-   <xref:System.Linq.Enumerable.ToArray%2A>  
  
-   <xref:System.Linq.Enumerable.ToDictionary%2A>  
  
-   <xref:System.Linq.Enumerable.ToLookup%2A>  
  
 We recommend that when you store the query results, you assign the returned collection object to a new variable as shown in the following example:  
  
## Example  
 [!code-csharp[csProgGuideLINQ#25](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideLINQ/CS/csrefLINQHowTos.cs#25)]  
  
## Compiling the Code  
  
-   Create a [!INCLUDE[vs_current_short](../../../includes/vs-current-short-md.md)] project that targets the .NET Framework version 3.5. By default, the project has a reference to System.Core.dll and a `using` directive for the System.Linq namespace.  
  
-   Copy the code into your project.  
  
-   Press F5 to compile and run the program.  
  
-   Press any key to exit the console window.  
  
## See Also  
 [LINQ Query Expressions](../../../csharp/programming-guide/linq-query-expressions/index.md)