---
title: FSharpType.IsRecord Method (F#)
description: FSharpType.IsRecord Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: da1304da-d1e4-4da1-8747-091b8259d44f 
---

# FSharpType.IsRecord Method (F#)

Returns `true` if the specified type is a representation of an F# record type.

**Namespace/Module Path:** Microsoft.FSharp.Reflection

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
static member IsRecord : Type * ?BindingFlags -> bool
static member IsRecord : Type * ?bool -> bool

// Usage:
FSharpType.IsRecord (typ)
FSharpType.IsRecord (typ, bindingFlags = bindingFlags)
open FSharpReflectionExtensions
FSharpType.IsRecord (type, allowAccessToPrivateRepresentation = false)
```

#### Parameters
*typ*
Type: **System.Type**


The type to check.


*bindingFlags*
Type: **System.Reflection.BindingFlags**


Optional binding flags.


*allowAccessToPrivateRepresentation*
Type: [bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5)


Optional flag that denotes accessibility of the private representation.

## Return Value

Returns `true` if the type check succeeds.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Reflection.FSharpType Class &#40;F&#35;&#41;](Reflection.FSharpType-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Reflection Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Reflection-Namespace-%5BFSharp%5D.md)