---
title: Unchecked.equals<'T> Function (F#)
description: Unchecked.equals<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 741c8794-eb6a-4989-8027-ef834ee54d34 
---

# Unchecked.equals<'T> Function (F#)

Perform generic equality on two values where the type of the values is not statically required to satisfy the equality constraint.

**Namespace/Module Path:** Microsoft.FSharp.Core.Operators.Unchecked

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
equals : 'T -> 'T -> bool

// Usage:
equals lhs rhs
```

#### Parameters
*lhs*
Type: **'T**


The first value to compare.


*rhs*
Type: **'T**


The second value to compare.


## Return Value

The result of the comparison.

## Remarks
This function is named `Equals` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Operators.Unchecked Module &#40;F&#35;&#41;](Operators.Unchecked-Module-%5BFSharp%5D.md)

[Core.Operators Module &#40;F&#35;&#41;](Core.Operators-Module-%5BFSharp%5D.md)