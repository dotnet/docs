---
title: Array2D.initBased<'T> Function (F#)
description: Array2D.initBased<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: b0d67c00-9bf2-4f63-b725-7a6f4c82a603 
---

# Array2D.initBased<'T> Function (F#)

Creates a based array given the dimensions and a generator function to compute the elements.

**Namespace/Module Path**: Microsoft.FSharp.Collections.Array2D

**Assembly**: FSharp.Core (in FSharp.Core.dll)

## Syntax

```fsharp
// Signature:
Array2D.initBased : int -> int -> int -> int -> (int -> int -> 'T) -> 'T [,]

// Usage:
Array2D.initBased base1 base2 length1 length2 initializer
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

*initializer*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)**-&gt;**[int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)**-&gt; 'T**

A function to produce elements of the array given the two indices.

## Return Value

Returns the created array.

## Remarks

This function is named `InitializeBased` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Platforms

Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information

**F# Core Library Versions**

Supported in: 2.0, 4.0

## See Also

[Collections.Array2D Module &#40;F&#35;&#41;](Collections.Array2D-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)
