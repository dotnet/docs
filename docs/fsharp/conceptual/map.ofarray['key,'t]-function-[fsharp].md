---
title: Map.ofArray<'Key,'T> Function (F#)
description: Map.ofArray<'Key,'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: b82c41f8-dcce-4392-8c25-760f655299de
---

# Map.ofArray<'Key,'T> Function (F#)

Returns a new map made from the given bindings.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Map

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Map.ofArray : ('Key * 'T) [] -> Map<'Key,'T> (requires comparison)

// Usage:
Map.ofArray elements
```

#### Parameters
*elements*
Type: **('Key &#42; 'T)**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)


The input array of key/value pairs.

## Return Value

The resulting map.

## Remarks
This function is named `OfArray` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Map Module &#40;F&#35;&#41;](Collections.Map-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)
