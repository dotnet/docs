---
title: Map.ofSeq<'Key,'T> Function (F#)
description: Map.ofSeq<'Key,'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: b65038b0-9121-4d19-af44-660f231a5ad3
---

# Map.ofSeq<'Key,'T> Function (F#)

Returns a new map made from the given bindings.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Map

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Map.ofSeq : seq<'Key * 'T> -> Map<'Key,'T> (requires comparison)

// Usage:
Map.ofSeq elements
```

#### Parameters
*elements*
Type: [seq](https://msdn.microsoft.com/library/2f0c87c6-8a0d-4d33-92a6-10d1d037ce75)**&lt;'Key &#42; 'T&gt;**


The input sequence of key/value pairs.

## Return Value

The resulting map.

## Remarks
This function is named `OfSeq` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Map Module &#40;F&#35;&#41;](Collections.Map-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)
