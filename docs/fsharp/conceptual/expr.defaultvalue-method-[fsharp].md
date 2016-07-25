---
title: Expr.DefaultValue Method (F#)
description: Expr.DefaultValue Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: ebdf6671-5737-432a-99ea-e3adfa2bcb9c 
---

# Expr.DefaultValue Method (F#)

Creates an expression that represents the invocation of a default object constructor

**Namespace/Module Path:** Microsoft.FSharp.Quotations

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
static member DefaultValue : Type -> Expr

// Usage:
Expr.DefaultValue (expressionType)
```

#### Parameters
*expressionType*
Type: **System.Type**


The type on which the constructor is invoked.

## Return Value

The resulting expression.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Quotations.Expr Class &#40;F&#35;&#41;](Quotations.Expr-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Quotations Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Quotations-Namespace-%5BFSharp%5D.md)