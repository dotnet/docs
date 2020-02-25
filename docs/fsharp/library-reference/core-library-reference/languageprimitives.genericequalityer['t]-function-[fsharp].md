---
title: LanguagePrimitives.GenericEqualityER<'T> Function (F#)
description: LanguagePrimitives.GenericEqualityER<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 269cdbb0-4b1d-4931-882c-5915149d155c 
---

# LanguagePrimitives.GenericEqualityER<'T> Function (F#)

Compare two values for equality using equivalence relation semantics ([nan] = [nan]).

**Namespace/Module Path:** Microsoft.FSharp.Core.LanguagePrimitives

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
GenericEqualityER : 'T -> 'T -> bool (requires equality)

// Usage:
GenericEqualityER e1 e2
```

#### Parameters
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