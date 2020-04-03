---
title: Array2D.map<'T,'U> Function (F#)
description: Array2D.map<'T,'U> Function (F#)
ms.date: 1/3/2020
---

# Array2D.map<'T,'U> Function (F#)

Creates a new array whose elements are the results of applying the given function to each of the elements of the array.

## Syntax

```fsharp
// Signature:
Array2D.map : ('T -> 'U) -> 'T [,] -> 'U [,]

// Usage:
Array2D.map mapping array
```

#### Parameters
*mapping*
Type: **'T -&gt; 'U**

A function that is applied to transform each item of the input array.

*array*
Type: [`'T [,]`](../core.['t]-type-2d-[fsharp].md)

The input array.

## Return Value

An array whose elements have been transformed by the given mapping.

## Remarks
For non-zero-based arrays the basing on an input array will be propagated to the output array.

This function is named `Map` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## See Also
[Collections.Array2D Module](index.md)

[Microsoft.FSharp.Collections Namespace](../Microsoft.FSharp.Collections-Namespace.md)