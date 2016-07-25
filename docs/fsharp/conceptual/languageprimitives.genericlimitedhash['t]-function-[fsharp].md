---
title: LanguagePrimitives.GenericLimitedHash<'T> Function (F#)
description: LanguagePrimitives.GenericLimitedHash<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: e3fb5f79-e700-473d-be11-aa415460b98d 
---

# LanguagePrimitives.GenericLimitedHash<'T> Function (F#)

Hash a value according to its structure. Use the given limit to restrict the hash when hashing F# records, lists and union types.

**Namespace/Module Path:** Microsoft.FSharp.Core.LanguagePrimitives

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
GenericLimitedHash : int -> 'T -> int

// Usage:
GenericLimitedHash limit obj
```

#### Parameters
*limit*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


The limit on the number of nodes.


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