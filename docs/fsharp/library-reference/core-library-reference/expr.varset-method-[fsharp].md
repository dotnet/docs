---
title: Expr.VarSet Method (F#)
description: Expr.VarSet Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 4070ade2-9b52-4d5c-bef0-4cccfb59c6b5 
---

# Expr.VarSet Method (F#)

Creates an expression that represents setting a mutable variable.

**Namespace/Module Path:** Microsoft.FSharp.Quotations

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
static member VarSet : Var * Expr -> Expr

// Usage:
Expr.VarSet (variable, value)
```

#### Parameters
*variable*
Type: [Var](https://msdn.microsoft.com/library/2b1237f9-d897-4bcf-872a-4a297db3f7b5)


The input variable.


*value*
Type: [Expr](https://msdn.microsoft.com/library/ed6a2caf-69d4-45c2-ab97-e9b3be9bce65)


The value to set.

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