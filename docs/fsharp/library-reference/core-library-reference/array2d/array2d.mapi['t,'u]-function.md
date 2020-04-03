---
title: Array2D.mapi<'T,'U> Function (F#)
description: Array2D.mapi<'T,'U> Function (F#)
ms.date: 1/3/2020
---

# Array2D.mapi<'T,'U> Function (F#)

Builds a new array whose elements are the results of applying the given function to each of the elements of the array. The integer indices passed to the function indicates the element being transformed.

## Syntax

```fsharp
// Signature:
Array2D.mapi : (int -> int -> 'T -> 'U) -> 'T [,] -> 'U [,]

// Usage:
Array2D.mapi mapping array
```

#### Parameters
*mapping*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)**-&gt;**[int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)**-&gt; 'T -&gt; 'U**

A function that is applied to transform each element of the array. The two integers provide the index of the element.

*array*
Type: **'T**[[,]](https://msdn.microsoft.com/library/077252f3-e6ce-441c-9d5b-a6030eaef7cd)

The input array.

## Return Value

An array whose elements have been transformed by the given mapping.

## Remarks
For non-zero-based arrays the basing on an input array will be propagated to the output array.

This function is named `MapIndexed` in compiled assemblies. If you are accessing the member from a language other than F#, or through reflection, use this name.

## See Also
[Collections.Array2D Module](Collections.Array2D-Module.md)

[Microsoft.FSharp.Collections Namespace](../Microsoft.FSharp.Collections-Namespace.md)