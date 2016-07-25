---
title: Operators.limitedHash<'T> Function (F#)
description: Operators.limitedHash<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: ab31b42d-8668-404b-950e-79b03697f964
---

# Operators.limitedHash<'T> Function (F#)

A generic hash function. This function has the same behavior as [hash](https://msdn.microsoft.com/library/a83c0432-919e-407d-9ffc-8cf34fbc6daa), however the default structural hashing for F# union, record and tuple types stops when the given limit of nodes is reached. The exact behavior of the function can be adjusted on a type-by-type basis by implementing `System.Object.GetHashCode` for each type.

**Namespace/Module Path:** Microsoft.FSharp.Core.Operators

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
limitedHash : int -> 'T -> int (requires equality)

// Usage:
limitedHash limit obj
```

#### Parameters
*limit*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


The limit of nodes.


*obj*
Type: **'T**


The input object.

## Return Value

The computed hash.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Core.Operators Module &#40;F&#35;&#41;](Core.Operators-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)
