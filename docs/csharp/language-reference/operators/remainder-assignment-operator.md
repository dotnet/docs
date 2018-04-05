---
title: "%= Operator (C# Reference)"
ms.date: 04/04/2018
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "%=_CSharpKeyword"
helpviewer_keywords: 
  - "remainder assignment operator (%=) [C#]"
  - "%= assignment operator (remainder assignment) [C#]"
ms.assetid: 47e5f068-1d97-4010-bd3b-e21b5d3a77f5
caps.latest.revision: 20
author: "BillWagner"
ms.author: "wiwagn"
---
# %= Operator (C# Reference)
The remainder assignment operator.  
  
## Remarks  
 An expression using the `%=` assignment operator, such as  
  
```  
x %= y  
```  
  
 is equivalent to  
  
```  
x = x % y  
```  
  
 except that `x` is only evaluated once. The [% operator](../../../csharp/language-reference/operators/remainder-operator.md) is predefined for numeric types to compute the remainder after division.  
  
 The `%=` operator cannot be overloaded directly, but user-defined types can overload the [% operator](../../../csharp/language-reference/operators/remainder-operator.md) (see [operator (C# Reference)](../../../csharp/language-reference/keywords/operator.md)).  
  
## Example  
 [!code-csharp[csRefOperators#4](../../../csharp/language-reference/operators/codesnippet/CSharp/modulus-assignment-operator_1.cs)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Operators](../../../csharp/language-reference/operators/index.md)
