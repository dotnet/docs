---
title: "Using foreach with arrays - C# Programming Guide"
description: The foreach statement in C# iterates through the elements of an array. For single-dimensional arrays, foreach processes elements in increasing index order.
ms.date: 05/23/2018
helpviewer_keywords: 
  - "arrays [C#], foreach"
  - "foreach statement [C#], using with arrays"
ms.assetid: 5f2da2a9-1f56-4de5-94cc-e07f4f7a0244
---
# Using foreach with arrays (C# Programming Guide)

The [foreach](../../language-reference/statements/iteration-statements.md#the-foreach-statement) statement provides a simple, clean way to iterate through the elements of an array.

For single-dimensional arrays, the `foreach` statement processes elements in increasing index order, starting with index 0 and ending with index `Length - 1`:

 [!code-csharp[csProgGuideArrays#28](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#28)]

For multi-dimensional arrays, elements are traversed such that the indices of the rightmost dimension are increased first, then the next left dimension, and so on to the left:

 [!code-csharp[csProgGuideArrays#29](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#29)]

However, with multidimensional arrays, using a nested [for](../../language-reference/statements/iteration-statements.md#the-for-statement) loop gives you more control over the order in which to process the array elements.

## See also

- <xref:System.Array>
- [C# Programming Guide](../index.md)
- [Arrays](index.md)
- [Single-Dimensional Arrays](single-dimensional-arrays.md)
- [Multidimensional Arrays](multidimensional-arrays.md)
- [Jagged Arrays](jagged-arrays.md)
