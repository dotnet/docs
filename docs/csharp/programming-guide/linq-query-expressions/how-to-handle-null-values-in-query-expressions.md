---
title: "How to: Handle Null Values in Query Expressions (C# Programming Guide) | Microsoft Docs"
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
  - "query expressions [LINQ in C#], null values"
  - "null values [LINQ in C#]"
  - "queries [LINQ in C#], null values"
ms.assetid: cb34f7a1-7ef5-466a-90ba-91da30ab525d
caps.latest.revision: 6
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# How to: Handle Null Values in Query Expressions (C# Programming Guide)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

This example shows how to handle possible null values in source collections. An object collection such as an <xref:System.Collections.Generic.IEnumerable%601> can contain elements whose value is [null](../../../csharp/language-reference/keywords/null.md). If a source collection is null or contains an element whose value is null, and your query does not handle null values, a <xref:System.NullReferenceException> will be thrown when you execute the query.  
  
## Example  
 You can code defensively to avoid a null reference exception as shown in the following example:  
  
 [!code-csharp[csProgGuideLINQ#82](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideLINQ/CS/csRef30LangFeatures_2.cs#82)]  
  
 In the previous example, the `where` clause filters out all null elements in the categories sequence. This technique is independent of the null check in the join clause. The conditional expression with null in this example works because `Products.CategoryID` is of type `int?` which is shorthand for `Nullable<int>`.  
  
## Example  
 In a join clause, if only one of the comparison keys is a nullable value type, you can cast the other to a nullable type in the query expression. In the following example, assume that `EmployeeID` is a column that contains values of type `int?`:  
  
 [!code-csharp[csProgGuideLINQ#83](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideLINQ/CS/csRef30LangFeatures_2.cs#83)]  
  
## See Also  
 <xref:System.Nullable%601>   
 [LINQ Query Expressions](../../../csharp/programming-guide/linq-query-expressions/index.md)   
 [Nullable Types](../../../csharp/programming-guide/nullable-types/index.md)