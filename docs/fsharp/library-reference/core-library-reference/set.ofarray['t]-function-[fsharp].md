---
title: Set.ofArray<'T> Function (F#)
description: Set.ofArray<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: b89b8b6f-220a-488a-bca0-e701269199db 
---

# Set.ofArray<'T> Function (F#)

Creates a set that contains the same elements as the given array.

**Namespace/Module Path**: Microsoft.FSharp.Collections.Set

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Set.ofArray : 'T array -> Set<'T> (requires comparison)

// Usage:
Set.ofArray array
```

#### Parameters
*array*
Type: **'T array**


The input array.

## Return Value

A set containing the elements of array.

## Remarks

This function is named `OfArray` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Set Module &#40;F&#35;&#41;](Collections.Set-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)