---
title: "-- Operator (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "--_CSharpKeyword"
helpviewer_keywords: 
  - "-- operator [C#]"
  - "decrement operator (--) [C#]"
ms.assetid: 6b9cfe86-63c7-421f-9379-c9690fea8720
caps.latest.revision: 17
author: "BillWagner"
ms.author: "wiwagn"
---
# -- Operator (C# Reference)
The decrement operator (`--`) decrements its operand by 1. The decrement operator can appear before or after its operand: `--variable` and `variable--`. The first form is a prefix decrement operation. The result of the operation is the value of the operand "after" it has been decremented. The second form is a postfix decrement operation. The result of the operation is the value of the operand "before" it has been decremented.  
  
## Remarks  
 Numeric and enumeration types have predefined decrement operators.  
  
 User-defined types can overload the `--` operator (see [operator](../../../csharp/language-reference/keywords/operator.md)). Operations on integral types are generally allowed on enumeration.  
  
## Example  
 [!code-csharp[csRefOperators#8](../../../csharp/language-reference/operators/codesnippet/CSharp/decrement-operator_1.cs)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Operators](../../../csharp/language-reference/operators/index.md)
