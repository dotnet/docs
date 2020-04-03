---
title: Array2D.get<'T> Function (F#)
description: Array2D.get<'T> Function (F#)
ms.date: 1/3/2020
---

# Array2D.get<'T> Function (F#)

Fetches an element from a 2D array. You can also use the syntax **array.[index1,index2]**.

## Syntax

```fsharp
// Signature:
Array2D.get : 'T [,] -> int -> int -> 'T

// Usage:
Array2D.get array index1 index2
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

## Return Value

Returns the value of the array at the given index.

## Remarks

This function is named `Get` in compiled assemblies. If you are accessing the member from a language other than F#, or through reflection, use this name.

## See Also

[Collections.Array2D Module](Collections.Array2D-Module.md)

[Microsoft.FSharp.Collections Namespace](../Microsoft.FSharp.Collections-Namespace.md)
