---
title: "/ Operator (C# Reference)"
ms.date: 04/04/2018
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
  
 When you divide two integers, the result is always an integer. For example, the result of 7 / 3 is 2. This is not to be confused with floored division, as the `/` operator rounds towards zero: -7 / 3 is -2.  
  
 To obtain a quotient as a rational number, use the `float`, `double`, or `decimal` types. There are many ways to convert between [built in numeric types](../../../csharp/language-reference/keywords/reference-tables-for-types.md).  
  
 To determine the remainder, use the [remainder operator](../../../csharp/language-reference/operators/remainder-operator.md) `%`.  
  
## Example  
 [!code-csharp[csRefOperators#42](../../../csharp/language-reference/operators/codesnippet/CSharp/division-operator_1.cs)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Operators](../../../csharp/language-reference/operators/index.md)
