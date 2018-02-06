---
title: "&gt; Operator (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - ">_CSharpKeyword"
helpviewer_keywords: 
  - "> operator [C#]"
  - "greater than operator (>) [C#]"
ms.assetid: 26d3cb69-9c0b-4cc5-858b-5be1abd6659d
caps.latest.revision: 16
author: "BillWagner"
ms.author: "wiwagn"
---
# &gt; Operator (C# Reference)
All numeric and enumeration types define a "greater than" relational operator (`>`) that returns `true` if the first operand is greater than the second, `false` otherwise.  
  
## Remarks  
 User-defined types can overload the `>` operator (see [operator](../../../csharp/language-reference/keywords/operator.md)). If `>` is overloaded, [<](../../../csharp/language-reference/operators/less-than-operator.md) must also be overloaded. When a binary operator is overloaded, the corresponding assignment operator, if any, is also implicitly overloaded.  
  
## Example  
 [!code-csharp[csRefOperators#29](../../../csharp/language-reference/operators/codesnippet/CSharp/greater-than-operator_1.cs)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Operators](../../../csharp/language-reference/operators/index.md)  
 [explicit](../../../csharp/language-reference/keywords/explicit.md)
