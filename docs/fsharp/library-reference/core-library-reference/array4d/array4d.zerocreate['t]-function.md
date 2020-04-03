---
title: Array4D.zeroCreate<'T> Function (F#)
description: Array4D.zeroCreate<'T> Function (F#)
ms.date: 4/3/2020
---

# Array4D.zeroCreate<'T> Function (F#)

Creates an array where the entries are initially the default value.

## Syntax

```fsharp
// Signature:
Array4D.zeroCreate : int -> int -> int -> int -> 'T [,,,]

// Usage:
Array4D.zeroCreate length1 length2 length3 length4
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

## Return Value

The created array.

## Remarks
This function is named `ZeroCreate` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## See Also
[Array4D Module](index.md)

[Microsoft.FSharp.Collections Namespace](Microsoft.FSharp.Collections-Namespace.md)