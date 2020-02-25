---
title: FSharpValue.GetUnionFields Method (F#)
description: FSharpValue.GetUnionFields Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: d5843dc5-c155-4fc2-950a-a32f9ebbbc1a 
---

# FSharpValue.GetUnionFields Method (F#)

Identify the union case and its fields for an object.

**Namespace/Module Path:** Microsoft.FSharp.Reflection

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
static member GetUnionFields : obj * Type * ?BindingFlags -> UnionCaseInfo * obj []
static member GetUnionFields : obj * Type * ?bool -> UnionCaseInfo * obj []

// Usage:
FSharpValue.GetUnionFields (value, unionType)
FSharpValue.GetUnionFields (value, unionType, bindingFlags = bindingFlags)

open FSharpReflectionExtensions
FSharpValue.GetUnionFields (value, unionType, allowAccessToPrivateRepresentation = false)
```

#### Parameters
*value*
Type: [obj](https://msdn.microsoft.com/library/dcf2430f-702b-40e5-a0a1-97518bf137f7)


The input union case.


*unionType*
Type: **System.Type**


The union type containing the value.


*bindingFlags*
Type: **System.Reflection.BindingFlags**


Optional binding flags.


*allowAccessToPrivateRepresentation*
Type: [bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5)


Optional flag that denotes accessibility of the private representation.
## Exceptions

|Exception|Condition|
|----|----|
|[ArgumentException](https://msdn.microsoft.com/library/system.argumentexception.aspx)|Thrown when the input type is not a union case value.|

## Return Value

The description of the union case (as a [UnionCaseInfo](https://msdn.microsoft.com/library/d97eb038-9521-4e20-89b4-dd0cd92d7221) object) and its fields.

## Remarks
If the type is not given, then the runtime type of the input object is used to identify the relevant union type. The type should always be given if the input object may be `null`. For example, option values may be represented using the `null`.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Reflection.FSharpValue Class &#40;F&#35;&#41;](Reflection.FSharpValue-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Reflection Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Reflection-Namespace-%5BFSharp%5D.md)