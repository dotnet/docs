---
title: Array3D.get<'T> Function (F#)
description: Array3D.get<'T> Function (F#)index.md
ms.date: 3/3/2020
---

# Array3D.get<'T> Function (F#)

Fetches an element from a 3D array.

## Syntax

```fsharp
// Signature:
Array3D.get : 'T [,,] -> int -> int -> int -> 'T

// Usage:
Array3D.get array index1 index2 index3
```

#### Parameters
*array*
Type: **'T**[[,,]](https://msdn.microsoft.com/library/b4e5b35b-dc83-4b50-94aa-85fcf3ccb2b0)


The input array.


*index1*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


The index along the first dimension.


*index2*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


The index along the second dimension.


*index3*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


The index along the third dimension.

## Return Value

The value at the given index.

## Remarks
You can also use the syntax `array.[index1,index2,index3]`.

This function is named `Get` in compiled assemblies. If you are accessing the member from a language other than F#, or through reflection, use this name.

## See Also
[Collections.Array3D Module](index.md)

[Microsoft.FSharp.Collections Namespace](Microsoft.FSharp.Collections-Namespace.md)