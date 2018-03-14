---
title: "= Operator (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "=_CSharpKeyword"
helpviewer_keywords: 
  - "= operator [C#]"
ms.assetid: d802a6d5-32f0-42b8-b180-12f5a081bfc1
caps.latest.revision: 14
author: "BillWagner"
ms.author: "wiwagn"
---
# = Operator (C# Reference)
The assignment operator (`=`) stores the value of its right-hand operand in the storage location, property, or indexer denoted by its left-hand operand and returns the value as its result. The operands must be of the same type (or the right-hand operand must be implicitly convertible to the type of the left-hand operand).  
  
## Remarks  
 The assignment operator cannot be overloaded. However, you can define implicit conversion operators for a type, which enable you to use the assignment operator with those types. For more information, see [Using Conversion Operators](../../../csharp/programming-guide/statements-expressions-operators/using-conversion-operators.md).  
  
## Example  
 [!code-csharp[csRefOperators#49](../../../csharp/language-reference/operators/codesnippet/CSharp/assignment-operator_1.cs)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Operators](../../../csharp/language-reference/operators/index.md)
