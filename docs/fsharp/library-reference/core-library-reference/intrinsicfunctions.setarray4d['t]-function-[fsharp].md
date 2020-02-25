---
title: IntrinsicFunctions.SetArray4D<'T> Function (F#)
description: IntrinsicFunctions.SetArray4D<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 916c0feb-c7b1-4adc-af8a-d85efda191c6 
---

# IntrinsicFunctions.SetArray4D<'T> Function (F#)

The standard overloaded associative (4-indexed) mutation operator.

**Namespace/Module Path:** Microsoft.FSharp.Core.LanguagePrimitives.IntrinsicFunctions

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
SetArray4D : 'T [,,,] -> int -> int -> int -> int -> 'T -> unit

// Usage:
SetArray4D target index1 index2 index3 index4 value
```

#### Parameters
*target*
Type: **'T**[[,,,]](https://msdn.microsoft.com/library/e957316d-b2e0-4f04-ac4c-426d4f38a968)


A four-dimensional array.


*index1*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


The index along the first dimension.


*index2*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


The index along the second dimension.


*index3*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


The index along the third dimension.


*index4*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


The index along the fourth dimension.


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