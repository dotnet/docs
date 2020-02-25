---
title: OperatorIntrinsics.RangeDouble Function (F#)
description: OperatorIntrinsics.RangeDouble Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 306c64a7-9709-41ba-82be-51746d04f6d7 
---

# OperatorIntrinsics.RangeDouble Function (F#)

Generate a range of float values.

**Namespace/Module Path:** Microsoft.FSharp.Core.Operators.OperatorIntrinsics

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
RangeDouble : float -> float -> float -> seq<float>

// Usage:
RangeDouble start step stop
```

#### Parameters
*start*
Type: [float](https://msdn.microsoft.com/library/3fa76cae-e9b5-4672-8bdf-88ff6dbcf7b8)


The initial value in the sequence.


*step*
Type: [float](https://msdn.microsoft.com/library/3fa76cae-e9b5-4672-8bdf-88ff6dbcf7b8)


An increment between values.


*stop*
Type: [float](https://msdn.microsoft.com/library/3fa76cae-e9b5-4672-8bdf-88ff6dbcf7b8)


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