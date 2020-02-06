---
title: FSharpValue.MakeRecord Method (F#)
description: FSharpValue.MakeRecord Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 75758974-2dcd-4502-b171-1ce537a94c27 
---

# FSharpValue.MakeRecord Method (F#)

Creates an instance of a record type.

**Namespace/Module Path:** Microsoft.FSharp.Reflection

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
static member MakeRecord : Type * obj [] * ?BindingFlags -> obj
static member MakeRecord : Type * obj [] * ?bool -> obj

// Usage:
FSharpValue.MakeRecord (recordType, values)
FSharpValue.MakeRecord (recordType, values, bindingFlags = bindingFlags)

open FSharpReflectionExtensions
FSharpValue.MakeRecord (recordType, values, allowAccessToPrivateRepresentation = false)
```

#### Parameters
*recordType*
Type: **System.Type**


The type of record to make.


*values*
Type: [obj](https://msdn.microsoft.com/library/dcf2430f-702b-40e5-a0a1-97518bf137f7)[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)


The array of values to initialize the record.


*bindingFlags*
Type: **System.Reflection.BindingFlags**


Optional binding flags for the record.


*allowAccessToPrivateRepresentation*
Type: [bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5)


Optional flag that denotes accessibility of the private representation.

## Exceptions

|Exception|Condition|
|----|----|
|[ArgumentException](https://msdn.microsoft.com/library/system.argumentexception.aspx)|Thrown if no elements are given.|

## Return Value

The created record.

## Remarks
Assumes the given input is a record type.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Reflection.FSharpValue Class &#40;F&#35;&#41;](Reflection.FSharpValue-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Reflection Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Reflection-Namespace-%5BFSharp%5D.md)