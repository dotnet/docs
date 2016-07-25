---
title: Unchecked.compare<'T> Function (F#)
description: Unchecked.compare<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 590fee98-88c2-41ac-9b1b-f2bc3a3a9df3 
---

# Unchecked.compare<'T> Function (F#)

Perform generic comparison on two values where the type of the values is not statically required to have the comparison constraint.

**Namespace/Module Path:** Microsoft.FSharp.Core.Operators.Unchecked

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
compare : 'T -> 'T -> int

// Usage:
compare lhs rhs
```

#### Parameters
*lhs*
Type: **'T**


The first value to compare.


*rhs*
Type: **'T**


The second value to compare.

## Return Value

The result of the comparison. The result follows the convention for comparison results: -1 if lhs is less then rhs; 1 if lhs is greater than rhs; 0 if they are equal.

## Remarks
This function is named `Compare` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable, Portable

## See Also
[Operators.Unchecked Module &#40;F&#35;&#41;](Operators.Unchecked-Module-%5BFSharp%5D.md)

[Core.Operators Module &#40;F&#35;&#41;](Core.Operators-Module-%5BFSharp%5D.md)