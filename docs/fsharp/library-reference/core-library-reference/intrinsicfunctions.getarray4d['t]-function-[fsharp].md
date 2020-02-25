---
title: IntrinsicFunctions.GetArray4D<'T> Function (F#)
description: IntrinsicFunctions.GetArray4D<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 23363c61-3746-4ccf-b783-215d382d9240 
---

# IntrinsicFunctions.GetArray4D<'T> Function (F#)

The standard overloaded associative (4-indexed) lookup operator.

**Namespace/Module Path:** Microsoft.FSharp.Core.LanguagePrimitives.IntrinsicFunctions

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
GetArray4D : 'T [,,,] -> int -> int -> int -> int -> 'T

// Usage:
GetArray4D source index1 index2 index3 index4
```

#### Parameters
*source*
Type: **'T**[[,,,]](https://msdn.microsoft.com/library/e957316d-b2e0-4f04-ac4c-426d4f38a968)


The input array.


*index1*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


The first index.


*index2*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


The second index.


*index3*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


The third index.


*index4*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


The fourth index.

## Return Value

The value of the array at the specified indices.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[LanguagePrimitives.IntrinsicFunctions Module &#40;F&#35;&#41;](LanguagePrimitives.IntrinsicFunctions-Module-%5BFSharp%5D.md)

[Core.LanguagePrimitives Module &#40;F&#35;&#41;](Core.LanguagePrimitives-Module-%5BFSharp%5D.md)