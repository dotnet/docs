---
title: "() Operator (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "()_CSharpKeyword"
helpviewer_keywords: 
  - "type conversion [C#], () operator"
  - "cast operator [C#]"
  - "() operator [C#]"
ms.assetid: 846e1f94-8a8c-42fc-a42c-fbd38e70d8cc
caps.latest.revision: 22
author: "BillWagner"
ms.author: "wiwagn"
---
# () Operator (C# Reference)
In addition to being used to specify the order of operations in an expression, parentheses are used to perform the following tasks:  
  
1.  Specify casts, or type conversions.  
  
     [!code-csharp[csRefOperators#1](../../../csharp/language-reference/operators/codesnippet/CSharp/invocation-operator_1.cs)]  
  
2.  Invoke methods or delegates.  
  
     [!code-csharp[csRefOperators#2](../../../csharp/language-reference/operators/codesnippet/CSharp/invocation-operator_2.cs)]  
  
## Remarks  
 A cast explicitly invokes the conversion operator from one type to another; the cast fails if no such conversion operator is defined. To define a conversion operator, see [explicit](../../../csharp/language-reference/keywords/explicit.md) and [implicit](../../../csharp/language-reference/keywords/implicit.md).  
  
 The `()` operator cannot be overloaded.  
  
 For more information, see [Casting and Type Conversions](../../../csharp/programming-guide/types/casting-and-type-conversions.md).  
  
 A cast expression could lead to ambiguous syntax. For example, the expression `(x)–y` could be either interpreted as a cast expression (a cast of –y to type x) or as an additive expression combined with a parenthesized expression, which computes the value x – y.  
  
 For more information about method invocation, see [Methods](../../../csharp/programming-guide/classes-and-structs/methods.md).  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Operators](../../../csharp/language-reference/operators/index.md)
