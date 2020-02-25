---
title: OperatorIntrinsics.RangeUIntPtr Function (F#)
description: OperatorIntrinsics.RangeUIntPtr Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: fccccf74-b06f-4f16-91b5-99c8d1002ae5 
---

# OperatorIntrinsics.RangeUIntPtr Function (F#)

Generates a range of `unativeint` values.

**Namespace/Module Path:** Microsoft.FSharp.Core.Operators.OperatorIntrinsics

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
RangeUIntPtr : unativeint -> unativeint -> unativeint -> seq<unativeint>

// Usage:
RangeUIntPtr start step stop
```

#### Parameters
*start*
Type: [unativeint](https://msdn.microsoft.com/library/9d2946a7-ace9-48a4-8cff-7894b8e7de86)


The first value in the sequence.


*step*
Type: [unativeint](https://msdn.microsoft.com/library/9d2946a7-ace9-48a4-8cff-7894b8e7de86)


The increment between values.


*stop*
Type: [unativeint](https://msdn.microsoft.com/library/9d2946a7-ace9-48a4-8cff-7894b8e7de86)


The maximum value in the sequence.

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