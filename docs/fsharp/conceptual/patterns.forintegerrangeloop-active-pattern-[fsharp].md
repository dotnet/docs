---
title: Patterns.ForIntegerRangeLoop Active Pattern (F#)
description: Patterns.ForIntegerRangeLoop Active Pattern (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 0a87706b-902d-486a-8c30-39ba15bd5974
---

# Patterns.ForIntegerRangeLoop Active Pattern (F#)

Recognizes expressions that represent looping operations over integer ranges.

**Namespace/Module Path**: Microsoft.FSharp.Quotations.Patterns

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
( |ForIntegerRangeLoop|_| ) : (input:Expr) -> (Var * Expr * Expr * Expr) option
```

#### Parameters
*input*
Type: [Expr](https://msdn.microsoft.com/library/ed6a2caf-69d4-45c2-ab97-e9b3be9bce65)


The input expression to match against.

## Return Value

The formal return type is (`Var` &#42; `Expr` &#42; `Expr` &#42; `Expr`) option. The option indicates whether there is a match to this pattern. In a pattern matching expression, the input is decomposed into a tuple of four elements upon a successful match. The first element represents the loop variable as a [Var](https://msdn.microsoft.com/library/2b1237f9-d897-4bcf-872a-4a297db3f7b5) object, the second and third elements represent the beginning and ending of the range, and the last element represents the body of the loop.

## Remarks
This function is named `ForIntegerRangeLoopPattern` in the .NET Framework assembly. If you are accessing the member from a .NET Framework language other than F#, or through reflection, use this name.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Quotations.Patterns Module &#40;F&#35;&#41;](Quotations.Patterns-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Quotations Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Quotations-Namespace-%5BFSharp%5D.md)
