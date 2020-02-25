---
title: LanguagePrimitives.AdditionDynamic<'T1,'T2,'U> Function (F#)
description: LanguagePrimitives.AdditionDynamic<'T1,'T2,'U> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 799185d9-fefb-4375-b60b-99bea123b7c8 
---

# LanguagePrimitives.AdditionDynamic<'T1,'T2,'U> Function (F#)

A compiler intrinsic that implements dynamic invocations of the `+` operator.

**Namespace/Module Path:** Microsoft.FSharp.Core.LanguagePrimitives

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
AdditionDynamic : 'T1 -> 'T2 -> 'U

// Usage:
AdditionDynamic x y
```

#### Parameters
*x*
Type: **'T1**


The first operand.


*y*
Type: **'T2**


The second operand.

## Return Value

The sum of the operands.

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