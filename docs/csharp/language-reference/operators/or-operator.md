---
title: "| Operator (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "|_CSharpKeyword"
helpviewer_keywords: 
  - "bitwise OR operator [C#]"
  - "| operator [C#]"
  - "binary operator (|) [C#]"
ms.assetid: 82d6bb78-54c8-40bf-b679-531180ddaf70
caps.latest.revision: 15
author: "BillWagner"
ms.author: "wiwagn"
---
# | Operator (C# Reference)
Binary `|` operators are predefined for the integral types and `bool`. For integral types, `|` computes the bitwise OR of its operands. For `bool` operands, `|` computes the logical OR of its operands; that is, the result is `false` if and only if both its operands are `false`.  
  
## Remarks  
 User-defined types can overload the `|` operator (see [operator](../../../csharp/language-reference/keywords/operator.md)).  
  
## Example  
 [!code-csharp[csRefOperators#31](../../../csharp/language-reference/operators/codesnippet/CSharp/or-operator_1.cs)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Operators](../../../csharp/language-reference/operators/index.md)
