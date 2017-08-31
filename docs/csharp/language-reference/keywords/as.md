---
title: "as (C# Reference) | Microsoft Docs"
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
  - "as_CSharpKeyword"
  - "as"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "type conversion [C#], as keyword"
  - "as keyword [C#]"
ms.assetid: a9be126b-cbf4-4990-a70d-d0e1983cad0e
caps.latest.revision: 24
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# as (C# Reference)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

You can use the `as` operator to perform certain types of conversions between compatible reference types or [nullable types](../../../csharp/programming-guide/nullable-types/index.md). The following code shows an example.  
  
 [!code-csharp[csrefKeywordsOperator#1](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsOperator/CS/csrefKeywordsOperators.cs#1)]  
  
## Remarks  
 The `as` operator is like a cast operation. However, if the conversion isn't possible, `as` returns `null` instead of raising an exception. Consider the following example:  
  
```  
expression as type  
```  
  
 The code is equivalent to the following expression except that the `expression` variable is evaluated only one time.  
  
```  
expression is type ? (type)expression : (type)null  
```  
  
 Note that the `as` operator performs only reference conversions, nullable conversions, and boxing conversions. The `as` operator can't perform other conversions, such as user-defined conversions, which should instead be performed by using cast expressions.  
  
## Example  
 [!code-csharp[csrefKeywordsOperator#2](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsOperator/CS/csrefKeywordsOperators.cs#2)]  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../../../includes/csharplangspec-md.md)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)   
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)   
 [is](../../../csharp/language-reference/keywords/is.md)   
 [?: Operator](../../../csharp/language-reference/operators/conditional-operator.md)   
 [Operator Keywords](../../../csharp/language-reference/keywords/operator-keywords.md)