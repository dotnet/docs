---
title: "/ Operator (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "/_CSharpKeyword"
helpviewer_keywords: 
  - "/ operator [C#]"
  - "division operator [C#]"
ms.assetid: d155e496-678f-4efa-bebe-2bd08da2c5af
caps.latest.revision: 21
author: "BillWagner"
ms.author: "wiwagn"
---
# / Operator (C# Reference)
The division operator (`/`) divides its first operand by its second operand. All numeric types have predefined division operators.  
  
## Remarks  
 User-defined types can overload the `/` operator (see [operator](../../../csharp/language-reference/keywords/operator.md)). An overload of the `/` operator implicitly overloads the [/= operator](division-assignment-operator.md).  
  
 When you divide two integers, the result is always an integer. For example, the result of 7 / 3 is 2. To determine the remainder of 7 / 3, use the remainder operator ([%](../../../csharp/language-reference/operators/modulus-operator.md)). To obtain a quotient as a rational number or fraction, give the dividend or divisor type `float` or type `double`. You can assign the type implicitly if you express the dividend or divisor as a decimal by putting a digit to the right side of the decimal point, as the following example shows.  
  
## Example  
 [!code-csharp[csRefOperators#42](../../../csharp/language-reference/operators/codesnippet/CSharp/division-operator_1.cs)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Operators](../../../csharp/language-reference/operators/index.md)
