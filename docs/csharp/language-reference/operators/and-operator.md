---
title: "&amp; Operator (C# Reference)"
ms.date: 04/04/2018
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "&_CSharpKeyword"
helpviewer_keywords: 
  - "bitwise AND operator [C#]"
  - "ampersand operator (&) [C#]"
  - "& operator [C#]"
  - "AND operator (&) [C#]"
ms.assetid: afa346d5-90ec-4b1f-a2c8-3881f018741d
caps.latest.revision: 19
author: "BillWagner"
ms.author: "wiwagn"
---
# &amp; Operator (C# Reference)
The `&` operator can function as either a unary or a binary operator.  
  
## Remarks  
 The unary `&` operator returns the address of its operand (requires [unsafe](../../../csharp/language-reference/keywords/unsafe.md) context).  
  
 Binary `&` operators are predefined for the integral types and `bool`. For integral types, & computes the logical bitwise AND of its operands. For `bool` operands, & computes the logical AND of its operands; that is, the result is `true` if and only if both its operands are `true`.  
  
 The binary `&` operator evaluates both operators regardless of the first one's value, in contrast to the [conditional AND operator](../../../csharp/language-reference/operators/conditional-and-operator.md) `&&`. For example:  
  
 [!code-csharp[csRefOperators#37](../../../csharp/language-reference/operators/codesnippet/CSharp/and-operator_1.cs)]  
  
 User-defined types can overload the binary `&` operator (see [operator](../../../csharp/language-reference/keywords/operator.md)). Operations on integral types are generally allowed on enumeration. When a binary operator is overloaded, the corresponding assignment operator, if any, is also implicitly overloaded.  
  
## Example  
 [!code-csharp[csRefOperators#38](../../../csharp/language-reference/operators/codesnippet/CSharp/and-operator_2.cs)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Operators](../../../csharp/language-reference/operators/index.md)
