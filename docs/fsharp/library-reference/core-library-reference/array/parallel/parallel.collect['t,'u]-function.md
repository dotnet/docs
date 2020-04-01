---
title: Parallel.collect<'T,'U> Function
description: Parallel.collect<'T,'U> Function
ms.date: 02/27/2020
---

# Parallel.collect<'T,'U> Function

For each element of the array, apply the given function. Concatenate all the results and return the combined array.

**Namespace/Module Path:** Microsoft.FSharp.Collections.ArrayModule.Parallel

## Syntax

```fsharp
// Signature:
collect : ('T -> 'U []) -> 'T [] -> 'U []

// Usage:
collect mapping array
```

#### Parameters
*mapping*
Type: **'T -&gt; 'U**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)


*array*
Type: **'T**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)


The input array.

## Return Value

The array of concatenated results.

## Remarks
Performs the operation in parallel using `System.Threading.Tasks.Parallel.For`. The order in which the given function is applied to elements of the input array is not specified.

This function is named `Collect` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## See Also
[Array.Parallel Module](array.parallel-module.md)

[Collections.Array Module](../index.md)
