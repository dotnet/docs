---
title: OperatorIntrinsics.SetArraySlice<'T> Function (F#)
description: OperatorIntrinsics.SetArraySlice<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 1387e059-0e73-42a4-9449-32b41ebb11ff 
---

# OperatorIntrinsics.SetArraySlice<'T> Function (F#)

Sets a slice of an array.

**Namespace/Module Path:** Microsoft.FSharp.Core.Operators.OperatorIntrinsics

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
SetArraySlice : 'T [] -> int option -> int option -> 'T [] -> unit

// Usage:
SetArraySlice target start finish source
```

#### Parameters
*target*
Type: **'T**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)


The target array.


*start*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)[option](https://msdn.microsoft.com/library/e5b1450c-2779-4c65-ae28-e7f740c37871)


The start index.


*finish*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)[option](https://msdn.microsoft.com/library/e5b1450c-2779-4c65-ae28-e7f740c37871)


The end index.


*source*
Type: **'T**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)


The source array.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable, Portable

## See Also
[Operators.OperatorIntrinsics Module &#40;F&#35;&#41;](Operators.OperatorIntrinsics-Module-%5BFSharp%5D.md)

[Core.Operators Module &#40;F&#35;&#41;](Core.Operators-Module-%5BFSharp%5D.md)