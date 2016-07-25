---
title: Map.Remove<'Key,'Value> Method (F#)
description: Map.Remove<'Key,'Value> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 2ec50220-dd7e-4898-b59e-1931071ba96e
---

# Map.Remove<'Key,'Value> Method (F#)

Removes an element from the domain of the map. No exception is raised if the element is not present.

**Namespace/Module Path:** Microsoft.FSharp.Collections

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
member this.Remove : 'Key -> Map<'Key, 'Value> (requires comparison)

// Usage:
map.Remove (key)
```

#### Parameters
*key*
Type: **'Key**


The input key.

## Return Value

The resulting map.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Map&#60;'Key,'Value&#62; Class &#40;F&#35;&#41;](Collections.Map%5B%27Key%2C%27Value%5D-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)
