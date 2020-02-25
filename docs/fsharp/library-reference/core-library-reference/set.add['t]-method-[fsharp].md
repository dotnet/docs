---
title: Set.Add<'T> Method (F#)
description: Set.Add<'T> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: ffdceab1-2006-466f-ae80-505b8181beec 
---

# Set.Add<'T> Method (F#)

A useful shortcut for [Set.add](https://msdn.microsoft.com/library/d06ab305-1183-487c-8dc0-9076ed0b4c28). Note this operation produces a new set and does not mutate the original set. The new set will share many storage nodes with the original. See the [Set module](https://msdn.microsoft.com/library/61efa732-d55d-4c32-993f-628e2f98e6a0) for further operations on sets.

**Namespace/Module Path:** Microsoft.FSharp.Collections

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
member this.Add : 'T -> Set<'T> (requires comparison)

// Usage:
set.Add (value)
```

#### Parameters
*value*
Type: **'T**


The value to add to the set.

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