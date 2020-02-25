---
title: FSharpValue.GetRecordField Method (F#)
description: FSharpValue.GetRecordField Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: a46537b1-b4d8-453b-b42c-dfb3fdc72425 
---

# FSharpValue.GetRecordField Method (F#)

Reads a field from a record value.

**Namespace/Module Path:** Microsoft.FSharp.Reflection

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
static member GetRecordField : obj * PropertyInfo -> obj

// Usage:
FSharpValue.GetRecordField (record, info)
```

#### Parameters
*record*
Type: [obj](https://msdn.microsoft.com/library/dcf2430f-702b-40e5-a0a1-97518bf137f7)


The record object.


*info*
Type: **System.Reflection.PropertyInfo**

## Return Value

The `System.Reflection.PropertyInfo` object describing the field to read.

## Exceptions

|Exception|Condition|
|----|----|
|[ArgumentException](https://msdn.microsoft.com/library/system.argumentexception.aspx)|Thrown when the input type is not a record type.|

## Return Value

The field from the record.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Reflection.FSharpValue Class &#40;F&#35;&#41;](Reflection.FSharpValue-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Reflection Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Reflection-Namespace-%5BFSharp%5D.md)