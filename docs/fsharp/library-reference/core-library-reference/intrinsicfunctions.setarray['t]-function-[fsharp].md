---
title: IntrinsicFunctions.SetArray<'T> Function (F#)
description: IntrinsicFunctions.SetArray<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: a384cb59-5de7-4c0a-92e3-4bcbe6fdc099 
---

# IntrinsicFunctions.SetArray<'T> Function (F#)

The standard overloaded associative (indexed) mutation operator.

**Namespace/Module Path:** Microsoft.FSharp.Core.LanguagePrimitives.IntrinsicFunctions

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
SetArray : 'T [] -> int -> 'T -> unit

// Usage:
SetArray target index value
```

#### Parameters
*target*
Type: **'T**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)


An array.


*index*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


An index into the array.


*value*
Type: **'T**


The new value to set at the specified array index.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable


## See Also
[LanguagePrimitives.IntrinsicFunctions Module &#40;F&#35;&#41;](LanguagePrimitives.IntrinsicFunctions-Module-%5BFSharp%5D.md)

[Core.LanguagePrimitives Module &#40;F&#35;&#41;](Core.LanguagePrimitives-Module-%5BFSharp%5D.md)