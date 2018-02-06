---
title: "&lt;= Operator (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "<=_CSharpKeyword"
helpviewer_keywords: 
  - "less than or equal to operator (<=) [C#]"
  - "<= operator [C#]"
ms.assetid: bb0caec9-d253-4105-b8bc-5252233251e4
caps.latest.revision: 16
author: "BillWagner"
ms.author: "wiwagn"
---
# &lt;= Operator (C# Reference)
All numeric and enumeration types define a "less than or equal" relational operator (`<=`) that returns `true` if the first operand is less than or equal to the second, `false` otherwise.  
  
## Remarks  
 User-defined types can overload the `<=` operator. For more information, see [operator](../../../csharp/language-reference/keywords/operator.md). If `<=` is overloaded, [>=](../../../csharp/language-reference/operators/greater-than-equal-operator.md) must also be overloaded. Operations on integral types are generally allowed on enumeration.  
  
## Example  
 [!code-csharp[csRefOperators#32](../../../csharp/language-reference/operators/codesnippet/CSharp/less-than-equal-operator_1.cs)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Operators](../../../csharp/language-reference/operators/index.md)  
 [explicit](../../../csharp/language-reference/keywords/explicit.md)
