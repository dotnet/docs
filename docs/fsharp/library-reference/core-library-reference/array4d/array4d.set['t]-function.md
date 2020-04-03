---
title: Array4D.set<'T> Function (F#)
description: Array4D.set<'T> Function (F#)
ms.date: 4/3/2020
---

# Array4D.set<'T> Function (F#)

Sets the value of an element in an array.

## Syntax

```fsharp
// Signature:
Array4D.set : 'T [,,,] -> int -> int -> int -> int -> 'T -> unit

// Usage:
Array4D.set array index1 index2 index3 index4 value
```

#### Parameters
*array*
Type: **'T**[[,,,]](https://msdn.microsoft.com/library/e957316d-b2e0-4f04-ac4c-426d4f38a968)


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


*index4*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


The index along the fourth dimension.


*value*
Type: **'T**


The value to set.

## Remarks
You can also use the syntax `array.[index1,index2,index3,index4] <- value`.

This function is named `Set` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## See Also
[Array4D Module](index.md)

[Microsoft.FSharp.Collections Namespace](Microsoft.FSharp.Collections-Namespace.md)