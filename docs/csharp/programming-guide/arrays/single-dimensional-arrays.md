---
title: "Single-Dimensional Arrays - C# Programming Guide"
description: Create a single-dimensional array in C# using the new operator specifying the array element type and the number of elements. 
ms.date: 06/03/2020
helpviewer_keywords: 
  - "single-dimensional arrays [C#]"
  - "arrays [C#], single-dimensional"
ms.assetid: 2cec1196-1de0-49d2-baf2-c607c33310e8
---
# Single-Dimensional Arrays (C# Programming Guide)

You create a single-dimensional array using the [new](../../language-reference/operators/new-operator.md) operator specifying the array element type and the number of elements. The following example declares an array of five integers:

:::code language="csharp" source="snippets/SingleDimensionArrays.cs" id="IntDeclaration":::

This array contains the elements from `array[0]` to `array[4]`. The elements of the array are initialized to the [default value](../../language-reference/builtin-types/default-values.md) of the element type, `0` for integers.

Arrays can store any element type you specify, such as the following example that declares an array of strings:

:::code language="csharp" source="snippets/SingleDimensionArrays.cs" id="StringDeclaration":::

## Array Initialization

You can initialize the elements of an array when you declare the array. The length specifier isn't needed because it's inferred by the number of elements in the initialization list. For example:

:::code language="csharp" source="snippets/SingleDimensionArrays.cs" id="IntInitialization":::

The following code shows a declaration of a string array where each array element is initialized by a name of a day:

:::code language="csharp" source="snippets/SingleDimensionArrays.cs" id="StringInitialization":::
  
You can avoid the `new` expression and the array type when you initialize an array upon declaration, as shown in the following code. This is called an [implicitly typed array](implicitly-typed-arrays.md):

:::code language="csharp" source="snippets/SingleDimensionArrays.cs" id="ShorthandInitialization":::

You can declare an array variable without creating it, but you must use the `new` operator when you assign a new array to this variable. For example:

:::code language="csharp" source="snippets/SingleDimensionArrays.cs" id="DeclareAllocate":::

## Value Type and Reference Type Arrays

Consider the following array declaration:  

:::code language="csharp" source="snippets/SingleDimensionArrays.cs" id="FinalInstantiation":::

The result of this statement depends on whether `SomeType` is a value type or a reference type. If it's a value type, the statement creates an array of 10 elements, each of which has the type `SomeType`. If `SomeType` is a reference type, the statement creates an array of 10 elements, each of which is initialized to a null reference. In both instances, the elements are initialized to the default value for the element type. For more information about value types and reference types, see [Value types](../../language-reference/builtin-types/value-types.md) and [Reference types](../../language-reference/keywords/reference-types.md).

## Retreving data from Array

You can retrieve the data of an array by using an index. For example:

:::code language="csharp" source="snippets/RetrevingArrayElements.cs" id="RetrevingDataArray" interactive="try-dotnet-method":::
  
## See also

- <xref:System.Array>
- [Arrays](./index.md)
- [Multidimensional Arrays](./multidimensional-arrays.md)
- [Jagged Arrays](./jagged-arrays.md)
