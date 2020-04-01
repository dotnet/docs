---
title: Parallel.mapi<'T,'U> Function
description: Parallel.mapi<'T,'U> Function
ms.date: 02/27/2020
---

# Parallel.mapi<'T,'U> Function

Build a new array whose elements are the results of applying the given function to each of the elements of the array. The integer index passed to the function indicates the index of element being transformed.

**Namespace/Module Path**: Microsoft.FSharp.Collections.ArrayModule.Parallel

## Syntax

```fsharp
// Signature:
mapi : (int -> 'T -> 'U) -> 'T [] -> 'U []

// Usage:
mapi mapping array
```

#### Parameters
*mapping*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)**-&gt; 'T -&gt; 'U**

*array*
Type: **'T**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)

The input array.

## Return Value

'U[]

## Remarks
Performs the operation in parallel using `System.Threading.Tasks.Parallel.For`. The order in which the given function is applied to elements of the input array is not specified.

This function is named `MapIndexed` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## See Also
[Array.Parallel Module](array.parallel-module.md)

[Collections.Array Module](../index.md)
