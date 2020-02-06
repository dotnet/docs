---
title: FSharpType.GetExceptionFields Method (F#)
description: FSharpType.GetExceptionFields Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 5ece1d44-14b5-4b77-81de-0f26abe86cf1 
---

# FSharpType.GetExceptionFields Method (F#)

Reads all the fields from an F# exception declaration, in declaration order.

**Namespace/Module Path:** Microsoft.FSharp.Reflection

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
static member GetExceptionFields : Type * ?BindingFlags -> PropertyInfo []
static member GetExceptionFields : Type * ?bool -> PropertyInfo []

// Usage:
FSharpType.GetExceptionFields (exceptionType)
FSharpType.GetExceptionFields (exceptionType, bindingFlags = bindingFlags)

open FSharpReflectionExtensions
FSharpType.GetExceptionFields (exceptionType, allowAccessToPrivateRepresentation = false)
```

#### Parameters
*exceptionType*
Type: **System.Type**

The exception type to read.

*bindingFlags*
Type: **System.Reflection.BindingFlags**

Optional binding flags.

*allowAccessToPrivateRepresentation*
Type: [bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5)

Optional flag that denotes accessibility of the private representation.

## Exceptions

|Exception|Condition|
|----|----|
|[ArgumentException](https://msdn.microsoft.com/library/system.argumentexception.aspx)|Thrown if the given type is not an exception.|

## Return Value
An array containing the `System.Reflection.PropertyInfo` of each field in the exception.

## Remarks
Assumes `exceptionType` is an exception representation type. If not, `System.ArgumentException` is raised.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Reflection.FSharpType Class &#40;F&#35;&#41;](Reflection.FSharpType-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Reflection Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Reflection-Namespace-%5BFSharp%5D.md)