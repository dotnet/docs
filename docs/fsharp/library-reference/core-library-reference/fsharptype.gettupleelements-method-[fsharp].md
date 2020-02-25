---
title: FSharpType.GetTupleElements Method (F#)
description: FSharpType.GetTupleElements Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: d6dd5d01-8966-4c81-9f5a-2234ea3821c1 
---

# FSharpType.GetTupleElements Method (F#)

Gets the tuple elements from the representation of an F# tuple type.

**Namespace/Module Path:** Microsoft.FSharp.Reflection

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
static member GetTupleElements : Type -> Type []

// Usage:
FSharpType.GetTupleElements (tupleType)
```

#### Parameters
*tupleType*
Type: **System.Type**


The input tuple type.

## Return Value

An array of the types contained in the given tuple type.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Reflection.FSharpType Class &#40;F&#35;&#41;](Reflection.FSharpType-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Reflection Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Reflection-Namespace-%5BFSharp%5D.md)