---
title: OperatorIntrinsics.SetArraySlice2DFixed1 Function (F#)
description: OperatorIntrinsics.SetArraySlice2DFixed1 Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 8134d2cc-f527-46b7-a226-6df06426e42e 
---

# OperatorIntrinsics.SetArraySlice2DFixed1 Function (F#)

Sets a vector slice of a 2D array. The index of the first dimension is fixed.

**Namespace/Module Path:** Microsoft.FSharp.Core.Operators.OperatorIntrinsics

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
SetArraySlice2DFixed1 : 'T [,] -> int -> int option -> int option -> 'T [] -> unit

// Usage:
SetArraySlice2DFixed1 target index1 start2 finish2 source
```

#### Parameters
*target*
Type: **'T**[[,]](https://msdn.microsoft.com/library/077252f3-e6ce-441c-9d5b-a6030eaef7cd)


The target array.


*index1*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


The start index of the first dimension.


*start2*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)[option](https://msdn.microsoft.com/library/e5b1450c-2779-4c65-ae28-e7f740c37871)


The start index of the second dimension.


*finish2*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)[option](https://msdn.microsoft.com/library/e5b1450c-2779-4c65-ae28-e7f740c37871)


The end index of the second dimension.


*source*
Type: **'T**[[]](https://msdn.microsoft.com/library/077252f3-e6ce-441c-9d5b-a6030eaef7cd)


The source array.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Arrays &#40;F&#35;&#41;](Arrays-%5BFSharp%5D.md)

[Operators.OperatorIntrinsics Module &#40;F&#35;&#41;](Operators.OperatorIntrinsics-Module-%5BFSharp%5D.md)

[Core.Operators Module &#40;F&#35;&#41;](Core.Operators-Module-%5BFSharp%5D.md)