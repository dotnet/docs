---
title: Operators.round<^T> Function (F#)
description: Operators.round<^T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 62afe362-a224-4653-ad14-db96ce00acea
---

# Operators.round<^T> Function (F#)

Round the given number.

**Namespace/Module Path:** Microsoft.FSharp.Core.Operators

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
round : ^T -> ^T (requires ^T with static member Round)

// Usage:
round value
```

#### Parameters
*value*
Type: **^T**


The input value.

## Return Value

The nearest integer to the input value, using the same semantics as `System.Math.Round`.

## Remarks
This function is named `Round` in compiled assemblies. If you are accessing the function from a .NET language other than F#, or through reflection, use this name.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Core.Operators Module &#40;F&#35;&#41;](Core.Operators-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)
