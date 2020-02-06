---
title: OperatorIntrinsics.SetArraySlice4D<'T> Function (F#)
description: OperatorIntrinsics.SetArraySlice4D<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: dad76b2b-e840-4f6a-97a3-71ffe0769aa2 
---

# OperatorIntrinsics.SetArraySlice4D<'T> Function (F#)

Sets a slice of an array.

**Namespace/Module Path:** Microsoft.FSharp.Core.Operators.OperatorIntrinsics

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
SetArraySlice4D : 'T [,,,] -> int option -> int option -> int option -> int option -> int option -> int option -> int option -> int option -> 'T [,,,] -> unit

// Usage:
SetArraySlice4D target start1 finish1 start2 finish2 start3 finish3 start4 finish4 source
```

#### Parameters
*target*
Type: **'T**[[,,,]](https://msdn.microsoft.com/library/e957316d-b2e0-4f04-ac4c-426d4f38a968)


The target array.


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


*start3*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)[option](https://msdn.microsoft.com/library/e5b1450c-2779-4c65-ae28-e7f740c37871)


The start index of the third dimension.


*finish3*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)[option](https://msdn.microsoft.com/library/e5b1450c-2779-4c65-ae28-e7f740c37871)


The end index of the third dimension.


*start4*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)[option](https://msdn.microsoft.com/library/e5b1450c-2779-4c65-ae28-e7f740c37871)


The start index of the fourth dimension.


*finish4*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)[option](https://msdn.microsoft.com/library/e5b1450c-2779-4c65-ae28-e7f740c37871)


The end index of the fourth dimension.


*source*
Type: **'T**[[,,,]](https://msdn.microsoft.com/library/e957316d-b2e0-4f04-ac4c-426d4f38a968)


The source array.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable, Portable

## See Also
[Operators.OperatorIntrinsics Module &#40;F&#35;&#41;](Operators.OperatorIntrinsics-Module-%5BFSharp%5D.md)

[Core.Operators Module &#40;F&#35;&#41;](Core.Operators-Module-%5BFSharp%5D.md)