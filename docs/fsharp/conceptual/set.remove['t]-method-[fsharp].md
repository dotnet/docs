---
title: Set.Remove<'T> Method (F#)
description: Set.Remove<'T> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 26efbedf-1641-4195-acab-dab70ba19950 
---

# Set.Remove<'T> Method (F#)

A useful shortcut for [Set.remove](https://msdn.microsoft.com/library/812a6d19-c1f0-4c57-9cbe-15d141d64ddb). Note this operation produces a new set and does not mutate the original set. The new set will share many storage nodes with the original. See the [Set module](https://msdn.microsoft.com/library/61efa732-d55d-4c32-993f-628e2f98e6a0) for further operations on sets.

**Namespace/Module Path:** Microsoft.FSharp.Collections

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
member this.Remove : 'T -> Set<'T> (requires comparison)

// Usage:
set.Remove (value)
```

#### Parameters
*value*
Type: **'T**


The value to remove from the set.


## Return Value

The result set.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Set&#60;'T&#62; Class &#40;F&#35;&#41;](Collections.Set%5B%27T%5D-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)