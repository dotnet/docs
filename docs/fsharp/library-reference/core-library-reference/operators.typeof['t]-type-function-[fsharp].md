---
title: Operators.typeof<'T> Type Function (F#)
description: Operators.typeof<'T> Type Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: fdcce670-0a0d-499e-b84d-95fb9445ca33
---

# Operators.typeof<'T> Type Function (F#)

Generate a `System.Type` runtime representation of a static type. The static type is still maintained on the value returned.

**Namespace/Module Path:** Microsoft.FSharp.Core.Operators

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
typeof<'T> :  Type

// Usage:
typeof
```

## Return Value

A `System.Type` object representing the type of the specified expression.

## Remarks
This function is named `TypeOf` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Core.Operators Module &#40;F&#35;&#41;](Core.Operators-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)
