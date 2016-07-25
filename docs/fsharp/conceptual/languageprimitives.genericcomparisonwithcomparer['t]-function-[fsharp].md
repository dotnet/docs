---
title: LanguagePrimitives.GenericComparisonWithComparer<'T> Function (F#)
description: LanguagePrimitives.GenericComparisonWithComparer<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: e710c87e-69b6-4059-8a50-06b704cd2321 
---

# LanguagePrimitives.GenericComparisonWithComparer<'T> Function (F#)

Compare two values. May be called as a recursive case from an implementation of `System.IComparable` to ensure consistent NaN comparison semantics.

**Namespace/Module Path:** Microsoft.FSharp.Core.LanguagePrimitives

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
GenericComparisonWithComparer : IComparer -> 'T -> 'T -> int (requires comparison)

// Usage:
GenericComparisonWithComparer comp e1 e2
```

#### Parameters
*comp*
Type: **System.Collections.IComparer**


The function to compare the values.


*e1*
Type: **'T**


The first value.


*e2*
Type: **'T**


The second value.


## Return Value

The result of the comparison.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Core.LanguagePrimitives Module &#40;F&#35;&#41;](Core.LanguagePrimitives-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)