---
title: Map.ofList<'Key,'T> Function (F#)
description: Map.ofList<'Key,'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 6b28aca1-b5b2-441f-b082-728521ecbc2c
---

# Map.ofList<'Key,'T> Function (F#)

Returns a new map made from the given bindings.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Map

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Map.ofList : 'Key * 'T list -> Map<'Key,'T> (requires comparison)

// Usage:
Map.ofList elements
```

#### Parameters
*elements*
Type: **'Key &#42; 'T**[list](https://msdn.microsoft.com/library/c627b668-477b-4409-91ed-06d7f1b3e4a7)


The input list of key/value pairs.

## Return Value

The resulting map.

## Remarks
This function is named `OfList` in compiled assemblies. If accessing the function from a language other than F#, or through reflection, use this name.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Map Module &#40;F&#35;&#41;](Collections.Map-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)
