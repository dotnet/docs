---
title: Parallel.iter<'T> Function
description: Parallel.iter<'T> Function
ms.date: 02/27/2020
---

# Parallel.iter<'T> Function

Apply the given function to each element of the array.

**Namespace/Module Path:** Microsoft.FSharp.Collections.ArrayModule.Parallel

## Syntax

```fsharp
// Signature:
iter : ('T -> unit) -> 'T [] -> unit

// Usage:
iter action array
```

#### Parameters
*action*
Type: **'T -&gt;**[unit](https://msdn.microsoft.com/library/00b837c2-6c8a-483a-87d3-0479c64037a7)

*array*
Type: **'T**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)

The input array.

## Remarks
Performs the operation in parallel using `System.Threading.Parallel.For`. The order in which the given function is applied to elements of the input array is not specified.

This function is named `Iterate` in the .NET assembly. If accessing the member from a .NET language other than F#, or through reflection, use this name.

## See Also
[Array.Parallel Module](array.parallel-module.md)

[Collections.Array Module](../index.md)
