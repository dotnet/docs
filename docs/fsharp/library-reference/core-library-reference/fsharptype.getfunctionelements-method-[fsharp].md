---
title: FSharpType.GetFunctionElements Method (F#)
description: FSharpType.GetFunctionElements Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: eb9d2192-1b4f-45b8-b2c6-0b000d0f1feb 
---

# FSharpType.GetFunctionElements Method (F#)

Gets the domain and range types from an F# function type or from the runtime type of a closure implementing an F# type.

**Namespace/Module Path:** Microsoft.FSharp.Reflection

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
static member GetFunctionElements : Type -> Type * Type

// Usage:
FSharpType.GetFunctionElements (functionType)
```

#### Parameters
*functionType*
Type: **System.Type**


The input function type.

## Return Value

A tuple of the domain and range types of the input function.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Reflection.FSharpType Class &#40;F&#35;&#41;](Reflection.FSharpType-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Reflection Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Reflection-Namespace-%5BFSharp%5D.md)