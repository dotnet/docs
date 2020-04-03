---
title: Array2D.zeroCreateBased<'T> Function (F#)
description: Array2D.zeroCreateBased<'T> Function (F#)
ms.date: 1/3/2020
---

# Array2D.zeroCreateBased<'T> Function (F#)

Creates a based array where the entries are initially [Unchecked.defaultof&lt;'T&gt;](https://msdn.microsoft.com/library/9ff97f2a-1bd4-4f4c-afbe-5886a74ab977).

## Syntax

```fsharp
// Signature:
Array2D.zeroCreateBased : int -> int -> int -> int -> 'T [,]

// Usage:
Array2D.zeroCreateBased base1 base2 length1 length2
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

## Return Value

Returns the created array.

## Remarks

This function is named `ZeroCreateBased` in compiled assemblies. If you are accessing the function from a .NET language other than F#, or through reflection, use this name.

## See Also

[Collections.Array2D Module](Collections.Array2D-Module.md)

[Microsoft.FSharp.Collections Namespace](../Microsoft.FSharp.Collections-Namespace.md)