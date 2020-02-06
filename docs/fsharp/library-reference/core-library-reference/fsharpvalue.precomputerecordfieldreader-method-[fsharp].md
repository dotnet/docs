---
title: FSharpValue.PreComputeRecordFieldReader Method (F#)
description: FSharpValue.PreComputeRecordFieldReader Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: f3eacd16-156d-425b-99ee-da3e1a6dce32 
---

# FSharpValue.PreComputeRecordFieldReader Method (F#)

Generates a function for reading a particular field from a record.

**Namespace/Module Path:** Microsoft.FSharp.Reflection

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
static member PreComputeRecordFieldReader : PropertyInfo -> obj -> obj

// Usage:
FSharpValue.PreComputeRecordFieldReader (info)
```

#### Parameters
*info*
Type: **System.Reflection.PropertyInfo**


Describes the field to read.

## Exceptions

|Exception|Condition|
|----|----|
|[ArgumentException](https://msdn.microsoft.com/library/system.argumentexception.aspx)|Thrown when the input type is not a record type.|

## Return Value

A function to read the specified field from the record.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Reflection.FSharpValue Class &#40;F&#35;&#41;](Reflection.FSharpValue-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Reflection Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Reflection-Namespace-%5BFSharp%5D.md)