---
title: FSharpType.GetUnionCases Method (F#)
description: FSharpType.GetUnionCases Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 5ce44998-126e-45d9-81f5-563d34ac4d9b 
---

# FSharpType.GetUnionCases Method (F#)

Gets the cases of a union type.

**Namespace/Module Path:** Microsoft.FSharp.Reflection

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
static member GetUnionCases : Type * ?BindingFlags -> UnionCaseInfo []
static member GetUnionCases : Type * ?bool -> UnionCaseInfo []

// Usage:
FSharpType.GetUnionCases (unionType)
FSharpType.GetUnionCases (unionType, bindingFlags = bindingFlags)

open FSharpReflectionExtensions
FSharpType.GetUnionCases (unionType, allowAccessToPrivateRepresentation = false)
```

#### Parameters
*unionType*
Type: **System.Type**


The input union type.


*bindingFlags*
Type: **System.Reflection.BindingFlags**


Optional binding flags.


*allowAccessToPrivateRepresentation*
Type: [bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5)


Optional flag that denotes accessibility of the private representation.

## Exceptions

|Exception|Condition|
|----|----|
|[ArgumentException](https://msdn.microsoft.com/library/system.argumentexception.aspx)|Thrown when the input type is not a union type.|

## Return Value

An array of descriptions of the cases ([UnionCaseInfo](https://msdn.microsoft.com/library/d97eb038-9521-4e20-89b4-dd0cd92d7221) objects) of the given union type.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Reflection.FSharpType Class &#40;F&#35;&#41;](Reflection.FSharpType-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Reflection Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Reflection-Namespace-%5BFSharp%5D.md)