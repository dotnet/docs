---
title: Operators.( .. .. )<^T,^Step> Function (F#)
description: Operators.( .. .. )<^T,^Step> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 3b66cda2-463f-4c14-a7f1-1a2a039407dc 
---

# Operators.( .. .. )<^T,^Step> Function (F#)

The standard overloaded skip range operator, for example, `[n..skip..m]` for lists, `seq {n..skip..m}` for sequences.

**Namespace/Module Path:** Microsoft.FSharp.Core.Operators

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
( .. .. ) : ^T -> ^Step -> ^T -> seq<^T> (requires ^T with static member (+) and ^Step with static member (+) and ^Step with static member Zero)

// Usage:
start .. step .. finish
```

#### Parameters
*start*
Type: **^T**


The start value of the range.


*step*
Type: **^Step**


The step value of the range.


*finish*
Type: **^T**


The end value of the range.

## Return Value

The sequence spanning the range using the specified step size.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Core.Operators Module &#40;F&#35;&#41;](Core.Operators-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)