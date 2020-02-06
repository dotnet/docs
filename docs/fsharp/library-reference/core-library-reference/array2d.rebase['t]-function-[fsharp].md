---
title: Array2D.rebase<'T> Function (F#)
description: Array2D.rebase<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 533e4e17-1a7f-41cf-9f5d-875a77bf07f2 
---

# Array2D.rebase<'T> Function (F#)

Creates a new array whose elements are the same as the input array but where a non-zero-based input array generates a corresponding zero-based output array.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Array2D

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Array2D.rebase : 'T [,] -> 'T [,]

// Usage:
Array2D.rebase array
```

#### Parameters
*array*
Type: **'T**[[,]](https://msdn.microsoft.com/library/077252f3-e6ce-441c-9d5b-a6030eaef7cd)


The input array.

## Return Value

The zero-based output array.

## Remarks
This function is named `Rebase` in compiled assemblies. If you are accessing the function from a .NET language other than F#, or through reflection, use this name.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Array2D Module &#40;F&#35;&#41;](Collections.Array2D-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)