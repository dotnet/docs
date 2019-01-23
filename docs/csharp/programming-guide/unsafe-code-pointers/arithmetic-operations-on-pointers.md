---
title: "Arithmetic operations on pointers - C# Programming Guide"
ms.custom: seodec18
ms.date: 07/20/2015
helpviewer_keywords: 
  - "pointers [C#], arithmetic operations"
ms.assetid: d4f0b623-827e-45ce-8649-cfcebc8692aa
---
# Arithmetic operations on pointers (C# Programming Guide)
This topic discusses using the arithmetic operators `+` and `-` to manipulate pointers.  
  
> [!NOTE]
>  You cannot perform any arithmetic operations on void pointers.  
  
## Adding and subtracting numeric values to or from pointers  
 You can add a value `n` of type [int](../../../csharp/language-reference/keywords/int.md), [uint](../../../csharp/language-reference/keywords/uint.md), [long](../../../csharp/language-reference/keywords/long.md), or [ulong](../../../csharp/language-reference/keywords/ulong.md) to a pointer. If `p` is a pointer of the type `pointer-type*`, the result `p+n` is the pointer resulting from adding `n * sizeof(pointer-type)` to the address of `p`. Similarly, `p-n` is the pointer resulting from subtracting `n * sizeof(pointer-type)` from the address of `p`.  
  
## Subtracting pointers  
 You can also subtract pointers of the same type. The result is always of the type `long`. For example, if `p1` and `p2` are pointers of the type `pointer-type*`, then the expression `p1-p2` results in:  
  
 `((long)p1 - (long)p2)/sizeof(pointer-type)`  
  
 No exceptions are generated when the arithmetic operation overflows the domain of the pointer, and the result depends on the implementation.  
  
## Example  
 [!code-csharp[csProgGuidePointers#14](../../../csharp/programming-guide/unsafe-code-pointers/codesnippet/CSharp/arithmetic-operations-on-pointers_1.cs)]  
  
 [!code-csharp[csProgGuidePointers#15](../../../csharp/programming-guide/unsafe-code-pointers/codesnippet/CSharp/arithmetic-operations-on-pointers_2.cs)]  
  
## C# language specification  
 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See also

- [C# Programming Guide](../../../csharp/programming-guide/index.md)
- [Unsafe Code and Pointers](../../../csharp/programming-guide/unsafe-code-pointers/index.md)
- [Pointer Expressions](../../../csharp/programming-guide/unsafe-code-pointers/pointer-expressions.md)
- [C# Operators](../../../csharp/language-reference/operators/index.md)
- [Manipulating Pointers](../../../csharp/programming-guide/unsafe-code-pointers/manipulating-pointers.md)
- [Pointer types](../../../csharp/programming-guide/unsafe-code-pointers/pointer-types.md)
- [Types](../../../csharp/language-reference/keywords/types.md)
- [unsafe](../../../csharp/language-reference/keywords/unsafe.md)
- [fixed Statement](../../../csharp/language-reference/keywords/fixed-statement.md)
- [stackalloc](../../../csharp/language-reference/keywords/stackalloc.md)
