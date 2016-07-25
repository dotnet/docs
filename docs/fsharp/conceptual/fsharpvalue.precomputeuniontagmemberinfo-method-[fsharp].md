---
title: FSharpValue.PreComputeUnionTagMemberInfo Method (F#)
description: FSharpValue.PreComputeUnionTagMemberInfo Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 29c6d40f-66f7-4258-9719-f854e48529ad 
---

# FSharpValue.PreComputeUnionTagMemberInfo Method (F#)

Generates a property or static method for reading an integer representing the case tag of a union type.

**Namespace/Module Path:** Microsoft.FSharp.Reflection

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
static member PreComputeUnionTagMemberInfo : Type * ?BindingFlags -> MemberInfo
static member PreComputeUnionTagMemberInfo : Type * ?bool -> MemberInfo

// Usage:
FSharpValue.PreComputeUnionTagMemberInfo (unionType)
FSharpValue.PreComputeUnionTagMemberInfo (unionType, bindingFlags = bindingFlags)

open FSharpReflectionExtensions
FSharpValue.PreComputeUnionTagMemberInfo (unionType, allowAccessToPrivateRepresentation = false)
```

#### Parameters
*unionType*
Type: **System.Type**


The type of union to read.


*bindingFlags*
Type: **System.Reflection.BindingFlags**


Optional binding flags.


*allowAccessToPrivateRepresentation*
Type: [bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5)


Optional flag that denotes accessibility of the private representation.

## Return Value

The description of the union case reader as a `System.Reflection.MemberInfo` object.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Reflection.FSharpValue Class &#40;F&#35;&#41;](Reflection.FSharpValue-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Reflection Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Reflection-Namespace-%5BFSharp%5D.md)