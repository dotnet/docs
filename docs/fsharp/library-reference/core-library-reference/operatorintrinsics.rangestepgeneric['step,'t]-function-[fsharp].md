---
title: OperatorIntrinsics.RangeStepGeneric<'Step,'T> Function (F#)
description: OperatorIntrinsics.RangeStepGeneric<'Step,'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: a12a611a-a8cc-44b5-8ffd-d3d4b46a01ec 
---

# OperatorIntrinsics.RangeStepGeneric<'Step,'T> Function (F#)

Generates a range of values using the given zero, add, start, step and stop values.

**Namespace/Module Path:** Microsoft.FSharp.Core.Operators.OperatorIntrinsics

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
RangeStepGeneric : 'Step -> ('T -> 'Step -> 'T) -> 'T -> 'Step -> 'T -> seq<'T>

// Usage:
RangeStepGeneric zero add start step stop
```

#### Parameters
*zero*
Type: **'Step**


The zero value for the step type.


*add*
Type: **'T -&gt; 'Step -&gt; 'T**


An addition function that adds a value and the step to produce another value.


*start*
Type: **'T**


The starting value.


*step*
Type: **'Step**


The increment to the value on each iteration.


*stop*
Type: **'T**


The final value.

## Return Value

An enumerable sequence of values starting with start, incrementing by step, and ending with stop.

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