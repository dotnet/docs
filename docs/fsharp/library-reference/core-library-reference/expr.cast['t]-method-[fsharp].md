---
title: Expr.Cast<'T> Method (F#)
description: Expr.Cast<'T> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 104b4d4c-946b-4d33-9762-0a4fdb73b03c 
---

# Expr.Cast<'T> Method (F#)

Returns a new typed expression given an underlying runtime-typed expression. A type annotation is usually required to use this function, and using an incorrect type annotation may result in a later runtime exception.

**Namespace/Module Path:** Microsoft.FSharp.Quotations

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
static member Cast : Expr -> Expr<'T>

// Usage:
Expr.Cast (source)
```

#### Parameters
*source*
Type: [Expr](https://msdn.microsoft.com/library/ed6a2caf-69d4-45c2-ab97-e9b3be9bce65)


The expression to cast.

## Return Value

The resulting typed expression.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Quotations.Expr Class &#40;F&#35;&#41;](Quotations.Expr-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Quotations Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Quotations-Namespace-%5BFSharp%5D.md)