---
title: OperatorIntrinsics.RangeUInt64 Function (F#)
description: OperatorIntrinsics.RangeUInt64 Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 7eebf91c-1b06-4a3c-886c-d48c843ec2f3 
---

# OperatorIntrinsics.RangeUInt64 Function (F#)

Generates a range of `uint64` values.

**Namespace/Module Path:** Microsoft.FSharp.Core.Operators.OperatorIntrinsics

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
RangeUInt64 : uint64 -> uint64 -> uint64 -> seq<uint64>

// Usage:
RangeUInt64 start step stop
```

#### Parameters
*start*
Type: [uint64](https://msdn.microsoft.com/library/3c4f3a04-06eb-48aa-b38e-16646bda2f33)


The initial value in the sequence.


*step*
Type: [uint64](https://msdn.microsoft.com/library/3c4f3a04-06eb-48aa-b38e-16646bda2f33)


The increment between each value.


*stop*
Type: [uint64](https://msdn.microsoft.com/library/3c4f3a04-06eb-48aa-b38e-16646bda2f33)


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