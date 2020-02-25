---
title: FSharpType.MakeFunctionType Method (F#)
description: FSharpType.MakeFunctionType Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 2b027cdc-5850-49c3-93bf-2037c135dda7 
---

# FSharpType.MakeFunctionType Method (F#)

Returns a `System.Type` representing the F# function type with the given domain and range

**Namespace/Module Path:** Microsoft.FSharp.Reflection

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
static member MakeFunctionType : Type * Type -> Type

// Usage:
FSharpType.MakeFunctionType (domain, range)
```

#### Parameters
*domain*
Type: **System.Type**


The input type of the function.


*range*
Type: **System.Type**


The output type of the function.

## Return Value

The function type with the given domain and range.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Reflection.FSharpType Class &#40;F&#35;&#41;](Reflection.FSharpType-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Reflection Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Reflection-Namespace-%5BFSharp%5D.md)