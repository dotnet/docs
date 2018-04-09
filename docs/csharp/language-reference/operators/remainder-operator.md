---
title: "% Operator (C# Reference)"
ms.date: 04/04/2018
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "%_CSharpKeyword"
helpviewer_keywords: 
  - "remainder operator [C#]"
  - "% operator [C#]"
ms.assetid: 3b74f4f9-fd9c-45e7-84fa-c8d71a0dfad7
caps.latest.revision: 15
author: "BillWagner"
ms.author: "wiwagn"
---
# % Operator (C# Reference)
The remainder operator (`%`) computes the remainder after dividing its first operand by its second. All numeric types have predefined remainder operators. 
  
## Remarks  
 The formula `a % b` will always return a value on the range `(-b, b)`, exclusive (it can never return `b` or `-b`), keeping the sign of the dividend. For integer division, the remainder operator satisfies the rule `a % b = a - (a / b) * b`.
  
 This is not to be confused with canonical modulus, which satisfies a similar rule but with floored division and returns values on the range `[0, b)`. C# does not have an operator for canonical modulus. However, the behavior is the same for positive dividends.
  
 User-defined types can overload the `%` operator (see [operator](../../../csharp/language-reference/keywords/operator.md)). When a binary operator is overloaded, the corresponding assignment operator, if any, is also implicitly overloaded.  
  
## Example  
 [!code-csharp[csRefOperators#9](../../../csharp/language-reference/operators/codesnippet/CSharp/remainder-operator_1.cs)]  
  
## Comments  
 Note the round-off errors associated with the double type.  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Operators](../../../csharp/language-reference/operators/index.md)
