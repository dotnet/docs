---
title: Patterns.Application Active Pattern (F#)
description: Patterns.Application Active Pattern (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 6f70fd5f-124d-4712-98cb-de05b537d0ba
---

# Patterns.Application Active Pattern (F#)

Recognizes expressions that represent applications of first-class function values.

**Namespace/Module Path**: Microsoft.FSharp.Quotations.Patterns

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
( |Application|_| ) : (input:Expr) -> (Expr * Expr) option
```

#### Parameters
*input*
Type: [Expr](https://msdn.microsoft.com/library/ed6a2caf-69d4-45c2-ab97-e9b3be9bce65)


The input expression to match against.

## Return Value

The formal return type is (`Expr` &#42; `Expr`) option. The option indicates whether a match exists. When you use the active pattern in a match expression, you use the tuple of two expressions directly to decompose the pattern.

The tuple contains two expressions that result from the decomposition of a curried function application expression. If there is one curried argument, the first expression represents the function name and the second expression represents the argument. If there are multiple curried arguments, the first expression is itself a function application that contains all the curried arguments except the last, and the second expression represents the last curried argument. The first expression can be recursively processed to decompose the next curried argument of the function.

## Remarks
This function is named `ApplicationPattern` in the .NET Framework assembly. If you are accessing the member from a .NET Framework language other than F#, or through reflection, use this name.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Quotations.Patterns Module &#40;F&#35;&#41;](Quotations.Patterns-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Quotations Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Quotations-Namespace-%5BFSharp%5D.md)
