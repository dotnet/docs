---
title: Parallel.collect<'T,'U> Function (F#)
description: Parallel.collect<'T,'U> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 8c575eca-8999-4569-b956-0f1b43f269b9
---

# Parallel.collect<'T,'U> Function (F#)

For each element of the array, apply the given function. Concatenate all the results and return the combined array.

**Namespace/Module Path:** Microsoft.FSharp.Collections.ArrayModule.Parallel

**Assembly:** FSharp.Core (in FSharp.Core.dll)


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


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 4.0


## See Also
[Array.Parallel Module &#40;F&#35;&#41;](Array.Parallel-Module-%5BFSharp%5D.md)

[Collections.Array Module &#40;F&#35;&#41;](Collections.Array-Module-%5BFSharp%5D.md)
