---
title: HashCompare.FastHashTuple5<'T1,'T2,'T3,'T4,'T5> Function (F#)
description: HashCompare.FastHashTuple5<'T1,'T2,'T3,'T4,'T5> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 9557c38c-39ad-4390-b955-39e62edaad47 
---

# HashCompare.FastHashTuple5<'T1,'T2,'T3,'T4,'T5> Function (F#)

A primitive entry point used by the F# compiler for optimization purposes.

**Namespace/Module Path**: Microsoft.FSharp.Core.LanguagePrimitives.HashCompare

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
FastHashTuple5 : IEqualityComparer -> 'T1 * 'T2 * 'T3 * 'T4 * 'T5 -> int

// Usage:
FastHashTuple5 comparer tuple
```

#### Parameters
*comparer*
Type: **System.Collections.IEqualityComparer**


A comparer object.


*tuple*
Type: **'T1 &#42; 'T2 &#42; 'T3 &#42; 'T4 &#42; 'T5**


A tuple of five elements.


## Return Value

The computed hash.

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