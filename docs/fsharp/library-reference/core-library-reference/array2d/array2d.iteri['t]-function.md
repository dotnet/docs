---
title: Array2D.iteri<'T> Function (F#)
description: Array2D.iteri<'T> Function (F#)
ms.date: 1/3/2020
---

# Array2D.iteri<'T> Function (F#)

Applies the given function to each element of the array. The integer indices passed to the function indicate the index of element.

## Syntax

```fsharp
// Signature:
Array2D.iteri : (int -> int -> 'T -> unit) -> 'T [,] -> unit

// Usage:
Array2D.iteri action array
```

#### Parameters
*action*
Type: `int -> int -> 'T -> unit`

A function to apply to each element of the array with the indices available as an argument.

*array*
Type: [`'T [,]`](../core.['t]-type-2d-[fsharp].md)

The input array.

## Remarks
This function is named `IterateIndexed` in compiled assemblies. If you are accessing the member from a language other than F#, or through reflection, use this name.

## See Also
[Collections.Array2D Module](index.md)

[Microsoft.FSharp.Collections Namespace](../Microsoft.FSharp.Collections-Namespace.md)