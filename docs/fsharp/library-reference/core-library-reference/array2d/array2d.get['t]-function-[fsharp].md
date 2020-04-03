---
title: Array2D.get<'T> Function (F#)
description: Array2D.get<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: cba6827e-e813-460d-bfa1-933c49bce7b7 
---

# Array2D.get<'T> Function (F#)

Fetches an element from a 2D array. You can also use the syntax **array.[index1,index2]**.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Array2D

**Assembly:** FSharp.Core (in FSharp.Core.dll)

## Syntax

```fsharp
// Signature:
Array2D.get : 'T [,] -> int -> int -> 'T

// Usage:
Array2D.get array index1 index2
```

#### Parameters

*array*
Type: **'T**[[,]](https://msdn.microsoft.com/library/077252f3-e6ce-441c-9d5b-a6030eaef7cd)

The input array.

*index1*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)

The index along the first dimension.

*index2*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)

The index along the second dimension.

## Return Value

Returns the value of the array at the given index.

## Remarks

This function is named `Get` in compiled assemblies. If you are accessing the member from a language other than F#, or through reflection, use this name.

## Platforms

Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information

**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also

[Collections.Array2D Module &#40;F&#35;&#41;](Collections.Array2D-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)
