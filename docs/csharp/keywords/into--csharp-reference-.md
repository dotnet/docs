---
title: "into (C# Reference)"
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
  - "into_CSharpKeyword"
  - "into"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "into keyword [C#]"
ms.assetid: 81ec62c1-f0b1-4755-8a31-959876e77f65
caps.latest.revision: 18
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
# into (C# Reference)
The `into` contextual keyword can be used to create a temporary identifier to store the results of a [group](../keywords/group-clause--csharp-reference-.md), [join](../keywords/join-clause--csharp-reference-.md) or [select](../keywords/select-clause--csharp-reference-.md) clause into a new identifier. This identifier can itself be a generator for additional query commands. When used in a `group` or `select` clause, the use of the new identifier is sometimes referred to as a *continuation*.  
  
## Example  
 The following example shows the use of the `into` keyword to enable a temporary identifier `fruitGroup` which has an inferred type of `IGrouping`. By using the identifier, you can invoke the <xref:System.Linq.Enumerable.Count*> method on each group and select only those groups that contain two or more words.  
  
 [!code[cscsrefQueryKeywords#18](../classes-and-structs/codesnippet/CSharp/into--csharp-reference-_1.cs)]  
  
 The use of `into` in a `group` clause is only necessary when you want to perform additional query operations on each group. For more information, see [group clause](../keywords/group-clause--csharp-reference-.md).  
  
 For an example of the use of `into` in a `join` clause, see [join clause](../keywords/join-clause--csharp-reference-.md).  
  
## See Also  
 [Query Keywords (LINQ)](../keywords/query-keywords--csharp-reference-.md)   
 [LINQ Query Expressions](../linq-query-expressions/linq-query-expressions--csharp-programming-guide-.md)   
 [group clause](../keywords/group-clause--csharp-reference-.md)