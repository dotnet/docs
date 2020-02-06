---
title: OperatorIntrinsics.RangeGeneric<'T> Function (F#)
description: OperatorIntrinsics.RangeGeneric<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 730fc15e-3e59-44aa-ba6e-ae7a79798204 
---

# OperatorIntrinsics.RangeGeneric<'T> Function (F#)

Generates a range of values using the given zero, add, start, step and stop values.

**Namespace/Module Path:** Microsoft.FSharp.Core.Operators.OperatorIntrinsics

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
RangeGeneric : 'T -> ('T -> 'T -> 'T) -> 'T -> 'T -> seq<'T>

// Usage:
RangeGeneric one add start stop
```

#### Parameters
*one*
Type: **'T**


The value representing 1 for the type parameter.


*add*
Type: **'T -&gt; 'T -&gt; 'T**


A function that performs addition to the type parameter.

*start*
Type: **'T**


The start of the range.

*stop*
Type: **'T**


The end of the range.

## Return Value

An enumerable sequence representing a range of values.

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