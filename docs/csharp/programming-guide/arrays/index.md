---
title: "Arrays - C# Programming Guide"
ms.custom: seodec18
ms.date: 07/20/2015
helpviewer_keywords: 
  - "arrays [C#]"
  - "C# language, arrays"
ms.assetid: bb79bdde-e570-4c30-adb0-1dd5759ae041
---
# Arrays (C# Programming Guide)

You can store multiple variables of the same type in an array data structure. You declare an array by specifying the type of its elements.  
  
 `type[] arrayName;`  
  
 The following example creates single-dimensional, multidimensional, and jagged arrays:  
  
 [!code-csharp[csProgGuideArrays#1](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#1)]  
  
## Array Overview

 An array has the following properties:  
  
-   An array can be [Single-Dimensional](../../../csharp/programming-guide/arrays/single-dimensional-arrays.md), [Multidimensional](../../../csharp/programming-guide/arrays/multidimensional-arrays.md) or [Jagged](../../../csharp/programming-guide/arrays/jagged-arrays.md).  
  
-   The number of dimensions and the length of each dimension are established when the array instance is created. These values can't be changed during the lifetime of the instance.  
  
-   The default values of numeric array elements are set to zero, and reference elements are set to null.  
  
-   A jagged array is an array of arrays, and therefore its elements are reference types and are initialized to `null`.  
  
-   Arrays are zero indexed: an array with `n` elements is indexed from `0` to `n-1`.  
  
-   Array elements can be of any type, including an array type.  
  
-   Array types are [reference types](../../../csharp/language-reference/keywords/reference-types.md) derived from the abstract base type <xref:System.Array>. Since this type implements <xref:System.Collections.IEnumerable> and <xref:System.Collections.Generic.IEnumerable%601>, you can use [foreach](../../../csharp/language-reference/keywords/foreach-in.md) iteration on all arrays in C#.  
  
## Related Sections  
  
-   [Arrays as Objects](../../../csharp/programming-guide/arrays/arrays-as-objects.md)  
  
-   [Using foreach with Arrays](../../../csharp/programming-guide/arrays/using-foreach-with-arrays.md)  
  
-   [Passing Arrays as Arguments](../../../csharp/programming-guide/arrays/passing-arrays-as-arguments.md)  
  
## C# Language Specification

 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See also

- [C# Programming Guide](../../../csharp/programming-guide/index.md)
- [Collections](../../../csharp/programming-guide/concepts/collections.md)
