---
title: Set.Contains<'T> Method (F#)
description: Set.Contains<'T> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 98be3bda-e4c0-4bc7-82ee-bac41fb43cdd 
---

# Set.Contains<'T> Method (F#)

A useful shortcut for [Set.contains](https://msdn.microsoft.com/library/7d616d1e-bca9-463e-b11e-88b5dc8b930b). See the [Set module](https://msdn.microsoft.com/library/61efa732-d55d-4c32-993f-628e2f98e6a0) for further operations on sets.

**Namespace/Module Path:** Microsoft.FSharp.Collections

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
member this.Contains : 'T -> bool (requires comparison)

// Usage:
set.Contains (value)
```

#### Parameters
*value*
Type: **'T**


The value to check.

## Return Value

True if the set contains value.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Set&#60;'T&#62; Class &#40;F&#35;&#41;](Collections.Set%5B%27T%5D-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)