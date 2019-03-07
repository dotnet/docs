---
title: "How to: increment and decrement pointers - C# Programming Guide"
ms.custom: seodec18
ms.date: 07/20/2015
helpviewer_keywords: 
  - "pointers [C#], increment and decrement"
  - "pointer expressions [C#], increment and decrement"
ms.assetid: 1b8b9281-44ee-485a-9045-3db38a4b4b89
---
# How to: increment and decrement pointers (C# Programming Guide)

Use the increment and the decrement operators, `++` and `--`, to change the pointer location by `sizeof(pointer-type)` for a pointer of the type `pointer-type*`. The increment and decrement expressions take the following form:  
  
```csharp
++p;  
p++;  
--p;  
p--;  
```  
  
 The increment and decrement operators can be applied to pointers of any type except the type `void*`.  
  
 The effect of applying the increment operator to a pointer of the type `pointer-type*` is to add `sizeof(pointer-type)` to the address that is contained in the pointer variable.  
  
 The effect of applying the decrement operator to a pointer of the type `pointer-type*` is to subtract `sizeof(pointer-type)` from the address that is contained in the pointer variable.  
  
 No exceptions are generated when the operation overflows the domain of the pointer, and the result depends on the implementation.  
  
## Example  
 In this example, you step through an array by incrementing the pointer by the size of `int`. With each step, you display the address and the content of the array element.  
  
 [!code-csharp[csProgGuidePointers#3](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuidePointers/CS/Pointers2.cs#3)]  
  
 [!code-csharp[csProgGuidePointers#13](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuidePointers/CS/Pointers.cs#13)]  
  
**Value:0 @ Address:12860272**
**Value:1 @ Address:12860276**
**Value:2 @ Address:12860280**
**Value:3 @ Address:12860284**
**Value:4 @ Address:12860288**

## See also

- [C# Programming Guide](../../../csharp/programming-guide/index.md)
- [Pointer Expressions](../../../csharp/programming-guide/unsafe-code-pointers/pointer-expressions.md)
- [C# Operators](../../../csharp/language-reference/operators/index.md)
- [Manipulating Pointers](../../../csharp/programming-guide/unsafe-code-pointers/manipulating-pointers.md)
- [Pointer types](../../../csharp/programming-guide/unsafe-code-pointers/pointer-types.md)
- [Types](../../../csharp/language-reference/keywords/types.md)
- [unsafe](../../../csharp/language-reference/keywords/unsafe.md)
- [fixed Statement](../../../csharp/language-reference/keywords/fixed-statement.md)
- [stackalloc](../../../csharp/language-reference/keywords/stackalloc.md)
- [sizeof](../../../csharp/language-reference/keywords/sizeof.md)
