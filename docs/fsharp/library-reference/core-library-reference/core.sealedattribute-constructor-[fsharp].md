---
title: Core.SealedAttribute Constructor (F#)
description: Core.SealedAttribute Constructor (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 6ae32d6f-8640-480e-b031-b80adb3fa1c9 
---

# Core.SealedAttribute Constructor (F#)

Creates an instance of the attribute

**Namespace/Module Path:** Microsoft.FSharp.Core

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signatures:
new SealedAttribute : bool -> SealedAttribute
new SealedAttribute : unit -> SealedAttribute

// Usage:
new SealedAttribute (value)
new SealedAttribute ()
```

#### Parameters
*value*
Type: [bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5)


Indicates whether the class is sealed.

## Return Value

A new `SealedAttribute` instance.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Core.SealedAttribute Class &#40;F&#35;&#41;](Core.SealedAttribute-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)