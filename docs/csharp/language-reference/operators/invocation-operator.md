---
title: "() Operator (C# Reference) | Microsoft Docs"
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
  - "()_CSharpKeyword"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "type conversion [C#], () operator"
  - "cast operator [C#]"
  - "() operator [C#]"
ms.assetid: 846e1f94-8a8c-42fc-a42c-fbd38e70d8cc
caps.latest.revision: 22
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# () Operator (C# Reference)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

In addition to being used to specify the order of operations in an expression, parentheses are used to perform the following tasks:  
  
1.  Specify casts, or type conversions.  
  
     [!code-csharp[csRefOperators#1](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefOperators/CS/csrefOperators.cs#1)]  
  
2.  Invoke methods or delegates.  
  
     [!code-csharp[csRefOperators#2](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csrefOperators/CS/csrefOperators.cs#2)]  
  
## Remarks  
 A cast explicitly invokes the conversion operator from one type to another; the cast fails if no such conversion operator is defined. To define a conversion operator, see [explicit](../../../csharp/language-reference/keywords/explicit.md) and [implicit](../../../csharp/language-reference/keywords/implicit.md).  
  
 The `()` operator cannot be overloaded.  
  
 For more information, see [Casting and Type Conversions](../../../csharp/programming-guide/types/casting-and-type-conversions.md).  
  
 A cast expression could lead to ambiguous syntax. For example, the expression `(x)–y` could be either interpreted as a cast expression (a cast of –y to type x) or as an additive expression combined with a parenthesized expression, which computes the value x – y.  
  
 For more information about method invocation, see [Methods](../../../csharp/programming-guide/classes-and-structs/methods.md).  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../../../includes/csharplangspec-md.md)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)   
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [C# Operators](../../../csharp/language-reference/operators/index.md)