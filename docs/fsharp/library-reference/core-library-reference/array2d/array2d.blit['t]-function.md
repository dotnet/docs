---
title: Array2D.blit<'T> Function (F#)
description: Array2D.blit<'T> Function (F#)
ms.date: 1/3/2020
---

# Array2D.blit<'T> Function (F#)

Reads a range of elements from the first array and writes them into the second.

## Syntax

```fsharp
// Signature:
Array2D.blit : 'T [,] -> int -> int -> 'T [,] -> int -> int -> int -> int -> unit

// Usage:
Array2D.blit source sourceIndex1 sourceIndex2 target targetIndex1 targetIndex2 length1 length2
```

#### Parameters

*source*
Type: [`'T [,]`](../core.['t]-type-2d-[fsharp].md)

The source array.

*sourceIndex1*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)

The first-dimension index to begin copying from in the source array.

*sourceIndex2*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)

The second-dimension index to begin copying from in the source array.

*target*
Type: [`'T [,]`](../core.['t]-type-2d-[fsharp].md)

The target array.

*targetIndex1*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)

The first-dimension index to begin copying into in the target array.

*targetIndex2*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)

The second-dimension index to begin copying into in the target array.

*length1*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)

The number of elements to copy across the first dimension of the arrays.

*length2*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)

The number of elements to copy across the second dimension of the arrays.

## Remarks

This function is named `CopyTo` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## See Also

[Collections.Array2D Module](Collections.Array2D-Module.md)

[Microsoft.FSharp.Collections Namespace](../Microsoft.FSharp.Collections-Namespace.md)