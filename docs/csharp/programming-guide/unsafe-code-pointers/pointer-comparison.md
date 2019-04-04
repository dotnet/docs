---
title: "Pointer Comparison - C# Programming Guide"
ms.custom: seodec18
ms.date: 07/20/2015
helpviewer_keywords: 
  - "pointers [C#], comparison"
ms.assetid: fcafd514-7405-4deb-8490-cc58efda5495
---
# Pointer Comparison (C# Programming Guide)
You can apply the following operators to compare pointers of any type:  
  
 **==   !=   \<   >   \<=   >=**  
  
 The comparison operators compare the addresses of the two operands as if they are unsigned integers.  
  
## Example  
 [!code-csharp[csProgGuidePointers#16](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuidePointers/CS/Pointers2.cs#16)]  
  
 [!code-csharp[csProgGuidePointers#17](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuidePointers/CS/Pointers.cs#17)]  
  
## Sample Output  
 `True`  
  
 `False`  
  
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
