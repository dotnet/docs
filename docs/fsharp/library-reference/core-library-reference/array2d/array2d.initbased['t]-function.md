---
title: Array2D.initBased<'T> Function (F#)
description: Array2D.initBased<'T> Function (F#)
ms.date: 1/3/2020
---

# Array2D.initBased<'T> Function (F#)

Creates a based array given the dimensions and a generator function to compute the elements.

## Syntax

```fsharp
// Signature:
Array2D.initBased : int -> int -> int -> int -> (int -> int -> 'T) -> 'T [,]

// Usage:
Array2D.initBased base1 base2 length1 length2 initializer
```

#### Parameters

*base1*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)

The base for the first dimension of the array.

*base2*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)

The base for the second dimension of the array.

*length1*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)

The length of the first dimension of the array.

*length2*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)

The length of the second dimension of the array.

*initializer*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)**-&gt;**[int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)**-&gt; 'T**

A function to produce elements of the array given the two indices.

## Return Value

Returns the created array.

## Remarks

This function is named `InitializeBased` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## See Also

[Collections.Array2D Module](index.md)

[Microsoft.FSharp.Collections Namespace](../Microsoft.FSharp.Collections-Namespace.md)
