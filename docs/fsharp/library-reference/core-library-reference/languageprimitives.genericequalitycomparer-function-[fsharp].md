---
title: LanguagePrimitives.GenericEqualityComparer Function (F#)
description: LanguagePrimitives.GenericEqualityComparer Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 84d2af71-eb71-4992-bcc7-7af09390bb43 
---

# LanguagePrimitives.GenericEqualityComparer Function (F#)

Return an F# comparer object suitable for hashing and equality. This hashing behavior of the returned comparer is not limited by an overall node count when hashing F# records, lists and union types.

**Namespace/Module Path:** Microsoft.FSharp.Core.LanguagePrimitives

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
GenericEqualityComparer :  IEqualityComparer

// Usage:
GenericEqualityComparer
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Core.LanguagePrimitives Module &#40;F&#35;&#41;](Core.LanguagePrimitives-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)