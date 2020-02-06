---
title: Operators.( .. )<^T> Function (F#)
description: Operators.( .. )<^T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 68c9c60f-3036-4f34-8b0e-c4d72dce2e6d 
---

# Operators.( .. )<^T> Function (F#)

The standard overloaded range operator, for example, `[n..m]` for lists, `seq {n..m}` for sequences.

**Namespace/Module Path:** Microsoft.FSharp.Core.Operators

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
( .. ) : ^T -> ^T -> seq<^T> (requires ^T with static member (+) and ^T with static member One)

// Usage:
start .. finish
```

#### Parameters
*start*
Type: **^T**


The start value of the range.


*finish*
Type: **^T**


The end value of the range.

## Return Value

The sequence spanning the range.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Core.Operators Module &#40;F&#35;&#41;](Core.Operators-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)