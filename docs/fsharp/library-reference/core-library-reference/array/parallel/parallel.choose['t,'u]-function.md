---
title: Parallel.choose<'T,'U> Function
description: Parallel.choose<'T,'U> Function
ms.date: 02/27/2020
---

# Parallel.choose<'T,'U> Function

Applies a supplied function to each element of an array and returns an array that contains the results for each element where the function returns `Some`.

**Namespace/Module Path:** Microsoft.FSharp.Collections.ArrayModule.Parallel

## Syntax

```fsharp
// Signature:
choose : ('T -> 'U option) -> 'T [] -> 'U []

// Usage:
choose chooser array
```

#### Parameters
*chooser*
Type: **'T -&gt; 'U**[option](https://msdn.microsoft.com/library/b08add48-34bf-4410-80a1-ef6a8daddc58)

The function used to generate options from the elements.

*array*
Type: **'T**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)

The input array.

## Return Value

The array that contains the results for each element where the function returns `Some`.

## Remarks
This function performs the operation in parallel by using `System.Threading.Tasks.Parallel.For`. The order in which the given function is applied to elements of the input array is not specified.

This function is named `Choose` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## See Also
[Array.Parallel Module](array.parallel-module.md)

[Collections.Array Module](../index.md)
