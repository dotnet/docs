---
title: Array3D.map<'T,'U> Function (F#)
description: Array3D.map<'T,'U> Function (F#)index.md
ms.date: 3/3/2020
---

# Array3D.map<'T,'U> Function (F#)

Creates a new array whose elements are the results of applying the given function to each of the elements of the array.

## Syntax

```fsharp
// Signature:
Array3D.map : ('T -> 'U) -> 'T [,,] -> 'U [,,]

// Usage:
Array3D.map mapping array
```

#### Parameters
*mapping*
Type: **'T -&gt; 'U**


The function to transform each element of the array.


*array*
Type: **'T**[[,,]](https://msdn.microsoft.com/library/b4e5b35b-dc83-4b50-94aa-85fcf3ccb2b0)


The input array.

## Return Value

The array created from the transformed elements.

## Remarks
For non-zero-based arrays the basing on an input array will be propagated to the output array.

This function is named `Map` in compiled assemblies. If you are accessing the function from a .NET language other than F#, or through reflection, use this name.

## See Also
[Collections.Array3D Module](index.md)

[Microsoft.FSharp.Collections Namespace](Microsoft.FSharp.Collections-Namespace.md)