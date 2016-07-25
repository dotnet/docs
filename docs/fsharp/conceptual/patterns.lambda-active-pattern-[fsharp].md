---
title: Patterns.Lambda Active Pattern (F#)
description: Patterns.Lambda Active Pattern (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 041485e7-08cd-4d47-951b-1af8b32f9567
---

# Patterns.Lambda Active Pattern (F#)

Recognizes expressions that represent first-class function values.

**Namespace/Module Path**: Microsoft.FSharp.Quotations.Patterns

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
( |Lambda|_| ) : (input:Expr) -> (Var * Expr) option
```

#### Parameters
*input*
Type: [Expr](https://msdn.microsoft.com/library/ed6a2caf-69d4-45c2-ab97-e9b3be9bce65)


The input expression to match against.

## Return Value

The formal return type is (`Var` &#42; `Expr`) option. The option indicates whether the input results in a match. In a pattern matching expression, the input is decomposed, upon a successful match, into a tuple of two elements. The first element is a [Var](https://msdn.microsoft.com/library/2b1237f9-d897-4bcf-872a-4a297db3f7b5) object that represents a single argument. The second object is an expression that represents the body of the lambda expression. Lambda expressions that have multiple arguments are decomposed one argument at a time. For example, a lambda expression that has two arguments is decomposed so that the `Var` element is the first argument, and the Expr element is a lambda expression that can be recursively decomposed so that the second-level `Var` element is the second argument and the second-level `Expr` element is the body.

## Remarks
This function is named `LambdaPattern` in the .NET Framework assembly. If you are accessing the member from a .NET Framework language other than F#, or through reflection, use this name.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Quotations.Patterns Module &#40;F&#35;&#41;](Quotations.Patterns-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Quotations Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Quotations-Namespace-%5BFSharp%5D.md)
