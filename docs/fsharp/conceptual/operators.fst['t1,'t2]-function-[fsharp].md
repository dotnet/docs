---
title: Operators.fst<'T1,'T2> Function (F#)
description: Operators.fst<'T1,'T2> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: cd81917e-87b7-4786-adc2-d189d1ce6688
---

# Operators.fst<'T1,'T2> Function (F#)

Return the first element of a tuple, `fst (a,b) = a`.

**Namespace/Module Path:** Microsoft.FSharp.Core.Operators

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
fst : 'T1 * 'T2 -> 'T1

// Usage:
fst tuple
```

#### Parameters
*tuple*
Type: **'T1 &#42; 'T2**


The input tuple.

## Return Value

The first value.

## Remarks
This function is named `Fst` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Core.Operators Module &#40;F&#35;&#41;](Core.Operators-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)
