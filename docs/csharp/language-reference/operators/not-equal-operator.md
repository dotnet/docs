---
title: "!= Operator (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "!=_CSharpKeyword"
helpviewer_keywords: 
  - "inequality operator (!=) [C#]"
  - "not equals operator (!=) [C#]"
  - "!= operator [C#]"
ms.assetid: eeff7a4e-ad6f-462d-9f8d-49e9b91c6c97
caps.latest.revision: 14
author: "BillWagner"
ms.author: "wiwagn"
---
# != Operator (C# Reference)
The inequality operator (`!=`) returns false if its operands are equal, true otherwise. Inequality operators are predefined for all types, including string and object. User-defined types can overload the `!=` operator.  
  
## Remarks  
 For predefined value types, the inequality operator (`!=`) returns true if the values of its operands are different, false otherwise. For reference types other than `string`, `!=` returns true if its two operands refer to different objects. For the `string` type, `!=` compares the values of the strings.  
  
 User-defined value types can overload the `!=` operator (see [operator](../../../csharp/language-reference/keywords/operator.md)). So can user-defined reference types, although by default `!=` behaves as described above for both predefined and user-defined reference types. If `!=` is overloaded, [==](../../../csharp/language-reference/operators/equality-comparison-operator.md) must also be overloaded. Operations on integral types are generally allowed on enumeration.  
  
## Example  
 [!code-csharp[csRefOperators#33](../../../csharp/language-reference/operators/codesnippet/CSharp/not-equal-operator_1.cs)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Operators](../../../csharp/language-reference/operators/index.md)
