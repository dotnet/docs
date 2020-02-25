---
title: FSharpValue.MakeUnion Method (F#)
description: FSharpValue.MakeUnion Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: e6cbb7a2-9197-49fc-b64b-b64729eb84b5 
---

# FSharpValue.MakeUnion Method (F#)

Create a union case value.

**Namespace/Module Path:** Microsoft.FSharp.Reflection

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
static member MakeUnion : UnionCaseInfo * obj [] * ?BindingFlags -> obj
static member MakeUnion : UnionCaseInfo * obj [] * ?bool -> obj
// Usage:
FSharpValue.MakeUnion (unionCase, args)
FSharpValue.MakeUnion (unionCase, args, bindingFlags = bindingFlags)

open FSharpReflectionExtensions
FSharpValue.MakeUnion (unionCase, args, allowAccessToPrivateRepresentation = false)
```

#### Parameters
*unionCase*
Type: [UnionCaseInfo](https://msdn.microsoft.com/library/d97eb038-9521-4e20-89b4-dd0cd92d7221)


The description of the union case to create.


*args*
Type: [obj](https://msdn.microsoft.com/library/dcf2430f-702b-40e5-a0a1-97518bf137f7)[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)


The array of arguments to construct the given case.


*bindingFlags*
Type: **System.Reflection.BindingFlags**


Optional binding flags.


*allowAccessToPrivateRepresentation*
Type: [bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5)


Optional flag that denotes accessibility of the private representation.

## Return Value

The constructed union case.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Reflection.FSharpValue Class &#40;F&#35;&#41;](Reflection.FSharpValue-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Reflection Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Reflection-Namespace-%5BFSharp%5D.md)