---
title: Parallel.map<'T,'U> Function
description: Parallel.map<'T,'U> Function
ms.date: 02/27/2020
---

# Parallel.map<'T,'U> Function

Creates a new array whose elements are the results of applying the given function to each of the elements of the array.

**Namespace/Module Path**: Microsoft.FSharp.Collections.ArrayModule.Parallel

## Syntax

```fsharp
// Signature:
map : ('T -> 'U) -> 'T [] -> 'U []

// Usage:
map mapping array
```

#### Parameters
*mapping*
Type: **'T -&gt; 'U**

*array*
Type: **'T**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)

The input array.

## Return Value

An array whose elements are the result of applying the mapping function to each element of the input array.

## Remarks
This function performs the operation in parallel using `System.Threading.Tasks.Parallel.For`. The order in which the given function is applied to elements of the input array is not specified.

This function is named `Map` in compiled assemblies. If you are accessing the function from a .NET language other than F#, or through reflection, use this name.

## See Also
[Array.Parallel Module](array.parallel-module.md)

[Collections.Array Module](../index.md)
