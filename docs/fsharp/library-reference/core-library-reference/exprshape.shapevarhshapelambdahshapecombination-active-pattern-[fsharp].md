---
title: ExprShape.ShapeVar|ShapeLambda|ShapeCombination Active Pattern (F#)
description: ExprShape.ShapeVar|ShapeLambda|ShapeCombination Active Pattern (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 8b0d29cd-1c4b-44ea-ab29-dad31aff60d0 
---

# ExprShape.ShapeVar|ShapeLambda|ShapeCombination Active Pattern (F#)

An active pattern that performs a complete decomposition viewing the expression tree as a binding structure.

**Namespace/Module Path:** Microsoft.FSharp.Quotations.ExprShape

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
( |ShapeVar|ShapeLambda|ShapeCombination| ) : (input:Expr) -> Choice<Var,(Var * Expr),(obj * Expr list)>
```

#### Parameters
*input*
Type: [Expr](https://msdn.microsoft.com/library/ed6a2caf-69d4-45c2-ab97-e9b3be9bce65)


The input expression.

## Return Value

The decomposed [`Var`](https://msdn.microsoft.com/library/2b1237f9-d897-4bcf-872a-4a297db3f7b5), [`Lambda`](https://msdn.microsoft.com/library/783760ed-8dd5-407e-a752-19451d81bb97), or `ConstApp`.

## Remarks
This function is named `ShapePattern` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Quotations.ExprShape Module &#40;F&#35;&#41;](Quotations.ExprShape-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Quotations Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Quotations-Namespace-%5BFSharp%5D.md)