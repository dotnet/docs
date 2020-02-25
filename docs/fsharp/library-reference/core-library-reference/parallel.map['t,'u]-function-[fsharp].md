---
title: Parallel.map<'T,'U> Function (F#)
description: Parallel.map<'T,'U> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 484f2e81-d544-4203-a629-13bf8a8e24f1
---

# Parallel.map<'T,'U> Function (F#)

Creates a new array whose elements are the results of applying the given function to each of the elements of the array.

**Namespace/Module Path**: Microsoft.FSharp.Collections.ArrayModule.Parallel

**Assembly**: FSharp.Core (in FSharp.Core.dll)


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


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 4.0


## See Also
[Array.Parallel Module &#40;F&#35;&#41;](Array.Parallel-Module-%5BFSharp%5D.md)

[Collections.Array Module &#40;F&#35;&#41;](Collections.Array-Module-%5BFSharp%5D.md)
