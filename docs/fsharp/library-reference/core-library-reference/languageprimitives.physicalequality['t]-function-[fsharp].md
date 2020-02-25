---
title: LanguagePrimitives.PhysicalEquality<'T> Function (F#)
description: LanguagePrimitives.PhysicalEquality<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 92a2b398-7435-498d-a8f2-fb65ce450d3b 
---

# LanguagePrimitives.PhysicalEquality<'T> Function (F#)

Implements reference, or *physical* equality.

**Namespace/Module Path:** Microsoft.FSharp.Core.LanguagePrimitives

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
PhysicalEquality : 'T -> 'T -> bool (requires reference type)

// Usage:
PhysicalEquality e1 e2
```

#### Parameters
*e1*
Type: **'T**


The first value.


*e2*
Type: **'T**


The second value.

## Return Value

`true` if boxed versions of the inputs are reference-equal, or if both are primitive numeric types and the implementation of `System.Object.Equals(System.Object)` for the type of the first argument returns `true` on the boxed version of the inputs.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library VersionsF# Core Library Versions**

Supported in: 2.0, 4.0, PortablePortable2.0, 4.0, Portable

## See Also
[Core.LanguagePrimitives Module &#40;F&#35;&#41;](Core.LanguagePrimitives-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)