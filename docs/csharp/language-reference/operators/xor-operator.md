---
title: "^ Operator (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "^_CSharpKeyword"
helpviewer_keywords: 
  - "^ operator [C#]"
  - "bitwise exclusive OR operator [C#]"
ms.assetid: b09bc815-570f-4db6-a637-5b4ed99d014a
caps.latest.revision: 19
author: "BillWagner"
ms.author: "wiwagn"
---
# ^ Operator (C# Reference)
Binary `^` operators are predefined for the integral types and `bool`. For integral types, `^` computes the bitwise exclusive-OR of its operands. For `bool` operands, `^` computes the logical exclusive-or of its operands; that is, the result is `true` if and only if exactly one of its operands is `true`.  
  
## Remarks  
 User-defined types can overload the `^` operator (see [operator](../../../csharp/language-reference/keywords/operator.md)). Operations on integral types are generally allowed on enumeration.  
  
## Example  
 [!code-csharp[csRefOperators#30](../../../csharp/language-reference/operators/codesnippet/CSharp/xor-operator_1.cs)]  
  
 The computation of `0xf8 ^ 0x3f` in the previous example performs a bitwise exclusive-OR of the following two binary values, which correspond to the hexadecimal values F8 and 3F:  
  
 `1111 1000`  
  
 `0011 1111`  
  
 The result of the exclusive-OR is `1100 0111`, which is C7 in hexadecimal.  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Operators](../../../csharp/language-reference/operators/index.md)
