---
title: OperatorIntrinsics.RangeInt16 Function (F#)
description: OperatorIntrinsics.RangeInt16 Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 62e7ee01-785c-4608-8988-9ce0dd962789 
---

# OperatorIntrinsics.RangeInt16 Function (F#)

Generates a range of `int16` values.

**Namespace/Module Path:** Microsoft.FSharp.Core.Operators.OperatorIntrinsics

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
RangeInt16 : int16 -> int16 -> int16 -> seq<int16>

// Usage:
RangeInt16 start step stop
```

#### Parameters
*start*
Type: [int16](https://msdn.microsoft.com/library/608e612c-5a8e-40c4-912f-55788628cb9b)


The first value of the sequence.


*step*
Type: [int16](https://msdn.microsoft.com/library/608e612c-5a8e-40c4-912f-55788628cb9b)


The increment between values.


*stop*
Type: [int16](https://msdn.microsoft.com/library/608e612c-5a8e-40c4-912f-55788628cb9b)


The maximum value of the sequence.

## Return Value

A sequence of enumerable values.

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