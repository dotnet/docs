---
title: Array3D.init<'T> Function (F#)
description: Array3D.init<'T> Function (F#)index.md
ms.date: 3/3/2020
---

# Array3D.init<'T> Function (F#)

Creates an array given the dimensions and a generator function to compute the elements.

## Syntax

```fsharp
// Signature:
Array3D.init : int -> int -> int -> (int -> int -> int -> 'T) -> 'T [,,]

// Usage:
Array3D.init length1 length2 length3 initializer
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


*initializer*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)**-&gt;**[int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)**-&gt;**[int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)**-&gt; 'T**


The function to create an initial value at each index into the array.

## Return Value

The created array.

## Remarks
This function is named `Initialize` in compiled assemblies. If you are accessing the function from a .NET language other than F#, or through reflection, use this name.

## See Also
[Collections.Array3D Module](index.md)

[Microsoft.FSharp.Collections Namespace](Microsoft.FSharp.Collections-Namespace.md)