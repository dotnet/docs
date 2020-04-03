---
title: Array2D.set<'T> Function (F#)
description: Array2D.set<'T> Function (F#)
ms.date: 1/3/2020
---

# Array2D.set<'T> Function (F#)

Sets the value of an element in an array.

## Syntax

```fsharp
// Signature:
Array2D.set : 'T [,] -> int -> int -> 'T -> unit

// Usage:
Array2D.set array index1 index2 value
```

#### Parameters

*array*
Type: [`'T [,]`](../core.['t]-type-2d-[fsharp].md)

The input array.

*index1*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)

The index along the first dimension.

*index2*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)

The index along the second dimension.

*value*
Type: **'T**

The value to set in the array.

## Remarks

You can also use the syntax `array.[index1,index2] <- value`.

This function is named `Set` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## See Also

[Collections.Array2D Module](Collections.Array2D-Module.md)

[Microsoft.FSharp.Collections Namespace](../Microsoft.FSharp.Collections-Namespace.md)
