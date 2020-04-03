---
title: Array2D.iter<'T> Function (F#)
description: Array2D.iter<'T> Function (F#)
ms.date: 1/3/2020
---

# Array2D.iter<'T> Function (F#)

Applies the given function to each element of the array.

## Syntax

```fsharp
// Signature:
Array2D.iter : ('T -> unit) -> 'T [,] -> unit

// Usage:
Array2D.iter action array
```

#### Parameters
*action*
Type: **'T -&gt;**[unit](https://msdn.microsoft.com/library/00b837c2-6c8a-483a-87d3-0479c64037a7)

A function to apply to each element of the array.

*array*
Type: [`'T [,]`](../core.['t]-type-2d-[fsharp].md)

The input array.

## Remarks
This function is named `Iterate` in compiled assemblies. If you are accessing the function from a .NET language other than F#, or through reflection, use this name.


## See Also
[Collections.Array2D Module](index.md)

[Microsoft.FSharp.Collections Namespace](../Microsoft.FSharp.Collections-Namespace.md)