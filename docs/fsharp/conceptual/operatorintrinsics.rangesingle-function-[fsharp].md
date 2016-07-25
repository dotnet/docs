---
title: OperatorIntrinsics.RangeSingle Function (F#)
description: OperatorIntrinsics.RangeSingle Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 70b0ceee-4e39-4fe5-a40f-7f62e606ba62 
---

# OperatorIntrinsics.RangeSingle Function (F#)

Generate a range of `float32` values.

**Namespace/Module Path:** Microsoft.FSharp.Core.Operators.OperatorIntrinsics

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
RangeSingle : float32 -> float32 -> float32 -> seq<float32>

// Usage:
RangeSingle start step stop
```

#### Parameters
*start*
Type: [float32](https://msdn.microsoft.com/library/9bf674b5-ea9a-4b08-ad42-4da313b6ebf0)


The initial value in the sequence.


*step*
Type: [float32](https://msdn.microsoft.com/library/9bf674b5-ea9a-4b08-ad42-4da313b6ebf0)


The increment between values.


*stop*
Type: [float32](https://msdn.microsoft.com/library/9bf674b5-ea9a-4b08-ad42-4da313b6ebf0)


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