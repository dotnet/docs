---
title: FSharpValue.PreComputeTupleConstructor Method (F#)
description: FSharpValue.PreComputeTupleConstructor Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: d8fb8694-0d3e-4fc2-a3e1-570f376f3ef4 
---

# FSharpValue.PreComputeTupleConstructor Method (F#)

Generates a function for reading the values of a particular tuple type.

**Namespace/Module Path:** Microsoft.FSharp.Reflection

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
static member PreComputeTupleConstructor : Type -> obj [] -> obj

// Usage:
FSharpValue.PreComputeTupleConstructor (tupleType)
```

#### Parameters
*tupleType*
Type: **System.Type**


The type of tuple to read.

## Exceptions

|Exception|Condition|
|----|----|
|[ArgumentException](https://msdn.microsoft.com/library/system.argumentexception.aspx)|Thrown when the given type is not a tuple type.|

## Return Value

A function to read a particular tuple type.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Reflection.FSharpValue Class &#40;F&#35;&#41;](Reflection.FSharpValue-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Reflection Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Reflection-Namespace-%5BFSharp%5D.md)