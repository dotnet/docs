---
title: Parallel.partition<'T> Function
description: Parallel.partition<'T> Function
ms.date: 02/27/2020
---

# Parallel.partition<'T> Function

Splits the collection into two collections, containing the elements for which the given predicate returns `true` and `false`, respectively

**Namespace/Module Path**: Microsoft.FSharp.Collections.ArrayModule.Parallel

## Syntax

```fsharp
// Signature:
partition : ('T -> bool) -> 'T [] -> 'T [] * 'T []

// Usage:
partition predicate array
```

#### Parameters
*predicate*
Type: **'T -&gt;**[bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5)

The function to test the input elements.

*array*
Type: **'T**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)

The input array.

## Return Value

The two collections.

## Remarks
Performs the operation in parallel using `System.Threading.Tasks.Parallel.For`. The order in which the given function is applied to indices is not specified.

This function is named `Partition` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## See Also
[Array.Parallel Module](array.parallel-module.md)

[Collections.Array Module](../index.md)
