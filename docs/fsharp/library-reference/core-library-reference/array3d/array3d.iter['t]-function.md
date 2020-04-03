---
title: Array3D.iter<'T> Function (F#)
description: Array3D.iter<'T> Function (F#)index.md
ms.date: 3/3/2020
---

# Array3D.iter<'T> Function (F#)

Applies the given function to each element of the array.

## Syntax

```fsharp
// Signature:
Array3D.iter : ('T -> unit) -> 'T [,,] -> unit

// Usage:
Array3D.iter action array
```

#### Parameters
*action*
Type: **'T -&gt;**[unit](https://msdn.microsoft.com/library/00b837c2-6c8a-483a-87d3-0479c64037a7)


The function to apply to each element of the array.


*array*
Type: **'T**[[,,]](https://msdn.microsoft.com/library/b4e5b35b-dc83-4b50-94aa-85fcf3ccb2b0)


The input array.




## Remarks
This function is named `Iterate` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## See Also
[Collections.Array3D Module](index.md)

[Microsoft.FSharp.Collections Namespace](Microsoft.FSharp.Collections-Namespace.md)
