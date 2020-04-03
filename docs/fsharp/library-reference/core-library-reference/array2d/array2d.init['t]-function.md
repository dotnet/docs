---
title: Array2D.init<'T> Function (F#)
description: Array2D.init<'T> Function (F#)
ms.date: 1/3/2020
---

# Array2D.init<'T> Function (F#)

Creates an array given the dimensions and a generator function to compute the elements.

## Syntax

```fsharp
// Signature:
Array2D.init : int -> int -> (int -> int -> 'T) -> 'T [,]

// Usage:
Array2D.init length1 length2 initializer
```

#### Parameters

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

Returns the generated array.

## Remarks

This function is named `Initialize` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

The following code demonstrates the use of `Array2D.init` to create a two-dimensional array.

[!code-fsharp[Main](~/samples/snippets/fsharp/arrays/snippet21.fs)]

## See Also

[Collections.Array2D Module](Collections.Array2D-Module.md)

[Microsoft.FSharp.Collections Namespace](../Microsoft.FSharp.Collections-Namespace.md)
