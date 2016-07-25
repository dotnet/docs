---
title: Operators.atan2<^T1,'T2> Function (F#)
description: Operators.atan2<^T1,'T2> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 1b76593b-1590-434e-b38d-a9066f095a66
---

# Operators.atan2<^T1,'T2> Function (F#)

Inverse tangent of `x/y` where `x` and `y` are specified separately.

**Namespace/Module Path:** Microsoft.FSharp.Core.Operators

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
atan2 : ^T1 -> ^T1 -> 'T2 (requires ^T1 with static member Atan2)

// Usage:
atan2 y x
```

#### Parameters
*y*
Type: **^T1**


The y input value.


*x*
Type: **^T1**


The x input value.

## Return Value

The inverse tangent of the input ratio.

## Remarks
This function is named `Atan2` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Core.Operators Module &#40;F&#35;&#41;](Core.Operators-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)
