---
title: "How to: access a member with a pointer - C# Programming Guide"
ms.custom: seodec18
ms.date: 07/20/2015
helpviewer_keywords: 
  - "pointers [C#], member access"
ms.assetid: 1e998498-8c85-4a78-8ce2-4d8c20f08342
---
# How to: access a member with a pointer (C# Programming Guide)
To access a member of a struct that is declared in an unsafe context, you can use the member access operator as shown in the following example in which `p` is a pointer to a [struct](../../../csharp/language-reference/keywords/struct.md) that contains a member `x`.  
  
```  
CoOrds* p = &home;  
p -> x = 25; //member access operator ->  
```  
  
## Example  
 In this example, a [struct](../../../csharp/language-reference/keywords/struct.md), `CoOrds`, that contains the two coordinates `x` and `y` is declared and instantiated. By using the member access operator `->` and a pointer to the instance `home`, `x` and `y` are assigned values.  
  
> [!NOTE]
>  Notice that the expression `p->x` is equivalent to the expression `(*p).x`, and you can obtain the same result by using either of the two expressions.  
  
 [!code-csharp[csProgGuidePointers#9](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuidePointers/CS/Pointers2.cs#9)]  
  
 [!code-csharp[csProgGuidePointers#10](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuidePointers/CS/Pointers.cs#10)]  
  
## See also

- [C# Programming Guide](../../../csharp/programming-guide/index.md)
- [Pointer Expressions](../../../csharp/programming-guide/unsafe-code-pointers/pointer-expressions.md)
- [Pointer types](../../../csharp/programming-guide/unsafe-code-pointers/pointer-types.md)
- [Types](../../../csharp/language-reference/keywords/types.md)
- [unsafe](../../../csharp/language-reference/keywords/unsafe.md)
- [fixed Statement](../../../csharp/language-reference/keywords/fixed-statement.md)
- [stackalloc](../../../csharp/language-reference/keywords/stackalloc.md)
