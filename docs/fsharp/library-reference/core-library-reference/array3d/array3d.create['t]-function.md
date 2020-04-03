---
title: Array3D.create<'T> Function (F#)
description: Array3D.create<'T> Function (F#)index.md
ms.date: 3/3/2020
---

# Array3D.create<'T> Function (F#)

Creates an array whose elements are all initially the given value.

## Syntax

```fsharp
// Signature:
Array3D.create : int -> int -> int -> 'T -> 'T [,,]

// Usage:
Array3D.create length1 length2 length3 initial
```

#### Parameters
*length1*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


The length of the first dimension.


*length2*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


The length of the second dimension.


*length3*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


The length of the third dimension.


*initial*
Type: **'T**


The value of the array elements.

## Return Value

The created array.

## Remarks
This function is named `Create` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## See Also
[Collections.Array3D Module](index.md)

[Microsoft.FSharp.Collections Namespace](Microsoft.FSharp.Collections-Namespace.md)