---
title: LanguagePrimitives.FastLimitedGenericEqualityComparer<'T> Function (F#)
description: LanguagePrimitives.FastLimitedGenericEqualityComparer<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 776268ff-1d82-4a4b-bddc-121f98136d7d 
---

# LanguagePrimitives.FastLimitedGenericEqualityComparer<'T> Function (F#)

Make an F# hash/equality object for the given type using node-limited hashing when hashing F# records, lists and union types.

**Namespace/Module Path:** Microsoft.FSharp.Core.LanguagePrimitives

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
FastLimitedGenericEqualityComparer : int -> IEqualityComparer<'T> (requires equality)

// Usage:
FastLimitedGenericEqualityComparer limit
```

#### Parameters
*limit*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


The input limit on the number of nodes.


## Return Value
The hash/equality object as a `System.Collections.Generic.IEqualityComparer`.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Core.LanguagePrimitives Module &#40;F&#35;&#41;](Core.LanguagePrimitives-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)