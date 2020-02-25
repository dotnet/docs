---
title: Patterns.TryWith Active Pattern (F#)
description: Patterns.TryWith Active Pattern (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 64ab4981-926c-4e9b-98d7-7b57101ac767
---

# Patterns.TryWith Active Pattern (F#)

Recognizes expressions that represent a try...with construct for exception filtering and catching.

**Namespace/Module Path:** Microsoft.FSharp.Quotations.Patterns

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
( |TryWith|_| ) : (input:Expr) -> (Expr * Var * Expr * Var * Expr) option
```

#### Parameters
*input*
Type: [Expr](https://msdn.microsoft.com/library/ed6a2caf-69d4-45c2-ab97-e9b3be9bce65)


The input expression to match against.

## Return Value

The formal return type is (`Expr` &#42; `Var` &#42; `Expr` &#42; `Var` &#42; `Expr`) option. The option indicates whether a successful match is made. In a pattern matching expression, upon a successful match, the input expression is decomposed into a tuple of five elements. The first element is an expression that represents the body of the `try...with` expression. The second element is the filter value, which is the value that is used to compare against the patterns. The third element is an expression that represents the filtering and assignment of any values set in the pattern matching (for example, by using the `as` keyword). The fourth element is the catch value, which is usually the same as the filter value and is used to determine which branch is taken. The final element is the catch expression, which includes the branching code. The tuple elements correspond to the arguments of the [Expr.TryWith](https://msdn.microsoft.com/library/bb6a4a9f-0a49-4fe5-b4fd-b2167bda74e1) method.

## Remarks
This function is named `TryWithPattern` in the .NET Framework assembly. If you are accessing the member from a .NET Framework language other than F#, or through reflection, use this name.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Quotations.Patterns Module &#40;F&#35;&#41;](Quotations.Patterns-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Quotations Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Quotations-Namespace-%5BFSharp%5D.md)
