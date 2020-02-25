---
title: NullableOperators.( ?<=? )<'T> Function (F#)
description: NullableOperators.( ?<=? )<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 218bdc2f-30de-48a4-8f0a-d41a1ceb9803
---

# NullableOperators.( ?<=? )<'T> Function (F#)

The `>=` operator where nullable values appear on the left and the right.

**Namespace/Module Path**: Microsoft.FSharp.Linq.NullableOperators

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
( ?>=? ) : Nullable<'T> -> Nullable<'T> -> bool when 'T : (IComparable) and 'T : (new : unit ->  'T) and 'T : struct and 'T :> ValueType

// Usage:
nullableValue1 ?>=? nullableValue2
```

#### Parameters
*nullableValue1*
Type: **System.Nullable&#96;1**&lt;'T&gt;


The first input value, as a nullable value.


*nullableValue2*
Type: 'T


The second input value, as a nullable value.

## Return Value
`true` if the first value is greater than or equal to the second.


## Remarks
If either of the values is null, the result is `false`.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 4.0, Portable

## See Also
[Linq.NullableOperators Module &#40;F&#35;&#41;](Linq.NullableOperators-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Linq Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Linq-Namespace-%5BFSharp%5D.md)
