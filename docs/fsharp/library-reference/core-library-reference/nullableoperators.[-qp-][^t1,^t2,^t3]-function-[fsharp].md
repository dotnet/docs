---
title: NullableOperators.( ?+ )<^T1,^T2,^T3> Function (F#)
description: NullableOperators.( ?+ )<^T1,^T2,^T3> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: d91c9023-7349-4bc5-8ed4-ef27b4cbdd6a
---

# NullableOperators.( ?+ )<^T1,^T2,^T3> Function (F#)

The addition operator where a nullable value appears on the left.

**Namespace/Module Path**: Microsoft.FSharp.Linq.NullableOperators

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
( ?+ ) : Nullable<^T1> -> ^T2 -> Nullable<^T3> when ^T1 with static member (+) and ^T1 : (new : unit ->  ^T1) and ^T1 : struct and ^T1 :> ValueType and ^T2 with static member (+) and ^T3 : (new : unit ->  ^T3) and ^T3 : struct and ^T3 :> ValueType

// Usage:
nullableValue ?+ value
```

#### Parameters
*nullableValue*
Type: **System.Nullable&#96;1**&lt;^T1&gt;


The first input value, as a nullable type.


*value*
Type: ^T2


The second input value.

## Return Value
The sum of the two input values, as a nullable type.


## Remarks
If the first value is null, the result is null, as a nullable type.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 4.0, Portable

## See Also
[Linq.NullableOperators Module &#40;F&#35;&#41;](Linq.NullableOperators-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Linq Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Linq-Namespace-%5BFSharp%5D.md)
