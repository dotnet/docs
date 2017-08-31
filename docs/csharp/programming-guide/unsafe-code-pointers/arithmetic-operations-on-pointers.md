---
title: "Arithmetic Operations on Pointers (C# Programming Guide) | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "pointers [C#], arithmetic operations"
ms.assetid: d4f0b623-827e-45ce-8649-cfcebc8692aa
caps.latest.revision: 18
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# Arithmetic Operations on Pointers (C# Programming Guide)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

This topic discusses using the arithmetic operators `+` and **-** to manipulate pointers.  
  
> [!NOTE]
>  You cannot perform any arithmetic operations on void pointers.  
  
## Adding and Subtracting Numeric Values to or From Pointers  
 You can add a value `n` of type [int](../../../csharp/language-reference/keywords/int.md), [uint](../../../csharp/language-reference/keywords/uint.md), [long](../../../csharp/language-reference/keywords/long.md), or [ulong](../../../csharp/language-reference/keywords/ulong.md) to a pointer, `p`,of any type except `void*`. The result `p+n` is the pointer resulting from adding `n * sizeof(p) to the address of p`. Similarly, `p-n` is the pointer resulting from subtracting `n * sizeof(p)` from the address of `p`.  
  
## Subtracting Pointers  
 You can also subtract pointers of the same type. The result is always of the type `long`. For example, if `p1` and `p2` are pointers of the type `pointer-type*`, then the expression `p1-p2` results in:  
  
 `((long)p1 - (long)p2)/sizeof(pointer_type)`  
  
 No exceptions are generated when the arithmetic operation overflows the domain of the pointer, and the result depends on the implementation.  
  
## Example  
 [!code-csharp[csProgGuidePointers#14](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuidePointers/CS/Pointers2.cs#14)]  
  
 [!code-csharp[csProgGuidePointers#15](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuidePointers/CS/Pointers.cs#15)]  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../../../includes/csharplangspec-md.md)]  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [Unsafe Code and Pointers](../../../csharp/programming-guide/unsafe-code-pointers/index.md)   
 [Pointer Expressions](../../../csharp/programming-guide/unsafe-code-pointers/pointer-expressions.md)   
 [C# Operators](../../../csharp/language-reference/operators/index.md)   
 [Manipulating Pointers](../../../csharp/programming-guide/unsafe-code-pointers/manipulating-pointers.md)   
 [Pointer types](../../../csharp/programming-guide/unsafe-code-pointers/pointer-types.md)   
 [Types](../../../csharp/language-reference/keywords/types.md)   
 [unsafe](../../../csharp/language-reference/keywords/unsafe.md)   
 [fixed Statement](../../../csharp/language-reference/keywords/fixed-statement.md)   
 [stackalloc](../../../csharp/language-reference/keywords/stackalloc.md)