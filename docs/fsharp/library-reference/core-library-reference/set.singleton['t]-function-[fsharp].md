---
title: Set.singleton<'T> Function (F#)
description: Set.singleton<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 7c1d6747-d835-4beb-b7e0-7be93ae2a158 
---

# Set.singleton<'T> Function (F#)

The set containing the given element.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Set

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Set.singleton : 'T -> Set<'T> (requires comparison)

// Usage:
Set.singleton value
```

#### Parameters
*value*
Type: **'T**


The value for the set to contain.


## Return Value

The set containing value.

## Remarks
This function is named `Singleton` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Set Module &#40;F&#35;&#41;](Collections.Set-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)