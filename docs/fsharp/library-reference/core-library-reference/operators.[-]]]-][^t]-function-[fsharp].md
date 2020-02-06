---
title: Operators.( >>> )<^T> Function (F#)
description: Operators.( >>> )<^T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 48b16f42-dd22-43b4-bb39-9e37d08c1980 
---

# Operators.( >>> )<^T> Function (F#)

Overloaded byte-shift right operator by a specified number of bits

**Namespace/Module Path:** Microsoft.FSharp.Core.Operators

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
( >>> ) : ^T -> int32 -> ^T (requires ^T with static member op_RightShift)

// Usage:
value >>> shift
```

#### Parameters
*value*
Type: **^T**


The input value.


*shift*
Type: [int32](https://msdn.microsoft.com/library/6ab0ea34-03db-4874-a265-bef9c64f8eff)


The amount to shift.

## Return Value

The result of the operation.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Core.Operators Module &#40;F&#35;&#41;](Core.Operators-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)