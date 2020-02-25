---
title: OperatorIntrinsics.RangeUInt16 Function (F#)
description: OperatorIntrinsics.RangeUInt16 Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 4856c912-3acd-415b-9405-d0ad85031b3a 
---

# OperatorIntrinsics.RangeUInt16 Function (F#)

Generates a range of `uint16` values.

**Namespace/Module Path:** Microsoft.FSharp.Core.Operators.OperatorIntrinsics

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
RangeUInt16 : uint16 -> uint16 -> uint16 -> seq<uint16>

// Usage:
RangeUInt16 start step stop
```

#### Parameters
*start*
Type: [uint16](https://msdn.microsoft.com/library/2ab2f1fa-344e-4fcf-a688-5024c589630b)


The starting value of the sequence.


*step*
Type: [uint16](https://msdn.microsoft.com/library/2ab2f1fa-344e-4fcf-a688-5024c589630b)


The increment between values.


*stop*
Type: [uint16](https://msdn.microsoft.com/library/2ab2f1fa-344e-4fcf-a688-5024c589630b)


The maximum value of the sequence.

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