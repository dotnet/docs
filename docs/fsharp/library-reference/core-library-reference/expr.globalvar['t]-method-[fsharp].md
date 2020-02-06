---
title: Expr.GlobalVar<'T> Method (F#)
description: Expr.GlobalVar<'T> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 84cbc7f3-fa5c-42f2-94bd-7a5aee3db332 
---

# Expr.GlobalVar<'T> Method (F#)

Fetches or creates a new variable with the given name and type from a global pool of shared variables indexed by name and type. The type is given by the expicit or inferred type parameter.

**Namespace/Module Path:** Microsoft.FSharp.Quotations

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
static member GlobalVar : string -> Expr<'T>

// Usage:
Expr.GlobalVar (name)
```

#### Parameters
*name*
Type: [string](https://msdn.microsoft.com/library/12b97856-ec80-4f70-a018-afb0753f755a)


The variable name.

## Return Value

The created of fetched typed global variable.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable


## See Also
[Quotations.Expr Class &#40;F&#35;&#41;](Quotations.Expr-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Quotations Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Quotations-Namespace-%5BFSharp%5D.md)