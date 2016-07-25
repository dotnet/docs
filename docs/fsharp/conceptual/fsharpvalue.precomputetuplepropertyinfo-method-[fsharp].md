---
title: FSharpValue.PreComputeTuplePropertyInfo Method (F#)
description: FSharpValue.PreComputeTuplePropertyInfo Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 6e4e5179-af69-4f2d-87de-ee637cb03c39 
---

# FSharpValue.PreComputeTuplePropertyInfo Method (F#)

Gets information that indicates how to read a field of a tuple.

**Namespace/Module Path:** Microsoft.FSharp.Reflection

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
static member PreComputeTuplePropertyInfo : Type * int -> PropertyInfo * (Type * int) option

// Usage:
FSharpValue.PreComputeTuplePropertyInfo (tupleType, index)
```

#### Parameters
*tupleType*
Type: **System.Type**


The input tuple type.


*index*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


The index of the tuple element to describe.

## Return Value

The description of the tuple element as a T:System.Reflection.PropertyInfo object and an optional type and index if the tuple is big.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Reflection.FSharpValue Class &#40;F&#35;&#41;](Reflection.FSharpValue-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Reflection Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Reflection-Namespace-%5BFSharp%5D.md)