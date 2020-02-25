---
title: LanguagePrimitives.GenericMaximum<'T> Function (F#)
description: LanguagePrimitives.GenericMaximum<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: d3254b9d-d576-4d87-a0ad-f65ab138f826 
---

# LanguagePrimitives.GenericMaximum<'T> Function (F#)

Take the maximum of two values structurally according to the order given by [`GenericComparison`](https://msdn.microsoft.com/library/593650cc-029a-422f-b412-6e9fb5b0b5eb).

**Namespace/Module Path:** Microsoft.FSharp.Core.LanguagePrimitives

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
GenericMaximum : 'T -> 'T -> 'T (requires comparison)

// Usage:
GenericMaximum e1 e2
```

#### Parameters
*e1*
Type: **'T**


The first value.


*e2*
Type: **'T**


The second value.

## Return Value

The maximum value.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Core.LanguagePrimitives Module &#40;F&#35;&#41;](Core.LanguagePrimitives-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)