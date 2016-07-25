---
title: Array2D.blit<'T> Function (F#)
description: Array2D.blit<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 6cc251e8-d496-454d-b86f-eb8f007788be 
---

# Array2D.blit<'T> Function (F#)

Reads a range of elements from the first array and writes them into the second.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Array2D

**Assembly:** FSharp.Core (in FSharp.Core.dll)

## Syntax

```fsharp
// Signature:
Array2D.blit : 'T [,] -> int -> int -> 'T [,] -> int -> int -> int -> int -> unit

// Usage:
Array2D.blit source sourceIndex1 sourceIndex2 target targetIndex1 targetIndex2 length1 length2
```

#### Parameters

*source*
Type: **'T**[[,]](https://msdn.microsoft.com/library/077252f3-e6ce-441c-9d5b-a6030eaef7cd)

The source array.

*sourceIndex1*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)

The first-dimension index to begin copying from in the source array.

*sourceIndex2*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)

The second-dimension index to begin copying from in the source array.

*target*
Type: **'T**[[,]](https://msdn.microsoft.com/library/077252f3-e6ce-441c-9d5b-a6030eaef7cd)

The target array.

*targetIndex1*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)

The first-dimension index to begin copying into in the target array.

*targetIndex2*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)

The second-dimension index to begin copying into in the target array.

*length1*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)

The number of elements to copy across the first dimension of the arrays.

*length2*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)

The number of elements to copy across the second dimension of the arrays.

## Remarks

This function is named `CopyTo` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Platforms

Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information

**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also

[Collections.Array2D Module &#40;F&#35;&#41;](Collections.Array2D-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)