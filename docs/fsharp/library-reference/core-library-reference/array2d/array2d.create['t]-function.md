---
title: Array2D.create<'T> Function (F#)
description: Array2D.create<'T> Function (F#)
ms.date: 1/3/2020
---

# Array2D.create<'T> Function (F#)

Creates an array whose elements are all initially the given value.


## Syntax

```fsharp
// Signature:
Array2D.create : int -> int -> 'T -> 'T [,]

// Usage:
Array2D.create length1 length2 value
```

#### Parameters

*length1*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)

The length of the first dimension of the array.

*length2*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)

The length of the second dimension of the array.

*value*
Type: **'T**

The value to populate the new array.

## Return Value

Returns the created array.

## Remarks

This function is named `Create` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## See Also

[Collections.Array2D Module](Collections.Array2D-Module.md)

[Microsoft.FSharp.Collections Namespace](../Microsoft.FSharp.Collections-Namespace.md)