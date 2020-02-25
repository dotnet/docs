---
title: OperatorIntrinsics.GetStringSlice Function (F#)
description: OperatorIntrinsics.GetStringSlice Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 82bea7b4-5caa-4bf5-8e3c-932a91604cef
---

# OperatorIntrinsics.GetStringSlice Function (F#)

Gets a slice from a string.

**Namespace/Module Path:** Microsoft.FSharp.Core.Operators.OperatorIntrinsics

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
GetStringSlice : string -> int option -> int option -> string

// Usage:
GetStringSlice source start finish
```

#### Parameters
*source*
Type: [string](https://msdn.microsoft.com/library/12b97856-ec80-4f70-a018-afb0753f755a)


The source string.


*start*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)[option](https://msdn.microsoft.com/library/e5b1450c-2779-4c65-ae28-e7f740c37871)


The index of the first character of the slice.


*finish*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)[option](https://msdn.microsoft.com/library/e5b1450c-2779-4c65-ae28-e7f740c37871)


The index of the last character of the slice.

## Return Value

The substring from the given indices.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable, Portable

## See Also
[Operators.OperatorIntrinsics Module &#40;F&#35;&#41;](Operators.OperatorIntrinsics-Module-%5BFSharp%5D.md)

[Core.Operators Module &#40;F&#35;&#41;](Core.Operators-Module-%5BFSharp%5D.md)
