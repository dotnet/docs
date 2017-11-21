---
title: "|| Operator (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "||_CSharpKeyword"
helpviewer_keywords: 
  - "logical OR operator [C#]"
  - "conditional-OR operator (||) [C#]"
  - "|| operator [C#]"
ms.assetid: 7d442d8e-400d-421f-b4d2-034bf82bcbdc
caps.latest.revision: 25
author: "BillWagner"
ms.author: "wiwagn"
---
# || Operator (C# Reference)
The conditional-OR operator (`||`) performs a logical-OR of its `bool` operands. If the first operand evaluates to `true`, the second operand isn't evaluated. If the first operand evaluates to `false`, the second operator determines whether the OR expression as a whole evaluates to `true` or `false`.  
  
## Remarks  
 The operation  
  
```  
x || y  
```  
  
 corresponds to the operation  
  
```  
x | y  
```  
  
 except that if `x` is `true`, `y` is not evaluated because the OR operation is `true` regardless of the value of `y`. This concept is known as "short-circuit" evaluation.  
  
 The conditional-OR operator cannot be overloaded, but overloads of the regular logical operators and the [true](../../../csharp/language-reference/keywords/true.md) and [false](../../../csharp/language-reference/keywords/false.md) operators are, with certain restrictions, also considered to be overloads of the conditional logical operators.  
  
## Example  
 In the following examples, the expression that uses `||` evaluates only the first operand. The expression that uses `|` evaluates both operands. In the second example, a run-time exception occurs if both operands are evaluated.  
  
 [!code-csharp[csRefOperators#52](../../../csharp/language-reference/operators/codesnippet/CSharp/conditional-or-operator_1.cs)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Operators](../../../csharp/language-reference/operators/index.md)
