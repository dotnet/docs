---
title: Array2D.rebase<'T> Function (F#)
description: Array2D.rebase<'T> Function (F#)
ms.date: 1/3/2020
---

# Array2D.rebase<'T> Function (F#)

Creates a new array whose elements are the same as the input array but where a non-zero-based input array generates a corresponding zero-based output array.

## Syntax

```fsharp
// Signature:
Array2D.rebase : 'T [,] -> 'T [,]

// Usage:
Array2D.rebase array
```

#### Parameters
*array*
Type: [`'T [,]`](../core.['t]-type-2d-[fsharp].md)

The input array.

## Return Value

The zero-based output array.

## Remarks
This function is named `Rebase` in compiled assemblies. If you are accessing the function from a .NET language other than F#, or through reflection, use this name.

## See Also
[Collections.Array2D Module](index.md)

[Microsoft.FSharp.Collections Namespace](../Microsoft.FSharp.Collections-Namespace.md)