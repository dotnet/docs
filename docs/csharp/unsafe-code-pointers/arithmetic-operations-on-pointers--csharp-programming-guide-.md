---
title: "Arithmetic Operations on Pointers (C# Programming Guide)"
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
translation.priority.ht: 
  - "cs-cz"
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "pl-pl"
  - "pt-br"
  - "ru-ru"
  - "tr-tr"
  - "zh-cn"
  - "zh-tw"
---
# Arithmetic Operations on Pointers (C# Programming Guide)
This topic discusses using the arithmetic operators `+` and **-** to manipulate pointers.  
  
> [!NOTE]
>  You cannot perform any arithmetic operations on void pointers.  
  
## Adding and Subtracting Numeric Values to or From Pointers  
 You can add a value `n` of type [int](../keywords/int--csharp-reference-.md), [uint](../keywords/uint--csharp-reference-.md), [long](../keywords/long--csharp-reference-.md), or [ulong](../keywords/ulong--csharp-reference-.md) to a pointer, `p`,of any type except `void*`. The result `p+n` is the pointer resulting from adding `n * sizeof(p) to the address of p`. Similarly, `p-n` is the pointer resulting from subtracting `n * sizeof(p)` from the address of `p`.  
  
## Subtracting Pointers  
 You can also subtract pointers of the same type. The result is always of the type `long`. For example, if `p1` and `p2` are pointers of the type `pointer-type*`, then the expression `p1-p2` results in:  
  
 `((long)p1 - (long)p2)/sizeof(pointer_type)`  
  
 No exceptions are generated when the arithmetic operation overflows the domain of the pointer, and the result depends on the implementation.  
  
## Example  
 [!code[csProgGuidePointers#14](../unsafe-code-pointers/codesnippet/CSharp/arithmetic-operations-on-pointers--csharp-programming-guide-_1.cs)]  
  
 [!code[csProgGuidePointers#15](../unsafe-code-pointers/codesnippet/CSharp/arithmetic-operations-on-pointers--csharp-programming-guide-_2.cs)]  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../arrays/includes/csharplangspec_md.md)]  
  
## See Also  
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [Unsafe Code and Pointers](../unsafe-code-pointers/unsafe-code-and-pointers--csharp-programming-guide-.md)   
 [Pointer Expressions](../unsafe-code-pointers/pointer-expressions--csharp-programming-guide-.md)   
 [C# Operators](../operators/csharp-operators.md)   
 [Manipulating Pointers](../unsafe-code-pointers/manipulating-pointers--csharp-programming-guide-.md)   
 [Pointer types](../unsafe-code-pointers/pointer-types--csharp-programming-guide-.md)   
 [Types](../keywords/types--csharp-reference-.md)   
 [unsafe](../keywords/unsafe--csharp-reference-.md)   
 [fixed Statement](../keywords/fixed-statement--csharp-reference-.md)   
 [stackalloc](../keywords/stackalloc--csharp-reference-.md)