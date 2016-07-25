---
title: FSharpValue.GetRecordFields Method (F#)
description: FSharpValue.GetRecordFields Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: af002be1-f326-4824-9ac4-3d8dac849d9c 
---

# FSharpValue.GetRecordFields Method (F#)

Reads all the fields from a record value.

**Namespace/Module Path:** Microsoft.FSharp.Reflection

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
static member GetRecordFields : obj * ?BindingFlags -> obj []
static member GetRecordFields : obj * ?bool -> obj []
// Usage:
FSharpValue.GetRecordFields (record)
FSharpValue.GetRecordFields (record, bindingFlags = bindingFlags)

open FSharpReflectionExtensions
FSharpValue.GetRecordFields (record, allowAccessToPrivateRepresentation = false)
```

#### Parameters
*record*
Type: [obj](https://msdn.microsoft.com/library/dcf2430f-702b-40e5-a0a1-97518bf137f7)


The record object.


*bindingFlags*
Type: **System.Reflection.BindingFlags**


Optional binding flags for the record.


*allowAccessToPrivateRepresentation*
Type: [bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5)


Optional flag that denotes accessibility of the private representation.

## Exceptions

|Exception|Condition|
|----|----|
|[ArgumentException](https://msdn.microsoft.com/library/system.argumentexception.aspx)|Thrown when the input type is not a record type.|

## Return Value

The array of fields from the record.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Reflection.FSharpValue Class &#40;F&#35;&#41;](Reflection.FSharpValue-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Reflection Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Reflection-Namespace-%5BFSharp%5D.md)