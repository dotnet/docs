---
title: "&gt;= Operator (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - ">=_CSharpKeyword"
helpviewer_keywords: 
  - "greater than or equal to operator (>=) [C#]"
  - ">= operator [C#]"
ms.assetid: 0db4dcaf-56a3-4884-a7ad-35f64978a58d
caps.latest.revision: 16
author: "BillWagner"
ms.author: "wiwagn"
---
# &gt;= Operator (C# Reference)
All numeric and enumeration types define a "greater than or equal" relational operator, `>=` that returns `true` if the first operand is greater than or equal to the second, `false` otherwise.  
  
## Remarks  
 User-defined types can overload the `>=` operator. For more information, see [operator](../../../csharp/language-reference/keywords/operator.md). If `>=` is overloaded, [<=](../../../csharp/language-reference/operators/less-than-equal-operator.md) must also be overloaded. Operations on integral types are generally allowed on enumeration.  
  
## Example  
 [!code-csharp[csRefOperators#39](../../../csharp/language-reference/operators/codesnippet/CSharp/greater-than-equal-operator_1.cs)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Operators](../../../csharp/language-reference/operators/index.md)
