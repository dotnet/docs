---
title: Array2D.copy<'T> Function (F#)
description: Array2D.copy<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: d7279629-41ad-4f89-b9f6-9b808eed7b2a 
---

# Array2D.copy<'T> Function (F#)

Creates a new array whose elements are the same as the input array.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Array2D

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Array2D.copy : 'T [,] -> 'T [,]

// Usage:
Array2D.copy array
```

#### Parameters
*array*
Type: **'T**[[,]](https://msdn.microsoft.com/library/077252f3-e6ce-441c-9d5b-a6030eaef7cd)


The input array.

## Return Value

A copy of the input array.

## Remarks
For non-zero-based arrays the basing on an input array will be propagated to the output array.

This function is named `Copy` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Array2D Module &#40;F&#35;&#41;](Collections.Array2D-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)