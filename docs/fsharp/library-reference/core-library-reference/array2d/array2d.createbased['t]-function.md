---
title: Array2D.createBased<'T> Function (F#)
description: Array2D.createBased<'T> Function (F#)
ms.date: 1/3/2020
---

# Array2D.createBased<'T> Function (F#)

Creates a based array whose elements are all initially the given value.

## Syntax

```fsharp
// Signature:
Array2D.createBased : int -> int -> int -> int -> 'T -> 'T [,]

// Usage:
Array2D.createBased base1 base2 length1 length2 initial
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

*initial*
Type: **'T**

The value to populate the new array.

## Return Value

Returns the created array.

## Remarks

This function is named `CreateBased` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## See Also

[Collections.Array2D Module](Collections.Array2D-Module.md)

[Microsoft.FSharp.Collections Namespace](../Microsoft.FSharp.Collections-Namespace.md)