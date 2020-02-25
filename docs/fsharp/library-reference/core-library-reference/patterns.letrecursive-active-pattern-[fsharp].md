---
title: Patterns.LetRecursive Active Pattern (F#)
description: Patterns.LetRecursive Active Pattern (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: b008f8aa-4836-40d6-a151-a55596a7c2fc
---

# Patterns.LetRecursive Active Pattern (F#)

Recognizes expressions that represent recursive `let` bindings of one or more variables.

**Namespace/Module Path**: Microsoft.FSharp.Quotations.Patterns

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
( |LetRecursive|_| ) : (input:Expr) -> ((Var * Expr) list * Expr) option
```

#### Parameters
*input*
Type: [Expr](https://msdn.microsoft.com/library/ed6a2caf-69d4-45c2-ab97-e9b3be9bce65)


The input expression to match against.

## Return Value

The formal return type is ((`Var` &#42; `Expr`) `list` &#42; `Expr`) option. The option indicates whether the input results in a match. In a pattern matching expression, the input is decomposed, upon a successful match, into a tuple that contains two elements. The first element is a list of tuples that has two elements. The first element of the inner tuple is a [Var](https://msdn.microsoft.com/library/2b1237f9-d897-4bcf-872a-4a297db3f7b5) object that represents the value being defined. The second element of the inner tuple represents the body of a recursive let binding. The second element of the outer tuple is the subexpression in which the binding is in scope.

## Remarks
This function is named `LetRecursivePattern` in the .NET Framework assembly. If you are accessing the member from a .NET Framework language other than F#, or through reflection, use this name.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Quotations.Patterns Module &#40;F&#35;&#41;](Quotations.Patterns-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Quotations Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Quotations-Namespace-%5BFSharp%5D.md)
