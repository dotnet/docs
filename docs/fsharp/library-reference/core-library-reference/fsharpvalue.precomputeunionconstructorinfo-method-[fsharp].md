---
title: FSharpValue.PreComputeUnionConstructorInfo Method (F#)
description: FSharpValue.PreComputeUnionConstructorInfo Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 5d45d32a-feb9-46c5-8d77-a25c2a9bca48 
---

# FSharpValue.PreComputeUnionConstructorInfo Method (F#)

A method that constructs objects of the given case.

**Namespace/Module Path:** Microsoft.FSharp.Reflection

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
static member PreComputeUnionConstructorInfo : UnionCaseInfo * ?BindingFlags -> MethodInfo
static member PreComputeUnionConstructorInfo : UnionCaseInfo * ?bool -> MethodInfo

// Usage:
FSharpValue.PreComputeUnionConstructorInfo (unionCase)
FSharpValue.PreComputeUnionConstructorInfo (unionCase, bindingFlags = bindingFlags)

open FSharpReflectionExtensions;
FSharpValue.PreComputeUnionConstructorInfo (unionCase, allowAccessToPrivateRepresentation = false)
```

#### Parameters
*unionCase*
Type: [UnionCaseInfo](https://msdn.microsoft.com/library/d97eb038-9521-4e20-89b4-dd0cd92d7221)


The description of the union case.


*bindingFlags*
Type: **System.Reflection.BindingFlags**


Optional binding flags.


*allowAccessToPrivateRepresentation*
Type: [bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5)


Optional flag that denotes accessibility of the private representation.

## Return Value

The description of the constructor of the given union case as a `System.Reflection.MethodInfo` object.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Reflection.FSharpValue Class &#40;F&#35;&#41;](Reflection.FSharpValue-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Reflection Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Reflection-Namespace-%5BFSharp%5D.md)