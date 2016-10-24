---
title: "orderby clause (C# Reference)"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "orderby"
  - "orderby_CSharpKeyword"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "orderby clause [C#]"
  - "orderby keyword [C#]"
ms.assetid: 21f87f48-d69d-4e95-9a52-6fec47b37e1f
caps.latest.revision: 17
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
translation.priority.ht: 
  - "cs-cz"
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "pl-pl"
  - "pt-br"
  - "ru-ru"
  - "tr-tr"
  - "zh-cn"
  - "zh-tw"
---
# orderby clause (C# Reference)
In a query expression, the `orderby` clause causes the returned sequence or subsequence (group) to be sorted in either ascending or descending order. Multiple keys can be specified in order to perform one or more secondary sort operations. The sorting is performed by the default comparer for the type of the element. The default sort order is ascending. You can also specify a custom comparer. However, it is only available by using method-based syntax. For more information, see [Sorting Data](../Topic/Sorting%20Data.md).  
  
## Example  
 In the following example, the first query sorts the words in alphabetical order starting from A, and second query sorts the same words in descending order. (The `ascending` keyword is the default sort value and can be omitted.)  
  
 [!code[cscsrefQueryKeywords#20](../classes-and-structs/codesnippet/CSharp/orderby-clause--csharp-reference-_1.cs)]  
  
## Example  
 The following example performs a primary sort on the students' last names, and then a secondary sort on their first names.  
  
 [!code[cscsrefQueryKeywords#22](../classes-and-structs/codesnippet/CSharp/orderby-clause--csharp-reference-_2.cs)]  
  
## Remarks  
 At compile time, the `orderby` clause is translated to a call to the <xref:System.Linq.Enumerable.OrderBy*> method. Multiple keys in the `orderby` clause translate to <xref:System.Linq.Enumerable.ThenBy*> method calls.  
  
## See Also  
 [C# Reference](../language-reference/csharp-reference.md)   
 [Query Keywords (LINQ)](../keywords/query-keywords--csharp-reference-.md)   
 [LINQ Query Expressions](../linq-query-expressions/linq-query-expressions--csharp-programming-guide-.md)   
 [group clause](../keywords/group-clause--csharp-reference-.md)   
 [Getting Started with LINQ in C#](../linq/getting-started-with-linq-in-csharp.md)