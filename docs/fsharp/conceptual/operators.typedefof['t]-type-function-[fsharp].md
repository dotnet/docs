---
title: Operators.typedefof<'T> Type Function (F#)
description: Operators.typedefof<'T> Type Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: dbbc6106-f834-4e27-8fcb-4085ce8cc4a9
---

# Operators.typedefof<'T> Type Function (F#)

Generate a `System.Type` representation for a type definition. If the input type is a generic type instantiation then return the generic type definition associated with all such instantiations.

**Namespace/Module Path:** Microsoft.FSharp.Core.Operators

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
typedefof<'T> :  Type

// Usage:
typedefof
```

## Return Value

A `System.Type` object representing the type of the expression, or generic type, if applicable.

## Remarks
This function is named `TypeDefOf` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Core.Operators Module &#40;F&#35;&#41;](Core.Operators-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)
