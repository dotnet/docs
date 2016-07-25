---
title: IntrinsicFunctions.SetArray2D<'T> Function (F#)
description: IntrinsicFunctions.SetArray2D<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 141681f8-66b0-48d8-879f-627dfdd2364a 
---

# IntrinsicFunctions.SetArray2D<'T> Function (F#)

The standard overloaded associative (2-indexed) mutation operator

**Namespace/Module Path**: Microsoft.FSharp.Core.LanguagePrimitives.IntrinsicFunctions

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
SetArray2D : 'T [,] -> int -> int -> 'T -> unit

// Usage:
SetArray2D target index1 index2 value
```

#### Parameters
*target*
Type: **'T**[[,]](https://msdn.microsoft.com/library/077252f3-e6ce-441c-9d5b-a6030eaef7cd)


A two-dimensional array.


*index1*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


An index along the first dimension.


*index2*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


An index along the second dimension.


*value*
Type: **'T**


The new value to set at the specified indices.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[LanguagePrimitives.IntrinsicFunctions Module &#40;F&#35;&#41;](LanguagePrimitives.IntrinsicFunctions-Module-%5BFSharp%5D.md)

[Core.LanguagePrimitives Module &#40;F&#35;&#41;](Core.LanguagePrimitives-Module-%5BFSharp%5D.md)