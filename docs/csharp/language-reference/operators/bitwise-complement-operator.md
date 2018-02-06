---
title: "~ Operator (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "~_CSharpKeyword"
helpviewer_keywords: 
  - "tilde (~) one's complement operator [C#]"
  - "~ operator [C#]"
  - "~ [C#], bitwise complement operator"
  - "bitwise complement operator [C#]"
ms.assetid: 11bc078a-50e2-4d7e-9896-67ef669dc602
caps.latest.revision: 18
author: "BillWagner"
ms.author: "wiwagn"
---
# ~ Operator (C# Reference)
The `~` operator performs a bitwise complement operation on its operand, which has the effect of reversing each bit. Bitwise complement operators are predefined for [int](../../../csharp/language-reference/keywords/int.md), [uint](../../../csharp/language-reference/keywords/uint.md), [long](../../../csharp/language-reference/keywords/long.md), and [ulong](../../../csharp/language-reference/keywords/ulong.md).  
  
> [!NOTE]
>  The `~` symbol also is used to declare finalizers. For more information, see [Finalizers](../../../csharp/programming-guide/classes-and-structs/destructors.md).  
  
## Remarks  
 User-defined types can overload the `~` operator. For more information, see [operator](../../../csharp/language-reference/keywords/operator.md). Operations on integral types are generally allowed on enumeration.  
  
## Example  
 [!code-csharp[csRefOperators#25](../../../csharp/language-reference/operators/codesnippet/CSharp/bitwise-complement-operator_1.cs)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Operators](../../../csharp/language-reference/operators/index.md)  
 [Finalizers](../../../csharp/programming-guide/classes-and-structs/destructors.md)
