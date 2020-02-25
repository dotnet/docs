---
title: Operators.compare<'T> Function (F#)
description: Operators.compare<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 635c2eb6-d5b7-4a0c-8ebd-a56a43d6be4e
---

# Operators.compare<'T> Function (F#)

Generic comparison.

**Namespace/Module Path:** Microsoft.FSharp.Core.Operators

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
compare : 'T -> 'T -> int (requires comparison)

// Usage:
compare e1 e2
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

## Remarks
This function is named `Compare` in compiled assemblies. If you are accessing the function from a .NET language other than F#, or through reflection, use this name.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable, Portable

## See Also
[Core.Operators Module &#40;F&#35;&#41;](Core.Operators-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)
