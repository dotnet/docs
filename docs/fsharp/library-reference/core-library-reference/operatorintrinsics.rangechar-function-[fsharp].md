---
title: OperatorIntrinsics.RangeChar Function (F#)
description: OperatorIntrinsics.RangeChar Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 2198f214-6c88-451a-b7ec-ea9ab7d35595 
---

# OperatorIntrinsics.RangeChar Function (F#)

Generates a range of `char` values.

**Namespace/Module Path:** Microsoft.FSharp.Core.Operators.OperatorIntrinsics

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
RangeChar : char -> char -> seq<char>

// Usage:
RangeChar start stop
```

#### Parameters
*start*
Type: [char](https://msdn.microsoft.com/library/3627f475-985b-4b4e-94d2-14f217c04958)


The first value in the sequence.


*stop*
Type: [char](https://msdn.microsoft.com/library/3627f475-985b-4b4e-94d2-14f217c04958)


The last value in the sequence.

## Return Value

An enumerable sequence of char values.

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