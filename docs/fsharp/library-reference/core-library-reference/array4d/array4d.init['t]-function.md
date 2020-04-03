---
title: Array4D.init<'T> Function (F#)
description: Array4D.init<'T> Function (F#)
ms.date: 4/3/2020
---

# Array4D.init<'T> Function (F#)

Creates an array given the dimensions and a generator function to compute the elements.

## Syntax

```fsharp
// Signature:
Array4D.init : int -> int -> int -> int -> (int -> int -> int -> int -> 'T) -> 'T [,,,]

// Usage:
Array4D.init length1 length2 length3 length4 initializer
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


*initializer*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)**-&gt;**[int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)**-&gt;**[int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)**-&gt;**[int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)**-&gt; 'T**


The function to create an initial value at each index in the array.

## Return Value

The created array.

## Remarks
This function is named `Initialize` in the assembly. If you are accessing the function from a language other than F#, or through reflection, use this name.

## See Also
[Array4D Module](index.md)

[Microsoft.FSharp.Collections Namespace](Microsoft.FSharp.Collections-Namespace.md)