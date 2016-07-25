---
title: NullableOperators.( <=? )<'T> Function (F#)
description: NullableOperators.( <=? )<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: cef48802-3a67-4abd-b2dc-03b3ce3e569e
---

# NullableOperators.( <=? )<'T> Function (F#)

The `<=` operator where a nullable value appears on the right.

**Namespace/Module Path**: Microsoft.FSharp.Linq.NullableOperators

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
( <=? ) : 'T -> Nullable<'T> -> bool when 'T : (IComparable) and 'T : (new : unit ->  'T) and 'T : struct and 'T :> ValueType

// Usage:
value <=? nullableValue
```

#### Parameters
*value*
Type: 'T


The first input value.


*nullableValue*
Type: **System.Nullable&#96;1**&lt;'T&gt;


The second input value, as a nullable value.

## Return Value
`true` if the first value is less than or equal to the second value.


## Remarks
If the second value is null, the result is `false`.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 4.0, Portable

## See Also
[Linq.NullableOperators Module &#40;F&#35;&#41;](Linq.NullableOperators-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Linq Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Linq-Namespace-%5BFSharp%5D.md)
