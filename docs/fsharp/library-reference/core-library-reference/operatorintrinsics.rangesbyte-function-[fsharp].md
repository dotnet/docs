---
title: OperatorIntrinsics.RangeSByte Function (F#)
description: OperatorIntrinsics.RangeSByte Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: dfcfac66-fc74-47cf-9409-44762e45cf0b 
---

# OperatorIntrinsics.RangeSByte Function (F#)

Generates a range of `sbyte` values.

**Namespace/Module Path:** Microsoft.FSharp.Core.Operators.OperatorIntrinsics

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
RangeSByte : sbyte -> sbyte -> sbyte -> seq<sbyte>

// Usage:
RangeSByte start step stop
```

#### Parameters
*start*
Type: [sbyte](https://msdn.microsoft.com/library/fbc28b7f-2dbf-4361-acb3-830886820068)


The first value of the sequence.


*step*
Type: [sbyte](https://msdn.microsoft.com/library/fbc28b7f-2dbf-4361-acb3-830886820068)


The increment between values.


*stop*
Type: [sbyte](https://msdn.microsoft.com/library/fbc28b7f-2dbf-4361-acb3-830886820068)


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