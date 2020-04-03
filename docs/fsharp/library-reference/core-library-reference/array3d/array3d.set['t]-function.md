---
title: Array3D.set<'T> Function (F#)
description: Array3D.set<'T> Function (F#)index.md
ms.date: 3/3/2020
---

# Array3D.set<'T> Function (F#)

Sets the value of an element in an array.

## Syntax

```fsharp
// Signature:
Array3D.set : 'T [,,] -> int -> int -> int -> 'T -> unit

// Usage:
Array3D.set array index1 index2 index3 value
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


*value*
Type: **'T**


The value to set at the given index.

## Remarks
You can also use the syntax `array.[index1,index2,index3] <- value`.

This function is named `Set` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## See Also
[Collections.Array3D Module](index.md)

[Microsoft.FSharp.Collections Namespace](Microsoft.FSharp.Collections-Namespace.md)