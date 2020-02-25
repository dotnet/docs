---
title: FSharpType.IsExceptionRepresentation Method (F#)
description: FSharpType.IsExceptionRepresentation Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 5189ac8d-5d99-4fa7-9848-0ab1a87d8f79 
---

# FSharpType.IsExceptionRepresentation Method (F#)

Returns `true` if the specified type is a representation of an F# exception declaration.

**Namespace/Module Path:** Microsoft.FSharp.Reflection

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
static member IsExceptionRepresentation : Type * ?BindingFlags -> bool
static member IsExceptionRepresentation : Type * ?bool -> bool

// Usage:
FSharpType.IsExceptionRepresentation (exceptionType)
FSharpType.IsExceptionRepresentation (exceptionType, bindingFlags = bindingFlags)

open FSharpReflectionExtensions
FSharpType.IsExceptionRepresentation (exceptionType, allowAccessToPrivateRepresentation = false)
```

#### Parameters
*exceptionType*
Type: **System.Type**


The type to check.


*bindingFlags*
Type: **System.Reflection.BindingFlags**


Optional binding flags.


*allowAccessToPrivateRepresentation*
Type: [bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5)


Optional flag that denotes accessibility of the private representation.

## Return Value

Returns `true` if the type checked is an F# exception.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Reflection.FSharpType Class &#40;F&#35;&#41;](Reflection.FSharpType-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Reflection Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Reflection-Namespace-%5BFSharp%5D.md)