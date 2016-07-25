---
title: OperatorIntrinsics.GetArraySlice2D<'T> Function (F#)
description: OperatorIntrinsics.GetArraySlice2D<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 98fc4668-bef6-4d90-9eee-e86bfe9129d4
---

# OperatorIntrinsics.GetArraySlice2D<'T> Function (F#)

Gets a slice of an array.

**Namespace/Module Path:** Microsoft.FSharp.Core.Operators.OperatorIntrinsics

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
GetArraySlice2D : 'T [,] -> int option -> int option -> int option -> int option -> 'T [,]

// Usage:
GetArraySlice2D source start1 finish1 start2 finish2
```

#### Parameters
*source*
Type: **'T**[[,]](https://msdn.microsoft.com/library/077252f3-e6ce-441c-9d5b-a6030eaef7cd)


The source array.


*start1*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)[option](https://msdn.microsoft.com/library/e5b1450c-2779-4c65-ae28-e7f740c37871)


The start index of the first dimension.


*finish1*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)[option](https://msdn.microsoft.com/library/e5b1450c-2779-4c65-ae28-e7f740c37871)


The end index of the first dimension.


*start2*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)[option](https://msdn.microsoft.com/library/e5b1450c-2779-4c65-ae28-e7f740c37871)


The start index of the second dimension.


*finish2*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)[option](https://msdn.microsoft.com/library/e5b1450c-2779-4c65-ae28-e7f740c37871)


The end index of the second dimension.

## Return Value

The two dimensional sub array from the input indices.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable, Portable

## See Also
[Operators.OperatorIntrinsics Module &#40;F&#35;&#41;](Operators.OperatorIntrinsics-Module-%5BFSharp%5D.md)

[Core.Operators Module &#40;F&#35;&#41;](Core.Operators-Module-%5BFSharp%5D.md)
