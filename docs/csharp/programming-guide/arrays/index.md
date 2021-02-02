---
title: "Arrays - C# Programming Guide"
description: Store multiple variables of the same type in an array data structure in C#. Declare an array by specifying a type or specify Object to store any type.
ms.date: 01/22/2021
helpviewer_keywords:
  - "arrays [C#]"
  - "C# language, arrays"
ms.assetid: bb79bdde-e570-4c30-adb0-1dd5759ae041
---
# Arrays (C# Programming Guide)

You can store multiple variables of the same type in an array data structure. You declare an array by specifying the type of its elements. If you want the array to store elements of any type, you can specify `object` as its type. In the unified type system of C#, all types, predefined and user-defined, reference types and value types, inherit directly or indirectly from <xref:System.Object>.

```csharp
type[] arrayName;
```

## Example

The following example creates single-dimensional, multidimensional, and jagged arrays:

[!code-csharp[csProgGuideArrays#1](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#1)]

## Array overview

An array has the following properties:

- An array can be [single-dimensional](single-dimensional-arrays.md), [multidimensional](multidimensional-arrays.md) or [jagged](jagged-arrays.md).
- The number of dimensions and the length of each dimension are established when the array instance is created. These values can't be changed during the lifetime of the instance.
- The default values of numeric array elements are set to zero, and reference elements are set to null.
- A jagged array is an array of arrays, and therefore its elements are reference types and are initialized to `null`.
- Arrays are zero indexed: an array with `n` elements is indexed from `0` to `n-1`.
- Array elements can be of any type, including an array type.
- Array types are [reference types](../../language-reference/keywords/reference-types.md) derived from the abstract base type <xref:System.Array>. Since this type implements <xref:System.Collections.IEnumerable> and <xref:System.Collections.Generic.IEnumerable%601>, you can use [foreach](../../language-reference/keywords/foreach-in.md) iteration on all arrays in C#.

### Arrays as Objects

In C#, arrays are actually objects, and not just addressable regions of contiguous memory as in C and C++. <xref:System.Array> is the abstract base type of all array types. You can use the properties and other class members that <xref:System.Array> has. An example of this is using the <xref:System.Array.Length%2A> property to get the length of an array. The following code assigns the length of the `numbers` array, which is `5`, to a variable called `lengthOfNumbers`:

[!code-csharp[csProgGuideArrays#3](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#3)]

The <xref:System.Array> class provides many other useful methods and properties for sorting, searching, and copying arrays. The following example uses the <xref:System.Array.Rank%2A> property to display the number of dimensions of an array.

[!code-csharp[csProgGuideArrays#2](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#2)]

## See also

- [How to use single-dimensional arrays](single-dimensional-arrays.md)
- [How to use multi-dimensional arrays](multidimensional-arrays.md)
- [How to use jagged arrays](jagged-arrays.md)
- [Using foreach with arrays](using-foreach-with-arrays.md)
- [Passing arrays as arguments](passing-arrays-as-arguments.md)
- [Implicitly typed arrays](implicitly-typed-arrays.md)
- [C# Programming Guide](../index.md)
- [Collections](../concepts/collections.md)

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]
