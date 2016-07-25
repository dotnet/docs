---
title: FSharpValue.PreComputeRecordConstructorInfo Method (F#)
description: FSharpValue.PreComputeRecordConstructorInfo Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: e989f1d9-47c1-4bd5-9e4f-3f8a04673fb7 
---

# FSharpValue.PreComputeRecordConstructorInfo Method (F#)

Gets a `System.Reflection.ConstructorInfo` object for a record type.

**Namespace/Module Path:** Microsoft.FSharp.Reflection

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
static member PreComputeRecordConstructorInfo : Type * ?BindingFlags -> ConstructorInfo
static member PreComputeRecordConstructorInfo : Type * ?bool -> ConstructorInfo

// Usage:
FSharpValue.PreComputeRecordConstructorInfo (recordType)
FSharpValue.PreComputeRecordConstructorInfo (recordType, bindingFlags = bindingFlags)

open FSharpReflectionExtensions
FSharpValue.PreComputeRecordConstructorInfo (recordType, allowAccessToPrivateRepresentation = false)
```

#### Parameters
*recordType*
Type: **System.Type**


The record type.


*bindingFlags*
Type: **System.Reflection.BindingFlags**


Optional binding flags.


*allowAccessToPrivateRepresentation*
Type: [bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5)


Optional flag that denotes accessibility of the private representation.

## Return Value

A `System.Reflection.ConstructorInfo` object for the given record type.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Reflection.FSharpValue Class &#40;F&#35;&#41;](Reflection.FSharpValue-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Reflection Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Reflection-Namespace-%5BFSharp%5D.md)