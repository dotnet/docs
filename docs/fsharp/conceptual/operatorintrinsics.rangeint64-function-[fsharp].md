---
title: OperatorIntrinsics.RangeInt64 Function (F#)
description: OperatorIntrinsics.RangeInt64 Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: fda06f8a-90ca-412d-ae71-756315e6a0e4 
---

# OperatorIntrinsics.RangeInt64 Function (F#)

Generate a range of `int64` values.

**Namespace/Module Path:** Microsoft.FSharp.Core.Operators.OperatorIntrinsics

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
RangeInt64 : int64 -> int64 -> int64 -> seq<int64>

// Usage:
RangeInt64 start step stop
```

#### Parameters
*start*
Type: [int64](https://msdn.microsoft.com/library/1bec11c0-45ac-469e-923b-22a1708c0701)


The first value in the sequence.


*step*
Type: [int64](https://msdn.microsoft.com/library/1bec11c0-45ac-469e-923b-22a1708c0701)


The increment between each value.


*stop*
Type: [int64](https://msdn.microsoft.com/library/1bec11c0-45ac-469e-923b-22a1708c0701)


The maximum value in the sequence.

## Return Value

An enumerable collection of values.

## Remarks
This function is for use by compiled F# code and should not be used directly.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable, Portable

## See Also
[Operators.OperatorIntrinsics Module &#40;F&#35;&#41;](Operators.OperatorIntrinsics-Module-%5BFSharp%5D.md)

[Core.Operators Module &#40;F&#35;&#41;](Core.Operators-Module-%5BFSharp%5D.md)