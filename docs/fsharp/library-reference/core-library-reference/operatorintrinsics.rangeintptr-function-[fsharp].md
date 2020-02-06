---
title: OperatorIntrinsics.RangeIntPtr Function (F#)
description: OperatorIntrinsics.RangeIntPtr Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 2eddf456-f3b7-4622-8ccb-cc95fb220f75 
---

# OperatorIntrinsics.RangeIntPtr Function (F#)

Generates a range of `nativeint`values.

**Namespace/Module Path:** Microsoft.FSharp.Core.Operators.OperatorIntrinsics

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
RangeIntPtr : nativeint -> nativeint -> nativeint -> seq<nativeint>

// Usage:
RangeIntPtr start step stop
```

#### Parameters
*start*
Type: [nativeint](https://msdn.microsoft.com/library/f8478c3e-fff5-4f10-82cf-4bedfe305f7b)


The first value in the sequence.


*step*
Type: [nativeint](https://msdn.microsoft.com/library/f8478c3e-fff5-4f10-82cf-4bedfe305f7b)


The increment between each value.


*stop*
Type: [nativeint](https://msdn.microsoft.com/library/f8478c3e-fff5-4f10-82cf-4bedfe305f7b)


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