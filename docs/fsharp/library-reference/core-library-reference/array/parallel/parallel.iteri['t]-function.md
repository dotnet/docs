---
title: Parallel.iteri<'T> Function
description: Parallel.iteri<'T> Function
ms.date: 02/27/2020
---

# Parallel.iteri<'T> Function

Apply the given function to each element of the array. The integer passed to the function indicates the index of element.

**Namespace/Module Path**: Microsoft.FSharp.Collections.ArrayModule.Parallel
## Syntax

```
// Signature:
iteri : (int -> 'T -> unit) -> 'T [] -> unit

// Usage:
iteri action array
```

#### Parameters
*action*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)**-&gt; 'T -&gt;**[unit](https://msdn.microsoft.com/library/00b837c2-6c8a-483a-87d3-0479c64037a7)

*array*
Type: **'T**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)

The input array.

## Remarks
Performs the operation in parallel using `System.Threading.Tasks.Parallel.For`. The order in which the given function is applied to elements of the input array is not specified.

This function is named `IterateIndexed` in compiled assemblies. If you are accessing the member from a .NET language other than F#, or through reflection, use this name.

## See Also
[Array.Parallel Module](array.parallel-module.md)

[Collections.Array Module](../index.md)
