---
title: IntrinsicOperators.( ~& )<'T> Function (F#)
description: IntrinsicOperators.( ~& )<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 1c2dacf6-55af-4653-8d62-d08738473622 
---

# IntrinsicOperators.( ~& )<'T> Function (F#)

Returns the address of the argument. Uses of this value may result in the generation of unverifiable code.

**Namespace/Module Path:** Microsoft.FSharp.Core.LanguagePrimitives.IntrinsicOperators

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
( ~& ) : 'T -> byref<'T>

// Usage:
& obj
```

#### Parameters
*obj*
Type: **'T**


The input object.

## Return Value

The managed pointer.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[LanguagePrimitives.IntrinsicOperators Module &#40;F&#35;&#41;](LanguagePrimitives.IntrinsicOperators-Module-%5BFSharp%5D.md)

[Core.LanguagePrimitives Module &#40;F&#35;&#41;](Core.LanguagePrimitives-Module-%5BFSharp%5D.md)