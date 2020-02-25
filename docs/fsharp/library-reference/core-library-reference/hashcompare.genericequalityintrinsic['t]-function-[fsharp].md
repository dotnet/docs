---
title: HashCompare.GenericEqualityIntrinsic<'T> Function (F#)
description: HashCompare.GenericEqualityIntrinsic<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 07c0d449-de6d-4e06-a8af-615e7dfc81f0 
---

# HashCompare.GenericEqualityIntrinsic<'T> Function (F#)

A primitive entry point used by the F# compiler for optimization purposes.

**Namespace/Module Path:** Microsoft.FSharp.Core.LanguagePrimitives.HashCompare

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
GenericEqualityIntrinsic : 'T -> 'T -> bool

// Usage:
GenericEqualityIntrinsic x y
```

#### Parameters
*x*
Type: **'T**


The first object to compare.


*y*
Type: **'T**


The second object to compare.


## Return Value

The result of the comparison.

## Remarks
This function is for use by compiled F# code and should not be used directly.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[LanguagePrimitives.HashCompare Module &#40;F&#35;&#41;](LanguagePrimitives.HashCompare-Module-%5BFSharp%5D.md)

[Core.LanguagePrimitives Module &#40;F&#35;&#41;](Core.LanguagePrimitives-Module-%5BFSharp%5D.md)