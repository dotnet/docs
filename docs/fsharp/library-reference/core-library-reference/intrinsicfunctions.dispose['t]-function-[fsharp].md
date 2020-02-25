---
title: IntrinsicFunctions.Dispose<'T> Function (F#)
description: IntrinsicFunctions.Dispose<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 4e261c31-9b82-43e5-89c3-0eca0d9bb3d6 
---

# IntrinsicFunctions.Dispose<'T> Function (F#)

A compiler intrinsic for the efficient compilation of sequence expressions.

**Namespace/Module Path:** Microsoft.FSharp.Core.LanguagePrimitives.IntrinsicFunctions

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Dispose : 'T -> unit (requires 'T :> IDisposable)

// Usage:
Dispose resource
```

#### Parameters
*resource*
Type: **'T**

## Remarks
This function is for use by compiled F# code and should not be used directly.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[LanguagePrimitives.IntrinsicFunctions Module &#40;F&#35;&#41;](LanguagePrimitives.IntrinsicFunctions-Module-%5BFSharp%5D.md)

[Core.LanguagePrimitives Module &#40;F&#35;&#41;](Core.LanguagePrimitives-Module-%5BFSharp%5D.md)