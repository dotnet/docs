---
title: FSharpValue.PreComputeRecordConstructor Method (F#)
description: FSharpValue.PreComputeRecordConstructor Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 808e5374-70bb-428f-af2a-4bf67494be55 
---

# FSharpValue.PreComputeRecordConstructor Method (F#)

Generates a function for constructing a record value.

**Namespace/Module Path:** Microsoft.FSharp.Reflection

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
static member PreComputeRecordConstructor : Type * ?BindingFlags -> obj [] -> obj
static member PreComputeRecordConstructor : Type * ?bool -> obj [] -> obj
// Usage:
FSharpValue.PreComputeRecordConstructor (recordType)
FSharpValue.PreComputeRecordConstructor (recordType, bindingFlags = bindingFlags)

open FSharpReflectionExtensions
FSharpValue.PreComputeRecordConstructor (recordType, allowAccessToPrivateRepresentation = false)
```

#### Parameters
*recordType*
Type: **System.Type**


The type of record to construct.


*bindingFlags*
Type: **System.Reflection.BindingFlags**


Optional binding flags.


*allowAccessToPrivateRepresentation*
Type: [bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5)


Optional flag that denotes accessibility of the private representation.

## Exceptions

|Exception|Condition|
|----|----|
|[ArgumentException](https://msdn.microsoft.com/library/system.argumentexception.aspx)|Thrown when the input type is not a record type.|


## Return Value

A function to construct records of the given type.

## Remarks

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Reflection.FSharpValue Class &#40;F&#35;&#41;](Reflection.FSharpValue-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Reflection Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Reflection-Namespace-%5BFSharp%5D.md)