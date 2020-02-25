---
title: OperatorIntrinsics.RangeByte Function (F#)
description: OperatorIntrinsics.RangeByte Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: d67182be-17d4-4c86-b183-6bf2bf4cc784 
---

# OperatorIntrinsics.RangeByte Function (F#)

Generates a range of `byte` values.

**Namespace/Module Path:** Microsoft.FSharp.Core.Operators.OperatorIntrinsics

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
RangeByte : byte -> byte -> byte -> seq<byte>

// Usage:
RangeByte start step stop
```

#### Parameters
*start*
Type: [byte](https://msdn.microsoft.com/library/17a98430-283a-4ff6-a475-e6999577179d)


The first value in the sequence.


*step*
Type: [byte](https://msdn.microsoft.com/library/17a98430-283a-4ff6-a475-e6999577179d)


An increment between each value.


*stop*
Type: [byte](https://msdn.microsoft.com/library/17a98430-283a-4ff6-a475-e6999577179d)


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