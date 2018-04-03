---
title: "* Operator (C# Reference)"
ms.date: 04/04/2018
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "*_CSharpKeyword"
helpviewer_keywords: 
  - "multiplication operator (*) [C#]"
  - "* operator [C#]"
ms.assetid: abd9a5f0-9b24-431e-971a-09ee1c45c50e
caps.latest.revision: 14
author: "BillWagner"
ms.author: "wiwagn"
---
# * Operator (C# Reference)
The multiplication operator (`*`) computes the product of its operands. All numeric types have predefined multiplication operators.  

`*` also serves as the dereference operator, which allows reading and writing to a pointer.
  
## Remarks  
 The `*` operator is also used to declare pointer types and to dereference pointers. This operator can only be used in unsafe contexts, denoted by the use of the [unsafe](../../../csharp/language-reference/keywords/unsafe.md) keyword, and requiring the [/unsafe](../../../csharp/language-reference/compiler-options/unsafe-compiler-option.md) compiler option.  The dereference operator is also known as the indirection operator.  
  
 User-defined types can overload the binary `*` operator (see [operator](../../../csharp/language-reference/keywords/operator.md)). When a binary operator is overloaded, the corresponding assignment operator, if any, is also implicitly overloaded.  
  
## Example  
 [!code-csharp[csRefOperators#50](../../../csharp/language-reference/operators/codesnippet/CSharp/multiplication-operator_1.cs)]  
  
## Example  
 [!code-csharp[csRefOperators#51](../../../csharp/language-reference/operators/codesnippet/CSharp/multiplication-operator_2.cs)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [Unsafe Code and Pointers](../../../csharp/programming-guide/unsafe-code-pointers/index.md)  
 [C# Operators](../../../csharp/language-reference/operators/index.md)
