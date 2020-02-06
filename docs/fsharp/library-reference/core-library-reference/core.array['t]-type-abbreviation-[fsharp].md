---
title: Core.array<'T> Type Abbreviation (F#)
description: Core.array<'T> Type Abbreviation (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 1a7e69c2-2b92-44e0-b5a3-ec55b82b3ca4 
---

# Core.array<'T> Type Abbreviation (F#)

Single dimensional, zero-based arrays, written `int[]`, `string[]` etc. This type is a type abbreviation for `System.Array`.

**Namespace/Module Path:** Microsoft.FSharp.Core

**Assembly:** FSharp.Core (in FSharp.Core.dll)

## Syntax

```fsharp
type array<'T> = []<'T>
```

## Remarks
Use the values in the [Array module](https://msdn.microsoft.com/library/0cda8040-9396-40dd-8dcd-cf48542165a1) to manipulate values of this type, or the notation `arr.[x]` to get or set array values.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)

[Arrays &#40;F&#35;&#41;](Arrays-%5BFSharp%5D.md)