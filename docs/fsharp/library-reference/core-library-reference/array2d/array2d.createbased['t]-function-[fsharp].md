---
title: Array2D.createBased<'T> Function (F#)
description: Array2D.createBased<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: f214f650-466d-4bb7-8b9c-3aa2b8e29354 
---

# Array2D.createBased<'T> Function (F#)

Creates a based array whose elements are all initially the given value.

**Namespace/Module Path**: Microsoft.FSharp.Collections.Array2D

**Assembly**: FSharp.Core (in FSharp.Core.dll)

## Syntax

```fsharp
// Signature:
Array2D.createBased : int -> int -> int -> int -> 'T -> 'T [,]

// Usage:
Array2D.createBased base1 base2 length1 length2 initial
```

#### Parameters

*base1*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)

The base for the first dimension of the array.

*base2*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)

The base for the second dimension of the array.

*length1*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)

The length of the first dimension of the array.

*length2*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)

The length of the second dimension of the array.

*initial*
Type: **'T**

The value to populate the new array.

## Return Value

Returns the created array.

## Remarks

This function is named `CreateBased` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Platforms

Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information

**F# Core Library Versions**

Supported in: 2.0, 4.0

## See Also

[Collections.Array2D Module &#40;F&#35;&#41;](Collections.Array2D-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)