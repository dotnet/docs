---
title: LanguagePrimitives.PhysicalHash<'T> Function (F#)
description: LanguagePrimitives.PhysicalHash<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 821c5c2a-81da-43a2-93cc-217724c494ff 
---

# LanguagePrimitives.PhysicalHash<'T> Function (F#)

Implements the physical hash. This function hashes on the object identity, except for value types, where it hashes on the contents.

**Namespace/Module Path:** Microsoft.FSharp.Core.LanguagePrimitives

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
PhysicalHash : 'T -> int (requires reference type)

// Usage:
PhysicalHash obj
```

#### Parameters
*obj*
Type: **'T**


The input object.

## Return Value

The hashed value.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Core.LanguagePrimitives Module &#40;F&#35;&#41;](Core.LanguagePrimitives-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)