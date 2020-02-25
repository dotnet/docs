---
title: FSharpValue.PreComputeUnionTagReader Method (F#)
description: FSharpValue.PreComputeUnionTagReader Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 29b7e954-060f-4df5-8392-7f634a1fba4d 
---

# FSharpValue.PreComputeUnionTagReader Method (F#)

Generates a function to read the tags of a union type.

**Namespace/Module Path:** Microsoft.FSharp.Reflection

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
static member PreComputeUnionTagReader : Type * ?BindingFlags -> obj -> int
static member PreComputeUnionTagReader : Type * ?bool -> obj -> int

// Usage:
FSharpValue.PreComputeUnionTagReader (unionType)
FSharpValue.PreComputeUnionTagReader (unionType, bindingFlags = bindingFlags)

open FSharpReflectionExtensions
FSharpValue.PreComputeUnionTagReader (unionType, allowAccessToPrivateRepresentation = false)
```

#### Parameters
*unionType*
Type: **System.Type**


The type of union to optimize reading.


*bindingFlags*
Type: **System.Reflection.BindingFlags**


Optional binding flags.


*allowAccessToPrivateRepresentation*
Type: [bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5)


Optional flag that denotes accessibility of the private representation.

## Return Value

An optimized function to read the tags of the given union type.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Reflection.FSharpValue Class &#40;F&#35;&#41;](Reflection.FSharpValue-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Reflection Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Reflection-Namespace-%5BFSharp%5D.md)