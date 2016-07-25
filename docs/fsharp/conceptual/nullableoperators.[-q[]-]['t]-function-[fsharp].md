---
title: NullableOperators.( ?<> )<'T> Function (F#)
description: NullableOperators.( ?<> )<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 934797af-ab45-4f2d-b702-6ca45d6934ce
---

# NullableOperators.( ?<> )<'T> Function (F#)

The `<>` operator where a nullable value appears on the left.

**Namespace/Module Path**: Microsoft.FSharp.Linq.NullableOperators

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
( ?<> ) : Nullable<'T> -> 'T -> bool when 'T : (IComparable) and 'T : (new : unit ->  'T) and 'T : struct and 'T :> ValueType

// Usage:
nullableValue ?<> value
```

#### Parameters
*nullableValue*
Type: **System.Nullable&#96;1**&lt;'T&gt;


The first input value, as a nullable value.


*value*
Type: 'T


The second input value.

## Return Value
`true` if the two values are not numerically equal; otherwise, `false`.


## Remarks
If the first value is null, the result is `false`.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 4.0, Portable

## See Also
[Linq.NullableOperators Module &#40;F&#35;&#41;](Linq.NullableOperators-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Linq Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Linq-Namespace-%5BFSharp%5D.md)
