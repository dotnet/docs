---
title: Array2D.set<'T> Function (F#)
description: Array2D.set<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 985a2f7b-7520-4d8d-b0ee-8622838cc6dc 
---

# Array2D.set<'T> Function (F#)

Sets the value of an element in an array.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Array2D

**Assembly:** FSharp.Core (in FSharp.Core.dll)

## Syntax

```fsharp
// Signature:
Array2D.set : 'T [,] -> int -> int -> 'T -> unit

// Usage:
Array2D.set array index1 index2 value
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

*value*
Type: **'T**

The value to set in the array.

## Remarks

You can also use the syntax `array.[index1,index2] <- value`.

This function is named `Set` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Platforms

Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information

**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also

[Collections.Array2D Module &#40;F&#35;&#41;](Collections.Array2D-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)
