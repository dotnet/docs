---
title: "How to: Store the Results of a Query in Memory (C# Programming Guide)"
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
# How to: Store the Results of a Query in Memory (C# Programming Guide)
A query is basically a set of instructions for how to retrieve and organize data. To execute the query requires a call to its <xref:System.Collections.Generic.IEnumerable`1.GetEnumerator*> method. This call is made when you use a `foreach` loop to iterate over the elements. To evaluate a query and store its results without executing a `foreach` loop, just call one of the following methods on the query variable:  
  
-   <xref:System.Linq.Enumerable.ToList*>  
  
-   <xref:System.Linq.Enumerable.ToArray*>  
  
-   <xref:System.Linq.Enumerable.ToDictionary*>  
  
-   <xref:System.Linq.Enumerable.ToLookup*>  
  
 We recommend that when you store the query results, you assign the returned collection object to a new variable as shown in the following example:  
  
## Example  
 [!code[csProgGuideLINQ#25](../arrays/codesnippet/CSharp/how-to--store-the-results-of-a-query-in-memory--csharp-programming-guide-_1.cs)]  
  
## Compiling the Code  
  
-   Create a [!INCLUDE[vs_current_short](../classes-and-structs/includes/vs_current_short_md.md)] project that targets the .NET Framework version 3.5. By default, the project has a reference to System.Core.dll and a `using` directive for the System.Linq namespace.  
  
-   Copy the code into your project.  
  
-   Press F5 to compile and run the program.  
  
-   Press any key to exit the console window.  
  
## See Also  
 [LINQ Query Expressions](../linq-query-expressions/linq-query-expressions--csharp-programming-guide-.md)