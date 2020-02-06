---
title: FSharpType.IsUnion Method (F#)
description: FSharpType.IsUnion Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: be0f59e1-7ea0-48ba-bbb3-4e1d38669d96 
---

# FSharpType.IsUnion Method (F#)

Returns `true` if the specified type is a representation of an F# union type or the runtime type of a value of that type.

**Namespace/Module Path:** Microsoft.FSharp.Reflection

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
static member IsUnion : Type * ?BindingFlags -> bool
static member IsUnion : Type * ?bool -> bool

// Usage:
FSharpType.IsUnion (typ)
FSharpType.IsUnion (typ, bindingFlags = bindingFlags)
open FSharpReflectionExtensions
FSharpType.IsUnion (type, allowAccesstoPrivateRepresentation = false)
```

#### Parameters
*typ*
Type: **System.Type**


The type to check.


*bindingFlags*
Type: **System.Reflection.BindingFlags**[option](https://msdn.microsoft.com/library/b08add48-34bf-4410-80a1-ef6a8daddc58)


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