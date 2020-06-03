---
title: "Single-Dimensional Arrays - C# Programming Guide"
ms.date: 06/03/2020
helpviewer_keywords: 
  - "single-dimensional arrays [C#]"
  - "arrays [C#], single-dimensional"
ms.assetid: 2cec1196-1de0-49d2-baf2-c607c33310e8
---
# Single-Dimensional Arrays (C# Programming Guide)

You can declare a single-dimensional array of five integers as shown in the following example:

:::code language="csharp" source="snippets/SingleDimensionArrays.cs" id="IntDeclaration":::

This array contains the elements from `array[0]` to `array[4]`. The [new](../../language-reference/operators/new-operator.md) operator is used to create the array and initialize the array elements to their default values. In this example, all the array elements are initialized to zero.

An array that stores string elements can be declared in the same way. For example:

:::code language="csharp" source="snippets/SingleDimensionArrays.cs" id="StringDeclaration":::

## Array Initialization

It is possible to initialize an array upon declaration, in which case, the length specifier is not needed because it is already supplied by the number of elements in the initialization list. For example:

:::code language="csharp" source="snippets/SingleDimensionArrays.cs" id="IntInitialization":::

A string array can be initialized in the same way. The following is a declaration of a string array where each array element is initialized by a name of a day:

:::code language="csharp" source="snippets/SingleDimensionArrays.cs" id="StringInitialization":::
  
When you initialize an array upon declaration, you can use the following shortcuts:

:::code language="csharp" source="snippets/SingleDimensionArrays.cs" id="ShorthandInitialization":::

It is possible to declare an array variable without initialization, but you must use the `new` operator when you assign an array to this variable. For example:

:::code language="csharp" source="snippets/SingleDimensionArrays.cs" id="DeclareAllocate":::

C# 3.0 introduces implicitly typed arrays. For more information, see [Implicitly Typed Arrays](./implicitly-typed-arrays.md).
  
## Value Type and Reference Type Arrays

Consider the following array declaration:  

:::code language="csharp" source="snippets/SingleDimensionArrays.cs" id="FinalInstantiation":::

The result of this statement depends on whether `SomeType` is a value type or a reference type. If it is a value type, the statement creates an array of 10 elements, each of which has the type `SomeType`. If `SomeType` is a reference type, the statement creates an array of 10 elements, each of which is initialized to a null reference.  

For more information about value types and reference types, see [Value types](../../language-reference/builtin-types/value-types.md) and [Reference types](../../language-reference/keywords/reference-types.md).
  
## See also

- <xref:System.Array>
- [Arrays](./index.md)
- [Multidimensional Arrays](./multidimensional-arrays.md)
- [Jagged Arrays](./jagged-arrays.md)
