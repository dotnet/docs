---
title: NullableOperators.( ?% ?)<^T1,^T2,^T3> Function (F#)
description: NullableOperators.( ?% ?)<^T1,^T2,^T3> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 0332baae-e9d6-4556-9bb2-ec5cc91bceeb
---

# NullableOperators.( ?% ?)<^T1,^T2,^T3> Function (F#)

The modulus operator where a nullable value appears on both left and right sides.

**Namespace/Module Path**: Microsoft.FSharp.Linq.NullableOperators

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
( ?%? ) : Nullable<^T1> -> Nullable<^T2> -> Nullable<^T3> when ^T1 with static member op_Modulus and ^T1 : (new : unit ->  ^T1) and ^T1 : struct and ^T1 :> ValueType and ^T2 with static member op_Modulus and ^T2 : (new : unit ->  ^T2) and ^T2 : struct and ^T2 :> ValueType and ^T3 : (new : unit ->  ^T3) and ^T3 : struct and ^T3 :> ValueType

// Usage:
?%?
```

#### Parameters
*nullableValue1*
Type: **System.Nullable&#96;1**&lt;^T1&gt;


The first input value, as a nullable value.


*nullableValue2*
Type: **System.Nullable&#96;1**&lt;^T2&gt;


The second input value, as a nullable value.

## Return Value
The result of the modulus operation, as a nullable value.


## Remarks
If either of the input values is null, then the return value is null.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 4.0, Portable

## See Also
[Linq.NullableOperators Module &#40;F&#35;&#41;](Linq.NullableOperators-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Linq Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Linq-Namespace-%5BFSharp%5D.md)
