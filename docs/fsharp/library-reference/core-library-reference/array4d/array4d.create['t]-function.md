---
title: Array4D.create<'T> Function (F#)
description: Array4D.create<'T> Function (F#)
ms.date: 4/3/2020
---

# Array4D.create<'T> Function (F#)

Creates an array whose elements are all initially the given value

## Syntax

```fsharp
// Signature:
Array4D.create : int -> int -> int -> int -> 'T -> 'T [,,,]

// Usage:
Array4D.create length1 length2 length3 length4 initial
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


*length4*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


The length of the fourth dimension.


*initial*
Type: **'T**


The initial value for each element of the array.

## Return Value

The created array.

## Remarks
This function is named `Create` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## See Also
[Array4D Module](index.md)

[Microsoft.FSharp.Collections Namespace](Microsoft.FSharp.Collections-Namespace.md)