---
title: Array2D.copy<'T> Function (F#)
description: Array2D.copy<'T> Function (F#)
ms.date: 1/3/2020
---

# Array2D.copy<'T> Function (F#)

Creates a new array whose elements are the same as the input array.

## Syntax

```fsharp
// Signature:
Array2D.copy : 'T [,] -> 'T [,]

// Usage:
Array2D.copy array
```

#### Parameters
*array*
Type: [`'T [,]`](../core.['t]-type-2d-[fsharp].md)

The input array.

## Return Value

A copy of the input array.

## Remarks
For non-zero-based arrays the basing on an input array will be propagated to the output array.

This function is named `Copy` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## See Also
[Collections.Array2D Module](Collections.Array2D-Module.md)

[Microsoft.FSharp.Collections Namespace](../Microsoft.FSharp.Collections-Namespace.md)