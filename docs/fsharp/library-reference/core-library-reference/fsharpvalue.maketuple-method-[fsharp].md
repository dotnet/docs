---
title: FSharpValue.MakeTuple Method (F#)
description: FSharpValue.MakeTuple Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: c2a30bf4-29ad-4519-adf4-c1000c4aba68 
---

# FSharpValue.MakeTuple Method (F#)

Creates an instance of a tuple type.

**Namespace/Module Path:** Microsoft.FSharp.Reflection

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
static member MakeTuple : obj [] * Type -> obj

// Usage:
FSharpValue.MakeTuple (tupleElements, tupleType)
```

#### Parameters
*tupleElements*
Type: [obj](https://msdn.microsoft.com/library/dcf2430f-702b-40e5-a0a1-97518bf137f7)[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)


The array of tuple fields.


*tupleType*
Type: **System.Type**


The tuple type to create.

## Exceptions

|Exception|Condition|
|----|----|
|[ArgumentException](https://msdn.microsoft.com/library/system.argumentexception.aspx)|Thrown if no elements are given.|

## Return Value

An instance of the tuple type with the given elements.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Reflection.FSharpValue Class &#40;F&#35;&#41;](Reflection.FSharpValue-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Reflection Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Reflection-Namespace-%5BFSharp%5D.md)