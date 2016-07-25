---
title: FSharpValue.PreComputeRecordReader Method (F#)
description: FSharpValue.PreComputeRecordReader Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 8d925d83-68a5-4358-9516-936ef5e1283d 
---

# FSharpValue.PreComputeRecordReader Method (F#)

Precompute a function for reading all the fields from a record.

**Namespace/Module Path:** Microsoft.FSharp.Reflection

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
static member PreComputeRecordReader : Type * ?BindingFlags -> obj -> obj []
static member PreComputeRecordReader : Type * ?bool -> obj -> obj []

// Usage:
FSharpValue.PreComputeRecordReader (recordType)
FSharpValue.PreComputeRecordReader (recordType, bindingFlags = bindingFlags)

open FSharpReflectionExtensions
FSharpValue.PreComputeRecordReader (recordType, allowAccessToPrivateRepresentation = false)
```

#### Parameters
*recordType*
Type: **System.Type**


The type of record to read.


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
An optimized reader for the given record type.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Reflection.FSharpValue Class &#40;F&#35;&#41;](Reflection.FSharpValue-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Reflection Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Reflection-Namespace-%5BFSharp%5D.md)