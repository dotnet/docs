---
title: FSharpType.MakeTupleType Method (F#)
description: FSharpType.MakeTupleType Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: cae09c89-eb1c-4b0a-b21b-c2e075b3ff2d 
---

# FSharpType.MakeTupleType Method (F#)

Returns a `System.Type` representing an F# tuple type with the given element types.

**Namespace/Module Path:** Microsoft.FSharp.Reflection

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
static member MakeTupleType : Type [] -> Type

// Usage:
FSharpType.MakeTupleType (types)
```

#### Parameters
*types*
Type: **System.Type**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)


An array of types for the tuple elements.

## Return Value

The type representing the tuple containing the input elements.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Reflection.FSharpType Class &#40;F&#35;&#41;](Reflection.FSharpType-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Reflection Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Reflection-Namespace-%5BFSharp%5D.md)