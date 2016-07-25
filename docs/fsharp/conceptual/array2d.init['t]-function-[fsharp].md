---
title: Array2D.init<'T> Function (F#)
description: Array2D.init<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 15a6a4cf-8c17-4222-9b93-182dc77d12dd 
---

# Array2D.init<'T> Function (F#)

Creates an array given the dimensions and a generator function to compute the elements.

**Namespace/Module Path**: Microsoft.FSharp.Collections.Array2D

**Assembly**: FSharp.Core (in FSharp.Core.dll)

## Syntax

```fsharp
// Signature:
Array2D.init : int -> int -> (int -> int -> 'T) -> 'T [,]

// Usage:
Array2D.init length1 length2 initializer
```

#### Parameters

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

Returns the generated array.

## Remarks

This function is named `Initialize` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Examxample

The following code demonstrates the use of `Array2D.init` to create a two-dimensional array.

[!code-fsharp[Main](snippets/fsarrays/snippet21.fs)]

## Platforms

Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information

**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also

[Collections.Array2D Module &#40;F&#35;&#41;](Collections.Array2D-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)