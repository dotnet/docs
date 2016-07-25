---
title: DerivedPatterns.Lambdas Active Pattern (F#)
description: DerivedPatterns.Lambdas Active Pattern (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: f1000877-3db0-409d-8523-c9da4dd8b44a 
---

# DerivedPatterns.Lambdas Active Pattern (F#)

Recognizes expressions that represent a (possibly curried or tupled) first-class function value

**Namespace/Module Path**: Microsoft.FSharp.Quotations.DerivedPatterns

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
( |Lambdas|_| ) : (input:Expr) -> (Var list list * Expr) option
```

#### Parameters
*input*
Type: [Expr](https://msdn.microsoft.com/library/ed6a2caf-69d4-45c2-ab97-e9b3be9bce65)


The input expression to match against.

## Return Value

The formal return type is (Var list list &#42; Expr) option. The option indicates whether the input results in a match. In a pattern matching expression, the input is decomposed, upon a successful match, into a tuple of two elements. The first element is a list of lists of Var objects that represent the arguments of the lambda expression. The second element is an expression that represents the body of the lambda expression.

## Remarks
This function is named `LambdasPattern` in the .NET Framework assembly. If you are accessing the member from a .NET Framework language other than F#, or through reflection, use this name.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Quotations.DerivedPatterns Module &#40;F&#35;&#41;](Quotations.DerivedPatterns-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Quotations Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Quotations-Namespace-%5BFSharp%5D.md)