---
title: "by (C# Reference) | Microsoft Docs"
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
  - "by"
  - "by_CSharpKeyword"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "by keyword [C#]"
ms.assetid: efe6f0e3-be40-4df2-a144-c7db968ae052
caps.latest.revision: 6
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# by (C# Reference)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

The `by` contextual keyword is used in the `group` clause in a query expression to specify how the returned items should be grouped. For more information, see [group clause](../../../csharp/language-reference/keywords/group-clause.md).  
  
## Example  
 The following example shows the use of the `by` contextual keyword in a `group` clause to specify that the students should be grouped according to the first letter of the last name of each student.  
  
 [!code-csharp[csrefKeywordsContextual#10](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsContextual/CS/csrefKeywordsContextual.cs#10)]  
  
## See Also  
 [LINQ Query Expressions](../../../csharp/programming-guide/linq-query-expressions/index.md)