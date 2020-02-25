---
title: LanguagePrimitives.DivideByIntDynamic<'T> Function (F#)
description: LanguagePrimitives.DivideByIntDynamic<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 2915f87d-e391-40f7-9f9a-7036bf0ae28c 
---

# LanguagePrimitives.DivideByIntDynamic<'T> Function (F#)

A compiler intrinsic that implements dynamic invocations for the [DivideByInt](https://msdn.microsoft.com/library/24b70b03-c9fb-4edf-b04e-c9d8355fe1ca) primitive.

**Namespace/Module Path:** Microsoft.FSharp.Core.LanguagePrimitives

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
DivideByIntDynamic : 'T -> int -> 'T

// Usage:
DivideByIntDynamic x y
```

#### Parameters
*x*
Type: **'T**


The dividend, or numerator.


*y*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


The divisor, or denominator.

## Return Value

The quotient.

## Remarks
This function is for use by compiled F# code and should not be used directly.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Core.LanguagePrimitives Module &#40;F&#35;&#41;](Core.LanguagePrimitives-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)