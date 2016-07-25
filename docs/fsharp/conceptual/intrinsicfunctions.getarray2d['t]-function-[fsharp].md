---
title: IntrinsicFunctions.GetArray2D<'T> Function (F#)
description: IntrinsicFunctions.GetArray2D<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 7ddd9166-47b3-4d22-96b5-1a08703bbfe7 
---

# IntrinsicFunctions.GetArray2D<'T> Function (F#)

The standard overloaded associative (2-indexed) lookup operator

**Namespace/Module Path:** Microsoft.FSharp.Core.LanguagePrimitives.IntrinsicFunctions

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
GetArray2D : 'T [,] -> int -> int -> 'T

// Usage:
GetArray2D source index1 index2
```

#### Parameters
*source*
Type: **'T**[[,]](https://msdn.microsoft.com/library/077252f3-e6ce-441c-9d5b-a6030eaef7cd)


The source array.


*index1*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


The first index.


*index2*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


The second index.

## Return Value

The value at the specified indices.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[LanguagePrimitives.IntrinsicFunctions Module &#40;F&#35;&#41;](LanguagePrimitives.IntrinsicFunctions-Module-%5BFSharp%5D.md)

[Core.LanguagePrimitives Module &#40;F&#35;&#41;](Core.LanguagePrimitives-Module-%5BFSharp%5D.md)