---
title: OperatorIntrinsics.RangeUInt32 Function (F#)
description: OperatorIntrinsics.RangeUInt32 Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: f8657a09-7bfe-42b7-9b2d-f66e0f52536f 
---

# OperatorIntrinsics.RangeUInt32 Function (F#)

Generates a range of `uint32` values.

**Namespace/Module Path:** Microsoft.FSharp.Core.Operators.OperatorIntrinsics

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
RangeUInt32 : uint32 -> uint32 -> uint32 -> seq<uint32>

// Usage:
RangeUInt32 start step stop
```

#### Parameters
*start*
Type: [uint32](https://msdn.microsoft.com/library/02aea3e2-e400-453a-a681-3a657afe1825)


The initial value in the sequence.


*step*
Type: [uint32](https://msdn.microsoft.com/library/02aea3e2-e400-453a-a681-3a657afe1825)


The increment between values.


*stop*
Type: [uint32](https://msdn.microsoft.com/library/02aea3e2-e400-453a-a681-3a657afe1825)


The maximum value in the sequence.

## Return Value

An enumerable sequence of values.

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