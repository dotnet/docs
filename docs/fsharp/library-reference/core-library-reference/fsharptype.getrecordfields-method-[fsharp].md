---
title: FSharpType.GetRecordFields Method (F#)
description: FSharpType.GetRecordFields Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 294821cf-d8f4-420d-aa11-93c78e17f6f5 
---

# FSharpType.GetRecordFields Method (F#)

Reads all the fields from a record value, in declaration order.

**Namespace/Module Path:** Microsoft.FSharp.Reflection

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
static member GetRecordFields : Type * ?BindingFlags -> PropertyInfo []
static member GetRecordFields : Type * ?bool -> PropertyInfo []

// Usage:
FSharpType.GetRecordFields (recordType)
FSharpType.GetRecordFields (recordType, bindingFlags = bindingFlags)

open FSharpReflectionExtensions
FSharpType.GetExceptionFields (recordType, allowAccessToPrivateRepresentation = false)
```

#### Parameters
*recordType*
Type: **System.Type**


The input record type.


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

An array of descriptions of the properties (`System.Reflection.PropertyInfo` objects) of the record type.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Reflection.FSharpType Class &#40;F&#35;&#41;](Reflection.FSharpType-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Reflection Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Reflection-Namespace-%5BFSharp%5D.md)