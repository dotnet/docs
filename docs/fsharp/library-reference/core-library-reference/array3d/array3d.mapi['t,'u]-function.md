---
title: Array3D.mapi<'T,'U> Function (F#)
description: Array3D.mapi<'T,'U> Function (F#)index.md
ms.date: 3/3/2020
---

# Array3D.mapi<'T,'U> Function (F#)

Builds a new array whose elements are the results of applying the given function to each of the elements of the array. The integer indices passed to the function indicates the element being transformed.

## Syntax

```fsharp
// Signature:
Array3D.mapi : (int -> int -> int -> 'T -> 'U) -> 'T [,,] -> 'U [,,]

// Usage:
Array3D.mapi mapping array
```

#### Parameters
*mapping*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)**-&gt;**[int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)**-&gt;**[int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)**-&gt; 'T -&gt; 'U**


The function to transform the elements at each index in the array.


*array*
Type: **'T**[[,,]](https://msdn.microsoft.com/library/b4e5b35b-dc83-4b50-94aa-85fcf3ccb2b0)


The input array.

## Return Value

The array created from the transformed elements.

## Remarks
For non-zero-based arrays the basing on an input array will be propagated to the output array.

This function is named `MapIndexed` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## See Also
[Collections.Array3D Module](index.md)

[Microsoft.FSharp.Collections Namespace](Microsoft.FSharp.Collections-Namespace.md)